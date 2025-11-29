using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMouseInput : InputDrag
{
    public override bool IsInputDown() => Input.GetMouseButtonDown(1);
    public override bool IsInputHold() => Input.GetMouseButton(1);
    public override bool IsInputUp() => Input.GetMouseButtonUp(1);

}
