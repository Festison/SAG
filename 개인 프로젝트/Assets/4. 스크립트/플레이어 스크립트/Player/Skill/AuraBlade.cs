using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraBlade : MonoBehaviour
{
    private PlayerController playerController;
    private float movingSpeed = 20f;
    private float destroyTime = 1f;

    private bool UpdateCheck = true;

    public void Fire(Vector3 dir)
    {
        UpdateCheck = true;
        this.transform.right = dir;
        StartCoroutine(destroyObj());
    }

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (UpdateCheck)
        {
            this.transform.Translate(-Vector2.right * movingSpeed * Time.deltaTime);
        }
    }

    IEnumerator destroyObj()
    {
        yield return new WaitForSeconds(destroyTime);
        UpdateCheck = false;
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<IHitable>() != null)
        {
            Debug.Log(other.gameObject.name + "맞음");
            other.GetComponent<Monster>().Hit(playerController.damage * 2);
        }     
    }
}
