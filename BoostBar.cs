using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxBoost(float fuel)
    {
        slider.maxValue = fuel;
        slider.value = fuel;
    }

    public void SetBoost(float fuel)
    {
        slider.value = fuel;
    }
}
