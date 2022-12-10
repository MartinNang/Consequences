using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1;
    Vector2 movement;
    public Rigidbody2D rb;
    public float friction;


    void Update()
    {
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        position.x = Mathf.Clamp(position.x, -30, 30);
        position.y = Mathf.Clamp(position.y, -15, 17);
        transform.position = position;

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }



}
