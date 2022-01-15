using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
   
    public float speed;
    public Transform firePoint;
    private Transform playerPos;
    private Rigidbody2D rb;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    private bool isinPlayerRange = false;
    //private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        EnemyFacingPlayer();
        
    }
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        FindPlayer();

        
    }
    private void FixedUpdate() {
        MoveEnemy();

    }
    //find player location
    void FindPlayer(){
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }
    //Move enemy toward player
    void EnemyFacingPlayer(){

            Vector2 direction = playerPos.position -transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
            // direction.Normalize();
            // movement = direction;
        
    }
    void MoveEnemy(){
         if(Vector2.Distance(transform.position,playerPos.position)>9f){
            transform.position = Vector2.MoveTowards(transform.position,playerPos.position,speed*Time.deltaTime);
            isinPlayerRange =true;
         }else{
             isinPlayerRange = false;
         }
    }

    IEnumerator Shoot(){
            EnemyWeapon();
            yield return new WaitForSeconds(1f);
        if (isinPlayerRange)
        {
            
            StartCoroutine(Shoot());
        }
        
        
    }

    void EnemyWeapon(){
        GameObject bullet =  Instantiate(bulletPrefab,firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce,ForceMode2D.Impulse);
    }

    
}