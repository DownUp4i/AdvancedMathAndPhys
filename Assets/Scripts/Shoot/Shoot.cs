using UnityEngine;
using UnityEngine.Windows;

public class Shoot
{
    private float _explodeForce;

    public Shoot(float explodeForce)
    {
        _explodeForce = explodeForce;
    }

    public void Execute(ShootController shootController, RayGroundController rayGroundController)
    {
        foreach (Collider item in shootController.Collider)
        {
            if (item.TryGetComponent<IExpodable>(out IExpodable explodableItem))
            {
                Vector3 directionAfterShoot = (rayGroundController.GetPoint() - item.transform.position);
                explodableItem.Explode(_explodeForce, directionAfterShoot);
            }
        }
    }
}
