using System;
using TMPro;
using UnityEngine;

public class TowerSubject : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI endText;
    [SerializeField] private GameObject endTextRelunch;
    public event Action MobDestroyed;
    public event Action TowerDamaged;
    public GameObject lastDestroyedMob;
    public int health = 3;

    [SerializeField] private TMP_Text healthText;
    [SerializeField] private GameObject boomParticles;
    private static TowerSubject instance;

    // Singleton
    public static TowerSubject Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Destruction d'un monstre au contact de la tour
    public void DestroyMob(GameObject mob)
    {
        if (mob != null)
        {
            lastDestroyedMob = mob;
            Instantiate(boomParticles, mob.transform.position + Vector3.up, Quaternion.identity);
            MobDestroyed?.Invoke();
            Destroy(mob, .1f);
        }
    }

    // Recevoir des dégats
    private void TakeDamages()
    {
        health--;
        if (health < 0) health = 0;
        healthText.text = health.ToString();
        TowerDamaged?.Invoke();
        CamShake.Instance.Shake(.2f, .8f, 1.5f);
        iTween.PunchScale(gameObject, new Vector3(90,90,90), .5f);

        if (health <= 0)
        {
            endText.text = "Défaite !";
            endTextRelunch.SetActive(true);
        }
    }

    // Gestion des collisions
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Mob")
        {
            DestroyMob(collision.gameObject);
            TakeDamages();
        }
    }
}
