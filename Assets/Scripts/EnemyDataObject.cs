using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDataObject", menuName = "ScriptableObjects/EnemyDataObject", order = 10)]
public class EnemyDataObject : ScriptableObject
{



    public HealthWrapper healthWrapper;

    public MovementModifierObject movementModifier;


}

[System.Serializable]
public class EnemyDataObjectOverride
{
    public bool overrideHealth;

    [ConditionalHide(ConditionalSourceField = "overrideHealth", InverseCondition1 = false)]
    public HealthWrapper healthWrapper;

    public bool overrideMovement;

    [ConditionalHide(ConditionalSourceField = "overrideMovement", InverseCondition1 = false)]
    public MovementModifierObject movementModifier;

}


[System.Serializable]
public class HealthWrapper
{

    [ConditionalHide("enemyHealthComponentReference", InverseCondition1 = true)]
    public EnemyHealthComponent healthComponent;

    public EnemyHealthComponentObject enemyHealthComponentReference;

    [ConditionalHide("enemyHealthComponentReference", InverseCondition1 = false)]
    public bool overrideHealthComponent = false;

    [ConditionalHide(ConditionalSourceField = "overrideHealthComponent", ConditionalSourceField2 = "enemyHealthComponentReference", InverseCondition1 = false, InverseCondition2 = false)]
    public EnemyHealthOverrideComponent overrideEnemyHealthComponent;

}
