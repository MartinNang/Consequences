using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveCounter : MonoBehaviour
{

    private TextMeshProUGUI textMeshProUGUI;
    private void Start()
    {
        
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        textMeshProUGUI.text = "Wave " + GameManager.wave.ToString();
    }

}

