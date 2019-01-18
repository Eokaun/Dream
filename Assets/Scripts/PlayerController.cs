using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float jumpForce;
    private Vector3 jumpVector;
    public float speed;
    Transform tran;
    Rigidbody2D rb;
    bool grounded;
    bool facingRight;
    public Transform GroundCheck;
    public LayerMask groundLayer;
    float moveH;


    void Start()
    {
        jumpVector = new Vector3(0f, 1.0f, 0f);
        grounded = true;
        facingRight = true;
        tran = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        moveH = 0f;

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) & grounded)
        {
            Debug.Log("Space is pressed !");
            rb.AddForce(jumpVector * jumpForce, ForceMode2D.Impulse);
            grounded = false;

        }

        moveH = Input.GetAxis("Horizontal");
        if(moveH > 0 && !facingRight)
        {
            Flip();
        }
        else if(moveH < 0 && facingRight) 
        {
            Flip();
        }

        
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(GroundCheck.position, 0.3f, groundLayer);
        Move(moveH);

    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void Move(float move)
    {
        tran.Translate(Vector3.right * move * speed * Time.deltaTime);
    }
}