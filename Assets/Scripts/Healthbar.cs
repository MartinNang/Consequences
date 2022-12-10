using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour 
{
    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = PlayerDamage.playerMaxHP;
        healthBar.value = PlayerDamage.currentHP;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetHealth(float hp)
    {
        healthBar.value = hp;
    }

    public void SetMaxHealth(float hp)
    {
        healthBar.maxValue = hp;
    }
}
