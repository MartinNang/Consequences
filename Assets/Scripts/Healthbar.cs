using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Healthbar : MonoBehaviour
{
    public GameObject player;
    private float playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //render health bar

    }

    public void setHealth(float health)
    {
        playerHealth = health;
    }
}
