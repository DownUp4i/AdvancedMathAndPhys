using UnityEngine;

public class LeftMouseInputDrag : InputDrag
{
    public override bool IsInputDown() => Input.GetMouseButtonDown(0);
    public override bool IsInputHold() => Input.GetMouseButton(0);
    public override bool IsInputUp() => Input.GetMouseButtonUp(0);
}
