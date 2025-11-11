using UnityEngine;
using System.Collections;

public class TernaryOperator : MonoBehaviour
{
    public float smoothing = 1f;
    public Transform target;

    void Start()
    {
        int health = 10;
        string message;
        
        message = health > 0 ? "Player is alive" : "Player is dead";
        
        transform.ResetTransform();
        StartCoroutine(MyCoroutine(target));
    }
    
    IEnumerator MyCoroutine(Transform target)
    {
        while (Vector3.Distance(transform.position, target.position) > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position,target.position,smoothing * Time.deltaTime);
            
            yield return null;
        }
        
        print("He llegado");
        yield return new WaitForSeconds(3);
        print("Globos");
    }

}
