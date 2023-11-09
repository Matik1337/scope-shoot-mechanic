using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletsPool : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private List<Bullet> _pool;
    [SerializeField] private int _poolSize;

    private void Awake()
    {
        SpawnBullets();
    }

    private void SpawnBullets()
    {
        for (int i = 0; i <= _poolSize; i++)
        {
            _pool.Add(Instantiate(_bulletPrefab));
        }
    }

    public void ActivateBullet(Transform point)
    {
        GetBullet().Activate(point);
    }

    private Bullet GetBullet()
    {
        foreach (var item in _pool)
        {
            if (!item.IsActive)
            {
                return item;
            }
        }

        Bullet bullet = _pool.OrderByDescending(b => b.StartTime).First();
        
        bullet.Deactivate();
        return bullet;
    }
}
