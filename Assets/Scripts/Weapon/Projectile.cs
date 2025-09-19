using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [Header("Flight")]
    [SerializeField] float speed = 20f;
    [SerializeField] float lifeTime = 5f;
    [SerializeField] int damage = 10;

    Rigidbody rb;
    Action<Projectile> returnToPool;
    float lifeTimer;

    void Awake() => rb = GetComponent<Rigidbody>();

    // Pool sẽ inject callback này
    public void SetPool(Action<Projectile> returnAction) => returnToPool = returnAction;

    // gọi ngay sau khi lấy từ pool
    public void Init(Vector3 dir)
    {
        lifeTimer = lifeTime;
        var moveDir = dir.normalized;
        transform.rotation = Quaternion.LookRotation(moveDir);
        rb.velocity = moveDir * speed;
    }

    void Update()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f) Despawn();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (other.TryGetComponent(out IDamageable d))
                d.TakeDamage(damage);

            Despawn();
        }
    }

    public void Despawn()
    {
        rb.velocity = Vector3.zero;
        returnToPool?.Invoke(this);
    }
}

public interface IDamageable { void TakeDamage(int amount); }
