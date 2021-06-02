using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    private CharacterController enemyCon;
    private Animator animator;
    //�ړI�n�̏ꏊ(�����TOWER)
    private GameObject TowerPosition;
    private Vector3 destination;
    //���s�X�s�[�h
    [SerializeField] private float speed = 1.0f;
    //���x
    private Vector3 velocity;
    //�ړI�n�̕���
    private Vector3 direction;
    //�ړI�n�̓����������ǂ����̔���
    private bool arrived;

    
   

    private void Start()
    {
        enemyCon = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        TowerPosition = GameObject.FindWithTag("Tower");
        destination = TowerPosition.transform.position;
        velocity = Vector3.zero;

        arrived = false;

        
    }

    private void Update()
    {
        if (!arrived)
        {
            if (enemyCon.isGrounded)
            {
                velocity = Vector3.zero;
                animator.SetFloat("Speed", 1f);
                direction = (destination - transform.position).normalized;
                transform.LookAt(new Vector3(destination.x, transform.position.y, destination.z));
                velocity = direction * speed;
                
            }
            velocity.y = Physics.gravity.y * Time.deltaTime;
            enemyCon.Move(velocity * Time.deltaTime);

            if (Vector3.Distance(transform.position, destination) < 2.0f)
            {
                arrived = true;
                animator.SetFloat("Speed", 0.0f);
            }
        }
    }

}
