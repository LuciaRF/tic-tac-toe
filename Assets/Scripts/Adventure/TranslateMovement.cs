using System;
using UnityEngine;

public class TranslateMovement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    
    [SerializeField] private Transform target;

    private void Update()
    {
        InputMovement();
        Movement();
        //Rotate();
        //LookingEnemy();
        RotationMouse();
    }

    void InputMovement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void Movement()
    {
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
        
        //transform.Translate(Vector3.forward * vertical * speed * Time.deltaTime);

    }

    void Rotate()
    {
        transform.Rotate(Vector3.up,horizontal * rotateSpeed * Time.deltaTime);

    }

    void LookingEnemy()
    {
        transform.LookAt(target);
    }

    void RotationMouse()
    {
        float xMouse = Input.GetAxis("Mouse X");
        float yMouse = Input.GetAxis("Mouse Y");
        
        transform.Rotate(Vector3.up, xMouse * rotateSpeed * Time.deltaTime);
        transform.Rotate(Vector3.right, -yMouse * rotateSpeed * Time.deltaTime);
    }
}
