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
    // Start is called before the first frame update
    void Start()
    {
        PlayerController.hpUi = this;        
    }

}
