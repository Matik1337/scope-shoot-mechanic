using System.Collections.Generic;
using UnityEngine;

public class BulletsPool : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private int _poolSize;

    private Queue<Bullet> _pool;
    
    private void Awake()
    {
        Init();
    }
    
    public Bullet GetBullet()
    {
        if (_pool.Count > 0)
            return _pool.Dequeue();

        return SpawnBullet();
    }

    private void OnDisable()
    {
        foreach (var bullet in _pool)
            bullet.Deactivated -= OnBulletDeactivated;
    }

    private void Init()
    {
        _pool = new Queue<Bullet>();
        
        for (int i = 0; i <= _poolSize; i++)
        {
            _pool.Enqueue(SpawnBullet());
        }
    }
    
    private void OnBulletDeactivated(Bullet bullet)
    {
        _pool.Enqueue(bullet);
    }

    private Bullet SpawnBullet()
    {
        Bullet bullet = Instantiate(_bulletPrefab);
        
        bullet.Deactivated += OnBulletDeactivated;
        
        return bullet;
    }
}
