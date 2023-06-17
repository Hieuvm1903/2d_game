using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : Character
{
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayer;
    private float horrizontal;
    [SerializeField]  private float speed = 5;
    [SerializeField] private float jumpforce = 350;
    [SerializeField] private Kunai kunaipref;
    [SerializeField] private Transform throwpoint;
    [SerializeField] private GameObject attackarea;

    private bool isgred = false;
    private bool isjping = false;
    private bool isatk = false;
    private int coin = 0;
    private Vector3 savepoint;

    // internal Player instance;
    // Start is called before the first frame update
    private void Awake()
    {
        coin = PlayerPrefs.GetInt("coin",0);
    }
    // Update is called once per frame
    
    void Update()
    {
        
        if(isdead)
        { return; }
       isgred =  checkgr();    
           // horrizontal = Input.GetAxisRaw("Horizontal");       
        if(isatk)
        {
           // rb.velocity = Vector2.zero;
            return; 
        }
        if (isgred)
        {
            if (isjping)
            {
                //getout();
                return;

            }
            if (Input.GetKeyDown(KeyCode.UpArrow) )
            {
                Jump();
            }
            if (Input.GetKeyDown(KeyCode.C) )
            {
                Throw();
            }
            if (Input.GetKeyDown(KeyCode.X) )
            {
                Attack();
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                skill();
            }
            if (Math.Abs(horrizontal) > 0.01f)
            {
                Changeanim("run");
            }
        }
        
        if (!isgred && rb.velocity.y < 0)
            {
                Changeanim("fall");
                isjping = false;

            }
        
        //checkplatform();

        if (Math.Abs( horrizontal) >0.01f)
        {
            if(!isgred && isjping)
            {
                Changeanim("fall");

            }
            else if(isgred)
            { Changeanim("run"); }
            rb.velocity = new Vector2(horrizontal *speed,rb.velocity.y);
            //transform.localScale = new Vector3(horrizontal, 1, 1);
            transform.rotation = Quaternion.Euler(new Vector3(0,horrizontal>0?0:180,0));
            //getout();
        }
        else 
        
        if (isgred)
        {
            Changeanim("idle");
            stop();

        }

    }
    private void stop()
    {
        rb.velocity = Vector2.zero;
    }
    private void rsatk()
    {
        Changeanim("idle");
        isatk = false;
    }
    private bool checkgr()
    {
        Debug.DrawLine(transform.position, transform.position + Vector3.down * 0.7f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.7f, groundLayer);
        if (hit.collider != null)
            return true;
        else
            return false;

    }
    public void Attack()
    {
        if (!isdead)
        {
            Changeanim("attack");
            // rb.velocity = Vector2.zero;
            isatk = true;
            activeatk();
            Invoke(nameof(deactiveatk), 0.3f);
            Invoke(nameof(rsatk), 0.1f);
        }
    }
    private void activeatk()
    {
        attackarea.SetActive(true);

    }
    private void deactiveatk()
    {
        attackarea.SetActive(false);
    }
    public void Throw()
    {
        if (!isdead)
        {
            Changeanim("throw");
            //rb.velocity = Vector2.zero;
            isatk = true;

            Invoke(nameof(rsatk), 0.5f);
            Instantiate(kunaipref, throwpoint.position, throwpoint.rotation);
        }


    }
    public void Jump()
    {
        if (isgred && !isjping&&!isdead)
        {
            //getout();
            Changeanim("jump");

            isjping = true;
            rb.AddForce(Vector2.up * jumpforce);
           
        }
        //checkplatform();
        if(rb.bodyType == RigidbodyType2D.Kinematic)
        {
            rb.velocity = new Vector2(rb.velocity.x, 2 );
            Changeanim("climb");
            Invoke(nameof(stop), 0.5f);
        }
    }
    public override void Oninit()
    {
        Changeanim("idle");

        base.Oninit();

        deactiveatk();

        isatk = false;
        isjping = false;

        transform.position = savepoint;
        Changeanim("idle");
        UImanger.instance.setcoin(coin);

    }
    public override void Ondespawn()
    {
        
        base.Ondespawn();
    }
    public override void Ondeath()
    {
        base.Ondeath();
        isatk = true;
        isjping = true;

          Invoke(nameof(Oninit), 0.65f);
        //Oninit();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin")
        {
            
            coin++;
            PlayerPrefs.SetInt("coin",coin);
            UImanger.instance.setcoin(coin);
            Destroy(collision.gameObject);


        }
        if(collision.tag=="die")
        {

            Ondeath();
        }
 

    }
    internal void savePoint()
    {
        savepoint = transform.position;

    }
    internal void checkplatform()
    {
        //Debug.DrawLine(transform.position, transform.position + Vector3.down * 1.1f, Color.blue);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundLayer);
        if (hit.collider != null)
        { 
            if (hit.collider.transform.tag == "moving" && hit.collider.transform.position.y+hit.collider.GetComponent<BoxCollider2D>().size.y/2 <= transform.position.y-this.GetComponent<CapsuleCollider2D>().size.y/2 )
            {
                this.transform.SetParent(hit.collider.transform);

            }
        }

    }
    internal void getout()
    {
        this.transform.SetParent(null);

    }
    public void Setmove(float hori)
    {
        if(!isdead)
        this.horrizontal = hori;
        //getout();
    }
    public void skill()
    {
        if(Mathf.Abs(horrizontal) >0.01f || isdead)
        {
            return;
        }
        horrizontal = 0;
        Changeanim("skill");

        isatk = true;
        Invoke(nameof(rsatk), 0.5f);
        Instantiate(kunaipref, throwpoint.position, throwpoint.rotation);
        Instantiate(kunaipref, throwpoint.position, Quaternion.Euler(15, 0, 0));
        Instantiate(kunaipref, throwpoint.position, Quaternion.Euler(-15, 0, 0));


    }    
}
