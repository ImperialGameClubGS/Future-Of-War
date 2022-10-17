using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage = 10;
    public float Speed = 10f;
    public float maxD = 0.1f;
    public float minD = -0.1f;

    [SerializeField] private Transform _player;

    private float _timer = 2f;
    private Vector3 Spread;

    private void Start()
    {
        Spread = new Vector3(1, Random.Range(minD, maxD), Random.Range(minD, maxD));
    }
    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
            Destroy(this.gameObject);
        else
        {
            transform.Translate(0, 0, Speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        IHittable hitObject = other.gameObject.GetComponent<IHittable>();
        if (hitObject != null)
        {
            hitObject.HitObject(this.Damage);
            Destroy(this.gameObject);
        }
        if (other.gameObject.layer == 0)
        {
            Destroy(this.gameObject);
        }

    }
}
