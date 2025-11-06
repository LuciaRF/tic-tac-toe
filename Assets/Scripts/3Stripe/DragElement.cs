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
}
