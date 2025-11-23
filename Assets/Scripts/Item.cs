using UnityEngine;

public class Item : MonoBehaviour, IMoveable
{
    Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void Move(Vector3 mousePosition)
    {
        transform.position = new Vector3(mousePosition.x, transform.position.y, mousePosition.z);
    }
}
