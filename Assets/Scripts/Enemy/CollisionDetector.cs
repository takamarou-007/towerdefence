using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//unity本格入門参考
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
    //Is TriggerがOnでほかのCollierと重なっている時は、このメソッド常にコールされる
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
