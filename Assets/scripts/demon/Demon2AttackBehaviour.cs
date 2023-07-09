using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon2AttackBehaviour : StateMachineBehaviour
{
   DemonBehaviour demonBehaviour;
   bool started, stopped;

   // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
   override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      demonBehaviour = animator.GetComponentInParent<DemonBehaviour>();
      started = stopped = false;
   }

   // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      if(!started && stateInfo.normalizedTime >= 0.3f)
      {
         demonBehaviour.SetEnabledHitterCollider(true);

         started = true;
      }

      if(!stopped && stateInfo.normalizedTime >= 0.65f)
      {
         demonBehaviour.SetEnabledHitterCollider(false);

         stopped = true;
      }
   }

   // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
   //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   //{
   //    
   //}

   // OnStateMove is called right after Animator.OnAnimatorMove()
   //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   //{
   //    // Implement code that processes and affects root motion
   //}

   // OnStateIK is called right after Animator.OnAnimatorIK()
   //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   //{
   //    // Implement code that sets up animation IK (inverse kinematics)
   //}
}
