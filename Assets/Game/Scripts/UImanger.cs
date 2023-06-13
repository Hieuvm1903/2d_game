using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanger : MonoBehaviour
{
    public static UImanger instance;
    [SerializeField] Text cointxt; 
    //public static uimanger instance
    //{
    //    get
    //    {
    //        if(instance != null)
    //        {
    //            instance = findobjectoftype<uimanger>();
    //        }
    //        return instance;


    //    }


    //}
    private void Awake()
    {
        instance = this;
    }
    public void setcoin(int coin)
    {
        cointxt.text = "Coin:" + coin.ToString();
    }
}
