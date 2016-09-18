using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    GameController gameController;
    private AudioSource dieSound;

    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    
    bool isDead;
    bool isSinking;


    void Awake()
    {
        currentHealth = startingHealth;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        dieSound = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage(int amount)
    {
        if (isDead)
            return;
        
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Death();
        }
    }


    void Death()
    {
        gameController.GotOne();
        isDead = true;
        StartSinking();

        dieSound.Play();
    }


    public void StartSinking()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        //ScoreManager.score += scoreValue;
        Destroy(gameObject, 2f);
    }
}
