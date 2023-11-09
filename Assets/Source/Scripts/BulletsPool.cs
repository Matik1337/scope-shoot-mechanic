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

    public void ReturnBullet(Bullet bullet)
    {
        _pool.Enqueue(bullet);
    }
    
    private void Init()
    {
        _pool = new Queue<Bullet>();
        
        for (int i = 0; i <= _poolSize; i++)
        {
            _pool.Enqueue(SpawnBullet());
        }
    }

    private Bullet SpawnBullet()
    {
        Bullet bullet = Instantiate(_bulletPrefab);
        bullet.Init(this);
        return bullet;
    }
}
