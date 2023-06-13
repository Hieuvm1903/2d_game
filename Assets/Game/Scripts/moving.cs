using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    [SerializeField] private Transform apoint, bpoint,cpoint;
    // Start is called before the first frame update
    Vector3 target;
    [SerializeField] private float speed;
    public float time = 0;
    public bool move = true;
    public float time2 = 5f;
    void Start()
    {
        transform.position = bpoint.position;
        //StartCoroutine(Idelay());
        //StartCoroutine(Istop());

    }


    // Update is called once per frame
    void Update()
    {


        
        float a = Random.Range(1, 2);

        if (time >= a)
        {
            move = true;
            time = 0;
        }

        Move();
        
        //ex12();

        /*
        if (time <= 0)
        {
            time += Time.deltaTime;
        }
      
        float x = transform.position.x - apoint.position.x;
        float y = transform.position.y - apoint.position.y;
        float phi = Mathf.Atan(x / y);
        */
        //Vector3 newpos = new Vector3(3*Mathf.Sin(Mathf.PI / 4 * time), 5*Mathf.Cos(Mathf.PI / 4 * time), 0);
        // Vector3 temp = transform.position;
        // transform.position = Vector3.Lerp(transform.position,  target+newpos, Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        //Debug.DrawRay(temp, -transform.position);

        /*
                if (Vector2.Distance(transform.position,apoint.position)<0.1f)
                {
                    target = bpoint.position;
                }
                else if(Vector2.Distance(transform.position, bpoint.position) < 0.1f)
                {
                     target = apoint.position;

                }

                else if (Vector2.Distance(transform.position, cpoint.position) < 0.1f)
                {
                    target = cpoint.position+ new Vector3(Random.Range(0,10),Random.Range(0,10),0);

                }
                */

    }
    IEnumerator Idelay()
    {
        
        while(true)
        {

            move = !move;

            yield return new WaitForSeconds(1f);
           
            
        }
        
    }
    IEnumerator Istop()
    {

        for (; ; )
        {
            if (Vector2.Distance(transform.position, bpoint.position) < 0.1f || (Vector2.Distance(transform.position, apoint.position) < 0.1f))
            {
                move = !move;
                yield return new WaitForSeconds(Random.Range(1, 2));
                move = !move;
            }
            
        }

    }
    private void Move()
    {
        //if (move)
        {

            //transform.position = Vector3.Lerp(transform.position, target , Time.deltaTime);
            //transform.position = Vector3.MoveTowards(transform.position, target, Vector2.Distance(bpoint.position, apoint.position)/time2*Time.deltaTime);
            //Settarget();
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            /*
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.position- target , 1.1f);
            
            if(hit.collider.tag == "Player")
            { Debug.Log("Complete"); }
            */
        }

        if (Vector2.Distance(transform.position, apoint.position) < 0.1f)
        {
            
            target = bpoint.position;
            move = false;
            time += Time.deltaTime;
            //Debug.Log("a");
        }
        else if (Vector2.Distance(transform.position, bpoint.position) < 0.1f)
        {
            
            target = apoint.position;
            move = false;
            time += Time.deltaTime;
            // Debug.Log("b");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" )
        {
           // collision.transform.SetParent(transform);

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);

        }
    }
    private void ex12()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouspos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouspos.z = transform.position.z;
            RaycastHit2D hit = Physics2D.Raycast(mouspos, transform.position - mouspos, 100);

            if (hit.collider != null)
            {
                Debug.Log("red");
                hit.collider.GetComponent<Renderer>().material.color = Color.red;
            }
        }

    }
    private void Settarget()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouspos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouspos.z = transform.position.z;
            target = mouspos;


        }
    }


}
