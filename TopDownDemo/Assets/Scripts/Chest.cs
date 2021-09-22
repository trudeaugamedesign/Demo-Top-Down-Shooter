using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable {

  public Sprite emptyChest;
  public int coinAmount = 10;
  public DroppedItem drop;

  protected override void OnCollect() { 
    if (!collected) {
      base.OnCollect();
      GetComponent<SpriteRenderer>().sprite = emptyChest;
      Player.instance.coins += coinAmount;
      GameManager.instance.ShowText("+" + coinAmount + " coins!", 60, Color.yellow, transform.position, 
                                  Vector3.up * 1, 2);
    }
  }

}
