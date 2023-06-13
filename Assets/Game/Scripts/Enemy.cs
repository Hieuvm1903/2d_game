using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private float atkcheck;
    [SerializeField] private float movespeed;
    [SerializeField] private Rigidbody2D rgbd;
    [SerializeField] private GameObject attackarea;

    // Start is called before the first frame update
    private IState currentstate;
    private Character target;
    public Character Target => target;
    

    private bool right = true;
    public void Update()
    {
        if (isdead)
        { return; }
        if (currentstate != null && !isdead)
        {

            currentstate.Onexcute(this);
        }
    }
    public override void Oninit()
    {
        base.Oninit();
        changestate(new idlestate());
        deactiveatk();

    }
    public override void Ondespawn()
    {
        base.Ondespawn();
        Destroy(gameObject);

    }
    public override void Ondeath()
    {
        changestate(null);
        Settarget(null);
        Destroy(healthbar.gameObject);
        base.Ondeath();
    }
    public void Moving()
    {
        Changeanim("run");
        rgbd.velocity = transform.right * movespeed;
    }
    public void Stop()
    {
        if (isdead)
        {   return; }
        Changeanim("idle");
        rgbd.velocity = Vector2.zero;
    }
    public void attack()
    {
        Changeanim("attack");
        activeatk();
        Invoke(nameof(deactiveatk), 0.5f);

    }
    public bool istargetinrange()
    {
        if (target != null)
        {
            return Vector2.Distance(target.transform.position, transform.position) < atkcheck;
        }
        else
            return false;

    }
    public void changestate(IState newstate)
    {
        if(currentstate != null)
        {

            currentstate.Onexit(this);
        }
        currentstate = newstate;
        if (currentstate != null)
        {

            currentstate.Enterenemy(this);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "ewall")
        {

            Changedirection(!right);
        }

    }


    public void Changedirection(bool isright)
    {
        right = isright;
        transform.rotation = isright ? Quaternion.Euler(Vector3.zero) : Quaternion.Euler(Vector3.up * 180);
    }
    internal void Settarget(Character character)
    {
        this.target = character;
        if(istargetinrange())
        {

            changestate(new atkstate());
        }
        else 
        if(Target != null)
        {

            changestate(new patrolstate());
        }
        else
        {
            changestate(new idlestate());
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

}
