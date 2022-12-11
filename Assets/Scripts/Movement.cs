using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1;
    Vector2 movement;
    public Rigidbody2D rb;
    public float friction;
    public static Transform t;
    public float fixedRotation;

    private void Start()
    {
        
        t = transform;
        fixedRotation = t.rotation.z;
    }

    void Update()
    {
        //lock Rotation around z-axis
        t.eulerAngles = new Vector3(t.eulerAngles.x, t.eulerAngles.y, fixedRotation);
        
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //Borders for movement
        position.x = Mathf.Clamp(position.x, -12.3f, 12.3f);
        position.y = Mathf.Clamp(position.y, -6.2f, 6.3f);
        transform.position = position;

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }



}
