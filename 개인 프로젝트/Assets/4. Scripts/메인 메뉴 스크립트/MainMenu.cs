using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Game;
    public void OnClickNewGame()
    {
        Debug.Log(" 게임시작 ");
        SceneManager.LoadScene("SAG");
    }
    public void OnclickCancel()
    {
        Game.SetActive(false);
    }
    public void OnclickGameUI()
    {
        Game.SetActive(true);
    }
    public void OnClickQuit()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Game.SetActive(false);
        }
    }
}