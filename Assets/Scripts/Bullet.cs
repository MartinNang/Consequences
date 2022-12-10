using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDamage;
    public int bulletHealth;
    
    void Start()
    {
        
        //bulletDamage = transform.parent.gameObject.GetComponent<Firing>().damage;
        Debug.Log("bulletDamage =" + bulletDamage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetBulletDamage(float damage)
    {
        this.bulletDamage = damage;

    }
}
