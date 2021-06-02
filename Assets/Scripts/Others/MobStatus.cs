using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

//unity本格入門参考
//動くオブジェクトの状態管理スクリプト
public class MobStatus : MonoBehaviour
{
    protected enum StateEnum
    {
        Normal,
        Attack,
        Die,
    }

    public bool isMovable => StateEnum.Normal == _state;
    public bool isAttackble => StateEnum.Normal == _state;
    public bool isDead => StateEnum.Die == _state;
    public float LifeMax => LifeMax;
    public float Life => _life;

    [SerializeField] private float lifeMax = 10;
    protected Animator _animator;
    protected StateEnum _state = StateEnum.Normal;
    private float _life;

    public Slider slider;
    public Canvas canvas;
    

    protected virtual void Start()
    {
        _life = lifeMax;
        _animator = GetComponentInChildren<Animator>();

        //Sliderを満タンにする
        slider.value = 1;
    }

    private void LateUpdate()
    {
        canvas.transform.rotation = Camera.main.transform.rotation;
    }

    protected virtual void OnDie()
    {
        Destroy(gameObject);
    }

    ///<param name="damage"></param>
    public void Damage(int damage)
    {
        if (_state == StateEnum.Die) return;

        _life -= damage;
        slider.value = _life / lifeMax;
        if (_life > 0) return;

        _state = StateEnum.Die;
        //_animator.SetTrigger("Die");
        OnDie();
    }

    public void GoToAttackStateIfPossible()
    {
        
        if (!isAttackble) return;

        _state = StateEnum.Attack;
        _animator.SetTrigger("Attack");
       
    }

    public void GoToNormalStateIfPossible()
    {
        if (_state == StateEnum.Die) return;

        _state = StateEnum.Normal;
    }

}
