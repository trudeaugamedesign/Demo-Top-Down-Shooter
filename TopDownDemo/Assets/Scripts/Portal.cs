using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collidable {
    
  public string targetScene;
  public Vector3 targetPos;

  protected override void OnCollide(Collider2D col) {
    if (col.name == "Player") {
      
      // change scene and move player
      Player.instance.transform.position = targetPos;
      Player.instance.respawnPos = targetPos;
      UnityEngine.SceneManagement.SceneManager.LoadScene(targetScene);
    }
  }

}
