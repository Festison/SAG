using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScene : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Berserker>() != null)
        {
            SceneManager.LoadScene("Ending");
        }
    }
}
