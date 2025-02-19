using System.Collections;
using UnityEngine;
using TMPro;

public class MobsGenerator : MonoBehaviour
{
    [SerializeField] MobGeneratorScriptableObject mobGeneratorData;
    [SerializeField] MobFactory[] factories;
    public static Transform generator;
    bool wavesEnded = false;
    MobGeneratorSubject mobGeneratorSubject;
    [SerializeField] GameObject portal;
    [SerializeField] TMP_Text waveText;

    private void Start()
    {
        mobGeneratorSubject = GetComponent<MobGeneratorSubject>();
        generator = GameObject.Find("GeneratorPosition").transform;
        StartCoroutine("GenerateMobs");
    }

    IEnumerator GenerateMobs()
    {
        int waveNumber = 1;
        // Vagues
        foreach (int wave in mobGeneratorData.mobsToSpawn)
        {
            yield return new WaitForSeconds(mobGeneratorData.delayBetweenWaves);
            // Mobs de la vague en cours
            for (int i = 0; i < mobGeneratorData.mobsPerWaves; i++)
            {
                yield return new WaitForSeconds(mobGeneratorData.delayBetweenMobs);
                IMobProduct createdMob = factories[wave].GetProduct(mobGeneratorData.instantiationPosition);
                mobGeneratorSubject.CreateNewMob(createdMob.gameObject);
                iTween.PunchScale(portal, new Vector3(60, 60, 60), .8f);
            }
            // Bonus argent
            MoneyManager.Instance.UpdateMoney(25);
            waveNumber++;
            waveText.text = "Vague " + waveNumber;
        }

        wavesEnded = true;
    }

}
