using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
  public Gradient gradient;
  public Slider slider;
  public Image fill;
  public void SetHealth(float health)
  {
    slider.value = health;
    fill.color = gradient.Evaluate(slider.normalizedValue);
  }
  public void SetMaxHealth(float health)
  {
    slider.maxValue = health;
    slider.value = health;
    fill.color = gradient.Evaluate(1f);
  }
}
