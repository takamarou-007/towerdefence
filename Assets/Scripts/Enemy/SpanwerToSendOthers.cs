using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanwerToSendOthers : MonoBehaviour
{
    [SerializeField] GameObject enemyMob;
    
    public void OnEnable()
    {
        float randomRotation = Random.value * 360f;
        GameObject.Instantiate(enemyMob, transform.position, Quaternion.Euler(0f, randomRotation, 0f));
        this.gameObject.SetActive(false);
    }
}
