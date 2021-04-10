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

            if (onMaxHealthChanged != null)
                onMaxHealthChanged.Invoke(value);

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

            if (value < 1 && onHealthDepleted != null)
                onHealthDepleted.Invoke();
        }
    }

    public HealthEvent onHealthChanged = new HealthEvent();
    public HealthEvent onMaxHealthChanged = new HealthEvent();
    public UnityEvent onHealthDepleted = new UnityEvent();

    public void SetHealthWithoutInvoke(int health)
    {
        _health = health;
    }
    public void SetMaxHealthWithoutInvoke(int maxHealth)
    {
        _maxHealth = maxHealth;
    }
}
