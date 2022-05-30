using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatMovement : MonoBehaviour
{
  [SerializeField] private float speed;
  private GameController gameController;

  void Start()
  {
    gameController = FindObjectOfType<GameController>();
  }

  void Update()
  {
    DragTouch();
  }

  private void DragTouch()
  {
    // Debug.Log("TouchCount: " + Input.touchCount);
    if (
      Input.touchCount > 0 &&
      Input.GetTouch(0).phase == TouchPhase.Moved &&
      gameController.gameStarted
    )
    {
      Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
      // transform.Translate(touchDeltaPosition.x * speed * Time.deltaTime, 0f, 0f);
      transform.Translate(touchDeltaPosition.x * speed * Time.deltaTime, 0f, 0f);
      // Debug.Log(
      //   "HatMovementDrag" +
      //   "\nTouchX:     " + touchDeltaPosition.x +
      //   "\nTransformX: " + transform.position.x +
      //   "\nTranslateX: " + touchDeltaPosition.x * speed * Time.deltaTime
      // );
    }
  }
}
