using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCount : MonoBehaviour
{
    public GameObject chest;
    public GameObject Portal;
    public GameObject Map;
    public bool isMonsterCount = false;
    void Update()
    {
        if (gameObject.transform.childCount==0 && !isMonsterCount)
        {
            chest.SetActive(true);
            Portal.SetActive(true);
            Map.SetActive(true);
            isMonsterCount = true;
        }
    }
}
