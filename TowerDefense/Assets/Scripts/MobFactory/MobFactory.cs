using UnityEngine;

public abstract class MobFactory : MonoBehaviour
{
    public abstract IMobProduct GetProduct(Vector3 position);
}
