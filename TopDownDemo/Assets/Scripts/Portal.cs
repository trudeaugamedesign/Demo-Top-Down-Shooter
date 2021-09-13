using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collidable {
    
  public string targetScene;
  public Vector3 targetPos;

  protected override void OnCollide(Collider2D col) {
    if (col.name == "Player") {
      // save state
      GameManager.instance.SaveState();
      
      // change scene and move player
      Player.instance.transform.position = targetPos;
      UnityEngine.SceneManagement.SceneManager.LoadScene(targetScene);
    }
  }

}
