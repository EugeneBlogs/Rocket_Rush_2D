using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {

    public void Replay()
    {
        LoadNewLevel(SceneManager.GetActiveScene().name);   
    }
    public void LoadNewLevel(int num)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(num);
    }
    public void LoadNewLevel(string name)
    {
        LoadNewLevelStatic(name);
    }

    public static void LoadNewLevelStatic(string name)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(name);
    }

    public static void LoadLevel(int index)
    {
        LoadNewLevelStatic(GlobalLevelController.Instance.GetScene(index).SceneName);
        
    }

    public static void LoadNewLevelStatic(int index)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(index);
    }

    public void LoadNextLevel()
    {
        LoadNewLevel(GlobalLevelController.Instance.Next().SceneName);
    }

    public void loadUrl(string url)
    {
        Application.OpenURL(url);
    }
}
