using UnityEngine;

public class SetPosition : MonoBehaviour
{
    public PropertiesAndCouroutines propertiesAndCouroutines;


    void OnMouseDown()
    {
        Debug.Log("Clicked");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Physics.Raycast(ray, out hit);
        Debug.Log(hit.collider.name);
        Debug.Log(gameObject.name);
        if (hit.collider.gameObject != gameObject)
        {
            Debug.Log(hit.collider.name);
            Vector3 newTarget = hit.point;
            propertiesAndCouroutines.Target = newTarget;
        }
    }
}
