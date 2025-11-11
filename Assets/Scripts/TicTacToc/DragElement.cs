using System;
using UnityEngine;

public class DragElement : MonoBehaviour
{
    private Vector3 offset;
    

    private void OnMouseDown()
    {
        Debug.Log("Pressed");
        Vector2 mousePos = Input.mousePosition;
        float distance = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, distance));
        
        offset = transform.position - worldPos;
    }

    private void OnMouseDrag()
    {
        Vector2 mousePos = Input.mousePosition;
        float distance = Camera.main.WorldToScreenPoint(transform.position).z;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, distance)) + offset;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Border"))
        {
            Debug.Log("OnTriggerEnter");
            transform.position = other.GetComponent<PlayerOnCenter>()._centerPosition;
            gameObject.GetComponent<DragElement>().enabled = false;
        }
    }
}
