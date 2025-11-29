using UnityEngine;

public class RayItemController : IRayController
{
    private LayerMask _itemMask;

    private Ray _ray;

    private InputDrag _inputDrag;

    public RayItemController(LayerMask itemMask)
    {
        _inputDrag = new LeftMouseInputDrag();

        _itemMask = itemMask;
    }

    public Vector3 GetPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(_inputDrag.InputPosition());
        Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _itemMask);
        return hit.point;
    }

    public IDraggable GetCollider(Ray ray)
    {
        Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _itemMask);

        if (hit.collider != null && hit.collider.TryGetComponent<IDraggable>(out IDraggable item))
            return item;

        return null;
    }

    public bool IsHit(Ray ray)
    {
        return Physics.Raycast(ray, _itemMask);
    }
}
