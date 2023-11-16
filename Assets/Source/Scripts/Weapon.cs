using System.Collections;
using TNRD;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private SerializableInterface<IInput> _input;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private BulletsPool _pool;
    [Space(10)] [Header("Shoot Settings")]
    [SerializeField] private float _frequency;
    [SerializeField] private int _maxAmmoCount;
    [SerializeField] private float _reloadDelay;

    private int _ammo;
    private bool _isReloading;
    private float _lastShootTime;

    private void Awake()
    {
        StartCoroutine(Reload(0));
    }

    private void Update()
    {
        if (CanShoot())
            Shoot();
    }

    private bool CanShoot() => _input.Value.IsShooting && !_isReloading && (Time.time - _lastShootTime > 60 / _frequency);
    
    private void Shoot()
    {
        _pool.GetBullet().Activate(_shootPoint);
        _lastShootTime = Time.time;
        _ammo--;
        
        if (_ammo == 0)
            StartCoroutine(Reload(_reloadDelay));
    }

    private IEnumerator Reload(float delay)
    {
        _isReloading = true;
        yield return new WaitForSeconds(delay);
        _ammo = _maxAmmoCount;
        _isReloading = false;
    }
}
