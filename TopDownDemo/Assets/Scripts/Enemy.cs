using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Fighter {

  [Header("Enemy Settings")]
  
  // logic
  public float detectLength = 1f;
  public float stopChaseLength = 3f;
  public float stopFromPlayerLength = 1f;
  public float minAttackWait = 3f, maxAttackWait = 5f;
  public int coinsGiven = 1;
  private Vector3 startPos;
  private Transform playerTransform;
  [HideInInspector] public bool touchingPlayer = false;

  protected override void Start() {
    base.Start();
    startPos = transform.position;
    playerTransform = Player.instance.transform;
  }

  protected override void Death() {
    base.Death();
    Debug.Log("player + " + coinsGiven + " coins");
    Player.instance.coins += coinsGiven;
    // play particles or smth ?
    Destroy(gameObject);
  }

}
