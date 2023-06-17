using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icefall : MonoBehaviour
{
    // Start is called before the first frame update

    void fall()
    {
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        Invoke(nameof(ondespawn), 3f);
    }
    void ondespawn()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "foot")
        {
            Invoke(nameof(fall), 2f);
        }

    }
}
