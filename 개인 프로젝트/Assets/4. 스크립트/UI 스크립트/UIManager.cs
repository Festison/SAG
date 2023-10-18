using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour 
{
    public static UIManager UI;

    [Header("키보드및 마우스 이미지")]
    public Image[] UIImage;
    public Sprite[] IdleUIImage;             // 클릭 안할시 이미지
    public Sprite[] PressedUIImage;          // 클릭시 이미지

    [Header("레벨업 시 바뀔 캐릭터 프리팹")]
    public GameObject[] BerserkerPrefab;    // 레벨업시 바뀔 캐릭터 프리팹

    [Header("현재 필드에 존재하는 몬스터")]
    public List<GameObject> MonsterList = new List<GameObject>();       // 몬스터 종류

    [Header("현재 플레이어 프리팹")]
    public GameObject PlayerObj;
    public GameObject CurrentPlayerObj;

    void Awake()
    {
        Screen.fullScreen = false;
        UI = this;
    }

    void Update () 
    {
        KeyUPDownchange();
    }

    // 키를 누르고 뗄때 이미지 변화
    public void KeyUPDownchange()
    {
        #region 키보드를 뗏을 때
        if (Input.GetKeyUp(KeyCode.A))
        {        
            UIManager.UI.UIImage[2].sprite = IdleUIImage[2];
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            UIManager.UI.UIImage[3].sprite = IdleUIImage[3];
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            UIManager.UI.UIImage[0].sprite = IdleUIImage[0];
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            UIManager.UI.UIImage[1].sprite = IdleUIImage[1];
        }
        #endregion

        #region 키보드를 누르고 있을 때
        if (Input.GetKeyDown(KeyCode.A))
        {
            UIManager.UI.UIImage[2].sprite = PressedUIImage[2];
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            UIManager.UI.UIImage[3].sprite = PressedUIImage[3];
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            UIManager.UI.UIImage[0].sprite = PressedUIImage[0];
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            UIManager.UI.UIImage[1].sprite = PressedUIImage[1];
        }
        #endregion

        #region 마우스를 뗏을 때
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            UIManager.UI.UIImage[4].sprite = IdleUIImage[4];
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            UIManager.UI.UIImage[5].sprite = IdleUIImage[5];
        }
        #endregion

        #region 마우스를 누르고 있을 때
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            UIManager.UI.UIImage[4].sprite = PressedUIImage[4];
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            UIManager.UI.UIImage[5].sprite = PressedUIImage[5];
        }
        #endregion

        #region 특정 키를 누르고 뗄때
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UIManager.UI.UIImage[6].sprite = PressedUIImage[6];
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            UIManager.UI.UIImage[6].sprite = IdleUIImage[6];
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UIManager.UI.UIImage[7].sprite = PressedUIImage[7];
        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            UIManager.UI.UIImage[7].sprite = IdleUIImage[7];
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UIManager.UI.UIImage[8].sprite = PressedUIImage[8];
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            UIManager.UI.UIImage[8].sprite = IdleUIImage[8];
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UIManager.UI.UIImage[9].sprite = PressedUIImage[9];
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            UIManager.UI.UIImage[9].sprite = IdleUIImage[9];
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            UIManager.UI.UIImage[10].sprite = PressedUIImage[10];
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            UIManager.UI.UIImage[10].sprite = IdleUIImage[10];
        }
        #endregion
    }
}
