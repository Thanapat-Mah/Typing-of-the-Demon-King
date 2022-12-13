using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Gradient gradient;
    public Image fill;
    public float monsterAttackTime = 1f;
    public float bossAttackTime = 2f;
    private float playerHealth;
    private float attackTime;
    private float currentTime;

    private void Start()
    {
        playerHealth = healthSlider.maxValue;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            currentTime = attackTime;
            healthSlider.value = playerHealth;
            fill.color = gradient.Evaluate(playerHealth);
        }
    }

    public void SetMaxHealth(int health)
    {
        healthSlider.maxValue = health;
        playerHealth = health;
        healthSlider.value = playerHealth;
        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int health)
    {
        playerHealth = health;
        fill.color = gradient.Evaluate(playerHealth);
    }
    public void MonsterDamage()
    {
        attackTime = monsterAttackTime;
    }
    
    public void BossDamage()
    {
        attackTime = bossAttackTime;
    }
    
    public void DamageHealth(int damage)
    {
        currentTime = attackTime;
        playerHealth -= damage;
    }
    
    public float getHealth()
    {
        return playerHealth;
    }
}
