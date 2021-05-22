using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EnemyHealthComponent
{

    public int health;
    public int maxHealth;

}

[System.Serializable]
public struct EnemyHealthOverrideComponent
{
    public bool overrideHealth;

    [ConditionalHide("overrideHealth")]
    public int newHealth;

    public bool overrideMaxHealth;
    
    [ConditionalHide("overrideMaxHealth")]
    public int newMaxHealth;

}
