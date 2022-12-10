using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour 
{
    public static Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = PlayerDamage.playerMaxHP;
        healthBar.value = PlayerDamage.playerCurrentHP;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static void SetHealth(float hp)
    {
        healthBar.value = hp;
    }

    public static void SetMaxHealth(float hp)
    {
        healthBar.maxValue = hp;
    }
}
