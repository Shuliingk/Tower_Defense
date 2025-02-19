
using UnityEngine;

public class TurretProductTurret2 : MonoBehaviour, ITurretProduct
{
    [SerializeField] private int turretCost = 25;
    [SerializeField] private string turretType = "normal";
    [SerializeField] private int turretPower = 1;
    [SerializeField] private float turretRadius = 3;
    [SerializeField] private int turretLevel = 1;
    [SerializeField] private GameObject[] turretParts;

    public int TurretCost { get => turretCost; set => turretCost = value; }
    public string TurretType { get => turretType; set => turretType = value; }
    public int TurretPower { get => turretPower; set => turretPower = value; }
    public float TurretRadius { get => turretRadius; set => turretRadius = value; }
    public int TurretLevel { get => turretLevel; set => turretLevel = value; }

    TurretBehaviour turretBehaviour;

    public void Initialize()
    {
        turretBehaviour = GetComponent<TurretBehaviour>();
        GameObject[] mobs = GameObject.FindGameObjectsWithTag("Mob");

        foreach (GameObject mob in mobs)
        {
            turretBehaviour.mobs.Add(mob);
        }
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, TurretRadius);
    }
#endif

    public void Upgrade()
    {
        turretParts[0].SetActive(false);
        turretParts[1].SetActive(true);
    }

}
