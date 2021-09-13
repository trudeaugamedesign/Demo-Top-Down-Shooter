using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {
  
  private Slider slider;
  public Color low, high;
  public Vector3 offset;

  void Start() {
    slider = GetComponent<Slider>();
  }
  
  public void SetHealth(float hp, float maxHp) {
    slider.maxValue = maxHp;
    slider.value = hp;

    slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
  }

  void Update() {
    if (transform.parent.parent != null) 
      slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.parent.position + offset);
  }

}
