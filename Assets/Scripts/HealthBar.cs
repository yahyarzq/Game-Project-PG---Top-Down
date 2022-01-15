using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public TextMeshPro healthNumber;
    // Start is called before the first frame update
    
    public void SetHealth(int health){
        slider.value = health;
        //healthNumber.text = health.ToString();
    }
    public void SetMaxHealth(int health){
        slider.maxValue = health;
        slider.value = health;
    }
}
