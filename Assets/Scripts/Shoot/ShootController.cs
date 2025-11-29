using UnityEngine;

public class ShootController
{
    private LayerMask _groundMask;
    private LayerMask _itemMask;
    private ShootRadius _shootRadius;

    public ShootController(LayerMask itemMask, LayerMask groundMask, ShootRadius shootRadius)
    {
        _itemMask = itemMask;
        _groundMask = groundMask;
        _shootRadius = shootRadius;
    }

    private Collider[] _colliders;
    public Collider[] Collider => _colliders;

    public void SetColliders(Ray ray)
    {
        Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _groundMask);
        _colliders = Physics.OverlapSphere(hit.point, _shootRadius.Radius, _itemMask);
    }
}
