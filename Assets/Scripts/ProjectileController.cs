using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour
{

    float speed = 10.0f;
    float timer = 0.5f;
    int damage = 10;

    void Start()
    {
        this.GetComponent<Rigidbody>().velocity = this.transform.forward * speed;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 10f) {
            Destroy(gameObject);
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            collision.collider.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.collider.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }

}
