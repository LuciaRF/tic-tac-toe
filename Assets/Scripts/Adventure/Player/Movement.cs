using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Animator animator;
    #region Rigidbody
    
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float lengthRay;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float jumpingForce;
    
    Rigidbody rb;
    private float horizontal, vertical;
    
    #endregion

    private Ray _ray;
    RaycastHit hit;
    
    bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Move();
        Turn();
        Jump();
    }

    void Update()
    {
        InputPlayer();
        IsMoving();
        InputJumping();
    }
    
    void InputPlayer()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void Move()
    {
        Vector3 movement = transform.forward * vertical * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }

    void Turn()
    {
        float turn = horizontal * rotateSpeed * Time.deltaTime;
        
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        
        rb.MoveRotation(transform.rotation * turnRotation);
    }

    void IsMoving()
    {
        if (vertical == 0)
        { 
            animator.SetBool("IsMoving", false);   
        }
        else
        {
            animator.SetBool("IsMoving", true);
        }
    }
    
    
    #region Jumping

    void Jump()
    {
        _ray.origin = transform.position;
        _ray.direction = Vector3.down;

        if (Physics.Raycast(_ray, out hit, lengthRay, layerMask))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
            Debug.Log(isGrounded);
        }
        
        Debug.DrawRay(_ray.origin, _ray.direction * lengthRay, Color.red);
    }

    void InputJumping()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jumping");
            isGrounded = false;
            Jumping();
        }
    }

    void Jumping()
    {
        rb.AddForce(Vector3.up * jumpingForce);
    }
    
    #endregion
}
