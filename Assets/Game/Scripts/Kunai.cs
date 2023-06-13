using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : MonoBehaviour
{
    [SerializeField] public GameObject hitvfx;
    [SerializeField] public Rigidbody2D rb;
    float damage = 30f;
    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }
    void OnInit()
    {
        rb.velocity = transform.right * 5f;
        Invoke(nameof(Ondespawn), 2f);

    }
    void Ondespawn()
    {
        Destroy(gameObject);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "enemy")
        {

            collision.GetComponent<Character>().Onhit(damage);
            Instantiate(hitvfx,transform.position,transform.rotation);
            Ondespawn();
        }
    }
}
