using UnityEngine;

public class AimingAmination : MonoBehaviour
{
    [SerializeField] private Transform _weapon;
    [SerializeField] private float _followSpeed;
    [SerializeField] private Scope _scope;
    private void Update()
    {
        _weapon.position = Vector3.Lerp(_weapon.position, _scope.Current.position, _followSpeed * Time.deltaTime);
        _weapon.rotation = Quaternion.Lerp(_weapon.rotation, _scope.Current.rotation, _followSpeed * Time.deltaTime);
    }
}
