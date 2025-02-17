using UnityEngine;
using UnityEngine.AI;

public class MobBehaviour : MonoBehaviour
{
    NavMeshAgent agent;
    Transform tower;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        tower = GameObject.Find("Tower").transform;
        agent.destination = tower.position;
    }

    void Update()
    {
        
    }
}
