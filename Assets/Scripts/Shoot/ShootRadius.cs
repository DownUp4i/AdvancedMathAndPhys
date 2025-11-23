using UnityEngine;

public class ShootRadius : MonoBehaviour
{
    [SerializeField] private float _radius = 3;
    public float Radius => _radius / 2;

    private void Awake()
    {
        transform.localScale = new Vector3(_radius, 0.03f, _radius);
    }
}
