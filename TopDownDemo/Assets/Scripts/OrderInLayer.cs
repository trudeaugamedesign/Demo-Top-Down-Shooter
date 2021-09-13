using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderInLayer : MonoBehaviour {
  
  public static int offset = -1000;
  public static float step = .1f;
  private SpriteRenderer spriteRenderer;

  void Start() {
    spriteRenderer = GetComponent<SpriteRenderer>();
  }

  void Update() {
    spriteRenderer.sortingOrder = (int) (-transform.position.y / step) + offset;
  }
}
