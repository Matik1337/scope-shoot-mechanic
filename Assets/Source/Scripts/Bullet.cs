using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    
    public bool IsActive { get; private set; }
    public float StartTime { get; private set; }

    public void Activate(Transform point)
    {
        IsActive = true;
        transform.SetPositionAndRotation(point.position, point.rotation);
        gameObject.SetActive(true);
        _rigidbody.velocity = -transform.forward * _speed;
        StartTime = Time.time;
    }

    public void Deactivate()
    {
        _rigidbody.velocity = Vector3.zero;
        gameObject.SetActive(false);
        IsActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Enemy enemy))
            enemy.Hit();
        
        Deactivate();
    }
}
