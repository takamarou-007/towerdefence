using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MobStatus))]
public class MobAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 0.5f; //UŒ‚Œã‚ÌƒN[ƒ‹ƒ_ƒEƒ“
    [SerializeField] private Collider attackCollider;
    public int damage;
    private MobStatus _status;


    private void Start()
    {
        _status = GetComponent<MobStatus>();
        
    }

   

    //UŒ‚‰Â”\‚Å‚ ‚ê‚ÎUŒ‚‚ğs‚¤
    public void AttackIfPossible()
    {
        
        if (!_status.isAttackble) return;

        _status.GoToAttackStateIfPossible();

    }

    //UŒ‚‘ÎÛ‚ªUŒ‚”ÍˆÍ“à‚É“ü‚Á‚½‚Æ‚«‚ÉŒÄ‚Î‚ê‚é
    ///<param name="collider"></param>
    public void OnAttackRangeEnter(Collider collider)
    {
        
        AttackIfPossible();
       
    }

    //UŒ‚‚ÌŠJn‚ÉŒÄ‚Î‚ê‚é
    public void OnAttackStart()
    {
        attackCollider.enabled = true;
    }

    //attackCollider‚ªUŒ‚‘ÎÛ‚É‚g‚‰‚”‚µ‚½‚Æ‚«‚ÉŒÄ‚Î‚ê‚Ü‚·
    ///<param name="collider"></param>
    public void OnHitAttack(Collider collider)
    {
        var targetMob = collider.GetComponent<MobStatus>();
        if (null == targetMob) return;
        targetMob.Damage(damage);
    }

    //UŒ‚‚ÌI—¹ˆÛ‚ÉŒÄ‚Î‚ê‚é
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
