using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArthurAttackBehavior : StateMachineBehaviour
{
    Vector3 currentPosition;
    Quaternion currentRotation;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Animation�J�n���̈ʒu�����擾
        currentPosition = animator.transform.position;
        //Animation�J�n���̌���������
        currentRotation = animator.transform.rotation;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //�擾�����ʒu����ǂݍ���
        animator.transform.position = currentPosition;
        //�擾�����������擾
        animator.transform.rotation = currentRotation;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //�擾�����ʒu����ǂݍ���
        animator.transform.position = currentPosition;
        //�擾�����������擾
        animator.transform.rotation = currentRotation;
    }

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
