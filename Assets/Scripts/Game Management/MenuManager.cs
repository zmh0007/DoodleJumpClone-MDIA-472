using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Main Level");
    }

    public void OnQuitButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
