using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChargeModifierObject", menuName = "ScriptableObjects/ChargeModifierObject", order = 3)]
public class ChargeModifierObject : MovementModifierObject
{
    public ChargeModifier chargeModifier;

    public override MovementModifier movementModifier
    {
        get
        {
            return new ChargeModifier(chargeModifier) ;
        }
    }
}
