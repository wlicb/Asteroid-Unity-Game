using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    [SerializeField]
    Text HPText;



    const string HPPrefix = "HP: ";
    public static int hp = 10;
    const string lastHP = "0";

    void Start()
    {
        if (hp > 0)
            HPText.text = HPPrefix + hp.ToString();
        else
            HPText.text = HPPrefix + lastHP;
    }


    void Update()
    {
        if (hp > 0)
            HPText.text = HPPrefix + hp.ToString();
        else
            HPText.text = HPPrefix + lastHP;
        if (Restart.isGameOver)
            hp = 10;

        
    }
}
