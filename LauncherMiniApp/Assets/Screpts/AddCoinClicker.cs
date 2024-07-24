using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddCoinClicker : MonoBehaviour
{
    private int num;
    public TMP_Text textNum;

    public void addNum()
    {
        num++;
        textNum.text = num.ToString();
    }
}

