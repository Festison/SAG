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
    }
}
