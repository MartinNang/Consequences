using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1;
    Vector2 movement;
    Vector2 input;
    public Rigidbody2D rb;
    public float friction;
    public static Transform t;
    public float fixedRotation;

    //for Dashing
    private float activeMoveSpeed;
    public float dashSpeed;

    public float dashLength = 5f, dashCooldown = 1f;
    private float dashCounter;
    private float dashCoolCounter;

    private void Start()
    {
        
        t = transform;
        fixedRotation = t.rotation.z;
        activeMoveSpeed = moveSpeed;
    }

    void Update()
    {
        //lock Rotation around z-axis
        t.eulerAngles = new Vector3(t.eulerAngles.x, t.eulerAngles.y, fixedRotation);
        
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        movement.x = 0;
        movement.y = 0;
        if(PlayerStatus.hasXAxis)
        {
            movement.x = input.x;
        }
        if(PlayerStatus.hasYAxis)
        {
            movement.y = input.y;
        }
        //Borders for movement
        position.x = Mathf.Clamp(position.x, -12.3f, 12.3f);
        position.y = Mathf.Clamp(position.y, -6.2f, 6.3f);
        transform.position = position;

        if (Input.GetButtonDown("Dash"))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                
                dashCounter = dashLength;
            }
        }
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }
        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
        if (PlayerStatus.hasDash)
        {
            rb.MovePosition(rb.position + (movement * moveSpeed + input * dashSpeed) * Time.deltaTime);
        }
        else
        {
            rb.MovePosition(rb.position + (movement * moveSpeed) * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        

        

    }



}
