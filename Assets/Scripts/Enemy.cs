using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private float repelRange = 2f;
    private float repelAmount = 3f;

    private List<Rigidbody2D> enemyRB;
    private Transform playerPos;
    private Rigidbody2D rb;
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyFacingPlayer();
        
    }
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        FindPlayer();
        EnemyAI();
        
    }
    private void FixedUpdate() {
        MoveEnemy(movement);
        EnemyAIRE();
    }
    //find player location
    void FindPlayer(){
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }
    //Move enemy toward player
    void EnemyFacingPlayer(){

            Vector2 direction = (playerPos.position -transform.position);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
            // direction.Normalize();
            // movement = direction;
        
    }
    void MoveEnemy(Vector2 direction){
         if(Vector2.Distance(transform.position,playerPos.position)>1f)
            transform.position = Vector2.MoveTowards(transform.position,playerPos.position,speed*Time.deltaTime);
    }


    //
    void EnemyAI(){
        if (enemyRB == null){
            enemyRB = new List<Rigidbody2D>();
        }
        enemyRB.Add(rb);
    }
    private void OnDestroy() {
        enemyRB.Remove(rb);
    }
    void EnemyAIRE(){
        Vector2 repelForce = Vector2.zero;
        foreach (Rigidbody2D enemy in enemyRB)
        {
            if(enemy ==rb)
                continue;
            if (Vector2.Distance(enemy.position,rb.position)<= repelRange){
                    Vector2 repelDir = (rb.position - enemy.position ).normalized;
                    repelForce += repelDir;
            }
        }
    }
}
