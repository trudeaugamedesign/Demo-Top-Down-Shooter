using UnityEngine;
using UnityEngine.UI;

public abstract class Fighter : Mover {
  
  [Header("Fight Settings")]
  public int hp = 10;
  public int maxHp = 10;
  public int attackDmg = 1;
  public Healthbar healthBar;
  public ParticleSystem bloodParticles;

  public float immuneTime = 1f;
  protected float lastImmune; 
  protected bool isImmune = false;

  protected override void Update() {
    healthBar.SetHealth(hp, maxHp);
  }

  public virtual void TakeDamage(Vector3 origin, int dmg, float knockbackForce) {
    if (Time.time - lastImmune > immuneTime) {
      lastImmune = Time.time;
      hp -= dmg;
      knockback = (transform.position - origin).normalized * knockbackForce;
      isImmune = false;

      // visuals here
      GameManager.instance.ShowText(dmg.ToString(), 45, Color.red, transform.position, Vector3.up * .5f, 1f);
      bloodParticles.Play();

      hp = Mathf.Max(hp, 0);
      healthBar.SetHealth(hp, maxHp);

      if (hp <= 0) 
        Death();
    } else {
      isImmune = true;
    }
  }

  protected virtual void Death() {
    
  }

}
