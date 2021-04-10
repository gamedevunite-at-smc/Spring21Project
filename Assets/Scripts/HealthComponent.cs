using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{

    public class HealthEvent : UnityEvent<int>
    {

    }

    [SerializeField] private int _maxHealth;
    public int maxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            if (_maxHealth == value)
                return;

            _maxHealth = value;

        }
    }

    [SerializeField] private int _health;
    public int health
    {
        get
        {
            return _health;
        }
        set
        {
            if (_health == value)
                return;

            _health = value;

            if (onHealthChanged != null)
                onHealthChanged.Invoke(value);
        }
    }

    public HealthEvent onHealthChanged = new HealthEvent();

    public void SetHealth(int health)
    {

    }
}
