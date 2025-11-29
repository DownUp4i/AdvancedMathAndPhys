using UnityEngine;

public class DragAndDropHandler : MonoBehaviour
{
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private LayerMask _itemMask;

    private RayGroundController _rayGroundController;
    private RayItemController _rayItemController;

    private InputDrag _inputDrag;

    private IDraggable _currentItem;

    private bool _isleftMouseDown;
    private bool _isleftMouseHold;
    private bool _isleftMouseUp;

    private Ray _ray;
    private Vector3 _groundPoint;

    private float _yPosition = 1f;

    private void Awake()
    {
        _inputDrag = new LeftMouseInputDrag();

        _rayGroundController = new RayGroundController(_groundMask);
        _rayItemController = new RayItemController(_itemMask);
    }

    private void Update()
    {
        _ray = Camera.main.ScreenPointToRay(_inputDrag.InputPosition());

        _groundPoint = _rayGroundController.GetPoint();

        if (_inputDrag.IsInputDown())
            SetCurrentItem();

        if (_inputDrag.IsInputUp())
            Drop();
    }

    private void FixedUpdate()
    {
        if (_rayItemController.IsHit(_ray))
        {
            if (_inputDrag.IsInputHold() && _currentItem != null)
                _currentItem.Drag(_groundPoint, _yPosition);
        }
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
