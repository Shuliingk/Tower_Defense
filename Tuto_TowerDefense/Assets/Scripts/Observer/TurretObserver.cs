using UnityEngine;

public class TurretObserver : MonoBehaviour
{
    [SerializeField] MobGeneratorSubject mobGeneratorSubject;
    [SerializeField] TowerSubject towerSubject;
    [SerializeField] TurretBehaviour turretBehaviour;
    [SerializeField] GameObject boomVfx;

    private void Awake()
    {
        mobGeneratorSubject ??= FindAnyObjectByType<MobGeneratorSubject>();
        towerSubject ??= FindAnyObjectByType<TowerSubject>();
        turretBehaviour ??= GetComponent<TurretBehaviour>();
    }

    private void Start()
    {
        mobGeneratorSubject.MobGenerated += OnMobGenerated;
        towerSubject.MobDestroyed += OnMobDestroyed;
        towerSubject.TowerDamaged += OnTowerDamaged;
    }

    private void OnDestroy()
    {
        mobGeneratorSubject.MobGenerated -= OnMobGenerated;
        towerSubject.MobDestroyed -= OnMobDestroyed;
        towerSubject.TowerDamaged -= OnTowerDamaged;
    }

    public void OnMobGenerated()
    {
        turretBehaviour.mobs.Add(mobGeneratorSubject.lastCreatedMob);
    }

    public void OnTowerDamaged()
    {
        if (towerSubject.health <= 0)
        {
            Instantiate(boomVfx, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void OnMobDestroyed()
    {
        if (towerSubject.lastDestroyedMob != null)
        {
            turretBehaviour.mobs.Remove(towerSubject.lastDestroyedMob);
        }
    }

}
