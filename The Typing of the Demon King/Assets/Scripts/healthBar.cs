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
    private float playerHealth;

    private void Start()
    {
        playerHealth = healthSlider.maxValue;
    }

    private void Update()
    {
        healthSlider.value = playerHealth;
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
        fill.color = gradient.Evaluate(healthSlider.normalizedValue);
    }
    public void DamageHealth(int damage)
    {
        playerHealth -= damage;
        fill.color = gradient.Evaluate(healthSlider.normalizedValue);
    }
    public float getHealth()
    {
        return playerHealth;
    }
}
