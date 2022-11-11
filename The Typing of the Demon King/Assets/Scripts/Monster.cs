using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    
    public void Attack ()
    {
        transform.parent.GetComponentInChildren<Border>().SetAttack();
    }
    public void Active ()
    {
        transform.parent.GetComponentInChildren<Border>().SetActive();
    }
    public void Idle ()
    {
        transform.parent.GetComponentInChildren<Border>().SetInactive();
    }
    public void RemoveMonster ()
    {
        Destroy(gameObject);
    }
}
