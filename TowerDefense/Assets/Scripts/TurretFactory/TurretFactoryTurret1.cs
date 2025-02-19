
using UnityEngine;

public class TurretFactoryTurret1 : TurretFactory
{
    [SerializeField] private TurretProductTurret1 productPrefab;

    public override ITurretProduct GetProduct(Vector3 position)
    {
        GameObject instance = Instantiate(productPrefab.gameObject, position, Quaternion.identity);
        TurretProductTurret1 newTurretProduct = instance.GetComponent<TurretProductTurret1>();
        // Rotation de la tourelle de -90 en X
        instance.transform.rotation = Quaternion.Euler(-90, 0, 0);

        newTurretProduct.Initialize();

        return newTurretProduct;
    }
}
