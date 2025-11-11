using UnityEngine;
using System.Collections;

public class PropertiesAndCouroutines : MonoBehaviour
{
    public float smoothing = 5f;

    private Vector3 target;

    public Vector3 Target
    {
        get { return target; }
        set
        {
            target = value;
            StopCoroutine(nameof(MyCoroutine));
            StartCoroutine(nameof(MyCoroutine),target);
        }
    }
    
    IEnumerator MyCoroutine(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position,target,smoothing * Time.deltaTime);
            
            yield return null;
        }
        
    }

}
