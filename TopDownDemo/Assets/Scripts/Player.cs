using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : Fighter {
    
  [HideInInspector] public static Player instance;

  [Header("Player Settings")]
  public Transform camTarget;
  public Animator damageScreen;
  private Vector2 inputVec;
  [HideInInspector] public int coins = 0;
  public Text coinsText;
  public Vector3 respawnPos = Vector2.zero;

  private void Awake() {
    // make sure no duplicate players
    if (Player.instance != null) {
      Destroy(gameObject);
      return;
    }
    
    Player.instance = this;
    DontDestroyOnLoad(gameObject);
  }

  protected override void Start() {
    base.Start();
    InvokeRepeating("SavePlayer", 1f, 10f);
  }

  protected override void Update() {
    base.Update();

    // Update() for more reliable input
    inputVec = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    
    // update UI
    coinsText.text = coins.ToString();
  }

  private void FixedUpdate() {
    // FixedUpdate() for movement because using physics
    Movement(inputVec);
    UpdateAnim();
    HandleCamTarget(inputVec);
  }

  private void UpdateAnim() {
    // Handle animations
    if (rb.velocity.magnitude == 0) {
      anim.SetBool("isRun", false);
    } else {
      anim.SetBool("isRun", true); 
    }
  }

  private void HandleCamTarget(Vector2 vel) {
    Vector2 vec = camTarget.localPosition;
    if (vel.x == 0) {
      vec.x = 0.5f;
    } else {
      vec.x = 2.5f;
    }

    if (vel.y == 0) {
      vec.y = 0f;
    } else {
      vec.y = 2f * Mathf.Sign(vel.y);
    }

    camTarget.localPosition = vec;
  }

  public override void TakeDamage(Vector3 origin, int dmg, float knockbackForce) {
    base.TakeDamage(origin, dmg, knockbackForce);
    if (!isImmune) {
      damageScreen.Play("player_damage");
    }
  }
  
  protected override void Death() {
    base.Death();
    // death anim ?
    Debug.Log("player death");
    coins = 0;
    hp = maxHp;
    transform.position = respawnPos;
    GameManager.instance.RestartScene();
  }

  public void SavePlayer() {
    SaveSystem.SavePlayer(this);
  }

  public void LoadPlayer() {
    PlayerData data = SaveSystem.LoadPlayer();

    hp = data.hp;
    transform.position = new Vector3(data.pos[0], data.pos[1], data.pos[2]);
    coins = data.coins;    
    weapon.attackDmg = hp;

    SceneManager.LoadScene(data.scene);

  }

}
