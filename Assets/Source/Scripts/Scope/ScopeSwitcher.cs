using TNRD;
using UnityEngine;

public class ScopeSwitcher : MonoBehaviour
{
    [SerializeField] private SerializableInterface<IInput> _input;
    [SerializeField] private Transform _defaultPosition;
    [SerializeField] private Transform _scopedPosition;

    public Transform Current { get; private set; }

    private void Awake()
    {
        Current = _defaultPosition;
    }

    private void Update()
    {
        Current = _input.Value.IsScoping ? _scopedPosition : _defaultPosition;
    }
}