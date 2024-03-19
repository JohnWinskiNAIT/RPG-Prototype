using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{   public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("SingletonObject");
    }

    public void PlayGame2()
    {
        SceneManager.LoadScene("Game2");
    }

    public void QuitGame2()
    {
        SceneManager.LoadScene("SingletonClass");
    }
}
