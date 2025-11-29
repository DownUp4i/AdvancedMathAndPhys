using UnityEngine;

public class Item : MonoBehaviour, IDraggable, IExpodable
{
    Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void Drag(Vector3 mousePosition, float yPosition)
    {
        _rigidbody.position = new Vector3(mousePosition.x, yPosition, mousePosition.z);
    }

    public void Explode(float explodeForce, Vector3 direction)
    {
        _rigidbody.AddForce(-direction * explodeForce, ForceMode.Impulse);
    }
}
