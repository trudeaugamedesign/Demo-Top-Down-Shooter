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

    PlayerPrefs.DeleteAll();

    instance = this;
    SceneManager.sceneLoaded += LoadState;
    DontDestroyOnLoad(gameObject);
  }

  private void Update() {
    if (Input.GetKeyDown("p")) {
      SaveState();
    }
  }

  public void ShowText(string msg, int fontSize, Color color, Vector3 pos, Vector3 motion, float duration) {
      floatingTextManager.Show(msg, fontSize, color, pos, motion, duration);
  }

  // Save state, health
  public void SaveState() { 
    string s="";
 
    s += player.coins.ToString();
    s += "|" + player.hp.ToString();

    PlayerPrefs.SetString("SaveState", s);

    Debug.Log("Saved state!");
  }
  
  public void LoadState(Scene scene, LoadSceneMode mode) {
    if (!PlayerPrefs.HasKey("SaveState")) {
      SaveState();
    }

    // Obtain values from saved string
    string[] data = PlayerPrefs.GetString("SaveState").Split('|');
    
    player.coins = int.Parse(data[0]);
    player.hp = int.Parse(data[1]);

    Debug.Log("Loaded state!");
  }

  public void RestartScene() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    
  } 

}
