using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//unity�{�i����Q��
//�G�̏�ԊǗ��X�N���v�g

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyStatus : MobStatus
{
    
    private NavMeshAgent _agent;
    private float enemySpeed;

   

    protected override void Start()
    {
        base.Start();
        _agent = GetComponent<NavMeshAgent>();
        enemySpeed = _agent.speed;

       

    }

    private void Update()
    {
        _animator.SetFloat("Speed", _agent.velocity.magnitude);

    }

    protected override void OnDie()
    {
       

        base.OnDie();     //animation��die���Ȃ��̂ŁA�I�u�W�F�N�g�̏����ƃp�[�e�B�N���ƃT�E���h�ł��������ɂ��܂�������
        StartCoroutine(DestroyCoroutine());
    }

    ///<param></param>
    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    
}
