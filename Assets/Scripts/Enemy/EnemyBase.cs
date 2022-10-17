using System.Collections;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IHittable
{
    public int Health = 100;
    public int Damage = 10;
    public float RunSpeed = 6f;
    public float RestingSpeed = 3.5f;
    public bool isDead => Health <= 0;


    void Start()
    {
    }

    public void HitObject(int damage)
    {
        this.Health -= damage;
        Debug.Log(this.Health);
        if (isDead)
        {

            Destroy(gameObject); 
        }

            
    }
}
