using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

  public static GameManager instance;
  public Player player;
  public FloatingTextManager floatingTextManager;

  private void Awake() {
    if (GameManager.instance != null) {
      Destroy(gameObject);
      return;
    }  

    instance = this;
    DontDestroyOnLoad(gameObject);
  } 

  public void ShowText(string msg, int fontSize, Color color, Vector3 pos, Vector3 motion, float duration) {
      floatingTextManager.Show(msg, fontSize, color, pos, motion, duration);
  }

  public void RestartScene() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    
  } 

}
