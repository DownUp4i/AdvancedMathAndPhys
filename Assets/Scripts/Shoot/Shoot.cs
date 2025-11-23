using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private ParticleSystem _shootEffectPrefab;

    [SerializeField] private LayerMask _groundMask;

    [SerializeField] private ShootRadius _shootRadius;
    [SerializeField] private ShootController _shootController;

    [SerializeField] private float _force;

    private RayGroundController _rayGroundController;

    private readonly int RightMouseInput = 1;

    private void Awake()
    {
        _rayGroundController = new RayGroundController(_groundMask);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(RightMouseInput))
        {
            foreach (Collider item in _shootController.Collider)
            {
                if (item.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
                {
                    Vector3 directionAfterShoot = (_rayGroundController.GetPoint() - item.transform.position);
                    rigidbody.AddForce(-directionAfterShoot * _force, ForceMode.Impulse);
                }
            }

            ParticleSystem effect = Instantiate(_shootEffectPrefab, _rayGroundController.GetPoint(), Quaternion.identity);
            effect.Play();
        }
    }
}
