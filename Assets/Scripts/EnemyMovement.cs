using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    //EnemyHealth enemyHealth;
    NavMeshAgent nav;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        //if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        //{
        if(nav.isActiveAndEnabled)
            nav.SetDestination(player.position);
        //}
        //else
        //{
        //    nav.enabled = false;
        //}
    }
}
