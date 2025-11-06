using System;
using UnityEngine;

public class PlayerOnCenter : MonoBehaviour
{
    private Collider _collider;
    [SerializeField] private Vector3 _centerPosition;
    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _centerPosition = _collider.bounds.center;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("PlayerOnCenter");
            other.transform.position = _centerPosition;
            
            
            DragElement dragElement = other.GetComponent<DragElement>();
            if (dragElement != null)
            {
                dragElement.enabled = false;
            }
        }
    }
}
