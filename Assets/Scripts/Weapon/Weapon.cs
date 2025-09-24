using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : GameUnit
{
    public float moveSpeed = 5f;
    public Character owner;

    public void OnInit(Transform target, Character PlayerFire)
    {
        owner = PlayerFire;

        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0; // bỏ chiều cao
        transform.rotation = Quaternion.LookRotation(lookPos);
        transform.DOMove(target.position, moveSpeed).SetSpeedBased();
    }
    public void DespawnWeapon()
    {
        StartCoroutine(WaitDespawn());
    }

    IEnumerator WaitDespawn()
    {
        yield return new WaitForSeconds(1f);
        OnDespawn(0.1f);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnDespawn(0.1f);
            owner.UpdateScore();
            owner.DrawCircle();
            Character character = other.GetComponent<Character>();
            if (character != null)
            {
                character.OnDeath();
            }

        }
    }


}
