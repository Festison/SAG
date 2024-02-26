using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeArea : MonoBehaviour
{
    public GameObject axe;
    public BoxCollider2D area;

    private void Start()
    {
        CreateAxe();
        StartCoroutine(CreateAxeCo());
    }

    IEnumerator CreateAxeCo()
    {
        while (true)
        {
            CreateAxe();
            yield return new WaitForSeconds(1);
        }
    }

    public void CreateAxe()
    {
        Vector2 pos = RandomPosition();
        Instantiate(axe, pos, Quaternion.Euler(0, 180, -180));
    }

    public Vector2 basePosition;

    public Vector2 RandomPosition()
    {
        basePosition = transform.position;
        Vector2 size = area.size;

        float posX = basePosition.x + Random.Range(0, size.x);
        float posY = basePosition.y;

        Vector2 spawnPos = new Vector2(posX, posY);

        return spawnPos;
    }
}
