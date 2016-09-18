using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public GameController gameController;
    private AudioSource hurtSound;
    private AudioSource screamSound;

    public int startingHealth = 100;
    public int currentHealth;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    
    //PlayerShooting playerShooting;
    bool isDead;
    bool damaged;


    void Awake()
    {
        //playerShooting = GetComponentInChildren <PlayerShooting> ();
        currentHealth = startingHealth;
        isDead = false;
        hurtSound = GetComponent<AudioSource>();
        screamSound = GameObject.Find("ScreamSound").GetComponent<AudioSource>();
    }


    void Update()
    {
        damaged = false;
    }


    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
        else
        {
            hurtSound.Play();
        }

    }


    void Death()
    {
        isDead = true;

        screamSound.Play();

        gameController.GameOver();

        //playerShooting.DisableEffects ();
   
        //playerShooting.enabled = false;
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
