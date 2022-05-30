using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
  [SerializeField] private float startTime;
  [SerializeField] private Transform player;
  private Vector2 playerPosition;
  private int highscore;
  private float currentTime;
  private SpawnController spawnController;
  [HideInInspector] public int score;
  [HideInInspector] public bool gameStarted;
  private UIController uiController;

  private void Awake()
  {
    DeleteHighscore();
  }

  void Start()
  {
    gameStarted = false;
    uiController = FindObjectOfType<UIController>();
    spawnController = FindObjectOfType<SpawnController>();
    highscore = GetHighscore();
    playerPosition = player.position;
  }

  public void DestroyAllBalls()
  {
    foreach (Transform ball in spawnController.allBallsParent)
    {
      Destroy(ball.gameObject);
    }
  }

  public void SaveScore()
  {
    if (score > highscore)
    {
      highscore = score;
      PlayerPrefs.SetInt("highscore", highscore);
    }
    else
    {
      return;
    }
  }

  public int GetHighscore()
  {
    int highscore = PlayerPrefs.GetInt("highscore");
    return highscore;
  }

  public void DeleteHighscore()
  {
    PlayerPrefs.DeleteKey("highscore");
  }

  public void InvokeCountdownTime()
  {
    // ("Method", timeout, interval)
    InvokeRepeating("CountdownTime", 0f, 1f);
  }

  public void StartGame()
  {
    score = 0;
    currentTime = startTime;
    player.position = playerPosition;
    uiController.txtTime.text = currentTime.ToString();
    uiController.txtScore.text = score.ToString();
    Time.timeScale = 1f;
    gameStarted = true;
    InvokeCountdownTime();
  }

  public void BackMainMenu()
  {
    gameStarted = false;
    CancelInvoke("CountdownTime");
    player.position = playerPosition;
    currentTime = 0f;
    score = 0;
  }

  public void CountdownTime()
  {
    uiController.txtTime.text = currentTime.ToString();

    if (currentTime > 0f && gameStarted)
    {
      currentTime -= 1f;
      // currentTime -= Time.deltaTime;
      // float currentTimeToInt = Mathf.RoundToInt(currentTime);
      // Debug.Log(currentTimeToInt);
    }
    else
    {
      Time.timeScale = 0f;
      uiController.panelInGame.gameObject.SetActive(false);
      uiController.panelGameOver.gameObject.SetActive(true);
      gameStarted = false;
      currentTime = 0f;
      CancelInvoke("CountdownTime");
      SaveScore();
    }
  }
}
