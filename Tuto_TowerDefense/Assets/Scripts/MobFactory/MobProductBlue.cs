using System;
using UnityEngine;
using UnityEngine.AI;

public class MobProductBlue : MonoBehaviour, IMobProduct
{

    [SerializeField] private int mobLife = 2;
    [SerializeField] private string mobType = "water";
    [SerializeField] private float mobSpeed = 1.25f;
    [SerializeField] private Transform[] pathPoints;
    private NavMeshAgent agent;
    [SerializeField] private RectTransform mobLifeBar;
    float lifePointValue;

    public int MobLife { get => mobLife; set => mobLife = value; }
    public string MobType { get => mobType; set => mobType = value; }
    public float MobSpeed { get => mobSpeed; set => mobSpeed = value; }

    public void Initialize()
    {
        agent = gameObject.AddComponent<NavMeshAgent>();
        agent.speed = MobSpeed;
        pathPoints[0] = GameObject.Find("pathPointLeft").transform;
        pathPoints[1] = GameObject.Find("pathPointRight").transform;
        agent.SetDestination(pathPoints[UnityEngine.Random.Range(0, pathPoints.Length)].position);
        InvokeRepeating(nameof(GoToTower), 3, 0.5f);
        lifePointValue = mobLifeBar.localScale.x / MobLife; 
    }

    public void GoToTower()
    {
        float dist = agent.remainingDistance;
        if (agent.remainingDistance < 0.5f)
        {
            agent.SetDestination(GameObject.Find("Tower").transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet") && MobLife > 0)
        {
            // MobLife--;
            MobLife -= other.gameObject.GetComponent<Bullet>().type == "fire" ? 2 : 1;
            mobLifeBar.localScale = new Vector3(MobLife * lifePointValue, 1, 1);

            if (MobLife <= 0)
            {
                try
                {
                    TowerSubject.Instance.DestroyMob(gameObject);
                }
                catch (Exception e)
                {
                    print(e.Message);
                }
            }
        }
    }

}
