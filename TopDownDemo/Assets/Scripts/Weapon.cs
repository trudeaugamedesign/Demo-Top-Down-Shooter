using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable {

  public CameraShake cameraShake;
    
  // damage
  public int attackDmg = 1;
  public float knockbackForce = 2f;
  private Animator anim;
  private bool isSwing;

  protected override void Start() {
    base.Start(); 

    anim = GetComponent<Animator>();
  }

  protected override void Update() {
    base.Update();
    
    isSwing = anim.GetCurrentAnimatorStateInfo(0).IsName("swing");
    if (Input.GetKeyDown(KeyCode.Space)) {
      if (!isSwing) {
        // then swing
        anim.SetTrigger("swing");
      }
    }
  }
    
  protected override void OnCollide(Collider2D col) {
    if (isSwing) {
      if (col.tag == "Fighter") {
        if (col.name == "Player") return;
        
        col.GetComponent<Enemy>().TakeDamage(transform.position, Player.instance.attackDmg + attackDmg, knockbackForce);
        StartCoroutine(cameraShake.Shake(0.2f, 0.1f));
      }

    }
      
  }

}
