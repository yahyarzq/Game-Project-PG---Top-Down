using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public Camera cam;
    private Vector2 moveDirection;
    private Vector2 mousePos;
    private Animator anim;

    public HealthBar healthBar;

    public Weapon weapon;
    public int maxHealth = 100;
    public int currentHealth = 10;
    public float moveSpeed = 5;
    
    public Transform firePoint;
    public float nextTimeOfFire = 0;

    private bool hit = true;
    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim =GetComponent<Animator>();
        ChangeWeaponSprite();
    }
    private void FixedUpdate()
    {
        Move();
        MouseAim();
    }
    void Start()
    {
        //set health
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        
            WeaponFire();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerTakeDamage(other);
    }
    // Process input from Player
    private void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    // Move Player
    private void Move()
    {
        float moveDX = moveDirection.x * moveSpeed;
        float moveDY = moveDirection.y * moveSpeed;

        rb.velocity = new Vector2(moveDX, moveDY);
    }
    // Move Camera Position
    private void MouseAim()

    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    IEnumerator HitboxOff()
    {
        hit = false;
        anim.SetTrigger("gethitbyenemy");
        yield return new WaitForSeconds(1.5f);
        hit = true;
    }
    //Player Take Dame
    private void PlayerTakeDamage(Collider2D target)
    {
        if((target.tag == "Enemy") || (target.tag == "Enemy_Projectile")){
            if (hit){
            
            currentHealth = currentHealth -10 ;
            healthBar.SetHealth(currentHealth);
            if (currentHealth < 1){
                StartCoroutine(Death());
            }
        }
        }
        
       
    
    }
    IEnumerator Death(){
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //fire weapon from class Wepaon 
    void WeaponFire(){
        //if (Input.GetButtonDown("Fire1")){
        //    weapon.Shoot();
        //}
        weapon.setFirePoint(firePoint);

        if (Input.GetMouseButton(0)){
            if (Time.time >= nextTimeOfFire){
                weapon.Shoot();
                nextTimeOfFire = Time.time +1/weapon.fireRate;
            }
            
        }
    }
    void ChangeWeaponSprite(){
        transform.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>().sprite = weapon.currentWeapon;
    }

}
