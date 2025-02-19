
using UnityEngine;

public class TurretFactoryTurret2 : TurretFactory
{
    [SerializeField] private TurretProductTurret2 productPrefab;

    public override ITurretProduct GetProduct(Vector3 position)
    {
        GameObject instance = Instantiate(productPrefab.gameObject, position, Quaternion.identity);
        TurretProductTurret2 newTurretProduct = instance.GetComponent<TurretProductTurret2>();
        // Rotation de la tourelle de -90 en X
        instance.transform.rotation = Quaternion.Euler(-90, 0, 0);

        newTurretProduct.Initialize();

        return newTurretProduct;
    }
}
