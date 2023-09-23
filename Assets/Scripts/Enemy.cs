using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Slider slider;

    public GameObject vfxDeath;

    private void Start()
    {
        currentHealth = maxHealth;
        SetMaxHealth(maxHealth);
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void TakeDamage(int damge)
    {
        currentHealth -= damge;

        SetHealth(currentHealth);

        if (currentHealth == 0)
        {
            GameObject vfx = Instantiate(vfxDeath, transform.position, Quaternion.identity) as GameObject;
            Destroy(vfx, 1f);

            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(gameObject);

            GameManager.Instance.CheckLevelUp();

            gameObject.SetActive(false);
        }
    }
}
