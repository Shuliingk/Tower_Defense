using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    private static MoneyManager instance;

    public static MoneyManager Instance
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

    [SerializeField] private TextMeshProUGUI goldText;
    public int money = 100;
    [SerializeField] Animation anim;

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

        anim = goldText.gameObject.GetComponent<Animation>();
    }

    private static void SetupInstance()
    {
        instance = FindFirstObjectByType<MoneyManager>();

        if (instance == null)
        {
            GameObject gameObj = new GameObject();
            gameObj.name = "MoneyManager_Singleton";
            instance = gameObj.AddComponent<MoneyManager>();
        }
    }

    public void UpdateMoney(int price)
    {
        money += price;
        goldText.text = money.ToString();

        if (!anim.isPlaying)
        {
            anim.Play();
        }
    }
}
