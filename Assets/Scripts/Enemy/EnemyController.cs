using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : Character
{
    private EIState currentState;
    private Transform target;
    private NavMeshAgent agent;
    Vector3 deadPoi;
    public Transform muzzle;

    public bool isMoving;
    public LayerMask enemyLayer;

    public Transform Target => target;
    public float waitTime = 2f;

    void Start()
    {
        OnInit();
    }
    void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }
    public override void OnInit()
    {
        base.OnInit();
        agent = GetComponent<NavMeshAgent>();
        isMoving = false;
        ResetTarget();
        isDead = false;
        ChangeState(new EIdleState());
    }
    public void ChangeState(EIState state)
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
    public override void Run()
    {
        base.Run();
        isMoving = true;
        StartCoroutine(WanderLoop());
    }
    IEnumerator WanderLoop()
    {
        // chọn điểm random toàn NavMesh
        Vector3 destination = NavMeshUtils.GetRandomPointOnNavMesh();
        agent.SetDestination(destination);

        // đợi tới khi đi xong
        while (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)

            yield return null;

        isMoving = false;
    }

    public void FindTarget()
    {
        // Lấy tất cả Collider trong bán kính attackRange
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);


        foreach (var hitCollider in hitEnemies)
        {
            if (hitCollider.gameObject == this.gameObject)
            {
                continue; // Ignore the calling object
            }
            target = hitCollider.transform;

        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    public void ResetTarget()
    {
        target = null;
    }

    public override void OnDeath()
    {
        base.OnDeath();
        OnDespawn();
        ChangeState(new EDeathState());

    }
    IEnumerator WaitAttack(Transform enemy)
    {
        yield return new WaitForSeconds(0.3f);

        var weapons = HBPool.Spawn<Weapon>(PoolType.Bullet, muzzle.position, Quaternion.identity);
        weapons.OnInit(enemy.transform, this);
        weapons.DespawnWeapon();
    }
    public override void Attack()
    {
        base.Attack();
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0; // bỏ chiều cao
        transform.rotation = Quaternion.LookRotation(lookPos);

        StartCoroutine(WaitAttack(target.transform));

    }
    public override void OnDespawn()
    {
        base.OnDespawn();
        agent.isStopped = true;
        StartCoroutine(WaitDespawn());
    }
    IEnumerator WaitDespawn()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }

    public void WaitIdles()
    {
        StartCoroutine(WaitIdle());
    }
    IEnumerator WaitIdle()
    {
        yield return new WaitForSeconds(1f);
    }
}

