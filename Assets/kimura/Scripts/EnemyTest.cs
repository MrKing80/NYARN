using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTest : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Player;
    private NavMeshAgent GetAgent;
    
    void Start()
    {
        GetAgent = GetComponent<NavMeshAgent>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(GetAgent.pathStatus!= NavMeshPathStatus.PathInvalid)
        {
            GetAgent.SetDestination(Player.transform.position);
            
        }
        
    }
}
