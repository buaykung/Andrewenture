using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerlife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    

    private void OnCollisionEnter2D(Collision2D collission) 
    {
        if (collission.gameObject.CompareTag("Trap"))
        {
            TakeDamage(20);
        }
        if (currentHealth == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        anim.SetBool("Death",true);
    }
    
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        healthBar.Sethealth(currentHealth);
    }

}
