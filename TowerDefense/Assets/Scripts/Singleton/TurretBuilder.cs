using Unity.VisualScripting;
using UnityEngine;

public class TurretBuilder : MonoBehaviour
{
    public int factory = 0; // selectedTurret
    [SerializeField] TurretFactory[] factories;

    private static TurretBuilder instance;

    public static TurretBuilder Instance
    {
        get
        {
            if (instance == null)
            {
                SetupInstance();
            }
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

    private static void SetupInstance()
    {
        instance = FindFirstObjectByType<TurretBuilder>();

        if (instance == null)
        {
            GameObject gameObj = new GameObject();
            gameObj.name = "TurretBuilder_Singleton";
            instance = gameObj.AddComponent<TurretBuilder>();
        }
    }

    public ITurretProduct CreateSelectedTowerAtPosition(Vector3 pos)
    {
        int turretPrice = 20 + (factory * 5);

        if (MoneyManager.Instance.money >= turretPrice)
        {
            SFXObserver.Instance.BuildTowerSfx();
            MoneyManager.Instance.UpdateMoney(-turretPrice);
            ITurretProduct product = factories[factory].GetProduct(pos);
            return product;
        }

        return null;
    }

    public void SelectFactory(int id)
    {
        factory = id;
    }
}
