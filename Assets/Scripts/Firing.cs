using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    
    public float bulletForce = 20f;
    public float damage = 1;
    public float fireCooldown = 0.5f;
    float fireCooldownRemaining = 0;
    void Update()
    {
        if(fireCooldownRemaining >= 0)
        {
            fireCooldownRemaining -= Time.deltaTime;
        }

        if (Input.GetButton("Fire1") && fireCooldownRemaining <= 0 /*&& PlayerStatus.hasLongRange*/)
        {
            Shoot();
            fireCooldownRemaining = fireCooldown;
            Debug.Log("Fire pushed!");
        }
        
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().SetBulletDamage(damage);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce * 1, ForceMode2D.Impulse);
    }
    
}
