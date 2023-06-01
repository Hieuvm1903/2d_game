using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    private float hp;
    protected string curani;
    [SerializeField] protected Animator animator;

    public bool isdead => hp <= 0;
    private void Start()
    {
        Oninit();
    }
    public virtual void Oninit()
    {

        hp = 100;

    }
    protected void Changeanim(string anime)
    {
        if (curani != anime)
        {
            animator.ResetTrigger(anime);
            curani = anime;
            animator.SetTrigger(curani);

        }


    }
    public virtual void Ondespawn()
    {


    }
    public void Onhit(float damage)
    { 
        if(!isdead)
        { 
            hp -= damage;
        if (isdead)
            {

                Ondeath();
            }
        }

    }
    protected virtual void Ondeath()
    {

    }
}
