using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MovementModifierObject", menuName = "ScriptableObjects/MovementModifierObject", order = 3)]
public abstract class MovementModifierObject : ScriptableObject
{
    public virtual MovementModifier movementModifier
    {
        get
        {
            return null;
        }
    }
}

