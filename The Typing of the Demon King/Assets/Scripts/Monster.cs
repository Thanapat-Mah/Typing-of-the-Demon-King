using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    public void Attack ()
    {
        transform.parent.GetComponentInChildren<Border>().SetAttack();
    }
    
    public void AttackAnimation ()
    {
        _animator.SetTrigger("Attack");
    }
    public float GetAttackAnimationLength()
    {
        return _animator.GetCurrentAnimatorStateInfo(0).length;
    }
    public void Active ()
    {
        transform.parent.GetComponentInChildren<Border>().SetActive();
    }
    public void Idle ()
    {
        transform.parent.GetComponentInChildren<Border>().SetInactive();
    }
    // public void RemoveMonster ()
    // {
    //     Destroy(gameObject);
    // }
    
    public IEnumerator RemoveMonster ()
    {
        _animator.SetTrigger("Defeated");
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }
}
