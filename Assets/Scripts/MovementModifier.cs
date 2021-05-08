using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class MovementModifier : ICloneable
{

    protected float timer = 0;
    private bool passedDelay = false;

    public float startDelay = 0;
    public float delay = 0;
    public float duration = 0;
    public float maxSpeed = 1;

    public MovementModifier(MovementModifier movementModifier) : this(movementModifier.startDelay, movementModifier.delay, movementModifier.duration, movementModifier.maxSpeed) { }

    protected MovementModifier(float startDelay, float delay, float duration, float maxSpeed)
    {
        this.startDelay = startDelay;
        this.delay = delay;
        this.duration = duration;

        this.maxSpeed = maxSpeed;
    }

    public Vector2 FixedUpdate(Vector2 currentVelocity)
    {

        if(passedDelay)
        {

            if(timer >= duration + delay)
            {
                timer = 0;
            }

            if (timer <= duration)
            {

                currentVelocity = UpdateVelocity(currentVelocity);

                currentVelocity = Vector3.ClampMagnitude(currentVelocity, maxSpeed);
            }

        }
        else
        {
            if(timer >= startDelay)
            {
                timer = 0;
                passedDelay = true;
            }
        }

        timer += Time.fixedDeltaTime;

        return currentVelocity;
    }

    protected virtual Vector2 UpdateVelocity(Vector2 currentVelocity)
    {
        return currentVelocity;
    }

    public virtual object Clone()
    {
        return new MovementModifier(this);
    }
}


[System.Serializable]
public class ChargeModifier : MovementModifier
{

    public Vector2 velocity;

    public ChargeModifier(ChargeModifier chargeModifier) : this(chargeModifier.velocity, chargeModifier.startDelay, chargeModifier.delay, chargeModifier.duration, chargeModifier.maxSpeed) { }

    public ChargeModifier(Vector2 velocity, float startDelay, float delay, float duration, float maxSpeed) : base(startDelay, delay, duration, maxSpeed)
    {
        this.velocity = velocity;
    }

    protected override Vector2 UpdateVelocity(Vector2 currentVelocity)
    {
        return velocity * Time.fixedDeltaTime + currentVelocity;
    }

    public override object Clone()
    {
        return new ChargeModifier(this);
    }
}

[System.Serializable]
public class CircularModifier : MovementModifier
{
    public Vector2 velocity;
    public float radius;

    public CircularModifier(CircularModifier circularModifier) : this(circularModifier.velocity, circularModifier.radius, circularModifier.startDelay, circularModifier.delay, circularModifier.duration, circularModifier.maxSpeed) { }

    public CircularModifier(Vector2 velocity, float radius, float startDelay, float delay, float duration, float maxSpeed) : base(startDelay, delay, duration, maxSpeed)
    {
        this.velocity = velocity;
        this.radius = radius;
    }   
    
    protected override Vector2 UpdateVelocity(Vector2 currentVelocity)
    {
        float theta = timer * 2 * Mathf.PI;
        float x = Mathf.Sin(theta) * radius;
        float y = Mathf.Cos(theta) * radius;
        currentVelocity.x += x * velocity.x * Time.fixedDeltaTime;
        currentVelocity.y += y * velocity.y * Time.fixedDeltaTime;
        return currentVelocity;
    }

    public override object Clone()
    {
        return new CircularModifier(this);
    }
}

[System.Serializable]
public class MovementStack : MovementModifier
{

    public List<MovementModifier> movementModifiers = new List<MovementModifier>();

    public MovementStack(MovementStack movementStack) : base(movementStack.startDelay, movementStack.delay, movementStack.duration, movementStack.maxSpeed)
    {
        for (int i = 0; i < movementStack.movementModifiers.Count; i++)
        {
            movementModifiers.Add((MovementModifier)movementStack.movementModifiers[i].Clone());
        }
    }

    public MovementStack(List<MovementModifier> movementModifiers, float startDelay, float delay, float duration, float maxSpeed) : base(startDelay, delay, duration, maxSpeed)
    {
        this.movementModifiers = movementModifiers;
    }

    protected override Vector2 UpdateVelocity(Vector2 currentVelocity)
    {
        for (int i = 0; i < movementModifiers.Count; i++)
        {
            currentVelocity = movementModifiers[i].FixedUpdate(currentVelocity);
        }

        return currentVelocity;
    }

    public override object Clone()
    {
        return new MovementStack(this);
    }
}


