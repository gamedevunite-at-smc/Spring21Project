using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public abstract class SpawnObject : ScriptableObject
{


    public Vector2 position;

    public GameObject InstantiateObject()
    {
        return InstantiateObject(position);
    }

    public abstract GameObject InstantiateObject(Vector2 spawnPosition);

}
