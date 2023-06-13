using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolstate : IState
{
    float timer;
    float randtime;
    public void Enterenemy(Enemy enemy)
    {
        timer = 0;
        randtime = Random.Range(3f, 5f);
    }

    public void Onexcute(Enemy enemy)
    {
        if (enemy.isdead)
        { return; }
        timer += Time.deltaTime;
        if (enemy.Target != null)
        {
            enemy.Changedirection(enemy.Target.transform.position.x > enemy.transform.position.x);

            if (enemy.istargetinrange())
            {
                enemy.changestate(new atkstate());
            }
            else
            {
                enemy.Moving();
            }
        }

        else
        {
            if (timer < randtime)
            {
                enemy.Moving();
            }
            else
            {
                enemy.changestate(new idlestate());

            }
        }
       

    }

    public void Onexit(Enemy enemy)
    {

    }
}
