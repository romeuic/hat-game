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
    if (
      Input.touchCount > 0 &&
      Input.GetTouch(0).phase == TouchPhase.Moved &&
      gameController.gameStarted
    )
    {
      Touch touch = Input.GetTouch(0);
      // Vector2 touchDeltaPosition = touch.deltaPosition;
      // transform.Translate(touchDeltaPosition.x * speed * Time.deltaTime, 0f, 0f);

      // Update hat position
      Vector3 position = Camera.main.ScreenToWorldPoint(touch.position);
      position.y = transform.position.y;
      position.z = transform.position.z;
      transform.position = position;
    }
  }
}
