using UnityEngine;

public class DesktopInput : IInput
{
    public bool IsShooting => Input.GetKey(KeyCode.Mouse0);
}
