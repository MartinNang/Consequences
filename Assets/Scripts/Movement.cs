using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5;
    Vector2 movement;
    Vector2 dashMovement;
    public Rigidbody2D rb;
    public float friction;
    public static Transform t;
    public float fixedRotation;

    //for Dashing
    [SerializeField] float dashSpeed = 5;

    public float dashLength = 5f, dashCooldown = 1f;
    private float dashCounter;
    private float dashCoolCounter;

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

        if (PlayerStatus.hasXAxis) movement.x = Input.GetAxisRaw("Horizontal");
        else movement.x = 0;

        if (PlayerStatus.hasYAxis) movement.y = Input.GetAxisRaw("Vertical");
        else movement.y = 0;

        //Borders for movement
        position.x = Mathf.Clamp(position.x, -12.3f, 12.3f);
        position.y = Mathf.Clamp(position.y, -6.2f, 6.3f);
        transform.position = position;

        
        
    }

    private void FixedUpdate()
    {
        if (PlayerStatus.hasDash)
        {
            dashMovement.x = Input.GetAxisRaw("Horizontal");
            dashMovement.y = Input.GetAxisRaw("Vertical");            

            if (Input.GetButtonDown("Dash"))
            {
                if (dashCoolCounter <= 0 && dashCounter <= 0)
                {
                    dashCounter = dashLength;
                }
            }
            if (dashCounter > 0)
            {
                // rb.MovePosition(rb.position + dashMovement * dashSpeed * Time.deltaTime);
                rb.velocity = dashMovement * dashSpeed;
                dashCounter -= Time.deltaTime;
                if (dashCounter <= 0)
                {
                    dashCoolCounter = dashCooldown;
                }
            }
            if (dashCoolCounter > 0)
            {
                dashCoolCounter -= Time.deltaTime;
            }
        }
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }



}
