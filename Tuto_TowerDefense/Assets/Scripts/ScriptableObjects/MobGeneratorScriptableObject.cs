using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MobGeneratorScriptableObject", order = 1)]
public class MobGeneratorScriptableObject : ScriptableObject
{
    // Pour les vagues de mobs
    public int[] mobsToSpawn;
    // Nb mobs / vague
    public int mobsPerWaves;
    // Position de génération du mob
    public Vector3 instantiationPosition;
    // Temps entre 2 mobs
    public float delayBetweenMobs;
    // Temps entre 2 vagues
    public float delayBetweenWaves;
}
