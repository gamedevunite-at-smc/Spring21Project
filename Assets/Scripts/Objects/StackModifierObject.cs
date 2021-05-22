using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "StackModifierObject", menuName = "ScriptableObjects/StackModifierObject", order = 3)]
public class StackModifierObject : MovementModifierObject
{
    public MovementModifier modifier;
    public List<MovementModifierObject> movementModifiers = new List<MovementModifierObject>();

    private MovementStack stack;

    public override MovementModifier movementModifier
    {
        get
        {
            if(stack != null)
            {
                return new MovementStack(stack);
            }

            return null;
        }
    }

    private void Awake()
    {
        OnValidate();
    }

    private void OnValidate()
    {
        List<MovementModifier> modifiers = new List<MovementModifier>(movementModifiers.Count);

        for (int i = 0; i < movementModifiers.Count; i++)
        {
            modifiers.Add(movementModifiers[i].movementModifier);
        }

        stack = new MovementStack(modifiers, modifier.startDelay, modifier.delay, modifier.duration, modifier.maxSpeed);
    }
}