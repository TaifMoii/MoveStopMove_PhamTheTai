using System;
using System.Collections;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;
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
    public Rigidbody rb;
    private IState currentState;
    private Transform target;
    CameraFollow cameraFollow;



    void Start()
    {
        OnInit(transform.position);
    }

    public override void OnInit(Vector3 des)
    {
        cameraFollow = Camera.main.GetComponent<CameraFollow>();
        rb = GetComponent<Rigidbody>();
        base.OnInit(des);
        ChangeState(new MainMenuState());
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

    public void BackMainMenu()
    {
        OnInit(transform.position);
    }
    public void ChangeGamePLay()
    {
        ChangeState(new IdleSate());
    }


    void FixedUpdate()
    {
        if (isDead)
        {
            rb.velocity = Vector3.zero;
            return;
        }
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

        StartCoroutine(WaitAttack(target.transform));

    }
    public override void OnDeath()
    {
        base.OnDeath();
        ChangeState(new DeathState());
    }
    IEnumerator WaitAttack(Transform enenmy)
    {
        yield return new WaitForSeconds(0.3f);

        var weapons = HBPool.Spawn<Weapon>(PoolType.Bullet, muzzle.position, Quaternion.identity);
        weapons.OnInit(enenmy.transform, this);
        weapons.DespawnWeapon();
    }
    public void AddYOffset(CinemachineVirtualCamera vcam)
    {
        var transposer = vcam.GetCinemachineComponent<CinemachineFramingTransposer>();
        if (transposer != null)
        {
            transposer.m_TrackedObjectOffset.y += 1f;   // cộng thêm 1 vào Y
        }
    }

}
