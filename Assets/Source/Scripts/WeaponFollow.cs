using UnityEngine;

public class WeaponFollow : MonoBehaviour
{
    [SerializeField] private Transform _weapon;
    [SerializeField] private float _followSpeed;
    [SerializeField] private ScopeSwitcher _scopeSwitcher;
    private void Update()
    {
        _weapon.position = Vector3.Lerp(_weapon.position, _scopeSwitcher.Current.position, _followSpeed * Time.deltaTime);
        _weapon.rotation = Quaternion.Lerp(_weapon.rotation, _scopeSwitcher.Current.rotation, _followSpeed * Time.deltaTime);
    }
}
