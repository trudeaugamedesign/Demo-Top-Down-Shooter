using UnityEngine;
using UnityEngine.UI;

public class DroppedItem : Collectable {
  
  public GameObject item;

  protected override void OnCollect() {
    base.OnCollect();
    Destroy(gameObject);
  }

}
