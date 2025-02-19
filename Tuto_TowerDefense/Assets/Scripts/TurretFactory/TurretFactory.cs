
using UnityEngine;

public abstract class TurretFactory : MonoBehaviour
{
    public abstract ITurretProduct GetProduct(Vector3 position);
}
