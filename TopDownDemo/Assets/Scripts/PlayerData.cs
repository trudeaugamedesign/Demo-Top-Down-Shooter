using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData {

  public int hp;
  public float[] pos;
  public string scene;
  public int coins;

  // weapon stats
  public int attackDmg;

  // inventory - 4 items
  // public string[] items;

  public PlayerData(Player player) {
    
    hp = player.hp;
    
    pos = new float[3];
    pos[0] = player.respawnPos.x;
    pos[1] = player.respawnPos.y;
    pos[2] = player.respawnPos.z;
    
    scene = SceneManager.GetActiveScene().name;
    coins = player.coins;

    attackDmg = player.weapon.attackDmg;

    // items <= player.inventory

  }

}