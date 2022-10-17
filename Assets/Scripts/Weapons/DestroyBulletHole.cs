using UnityEngine;

public class DestroyBulletHole : MonoBehaviour
{
    public float DestroyTimer = 1.2f;
    void Start()
    {
        Destroy(gameObject, DestroyTimer);
    }
}
