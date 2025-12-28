using System;
using UnityEngine;
using UnityEngine.UI;

public class CsSlider : MonoBehaviour
{
    Text txt;
    Slider mainSlider;
    Slider subSlider;
    float fontSiz;

    private void Start()
    {
        txt = GameObject.Find("txtCenter").GetComponent<Text>();
        mainSlider = GameObject.Find("mainSlider").GetComponent<Slider>();
        subSlider = GameObject.Find("subSlider").GetComponent<Slider>();

        fontSiz = txt.fontSize;

        subSlider.onValueChanged.AddListener(ChangeSliderValue);
    }

    private void ChangeSliderValue(float value)
    {
        float val = subSlider.value;
        mainSlider.value = val;

        txt.fontSize = (int)value * 100;
    }
}
