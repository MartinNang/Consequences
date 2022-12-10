using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    Vector2 mousePosition;
    public Camera cam;

    void Start()
    {
        Debug.Log(transform.position);
    }


    void Update()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {

        Vector2 lookDirection = mousePosition - new Vector2(transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg + 90f;
        Vector3 rotation3 = new Vector3(0, 0, angle + 180);
        transform.rotation = Quaternion.Euler(rotation3);

    }
}
