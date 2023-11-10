using UnityEngine;

public class DesktopInput : IInput
{
    public bool IsShooting => Input.GetKey(KeyCode.Mouse0);
    public bool IsScoping => Input.GetKey(KeyCode.Mouse1);
}
