using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{

    [SerializeField] LayerMask Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkplayer();
    }
    void checkplayer()
    {
        Debug.DrawLine(transform.position, transform.position + Vector3.down * 4f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 4f, Player);
        if(hit.collider !=null)
        if (hit.collider.tag == "Player")
        {
            Debug.Log("fall");
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Invoke(nameof(Ondespawn), 3f);
        }

           
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Player")
        {
            collision.GetComponent<Character>().Onhit(20);
            
        }
        
    }
    void Ondespawn()
    {
        Destroy(gameObject);
    }

}
