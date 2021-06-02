using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Unityñ{äiì¸ñÂéQçl
[RequireComponent(typeof(EnemyStatus))]
public class EnemyMove : MonoBehaviour
{ 
    private NavMeshAgent _agent;
    private EnemyStatus _status;
    private GameObject tower1;
    private GameObject tower2;
    private GameObject tower3;
    private GameObject tower4;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _status = GetComponent<EnemyStatus>();
        tower1 = GameObject.Find("Tower-1");
        tower2 = GameObject.Find("Tower-2");
        tower3 = GameObject.Find("Tower-3");
        tower4 = GameObject.Find("Tower-4");
    }

    private void Update()
    {
        if (this.gameObject.tag == "Enemy1")
        {
            if(tower1 == null)
            {
                Destroy(gameObject);
            }
            else
            {
                _agent.destination = tower1.transform.position;
            }
        }
        if(this.gameObject.tag == "Enemy2")
        {
            if (tower2 == null)
            {
                Destroy(gameObject);
            }
            else
            {
                _agent.destination = tower2.transform.position;
            }
        }
        if(this.gameObject.tag == "Enemy3")
        {
            if (tower3 == null)
            {
                Destroy(gameObject);
            }
            else
            {
                _agent.destination = tower3.transform.position;
            }
        }
        if(this.gameObject.tag == "Enemy4")
        {
            if (tower4 == null)
            {
                Destroy(gameObject);
            }
            else
            {
                _agent.destination = tower4.transform.position;
            }
        }
    }

    public void OnDetectObject(Collider collider)
    {
        if (!_status.isDead)
        {
            if (!_status.isMovable)
            {
                _agent.isStopped = true;
                return;
            }
        }
    }
}
