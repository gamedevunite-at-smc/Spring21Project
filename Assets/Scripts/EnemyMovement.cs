using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private new Rigidbody2D rigidbody2D;

    public List<MovementModifierObject> movementModifiers = new List<MovementModifierObject>();

    private List<MovementModifier> _movementModifier = new List<MovementModifier>();

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        for (int i = 0; i < movementModifiers.Count; i++)
        {
            _movementModifier.Add(movementModifiers[i].movementModifier);
        }

        //movementModifiers.Add(new ChargeModifier(new Vector2(-25, 25), 0, 1, 1, 25));
        //movementModifiers.Add(new ChargeModifier(new Vector2(-25, -25), 1, 1, 1, 25));

        //movementModifiers.Add(new CircularModifier(new Vector2(10, 10), 5, 0, 1, 1, 25));
    }

    private void FixedUpdate()
    {
        var velocity = rigidbody2D.velocity;

        for (int i = 0; i < _movementModifier.Count; i++)
        {
            velocity = _movementModifier[i].FixedUpdate(velocity);
        }

        rigidbody2D.velocity = velocity;
    }
}
