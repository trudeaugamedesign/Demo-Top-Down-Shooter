using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// abstract means it can only be used for inheritance
public abstract class Mover : Collidable {
    
  [Header("Move Settings")]
  public Vector2 speed = new Vector2(5f, 4f);
  
  protected Animator anim;
  protected Rigidbody2D rb;
  protected Vector2 knockback; 
  public float knockbackRecoverSpeed = 0.1f;

  protected override void Start() {
    base.Start();
    anim = GetComponent<Animator>();
    rb = GetComponent<Rigidbody2D>();
      
  }

  public virtual void Movement(Vector2 input) {
    // Calculate velocity
    Vector2 vel = Vector2.Scale(input, speed); // vector2.scale performs element-wise multiplcation

    // Swap sprite's direction based on movement
    if (vel.x < 0) {
      transform.localScale = new Vector2(-1,1);
    } else if (vel.x > 0) {
      transform.localScale = new Vector2(1,1);
    }

    // Add knockback, if any
    vel += knockback;
    knockback = Vector2.MoveTowards(knockback, Vector2.zero, knockbackRecoverSpeed);

    // Update rigidbody movement
    rb.velocity = vel;
    
  }

}
