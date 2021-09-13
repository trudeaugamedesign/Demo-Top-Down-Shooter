using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Chase : StateMachineBehaviour {
  private Player player; 
  private Enemy enemy; 
  private float nextAttack;

  // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
  override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { 
    player = Player.instance;
    enemy = animator.GetComponent<Enemy>();
    nextAttack = Time.time + Random.Range(enemy.minAttackWait, enemy.maxAttackWait);
    
  }

  // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
  override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    float dist = Vector2.Distance(enemy.transform.position, player.transform.position);
    if (dist > enemy.stopFromPlayerLength) {
      // move towards player, but not directly on top
      enemy.Movement((player.transform.position - enemy.transform.position).normalized);
    } else if (dist <= enemy.stopFromPlayerLength/2) {
      // if too close to player, move back a bit
      enemy.Movement(-(player.transform.position - enemy.transform.position).normalized);
    } else {
      enemy.Movement(Vector2.zero);
    }

    if (Time.time >= nextAttack) {
      // attack code or trigger attack state in animator
      nextAttack = Time.time + Random.Range(enemy.minAttackWait, enemy.maxAttackWait);
      animator.SetBool("isAttack", true);
    }
    
    if (Vector2.Distance(enemy.transform.position, player.transform.position) > enemy.stopChaseLength) {
      animator.SetBool("isChase", false);
    }
    
  }

  // OnStateExit is called before OnStateExit is called on any state inside this state machine
  override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
      
  }
  
}
