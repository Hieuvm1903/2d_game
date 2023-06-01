using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private float atkcheck;
    [SerializeField] private float movespeed;
    // Start is called before the first frame update

    public override void Oninit()
    {
        base.Oninit();


    }
    public override void Ondespawn()
    {
        base.Ondespawn();
    }
    protected override void Ondeath()
    {
        base.Ondeath();
    }
    public void Moving()
    {

    }
    public void Stopp()
    {
        
    }
    public void attack()
    {

    }
    public bool istargetinrange()
    {


        return true;

    }
}
