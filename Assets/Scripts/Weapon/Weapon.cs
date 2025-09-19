using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform muzzle;
    [SerializeField] ProjectilePool pool;

    public void ShootAt(Transform enemy)
    {
        if (!enemy) return;

        Vector3 dir = (enemy.position - muzzle.position);
        var proj = pool.Get(muzzle.position, Quaternion.identity);
        proj.Init(dir);
    }
}