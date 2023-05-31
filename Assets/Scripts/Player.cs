using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;
    private float horrizontal;
    [SerializeField]  private float speed = 5;
    [SerializeField] private float jumpforce = 350;
    private bool isgred = true;
    private bool isjping = false;
    private bool isatk = false;
    private int coin = 0;
    private string curani;
    private bool isdeath;
    private Vector3 savepoint;
    // Start is called before the first frame update
    void Start()
    {
        savePoint();
        Oninit();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       isgred =  checkgr();
        horrizontal = Input.GetAxisRaw("Horizontal");
        if(isatk)
        {
            rb.velocity = Vector2.zero;
            return; }
        if (isgred)
        {
           
            
            //verticle
            if (Input.GetKeyDown(KeyCode.Space) && isgred)
            {
                Jump();
            }
            if (Input.GetKeyDown(KeyCode.C) && isgred)
            {
                Throw();
            }
            if (Input.GetKeyDown(KeyCode.X) && isgred)
            {
                Attack();
            }

            if (Math.Abs(horrizontal) > 0.1f)
            {
                Changeanim("run");
            }
        }
        if (isgred && rb.velocity.y < 0)
            {
                Changeanim("jump");
                isjping = false;

            }

        


        if (Math.Abs( horrizontal) >0.1f)
        {
            Changeanim("run");
            rb.velocity = new Vector2(horrizontal *Time.fixedDeltaTime*speed,rb.velocity.y);
            //transform.localScale = new Vector3(horrizontal, 1, 1);
            transform.rotation = Quaternion.Euler(new Vector3(0,horrizontal>0?0:180,0));
        }
        else if (isgred)
        {
            Changeanim("idle");
            rb.velocity = Vector2.zero;

        }
    }
    private void rsatk()
    {
        Changeanim("idle");
        isatk = false;
    }
    private bool checkgr()
    {
        Debug.DrawLine(transform.position, transform.position + Vector3.down * 1.1f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundLayer);
        if (hit.collider != null)
            return true;
        else
            return false;

    }
    private void Attack()
    {
        
        Changeanim("attack");
        isatk = true;
        Invoke(nameof(rsatk), 0.5f);



    }
    private void Throw()
    {
        Changeanim("throw");
        rb.velocity = Vector2.zero;
        isatk = true;
        
        Invoke(nameof(rsatk), 0.5f);
    }
    private void Jump()
    {
        isjping = true;
        rb.AddForce(Vector2.up * jumpforce);
        Changeanim("jump");

    }
    private void Changeanim(string anime)
    {
        if (curani != anime)
        {
            animator.ResetTrigger(anime);
            curani = anime;
            animator.SetTrigger(curani);

        }    


    }
    public void Oninit()
    {
        isdeath = false;
        isatk = false;
        transform.position = savepoint;
        Changeanim("idle");

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin")
        {
            
            coin++;
            Destroy(collision.gameObject);


        }
        if(collision.tag=="die")
        {

            Changeanim("idle");
            isdeath = true;
            Invoke(nameof(Oninit), 1f);
        }
        
    }
    internal void savePoint()
    {
        savepoint = transform.position;

    }
}
