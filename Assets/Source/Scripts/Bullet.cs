using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    
    private BulletsPool _pool;

    public void Init(BulletsPool pool)
    {
        _pool = pool;
    }

    public void Activate(Transform point)
    {
        transform.SetPositionAndRotation(point.position, point.rotation);
        gameObject.SetActive(true);
        _rigidbody.velocity = -transform.forward * _speed;
    }

    public void Deactivate()
    {
        _rigidbody.velocity = Vector3.zero;
        gameObject.SetActive(false);
        _pool.ReturnBullet(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Enemy enemy))
            enemy.Hit();
        
        Deactivate();
    }
}
