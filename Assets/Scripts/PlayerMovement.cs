using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Camera cam;
    private Vector2 moveDirection;
    private Vector2 mousePos;

    public float moveSpeed = 5;
    // Start is called before the first frame update

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate() {
        Move();
        MouseAim();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }
    private void ProcessInput(){
        float moveX  = Input.GetAxisRaw("Horizontal");
        float moveY  = Input.GetAxisRaw("Vertical");
        moveDirection =  new Vector2(moveX,moveY).normalized;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void Move(){
        float  moveDX = moveDirection.x * moveSpeed;
        float moveDY = moveDirection.y * moveSpeed;

        rb.velocity = new Vector2(moveDX, moveDY);
    }
    private void MouseAim(){
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x) *Mathf.Rad2Deg -90f;
        rb.rotation = angle;
    }
}
