using UnityEngine;
using System.Collections.Generic;

public class TurretBehaviour : MonoBehaviour
{
    private ITurretProduct turretProduct;
    [SerializeField] private Transform gun;
    [SerializeField] private Transform pivot;
    public List<GameObject> mobs = new List<GameObject>();
    private Transform target;
    [SerializeField] ObjectPool objectPool;
    private float shotPower = 650f;

    private void Awake()
    {
        turretProduct ??= GetComponent<ITurretProduct>();
        objectPool ??= FindAnyObjectByType<ObjectPool>();
        pivot = transform.Find("Pivot");
    }

    private void Start()
    {
        InvokeRepeating("HandleTurretBehaviour", .5f, .5f);
        InvokeRepeating("Shot", 1, 1);
    }

    public void SearchTarget()
    {
        foreach (GameObject mob in mobs)
        {
            if (mob != null && !target && Vector3.Distance(transform.position, mob.transform.position) <= turretProduct.TurretRadius)
            {
                target = mob.transform;
            }
        }
    }

    private void HandleTurretBehaviour()
    {
        if (!target)
        {
            SearchTarget();
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) > turretProduct.TurretRadius)
            {
                target = null;
            }
        }
    }

    private void Shot()
    {
        if (target)
        {
            SFXObserver.Instance.TurretShot();
            CamShake.Instance.Shake(.15f, .6f, 1.2f);

            GameObject bulletObject = objectPool.GetPooledObject().gameObject;

            if (bulletObject == null)
                return;

            bulletObject.SetActive(true);

            bulletObject.transform.SetPositionAndRotation(gun.position, gun.rotation);

            bulletObject.GetComponent<Rigidbody>().AddForce(bulletObject.transform.forward * shotPower, ForceMode.Acceleration);

            Bullet projectile = bulletObject.GetComponent<Bullet>();
            projectile.type = turretProduct.TurretType;
            projectile?.Deactivate();
        }
    }

    private void Update()
    {
        if (target)
        {
            var mobPos = target.position;
            mobPos.y = pivot.position.y;
            pivot.LookAt(mobPos);
        }
    }

}
