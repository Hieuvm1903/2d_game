using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idlestate : IState
{
    float timer;
    float randtime;
    public void Enterenemy(Enemy enemy)
    {
        if (enemy.isdead)
        { return; }
        enemy.Stop();
        timer = 0;
        randtime = Random.Range(2.5f, 4f);
    }

    public void Onexcute(Enemy enemy)
    {
        if (enemy.isdead)
        { return; }
        if (timer > randtime)
        {
            enemy.changestate(new patrolstate());
            
        }
        timer += Time.deltaTime;
    }

    public void Onexit(Enemy enemy)
    {

    }
}

