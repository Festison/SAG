using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject teleportPosition = null;
    public GameObject nextMap;
    public GameObject currentMap;

    private Vector2 position;
    public Collider2D targetBound;
    public CameraManager theCamera;

    private void Start()
    {
        position = teleportPosition.transform.position;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Berserker>()!=null&& Input.GetKeyDown(KeyCode.UpArrow))
        {
            collision.transform.position = position;
            theCamera.SetBound(targetBound);
            currentMap.SetActive(false);
        }
        else if (collision.GetComponent<Berserker>())
        {
            nextMap.SetActive(true);
        }
    }
}

