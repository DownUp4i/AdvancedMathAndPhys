using System;
using UnityEngine;

public class RayGroundController : IRayController
{
    private LayerMask _groundMask;
    private InputDrag _inputDrag;

    public RayGroundController(LayerMask groundMask)
    {
        _inputDrag = new LeftMouseInputDrag();
        _groundMask = groundMask;
    }

    public Vector3 GetPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(_inputDrag.InputPosition());

        Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _groundMask);

        return hit.point;
    }

    public bool IsHit(Ray ray)
    {
        return Physics.Raycast(ray, Mathf.Infinity, _groundMask);
    }
}
