using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MobStatus))]
public class MobAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 0.5f; //攻撃後のクールダウン
    [SerializeField] private Collider attackCollider;
    public int damage;
    private MobStatus _status;


    private void Start()
    {
        _status = GetComponent<MobStatus>();
        
    }

   

    //攻撃可能であれば攻撃を行う
    public void AttackIfPossible()
    {
        
        if (!_status.isAttackble) return;

        _status.GoToAttackStateIfPossible();

    }

    //攻撃対象が攻撃範囲内に入ったときに呼ばれる
    ///<param name="collider"></param>
    public void OnAttackRangeEnter(Collider collider)
    {
        
        AttackIfPossible();
       
    }

    //攻撃の開始時に呼ばれる
    public void OnAttackStart()
    {
        attackCollider.enabled = true;
    }

    //attackColliderが攻撃対象にＨｉｔしたときに呼ばれます
    ///<param name="collider"></param>
    public void OnHitAttack(Collider collider)
    {
        var targetMob = collider.GetComponent<MobStatus>();
        if (null == targetMob) return;
        targetMob.Damage(damage);
    }

    //攻撃の終了維持に呼ばれる
    public void OnAttackFinished()
    {
        attackCollider.enabled = false;
        StartCoroutine(CooldownCoroutine());
    }

    private IEnumerator CooldownCoroutine()
    {
        yield return new WaitForSeconds(attackCooldown);
        _status.GoToNormalStateIfPossible();
    }

}
