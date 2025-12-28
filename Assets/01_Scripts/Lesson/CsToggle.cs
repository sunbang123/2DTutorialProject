using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CsToggle : MonoBehaviour
{
    GameObject obj;
    Text txt;
    Toggle tg;

    private void Start()
    {
        obj = GameObject.Find("txtCenter");
        txt = obj.GetComponent<Text>();
        tg = GameObject.Find("Toggle").GetComponent<Toggle>();

        tg.onValueChanged.AddListener(ChangeText);
    }

    private void ChangeText(bool _bool)
    {
        // tgChangeText.isOn
        if (_bool)
        {
            txt.text = "Do you like yellow?";
            txt.color = Color.yellow;
        }
        else
        {
            txt.text = "Do you like green?";
            txt.color = Color.green;
        }
    }
}
