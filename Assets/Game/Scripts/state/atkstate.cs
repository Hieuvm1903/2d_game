using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atkstate : IState
{
    float timer;
    public void Enterenemy(Enemy enemy)
    {
        if (enemy.isdead)
        { return; }
        if (enemy.Target != null)
        {
            enemy.Changedirection(enemy.Target.transform.position.x > enemy.transform.position.x);
            enemy.Stop();
            enemy.attack();

        }
        timer = 0; ;
    }

    public void Onexcute(Enemy enemy)
    {
        if (enemy.isdead)
        { return; }
        timer += Time.deltaTime;
        if(timer >= 1.5f)
        {
            enemy.changestate(new patrolstate());
        }
    }

    public void Onexit(Enemy enemy)
    {
        
    }
}
