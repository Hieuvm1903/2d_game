using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class combattetxt : MonoBehaviour
{
    [SerializeField] Text txt;
    public void Oninit(float dmg)
    {
        txt.text = dmg.ToString();
        Invoke(nameof(Ondespawn), 1f);
    }
    public void Ondespawn()
    {

        Destroy(gameObject);
    }
}
