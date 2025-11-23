using UnityEngine;

public class DragAndDropHandler : MonoBehaviour
{
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private LayerMask _itemMask;

    private RayGroundController _rayGroundController;
    private RayItemController _rayItemController;

    private IMoveable _currentItem;

    private bool _isleftMouseDown;
    private bool _isleftMouseHold;
    private bool _isleftMouseUp;

    private Ray _ray;

    private void Awake()
    {
        _rayGroundController = new RayGroundController(_groundMask);
        _rayItemController = new RayItemController(_itemMask);
    }

    private void Update()
    {
        _isleftMouseDown = Input.GetMouseButtonDown(0);
        _isleftMouseHold = Input.GetMouseButton(0);
        _isleftMouseUp = Input.GetMouseButtonUp(0);

        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Vector3 groundPoint = _rayGroundController.GetPoint();

        if (_isleftMouseDown)
            SetCurrentItem();

        if (_rayItemController.IsHit(_ray))
        {
            if (_isleftMouseHold && _currentItem != null)
                _currentItem.Move(groundPoint);
        }

        if (_isleftMouseUp)
            Drop();
    }

    private void SetCurrentItem()
    {
        if (_rayItemController.IsHit(_ray))
            _currentItem = _rayItemController.GetCollider(_ray);
    }

    private void Drop()
    {
        _currentItem = null;
    }
}
