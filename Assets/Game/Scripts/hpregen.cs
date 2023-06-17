using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpregen : MonoBehaviour
{
    // Start is called before the first frame update
    Collider2D collision1;
    float regen = -2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (collision.GetComponent<Character>().hp < 100)
            collision1 = collision;
            StartCoroutine(nameof(Ihpregen));
        }
    }
    
   
    IEnumerator Ihpregen()
    {
        while (true)
        {
            collision1.GetComponent<Character>().Onhit(regen);
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        StopAllCoroutines();
    }
}
