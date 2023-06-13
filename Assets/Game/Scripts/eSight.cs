using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eSight : MonoBehaviour
{
    // Start is called before the first frame update
    public Enemy enemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            enemy.Settarget(collision.GetComponent<Character>());

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enemy.Settarget(null);

        }
    }

}
