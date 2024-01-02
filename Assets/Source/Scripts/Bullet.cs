using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;

    public event UnityAction<Bullet> Deactivated; 

    public void Activate(Transform point)
    {
        transform.SetPositionAndRotation(point.position, point.rotation);
        gameObject.SetActive(true);
        _rigidbody.velocity = -transform.forward * _speed;
    }

    private void Deactivate()
    {
        _rigidbody.velocity = Vector3.zero;
        gameObject.SetActive(false);
        Deactivated?.Invoke(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Enemy enemy))
            enemy.Hit();
        
        Deactivate();
    }
}
