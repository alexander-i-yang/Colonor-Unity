using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserShooter : MonoBehaviour {
    private Transform laserT = null;
    public float laserRange = 10.0f;
    [SerializeField]
    public LayerMask layers = ~0;
    private LineRenderer lineRenderer;
    public Vector2 direction;
    void Start() {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.useWorldSpace = true;
    }

    public void SetEnabled(bool e) {
        lineRenderer.enabled = e;
    }

    public void SetSpawnObject(Transform t) { laserT = t; }

    void Update() {
        if (lineRenderer.enabled) {
            Vector3 laserSpawn = laserT.position;
            Vector3 hitPoint = Physics2D.Raycast(laserSpawn, direction, layerMask: layers, distance:laserRange).point;
            if (hitPoint == Vector3.zero) {
                hitPoint = laserSpawn;
                hitPoint.x += laserRange * direction.x;
            }
            Debug.DrawLine(laserSpawn, hitPoint);
            lineRenderer.SetPosition(0, laserSpawn);
            lineRenderer.SetPosition(1, hitPoint);
        }
    }
}
/*
namespace Gamekit2D
{
    public class BulletPool : ObjectPool<BulletPool, BulletObject, Vector2>
    {
        static protected Dictionary<GameObject, BulletPool> s_PoolInstances = new Dictionary<GameObject, BulletPool>();

        private void Awake()
        {
            //This allow to make Pool manually added in the scene still automatically findable & usable
            if(prefab != null && !s_PoolInstances.ContainsKey(prefab))
                s_PoolInstances.Add(prefab, this);
        }

        private void OnDestroy()
        {
            s_PoolInstances.Remove(prefab);
        }

        //initialPoolCount is only used when the objectpool don't exist
        static public BulletPool GetObjectPool(GameObject prefab, int initialPoolCount = 10)
        {
            BulletPool objPool = null;
            if (!s_PoolInstances.TryGetValue(prefab, out objPool))
            {
                GameObject obj = new GameObject(prefab.name + "_Pool");
                objPool = obj.AddComponent<BulletPool>();
                objPool.prefab = prefab;
                objPool.initialPoolCount = initialPoolCount;

                s_PoolInstances[prefab] = objPool;
            }

            return objPool;
        }
    }

    public class BulletObject : PoolObject<BulletPool, BulletObject, Vector2>
    {
        public Transform transform;
        public Rigidbody2D rigidbody2D;
        public SpriteRenderer spriteRenderer;
        public Bullet bullet;

        protected override void SetReferences()
        {
            transform = instance.transform;
            rigidbody2D = instance.GetComponent<Rigidbody2D> ();
            spriteRenderer = instance.GetComponent<SpriteRenderer> ();
            bullet = instance.GetComponent<Bullet>();
            bullet.bulletPoolObject = this;
            bullet.mainCamera = Object.FindObjectOfType<Camera> ();
        }

        public override void WakeUp(Vector2 position)
        {
            transform.position = position;
            instance.SetActive(true);
        }

        public override void Sleep()
        {
            instance.SetActive(false);
        }
    }
}*/