using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDamage;
    public int bulletHealth;
    
    void Awake()
    {
        bulletHealth = 1;
        
        
    }

    
    void Update()
    {
        
    }
    public void SetBulletDamage(float damage)
    {
        this.bulletDamage = damage;

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (collision.gameObject.tag == "Enemy" && bulletHealth >= 1)
        {
            bulletHealth --;
            Debug.Log("Bullet hit enemy!");

            enemy.hp -= bulletDamage;

            Destroy(this.gameObject);
        }
        


    }

}
