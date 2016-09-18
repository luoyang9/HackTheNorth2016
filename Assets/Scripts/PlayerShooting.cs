using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float timeBetweenBullets = 0.5f;
    public GameObject projectile;
	public AudioSource bulletSound;

    PlayerHealth playerHealth;

    private Vector3 _shooterOffset;
    float timer;
    Light gunLight;
    float effectsDisplayTime = 0.2f;


    void Awake()
    {
        gunLight = GetComponent<Light>();
        _shooterOffset = new Vector3(0.0f, -0.4f, 0.0f);
        playerHealth = GetComponent<PlayerHealth>();
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (GvrViewer.Instance.VRModeEnabled && GvrViewer.Instance.Triggered && playerHealth.currentHealth > 0)
        {
            timer = 0f;
            gunLight.enabled = true;

            GameObject vrLauncher = GvrViewer.Instance.GetComponentInChildren<GvrHead>().gameObject;
            Vector3 transformedOffset = vrLauncher.transform.rotation * _shooterOffset;
            Instantiate(projectile, vrLauncher.transform.position + transformedOffset, vrLauncher.transform.rotation);

            bulletSound.Play();
        }

        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }
    }


    public void DisableEffects()
    {
        gunLight.enabled = false;
    }

}
