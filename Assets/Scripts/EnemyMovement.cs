using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    NavMeshAgent nav;
    EnemyHealth enemyHealth;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if (enemyHealth.currentHealth > 0)
        {
            if (Vector3.Distance(transform.position, player.transform.position) <= 1)
            {
                nav.enabled = false;
            }
            else
            {
                nav.enabled = true;
                nav.SetDestination(player.position);
            }
        }
    }
}
