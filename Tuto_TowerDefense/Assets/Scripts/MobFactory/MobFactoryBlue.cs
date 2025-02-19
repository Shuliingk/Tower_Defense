using UnityEngine;

public class MobFactoryBlue : MobFactory
{
    [SerializeField] private MobProductBlue productPrefab;

    public override IMobProduct GetProduct(Vector3 position)
    {
        GameObject instance = Instantiate(productPrefab.gameObject, position, Quaternion.identity);
        instance.transform.parent = MobsGenerator.generator;
        MobProductBlue newMobProduct = instance.GetComponent<MobProductBlue>();

        newMobProduct.Initialize();

        return newMobProduct;
    }
}
