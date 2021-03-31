using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

  public static float scoreValue;

  Text scoreText;

  void Start()
  {
    scoreValue = 0;
    scoreText = GetComponent<Text>();
  }
  void FixedUpdate()
  {
    scoreText.text = "Score: " + scoreValue;
  }
}
