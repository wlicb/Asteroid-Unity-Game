using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField]
    Sprite None;

    [SerializeField]
    GameObject[] hpBar = new GameObject[10];

    // Update is called once per frame
    void Update()
    {
        for (int i = 9; i >= HP.hp; i--)
            hpBar[i].GetComponent<SpriteRenderer>().sprite = None;
    }
}
