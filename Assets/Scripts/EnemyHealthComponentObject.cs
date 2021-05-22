using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyHealthComponentObject", menuName = "ScriptableObjects/EnemyHealthComponentObject", order = 9)]
public class EnemyHealthComponentObject : ScriptableObject
{

    //[System.NonSerialized]
    //public EnemyHealthComponent enemyHealthComponentReference;

    //[ConditionalHide("enemyHealthComponentReference")]
    public EnemyHealthComponent enemyHealthComponent;

}