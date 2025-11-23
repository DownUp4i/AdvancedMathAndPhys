using UnityEngine;

public class RayItemController : IRayController
{
    private LayerMask _itemMask;

    private Ray _ray;

    public RayItemController(LayerMask itemMask)
    {
        _itemMask = itemMask;
    }

    public Vector3 GetPoint(Ray ray)
    {
        Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _itemMask);
        return hit.point;
    }

    public IMoveable GetCollider(Ray ray)
    {
        Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _itemMask);
        return hit.collider.GetComponent<IMoveable>();
    }

    public bool IsHit(Ray ray)
    {
        return Physics.Raycast(ray, _itemMask);
    }
}
