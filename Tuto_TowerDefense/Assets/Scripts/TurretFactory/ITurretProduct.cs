

using Unity.VisualScripting;
using UnityEngine;

public interface ITurretProduct 
{
    public int TurretCost { get; set; }
    public string TurretType { get; set; }
    public int TurretPower { get; set; }
    public float TurretRadius { get; set; }
    public int TurretLevel { get; set; }

    public void Initialize();
    public void Upgrade();

    GameObject gameObject { get; }

}
