using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
  private GameController gameController;
  public GameObject panelMainMenu, panelInGame, panelPause, panelGameOver;
  public TMP_Text txtHighscore, txtTime, txtScore;

  void Start()
  {
    gameController = FindObjectOfType<GameController>();
    txtHighscore.text = "Highscore: " + gameController.GetHighscore().ToString();
  }

  public void ButtonExit()
  {
    // Forma genérica
    // if (Input.GetKeyDown(KeyCode.Escape))
    // {
    //   Application.Quit();
    // }

    // Forma Android
    AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer")
      .GetStatic<AndroidJavaObject>("currentActivity");
    activity.Call<bool>("moveTaskToBack", true);
  }

  public void ButtonStartGame()
  {
    panelMainMenu.gameObject.SetActive(false);
    panelInGame.gameObject.SetActive(true);
    gameController.StartGame();
  }

  public void ButtonPause()
  {
    Time.timeScale = 0f;
    panelInGame.gameObject.SetActive(false);
    panelPause.gameObject.SetActive(true);
  }

  public void ButtonResume()
  {
    panelPause.gameObject.SetActive(false);
    panelInGame.gameObject.SetActive(true);
    Time.timeScale = 1f;
  }

  public void ButtonRestart()
  {
    panelPause.gameObject.SetActive(false);
    panelGameOver.gameObject.SetActive(false);
    panelInGame.gameObject.SetActive(true);
    gameController.DestroyAllBalls();
    gameController.StartGame();
  }

  public void ButtonBackMainMenu()
  {
    panelPause.gameObject.SetActive(false);
    panelGameOver.gameObject.SetActive(false);
    txtHighscore.text = "Highscore: " + gameController.GetHighscore().ToString();
    panelMainMenu.gameObject.SetActive(true);
    gameController.DestroyAllBalls();
    gameController.BackMainMenu();
    Time.timeScale = 1f;
  }
}
