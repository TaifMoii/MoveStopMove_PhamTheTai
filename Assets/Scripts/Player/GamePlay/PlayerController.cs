using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]

public class PlayerController : Character
{
    public float moveSpeed = 5f;
    public JoyStick joystick;
    public Transform Target => target;
    public LayerMask enemyLayer;
    public bool canAttack;
    public bool isMoving;

    public Transform muzzle;
    private Rigidbody rb;
    private IState currentState;
    private Transform target;



    void Start()
    {
        OnInit();
    }

    public override void OnInit()
    {
        rb = GetComponent<Rigidbody>();


        base.OnInit();
        ChangeState(new IdleSate());
        isMoving = false;
        canAttack = false;
    }
    void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }



    void FixedUpdate()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        Vector3 direction = new Vector3(horizontal, 0, vertical);

        // Di chuyển
        rb.velocity = direction.normalized * moveSpeed + new Vector3(0, rb.velocity.y, 0);

        // Quay mặt theo hướng di chuyển
        if (direction.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 0.3f));
        }

        if (direction.sqrMagnitude > 0.01f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

    }

    public void FindTarget()
    {
        // Lấy tất cả Collider trong bán kính attackRange
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

        if (hitEnemies.Length >= 1)
        {
            target = hitEnemies[0].transform;
        }

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    public void ChangeState(IState state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = state;
        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }
    public void ResetTarget()
    {
        target = null;
    }
    public override void Attack()
    {
        base.Attack();
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0; // bỏ chiều cao
        transform.rotation = Quaternion.LookRotation(lookPos);
        StartCoroutine(WaitAttack());

    }
    public override void OnDeath()
    {
        base.OnDeath();
        ChangeState(new DeathState());
    }
    IEnumerator WaitAttack()
    {
        yield return new WaitForSeconds(0.3f);

        var weapons = HBPool.Spawn<Weapon>(PoolType.Bullet, muzzle.position, Quaternion.identity);
        weapons.OnInit(target, this);
        weapons.DespawnWeapon();
    }

}
