using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject teleportPosition = null;
    Vector2 position;

    public Collider2D targetBound;
    public CameraManager theCamera;

    private void Start()
    {
        theCamera = FindObjectOfType<CameraManager>();
        position = teleportPosition.transform.position;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Berserker>()!=null&& Input.GetKeyDown(KeyCode.W))
        {
            collision.transform.position = position + new Vector2(2, 2);
            theCamera.SetBound(targetBound);
        }
    }
}

