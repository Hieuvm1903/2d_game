using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void Enterenemy(Enemy enemy);


    void Onexcute(Enemy enemy);

    void Onexit(Enemy enemy);
   
}
