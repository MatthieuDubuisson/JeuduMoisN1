using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("GAME");
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void PlayLevel3()
    {
        SceneManager.LoadScene("Level3");
    }



public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
