using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HealthNumber : MonoBehaviour
{
    public TextMeshPro healthNumber;
    // Start is called before the first frame update
    
    public void SetHealth(int health){
        healthNumber.text = health.ToString();
    }
    
}
