using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyObject", menuName = "ScriptableObjects/EnemyObject", order = 5)]
public class EnemyObject : SpawnObject
{

    public EnemyObjectWrapper enemyDataObject;

    public override GameObject InstantiateObject(Vector2 spawnPosition)
    {

        var enemyGameObject = Instantiate(EnemySeqenceSpawner.enemyBasePrefab, new Vector3(spawnPosition.x, spawnPosition.y, 5), Quaternion.identity, null);

        var healthComponent = enemyGameObject.GetComponent<HealthComponent>();
        healthComponent.health = enemyDataObject.enemyDataObject.healthWrapper.healthComponent.health;
        healthComponent.maxHealth = enemyDataObject.enemyDataObject.healthWrapper.healthComponent.maxHealth;

        return enemyGameObject;
    }
}

[System.Serializable]
public class EnemyObjectWrapper
{
    public EnemyDataObject enemyDataObject;

    public bool overrideEnemyData;

    [ConditionalHide("overrideEnemyData", InverseCondition1 = false)]
    public EnemyDataObjectOverride enemyDataObjectOverride;
}
