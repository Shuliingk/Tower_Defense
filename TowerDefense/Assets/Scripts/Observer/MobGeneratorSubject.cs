using UnityEngine;
using System;

public class MobGeneratorSubject : MonoBehaviour 
{
    public event Action MobGenerated;
    public GameObject lastCreatedMob;

    public void CreateNewMob(GameObject mob)
    {
        lastCreatedMob = mob;
        MobGenerated?.Invoke();
    }
}
