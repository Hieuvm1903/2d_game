using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footscrpit : MonoBehaviour
{
    [SerializeField] public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.rb.velocity.y>0)
        {
            player.transform.SetParent(null);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "moving")
        {
            
            if( transform.position.y>collision.transform.position.y)
            player.transform.SetParent(collision.transform);
            //Debug.Log("stick");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        player.transform.SetParent(null);
    }

}
