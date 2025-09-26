using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UIElements;

public class Character : GameUnit
{
    [SerializeField] private Animator animator;
    private string currentAnim;
    public Transform skin;
    public float attackRange;
    public bool isDead;
    public int segments = 100;   // độ mịn vòng tròn
    public float radius = 5f;    // bán kính tấn công
    public Color color = Color.white;

    private LineRenderer line;


    public virtual void OnInit()
    {
        ChangeAnim("idle");
        isDead = false;
        line = GetComponent<LineRenderer>();
        line.positionCount = segments + 1;
        line.useWorldSpace = false;
        line.loop = true;
        line.widthMultiplier = 0.05f;
        line.material = new Material(Shader.Find("Unlit/Color"));
        line.material.color = color;

        DrawCircle();
    }
    protected void ChangeAnim(string animName)
    {
        if (currentAnim != animName)
        {
            animator.ResetTrigger(animName);
            currentAnim = animName;
            animator.SetTrigger(currentAnim);
        }
    }
    public virtual void OnDespawn()
    {
        ChangeAnim("dead");
    }
    public virtual void Attack()
    {
        ChangeAnim("attack");
    }
    public virtual void Run()
    {
        ChangeAnim("run");
    }
    public virtual void Idle()
    {
        ChangeAnim("idle");
    }
    public virtual void Dance()
    {
        ChangeAnim("dance");
    }

    public void UpdateScore()
    {
        attackRange += 1;
        radius += 1;

        Grow();

    }
    void Grow()
    {
        skin.localScale += Vector3.one * 0.2f;
    }
    public virtual void OnDeath()
    {
        isDead = true;

    }
    public void DrawCircle()
    {
        float angle = 0f;
        for (int i = 0; i <= segments; i++)
        {
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            float z = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
            line.SetPosition(i, new Vector3(x, 0, z));
            angle += (360f / segments);
        }
    }
}
