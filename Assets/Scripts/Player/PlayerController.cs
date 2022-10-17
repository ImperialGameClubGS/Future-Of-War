using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IHittable
{
    public event Action<int> OnPlayerHealthValueChangedEvent;

    public int HealthDefault = 100;
    
    private int _health; 

    void Start()
    {
        _health = HealthDefault;

        this.OnPlayerHealthValueChangedEvent?.Invoke(this._health);
    }

    public void HitObject(int damage)
    {
        _health -= damage;

        this.OnPlayerHealthValueChangedEvent?.Invoke(this._health);
    }
}
