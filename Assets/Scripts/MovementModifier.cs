using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementModifier
{

    protected float startDelay = 0;
    protected float timer = 0;
    protected float delay = 0;
    protected float duration = 0;

    protected float maxSpeed;

    protected MovementModifier(float startDelay, float delay, float duration, float maxSpeed)
    {
        this.startDelay = startDelay;
        this.delay = delay;
        this.duration = duration;

        this.maxSpeed = maxSpeed;
    }

    public void Start()
    {

    }

    public Vector2 Update(Vector2 currentVelocity)
    {
        if(timer > delay)
        {

            currentVelocity = UpdateVelocity(currentVelocity);

            currentVelocity = Vector3.ClampMagnitude(currentVelocity, maxSpeed);

            if (timer > duration)
            {
                timer = 0;
            }

        }

        timer += Time.deltaTime;

        return currentVelocity;
    }

    protected virtual Vector2 UpdateVelocity(Vector2 currentVelocity)
    {
        return currentVelocity;
    }
}

public class ChargeModifier : MovementModifier
{

    public Vector2 velocity;

    public ChargeModifier(Vector2 velocity, float startDelay, float delay, float duration, float maxSpeed) : base(startDelay, delay, duration, maxSpeed)
    {
        this.velocity = velocity;
    }

    protected override Vector2 UpdateVelocity(Vector2 currentVelocity)
    {
        return velocity + currentVelocity;
    }
}
