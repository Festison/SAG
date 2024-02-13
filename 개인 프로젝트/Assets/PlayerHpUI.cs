using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class SliderBarUITest
{
    public TextMeshProUGUI hpText;
    public Image image;
}
public class PlayerHpUI : MonoBehaviour
{

    public TextMeshProUGUI hpText;
    public Image image;

    void Start()
    {
        PlayerController.hpUi = this;        
    }

}
