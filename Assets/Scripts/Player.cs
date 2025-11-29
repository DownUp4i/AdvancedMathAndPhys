using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    [SerializeField] ParticleSystem _shootEffectPrefab;
    [SerializeField] ShootRadius _shootRadius;

    [SerializeField] private LayerMask _itemMask;
    [SerializeField] private LayerMask _groundMask;

    private RayGroundController _rayGroundController;

    private InputDrag _input;

    private Shoot _shoot;
    private ShootController _shootController;

    private float explodeForce = 5f;

    private void Awake()
    {
        _input = new RightMouseInput();
        _shoot = new Shoot(explodeForce);
        _shootController = new ShootController(_itemMask, _groundMask, _shootRadius);

        _rayGroundController = new RayGroundController(_groundMask);
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(_input.InputPosition());

        Vector3 point = _rayGroundController.GetPoint();

        _shootRadius.transform.position = new Vector3(point.x, _shootRadius.transform.position.y, point.z);

        if (_input.IsInputDown())
        {
            _shootController.SetColliders(ray);
            _shoot.Execute(_shootController, _rayGroundController);

            ParticleSystem effect = Instantiate(_shootEffectPrefab, _rayGroundController.GetPoint(), Quaternion.identity);
            effect.Play();
        }
    }
}
