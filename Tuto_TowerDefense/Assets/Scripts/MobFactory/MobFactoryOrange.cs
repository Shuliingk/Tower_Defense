using UnityEngine;

public class MobFactoryOrange : MobFactory
{
    [SerializeField] private MobProductOrange productPrefab;

    public override IMobProduct GetProduct(Vector3 position)
    {
        GameObject instance = Instantiate(productPrefab.gameObject, position, Quaternion.identity);
        instance.transform.parent = MobsGenerator.generator;
        MobProductOrange newMobProduct = instance.GetComponent<MobProductOrange>();

        newMobProduct.Initialize();

        return newMobProduct;
    }
}
