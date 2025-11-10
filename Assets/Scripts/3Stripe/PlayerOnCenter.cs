using UnityEngine;

public class PlayerOnCenter : MonoBehaviour
{
    private Collider _collider;
    [SerializeField] public Vector3 _centerPosition;
    
    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _centerPosition = _collider.bounds.center;
    }
}
