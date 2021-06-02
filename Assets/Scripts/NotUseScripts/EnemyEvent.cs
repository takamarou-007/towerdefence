using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�@�\���Ă��Ȃ�
public class EnemyEvent : MonoBehaviour
{
    private MoveEnemy enemy;
    [SerializeField] private BoxCollider boxCollider;

    private void Start()
    {
        enemy = GetComponent<MoveEnemy>();
    }

    void AttackStart()
    {
        boxCollider.enabled = true;
    }

    public void AttackEnd()
    {
        boxCollider.enabled = false;
    }

    

}
