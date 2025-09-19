using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;

public class Character : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private string currentAnim;


    public virtual void OnInit()
    {
        ChangeAnim("idle");
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
    public void OnDespawn()
    {
        ChangeAnim("dead");
    }
    public virtual void Attack()
    {
        ChangeAnim("attack");
    }
    public void Run()
    {
        ChangeAnim("run");
    }
    public void Idle()
    {
        ChangeAnim("idle");
    }
    public void Dance()
    {
        ChangeAnim("dance");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            OnDespawn();
        }
    }
}
