using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CsButton : MonoBehaviour
{
    GameObject obj;
    Text txt;
    Button btn;

    Image image;
    bool btnFlag = false;

    private void Start()
    {
        obj = GameObject.Find("txtCenter");
        txt = obj.GetComponent<Text>();
        btn = GameObject.Find("Button").GetComponent<Button>();
        image = this.GetComponent<Image>();
        
        btn.onClick.AddListener(ChangeText);
    }

    private void ChangeText()
    {
        btnFlag = !btnFlag;

        if (btnFlag)
        {
            txt.text = "GoodBye Player";
            image.sprite = Resources.Load<Sprite>("player2U_2");
        }
        else
        {
            txt.text = "Hello Player";
            image.sprite = Resources.Load<Sprite>("player2D_0");
        }
    }
}
