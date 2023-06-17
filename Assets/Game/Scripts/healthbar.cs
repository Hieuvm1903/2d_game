using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Image image;
    [SerializeField] Vector3 offset; 
    float hp;
    float maxhp;
    private Transform target;
    // Update is called once per frame
    void Update()
    {
        image.fillAmount = Mathf.Lerp(image.fillAmount, hp / maxhp, Time.deltaTime * 5f);
        transform.position = target.position + offset;
    }
    public void Oninit(float maxhp, Transform target)
    {
        this.target = target;
        this.maxhp = maxhp;
        hp = maxhp;
        image.fillAmount = 1;
    }
    public void sethp(float hp)
    {
        this.hp = hp;
        //image.fillAmount = hp / maxhp;
    }
}
