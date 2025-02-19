using UnityEngine;

public class TreeObserver : MonoBehaviour
{
    [SerializeField] TowerSubject towerSubject;

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
        if (towerSubject.health <= 0)
        {
            iTween.PunchPosition(gameObject, new Vector3(
                0,
                0,
                transform.position.z + 1
                ), 1);
        }
    }
}
