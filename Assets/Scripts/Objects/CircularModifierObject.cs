using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CircularModifierObject", menuName = "ScriptableObjects/CircularModifierObject", order = 3)]
public class CircularModifierObject : MovementModifierObject
{
    public CircularModifier circularModifier;

    public override MovementModifier movementModifier
    {
        get
        {
            return new CircularModifier(circularModifier);
        }
    }
}
