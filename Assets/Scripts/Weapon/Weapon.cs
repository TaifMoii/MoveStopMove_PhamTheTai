using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : GameUnit
{
    public float moveSpeed = 5f;
    public void OnInit(Transform target)
    {
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0; // bỏ chiều cao
        transform.rotation = Quaternion.LookRotation(lookPos);
        transform.DOMove(target.position, moveSpeed).SetSpeedBased();

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnDespawn(0.1f);
        }
    }
}
