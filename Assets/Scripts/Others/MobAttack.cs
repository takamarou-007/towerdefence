using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MobStatus))]
public class MobAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 0.5f; //�U����̃N�[���_�E��
    [SerializeField] private Collider attackCollider;
    public int damage;
    private MobStatus _status;


    private void Start()
    {
        _status = GetComponent<MobStatus>();
        
    }

   

    //�U���\�ł���΍U�����s��
    public void AttackIfPossible()
    {
        
        if (!_status.isAttackble) return;

        _status.GoToAttackStateIfPossible();

    }

    //�U���Ώۂ��U���͈͓��ɓ������Ƃ��ɌĂ΂��
    ///<param name="collider"></param>
    public void OnAttackRangeEnter(Collider collider)
    {
        
        AttackIfPossible();
       
    }

    //�U���̊J�n���ɌĂ΂��
    public void OnAttackStart()
    {
        attackCollider.enabled = true;
    }

    //attackCollider���U���Ώۂɂg���������Ƃ��ɌĂ΂�܂�
    ///<param name="collider"></param>
    public void OnHitAttack(Collider collider)
    {
        var targetMob = collider.GetComponent<MobStatus>();
        if (null == targetMob) return;
        targetMob.Damage(damage);
    }

    //�U���̏I���ێ��ɌĂ΂��
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
