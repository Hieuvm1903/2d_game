using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    float damage = 40;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" )
        {
            collision.GetComponent<Character>().Onhit(30);


        }
        else if (collision.tag == "enemy")
        {
            collision.GetComponent<Character>().Onhit(damage);
        }
    }
}
