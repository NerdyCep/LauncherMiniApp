using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddCoinClicker : MonoBehaviour
{
    
    private int num;
    public TMP_Text textNum;
    public GameObject TargetObj;
    private SB_Mode _bonus;
    
    void Start()
    {
       _bonus = TargetObj.GetComponent<SB_Mode>();
    }
    public void addNum()
    {
        num++;
        textNum.text = num.ToString();
        _bonus._sbSlider.value = num*0.1f;
        
    }

 
}

