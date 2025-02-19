using TMPro;
using UnityEngine;

public class SFXObserver : MonoBehaviour
{
    [SerializeField] TowerSubject towerSubject;
    [SerializeField] MobGeneratorSubject mobGeneratorSubject;
    AudioSource audioSource;
    [SerializeField] AudioSource audioSourceMusic;
    [SerializeField] AudioClip mobCreatedClip;
    [SerializeField] AudioClip mobDestroyedClip;
    [SerializeField] AudioClip turretClip;
    [SerializeField] AudioClip clickClip; 
    [SerializeField] AudioClip buildClip;

    private static SFXObserver instance;

    public static SFXObserver Instance
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

    private static void SetupInstance()
    {
        instance = FindFirstObjectByType<SFXObserver>();

        if (instance == null)
        {
            GameObject gameObj = new GameObject();
            gameObj.name = "SFXObserver_Singleton";
            instance = gameObj.AddComponent<SFXObserver>();
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

        mobGeneratorSubject ??= FindAnyObjectByType<MobGeneratorSubject>();
        towerSubject ??= FindAnyObjectByType<TowerSubject>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        mobGeneratorSubject.MobGenerated += OnMobGenerated;
        towerSubject.MobDestroyed += OnMobDestroyed;

        audioSource.volume = PlayerPrefs.GetFloat("VolumeSFX", 0.5f);
        audioSourceMusic.volume = PlayerPrefs.GetFloat("VolumeMusique", 0.5f);
    }

    private void OnDestroy()
    {
        mobGeneratorSubject.MobGenerated -= OnMobGenerated;
        towerSubject.MobDestroyed -= OnMobDestroyed;
    }

    public void OnMobGenerated()
    {
        audioSource.PlayOneShot(mobCreatedClip);
    }


    public void OnMobDestroyed()
    {
        audioSource.PlayOneShot(mobDestroyedClip);
    }

    public void TurretShot()
    {
        audioSource.PlayOneShot(turretClip);
    }

    public void ClickSfx()
    {
        audioSource.PlayOneShot(clickClip);
    }

    public void BuildTowerSfx()
    {
        audioSource.PlayOneShot(buildClip);
    }


}
