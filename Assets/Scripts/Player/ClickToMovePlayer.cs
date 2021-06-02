using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMovePlayer : MonoBehaviour
{
    private NavMeshAgent agent;
    private RaycastHit hit;
    private Ray ray;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 200f))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
