using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : StateMachineBehaviour {
  
  private Player player; 
  private Enemy enemy;
  private float speedBoost = 1.5f;
  
  // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
  override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    player = Player.instance;
    enemy = animator.GetComponent<Enemy>();
    
  }

  // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
  override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    enemy.Movement((player.transform.position - enemy.transform.position).normalized * speedBoost);

    if (enemy.CollidesWithTag("Player")) {
      player.TakeDamage(enemy.transform.position, enemy.attackDmg, 3f);
      animator.SetBool("isAttack", false);
    }
    
  }

  // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
  override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    
  } 
}
