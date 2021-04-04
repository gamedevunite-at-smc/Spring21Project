using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private SpriteColor spriteColor;

    private void Awake()
    {
        spriteColor = GetComponent<SpriteColor>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        //what ever we want
    }

    private void OnParticleCollision(GameObject other)
    {
        spriteColor.SetColor(Color.red);
        spriteColor.color = Color.white;
    }
}
