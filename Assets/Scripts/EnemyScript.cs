using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        //what ever we want
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("IVE BEEN HIT!");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("IVE BEEN HIT!");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("IVE BEEN HIT!");
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("IVE BEEN HIT!");
    }

    private void OnTriggerCollision(GameObject other)
    {
        Debug.Log("IVE BEEN HIT!");
    }
}
