using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name);
    }

    private void OnParticleTrigger()
    {
        Debug.Log("Our particle has hit something");
    }
}
