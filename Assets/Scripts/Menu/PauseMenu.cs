using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    [SerializeField]
    GameObject _pauseMenu;
	public void ShowPauseMenu()
    {
        Time.timeScale = 0;
        _pauseMenu.SetActive(true);
    }

    public void HidePauseMenu()
    {
        Time.timeScale = 1;
        _pauseMenu.SetActive(false);
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause) ShowPauseMenu();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            ShowPauseMenu();
        }
    }
}
