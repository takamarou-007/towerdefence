using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//unity�{�i����Q�l
[RequireComponent(typeof(Collider))]
public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private TriggerEvent onTriggerEnter = new TriggerEvent();
    [SerializeField] private TriggerEvent onTriggerStay = new TriggerEvent();

    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke(other);
    }


    //<sumary>
    //Is Trigger��On�łق���Collier�Əd�Ȃ��Ă��鎞�́A���̃��\�b�h��ɃR�[�������
    // 
    // </sumary>

    /// <param nama="other"></param>
    private void OnTriggerStay(Collider other)
    {
        onTriggerStay.Invoke(other);
    }

    [Serializable]
    public class TriggerEvent : UnityEvent<Collider>
    {
    }
    
}
