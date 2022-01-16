using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive_Projectile : MonoBehaviour
{
    private Vector2 center;
    public float radius = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] enemyHit = Physics2D.OverlapCircleAll(transform.position,radius);
        foreach(Collider2D col in enemyHit){
            EnemyHealth enemyHealth = col.GetComponent<EnemyHealth>();
            if(enemyHealth != null) enemyHealth.TakeDamage();
            }
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(transform.position,radius);
    }

    void Destroy(){
        Destroy(gameObject);
    }
}
