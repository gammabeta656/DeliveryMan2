using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void SettingsButton()
    {
        SceneManager.LoadScene("Settings");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
