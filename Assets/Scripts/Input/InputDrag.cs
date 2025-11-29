using UnityEngine;

public abstract class InputDrag
{
    public abstract bool IsInputDown();
    public abstract bool IsInputHold();
    public abstract bool IsInputUp();

    public virtual Vector3 InputPosition() => Input.mousePosition;
}
