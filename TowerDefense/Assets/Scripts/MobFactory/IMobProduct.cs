using UnityEngine;

public interface IMobProduct
{
    // Vie du mob
    public int MobLife { get; set; }
    // Type de monstre
    public string MobType { get; set; }
    // Vitesse du monstre
    public float MobSpeed { get; set; }

    // Initialisation du mob
    public void Initialize();

    // Aller vers la tour
    public void GoToTower();

    // Ref vers le go
    GameObject gameObject { get; }

}
