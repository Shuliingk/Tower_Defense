using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Collections;

public class MobProductOrange : MonoBehaviour, IMobProduct
{

    [SerializeField] private int mobLife = 3;
    [SerializeField] private string mobType = "normal";
    [SerializeField] private float mobSpeed = 1f;
    [SerializeField] private Transform[] pathPoints;
    private NavMeshAgent agent;
    [SerializeField] private RectTransform mobLifeBar;
    float lifePointValue;
    Material[] materials; // materials mob
    Renderer mobRenderer; // renderer mob
    Color[] tempColors = new Color[4];

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
        mobRenderer = transform.Find("Mob").GetComponent<Renderer>();
        materials = mobRenderer.materials;
        for (int i = 0; i < materials.Length; i++)
        {
            tempColors[i] = materials[i].color;
        }
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
            MobLife -= other.gameObject.GetComponent<Bullet>().type == "water" ? 3 : 1;
            mobLifeBar.localScale = new Vector3(MobLife * lifePointValue,1,1);

            for (int i=0; i<materials.Length; i++)
            {
                materials[i].color = Color.white;
            }
            StartCoroutine("ResetMaterials");

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

    IEnumerator ResetMaterials()
    {
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].color = tempColors[i];
        }
    }
}
