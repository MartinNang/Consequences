using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HPScript : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMeshProUGUI.text = "HP: " + PlayerDamage.playerCurrentHP.ToString() + "/" + PlayerDamage.playerMaxHP.ToString();
    }
}
