using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyScript : MonoBehaviour
{

    private HealthComponent healthComponent;

    private SpriteColor spriteColor;

    private Scrollbar healthScrollBar;

    private void Awake()
    {
        spriteColor = GetComponent<SpriteColor>();
        healthComponent = GetComponent<HealthComponent>();
        healthScrollBar = GetComponentInChildren<Scrollbar>();
    }

    private void Start()
    {
        //what ever we want
        healthComponent.onHealthChanged.AddListener(OnHealthChanged);

        healthScrollBar.size = 1.0f;
    }

    private void OnParticleCollision(GameObject other)
    {
        spriteColor.SetColor(Color.red);
        spriteColor.color = Color.white;

        healthComponent.health -= 1;
    }

    private void OnHealthChanged(int health)
    {
        healthScrollBar.size = Mathf.Clamp01(health / (float)healthComponent.maxHealth);
    }
}
