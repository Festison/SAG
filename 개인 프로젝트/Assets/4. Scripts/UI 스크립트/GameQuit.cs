using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameQuit : MonoBehaviour
{
    public void OnBtnClick()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
