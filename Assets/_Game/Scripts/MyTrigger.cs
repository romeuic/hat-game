using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTrigger : MonoBehaviour
{
  private GameController gameController;
  private UIController uiController;

  void Start()
  {
    gameController = FindObjectOfType<GameController>();
    uiController = FindObjectOfType<UIController>();
  }
  private void OnTriggerEnter2D(Collider2D target)
  {
    if (target.gameObject.CompareTag("Point"))
    {
      gameController.score++;
      uiController.txtScore.text = gameController.score.ToString();
      Destroy(this.gameObject);
    }
    else if (target.gameObject.CompareTag("Destroyer"))
    {
      Destroy(this.gameObject);
    }
  }
}
