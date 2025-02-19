using UnityEngine;

public class TowerMenu : MonoBehaviour
{
    public ITurretProduct turret;

    void Start()
    {
        AskToCloseMenu();
    }

    public void AskToCloseMenu()
    {
        Invoke("CloseMenu", .1f);
    }

    public void CloseMenu()
    {
        gameObject.SetActive(false);
    }

    public void SellTower()
    {
        Destroy(turret.gameObject);
        MoneyManager.Instance.UpdateMoney(10);
    }

    public void UpgradeTower()
    {
        MoneyManager.Instance.UpdateMoney(-20);
        turret.TurretLevel++;
        turret.TurretPower++;
        turret.TurretRadius++;
        turret.Upgrade();
    }

}
