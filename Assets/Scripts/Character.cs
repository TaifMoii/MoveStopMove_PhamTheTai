using UnityEngine;


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
    public bool isPlayer;
    private int score;
    private LineRenderer line;


    public virtual void OnInit(Vector3 des)
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
    public virtual void Dead()
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
        score++;
        if (score % 2 == 0 && score <= 10)
        {
            attackRange += 1;
            radius += 1;
        }
        Level.Ins.UpdateEnemy();
        Grow();

    }
    void Grow()
    {
        skin.localScale += Vector3.one * 0.2f;
    }
    public virtual void OnDeath()
    {
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
