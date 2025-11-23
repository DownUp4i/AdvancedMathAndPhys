using System;
using UnityEngine;

public class RayGroundController : IRayController
{
    private LayerMask _groundMask;

    public RayGroundController(LayerMask groundMask)
    {
        _groundMask = groundMask;
    }

    public Vector3 GetPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _groundMask);

        return hit.point;
    }

    public bool IsHit(Ray ray)
    {
        return Physics.Raycast(ray, Mathf.Infinity, _groundMask);
    }
}
