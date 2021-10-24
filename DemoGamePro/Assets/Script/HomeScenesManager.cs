using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HomeScenesManager : MonoBehaviour
{
    public void GoToL1()
    {
        SceneManager.LoadScene("level1");
    }
    public void GoToHome()
    {
        SceneManager.LoadScene("Home");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}