using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//unity本格入門参照
//敵の状態管理スクリプト

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
       

        base.OnDie();     //animationでdieがないので、オブジェクトの消去とパーティクルとサウンドでいい感じにごまかすつもり
        StartCoroutine(DestroyCoroutine());
    }

    ///<param></param>
    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    
}
