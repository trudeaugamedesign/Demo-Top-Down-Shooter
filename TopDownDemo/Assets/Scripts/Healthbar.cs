using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {
  
  private Slider slider;
  public Color low, high; 

  void Start() {
    slider = GetComponent<Slider>();
  }
  
  public void SetHealth(float hp, float maxHp) {
    slider.maxValue = maxHp;
    slider.value = hp;

    slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
  }

}
