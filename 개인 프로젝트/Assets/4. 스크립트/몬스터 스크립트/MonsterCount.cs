using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCount : MonoBehaviour
{
    public GameObject chest;
    public bool isMonsterCount = false;
    void Update()
    {
        if (gameObject.transform.childCount==0 && !isMonsterCount)
        {
            chest.SetActive(true);
            isMonsterCount = true;
        }
    }
}
