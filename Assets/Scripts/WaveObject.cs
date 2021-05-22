using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveObject", menuName = "ScriptableObjects/WaveObject", order = 6)]
public class WaveObject : SpawnObject
{


    public List<SpawnObjectWrapper> spawnObjects;

    public override GameObject InstantiateObject(Vector2 spawnPosition)
    {

        for (int i = 0; i < spawnObjects.Count; i++)
        {

            if(spawnObjects[i].overridePosition)
            {
                spawnObjects[i].spawnObject.InstantiateObject();
            }
            else
            {
                spawnObjects[i].spawnObject.InstantiateObject(spawnObjects[i].position);
            }
        }

        return null;
    }

}

[System.Serializable]
public class SpawnObjectWrapper
{

    public SpawnObject spawnObject;

    public bool overridePosition = false;

    [ConditionalHide("overridePosition", InverseCondition1 = false)]
    public Vector2 position;

}
