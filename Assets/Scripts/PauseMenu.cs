using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
  public static bool GameIsPaused = false;

  public GameObject pauseMenuUI;
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      if (GameIsPaused)
      {
        Resume();
      }
      else
      {
        Pause();
      }
    }
  }
  public void Pause()
  {
    pauseMenuUI.SetActive(true);
    Time.timeScale = 0f;
    GameIsPaused = true;
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
    FindObjectOfType<AudioManager>().Play("PauseLoop");
    FindObjectOfType<AudioManager>().Stop("Bgm");
  }
  public void Resume()
  {
    pauseMenuUI.SetActive(false);
    Time.timeScale = 1f;
    GameIsPaused = false;
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
    FindObjectOfType<AudioManager>().Stop("PauseLoop");
    FindObjectOfType<AudioManager>().Play("Bgm");
  }

  public void Menu()
  {
    Time.timeScale = 1f;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
  }
  public void QuitGame()
  {
    print("Quit");
    Application.Quit();
  }
}
