using UnityEngine;

public class TowerHealthObserver : MonoBehaviour
{
    [SerializeField] TowerSubject towerSubject;
    [SerializeField] GameObject lowHealthVolume;

    private void Awake()
    {
        towerSubject ??= FindAnyObjectByType<TowerSubject>();
    }

    private void Start()
    {
        towerSubject.TowerDamaged += OnTowerDamaged;
    }

    private void OnDestroy()
    {
        towerSubject.TowerDamaged -= OnTowerDamaged;
    }

    public void OnTowerDamaged()
    {
        if (towerSubject.health <= 1)
        {
            lowHealthVolume.SetActive(true);
        } else
        {
            lowHealthVolume.SetActive(false);
        }
    }

}
