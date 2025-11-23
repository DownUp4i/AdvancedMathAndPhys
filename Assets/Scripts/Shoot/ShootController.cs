using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private LayerMask _itemMask; 
    [SerializeField] private ShootRadius _shootRadius;

    private RayGroundController _rayGroundController;

    private Collider[] _colliders;
    public Collider[] Collider => _colliders;

    private void Awake()
    {
        _rayGroundController = new RayGroundController(_groundMask);
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Vector3 point = _rayGroundController.GetPoint();

        _shootRadius.transform.position = new Vector3(point.x, _shootRadius.transform.position.y, point.z);

        SetColliders(ray);
    }

    public void SetColliders (Ray ray)
    {
        Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _groundMask);
        _colliders = Physics.OverlapSphere(hit.point, _shootRadius.Radius, _itemMask);
    }
}
