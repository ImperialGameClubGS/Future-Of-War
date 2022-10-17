using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        IHittable hitObject = other.gameObject.GetComponent<IHittable>();
        if (hitObject != null)
        {
            hitObject.HitObject(1000);
        }
    }
}
