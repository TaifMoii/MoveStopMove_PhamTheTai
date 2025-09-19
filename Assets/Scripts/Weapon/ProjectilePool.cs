using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    [Header("Pool")]
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] int initialSize = 20;
    readonly Queue<Projectile> pool = new();

    void Awake()
    {
        for (int i = 0; i < initialSize; i++)
            CreateInstance();
    }

    Projectile CreateInstance()
    {
        var p = Instantiate(projectilePrefab, transform);
        p.gameObject.SetActive(false);
        p.SetPool(ReturnToPool);
        pool.Enqueue(p);
        return p;
    }

    void ReturnToPool(Projectile p)
    {
        p.gameObject.SetActive(false);
        p.transform.SetParent(transform, worldPositionStays: false);
        pool.Enqueue(p);
    }

    public Projectile Get(Vector3 pos, Quaternion rot)
    {
        if (pool.Count == 0) CreateInstance();
        var p = pool.Dequeue();
        p.transform.SetPositionAndRotation(pos, rot);
        p.gameObject.SetActive(true);
        return p;
    }
}
