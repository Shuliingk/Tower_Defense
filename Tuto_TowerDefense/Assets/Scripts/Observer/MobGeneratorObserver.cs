using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MobGeneratorObserver : MonoBehaviour
{
    [SerializeField] MobGeneratorScriptableObject mobGeneratorData;
    [SerializeField] TowerSubject towerSubject;
    [SerializeField] private TextMeshProUGUI endText;

    int totalMobs;
    int destroyedMobs;

    private void Awake()
    {
        towerSubject ??= FindAnyObjectByType<TowerSubject>();
    }

    private void Start()
    {
        totalMobs = mobGeneratorData.mobsToSpawn.Length * mobGeneratorData.mobsPerWaves;
        towerSubject.MobDestroyed += OnMobDestroyed;
        towerSubject.TowerDamaged += OnTowerDamaged;
    }

    private void OnDestroy()
    {
        towerSubject.MobDestroyed -= OnMobDestroyed;
        towerSubject.TowerDamaged -= OnTowerDamaged;
    }

    public void OnMobDestroyed()
    {
        destroyedMobs++;
        MoneyManager.Instance.UpdateMoney(5);

        if (destroyedMobs >= totalMobs && towerSubject.health > 0)
        {
            endText.text = "Victoire !";
            Invoke("LoadNextLevel", 2);
        }
    }

    public void OnTowerDamaged()
    {
        if (towerSubject.health <= 0) { 
            Destroy(gameObject);
        }
    }

    public void LoadNextLevel()
    {
        int actualLevel = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = actualLevel + 1;
        if (nextLevel < 3) // Exemple si 2 levels
        {
            SceneManager.LoadScene(nextLevel);
        } else
        {
            SceneManager.LoadScene(0); // crédits de fin
        }
        
    }
}
