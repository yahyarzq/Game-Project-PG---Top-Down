using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public  GameObject hitEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D other) {
        GameObject effect = Instantiate(hitEffect,transform.position, Quaternion.identity);
        Destroy(effect,0.4f);
        Destroy(gameObject);
    }
}
