using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    private float hp;
    protected string curani;
    [SerializeField] protected Animator animator;
    [SerializeField] protected healthbar healthbar;
    [SerializeField] protected combattetxt cbtxt;


    public bool isdead => hp <= 0;
    private void Start()
    {
        Oninit();
    }
    public virtual void Oninit()
    {

        hp = 100;
        healthbar.Oninit(100,transform);

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
                hp = 0;
                Ondeath();
            }
            healthbar.sethp(hp);
            Instantiate(cbtxt, transform.position + Vector3.up, Quaternion.identity).Oninit(damage);
        }


    }
    public virtual void Ondeath()
    {
        hp = 0;
        Changeanim("die");
        Invoke(nameof(Ondespawn), 0.5f);
    }
}
