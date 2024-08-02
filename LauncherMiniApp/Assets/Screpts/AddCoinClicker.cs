using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class AddCoinClicker : MonoBehaviour
{
    public UnityEvent onNumChanged;

    private int num;
    public TMP_Text textNum;
    public GameObject TargetBonusLine;
    public GameObject TargetSound;
    private SB_Mode _bonus;
    private Sounds _soundClick;
    
    void Start()
    {  
        _soundClick = TargetSound.GetComponent<Sounds>();
        _bonus = TargetBonusLine.GetComponent<SB_Mode>();
    }

    public void addNum()
    {
        num++;
        textNum.text = num.ToString();
        _bonus._sbSlider.value = num*0.1f;

         // Вызываем событие, когда число изменено
        if (onNumChanged != null)
        {
            onNumChanged.Invoke();
            _soundClick.PlaySound();
        }  
    }
}

