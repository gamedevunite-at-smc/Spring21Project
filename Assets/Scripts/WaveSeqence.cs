using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveSeqence", menuName = "ScriptableObjects/WaveSeqence", order = 7)]
public class WaveSeqence : ScriptableObject
{


    //and their offsets
    public List<WaveSeqenceData> waveObjects;

}

[System.Serializable]
public class WaveSeqenceData
{

    public WaveObject waveObject;

    public float spawnDelay;

    public bool overrideSpawnPosition;
    [ConditionalHide("overrideSpawnPosition", InverseCondition1 = false)]
    public Vector2 spawnPosition;

}


