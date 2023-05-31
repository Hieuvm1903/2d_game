using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    [SerializeField] private Transform apoint, bpoint;
    // Start is called before the first frame update
    Vector3 target;
    [SerializeField] private float speed;
    void Start()
    {
        transform.position = apoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position,apoint.position)<0.1f)
        {
            target = bpoint.position;

        }
        else if(Vector2.Distance(transform.position, bpoint.position) < 0.1f)
        {
            target = apoint.position;


        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);

        }
    }
}
