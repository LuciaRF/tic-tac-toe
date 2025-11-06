using UnityEngine;

public class CreateObject : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector3 createLocation;
    
    public void CreatingAPlayer()
    {
        Vector2 mousePos = Input.mousePosition;
        float distance = Camera.main.WorldToScreenPoint(transform.position).z;
        createLocation = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, distance));
        
        Instantiate(player, createLocation, Quaternion.identity);
    }
}
