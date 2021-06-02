using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�@�\���Ă��Ȃ�
public class AttackTower : MonoBehaviour
{
    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tower")
        {
            Debug.Log("������");
            StartCoroutine("EnemyAttack");
        }
    }

    IEnumerator EnemyAttack()
    {
        animator.SetBool("Attack", true);
        yield return new WaitForSeconds(0.05f);
        animator.SetBool("Attack", false);
    }
}
