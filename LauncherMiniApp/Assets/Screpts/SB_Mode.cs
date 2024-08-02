using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SB_Mode : MonoBehaviour
{
    public Slider _sbSlider;
    

    void Start()
    {
        _sbSlider = GetComponent<Slider>();
        _sbSlider.value = 0;
    }

    public void SetMaxBonus(int maxBonus)
    {
        _sbSlider.maxValue = maxBonus;
    }

    public void SetBonus(int Bonus)
    {
        _sbSlider.value = Bonus;
    }
    
}