using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieNPC : MonoBehaviour
{
    public int minHealthRange = 10;
    public int maxHealthRange = 20;
    public int maxHealth;
    private int currentHealth;

    void Start()
    {
        maxHealth = Random.Range(minHealthRange, maxHealthRange + 1);
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Brick")
        {
            currentHealth -= 2;
            Destroy(other.gameObject);

            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
