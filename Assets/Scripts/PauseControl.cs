using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseControl : MonoBehaviour
{

    void Start()
    {
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }

    public void Menu1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        //Time.timeScale = 0;
    }

    public void Menu2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        //Time.timeScale = 0;
    }

    public void Menu3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        //Time.timeScale = 0;
    }

    public void Menu4()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
        //Time.timeScale = 0;
    }

    public void Menu5()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
        //Time.timeScale = 0;
    }

    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitPlay()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
