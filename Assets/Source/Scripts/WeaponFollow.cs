using UnityEngine;

public class WeaponFollow : MonoBehaviour
{
    [SerializeField] private Transform _weapon;
    [SerializeField] private Transform _target;
    [SerializeField] private float _followSpeed;

    private void Update()
    {
        _weapon.position = Vector3.Lerp(_weapon.position, _target.position, _followSpeed * Time.deltaTime);
        _weapon.rotation = Quaternion.Lerp(_weapon.rotation, _target.rotation, _followSpeed * Time.deltaTime);
    }
}
