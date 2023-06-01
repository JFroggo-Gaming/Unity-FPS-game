using UnityEngine;

public enum MaterialType
{
    Wood,
    Metal,
    Barrel,
    Skin,
    Stone,
    Wall
}

public class ObjectHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public MaterialType materialType;
    public GameObject smallExplosionEffect;

    public AudioSource woodHitSound;
    public AudioSource metalHitSound;
    public AudioSource characterHitSound;
    public AudioSource destructionSound;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Play appropriate hit sound based on material type
        switch (materialType)
        {
            case MaterialType.Wood:
                if (woodHitSound != null)
                {
                    woodHitSound.Play();
                }
                break;
            case MaterialType.Metal:
                if (metalHitSound != null)
                {
                    metalHitSound.Play();
                }
                break;
            case MaterialType.Skin:
                if (characterHitSound != null)
                {
                    characterHitSound.Play();
                }
                break;
            default:
                break;
        }

        if (currentHealth <= 0)
        {
            DestroyObject();
        }
    }

    private void DestroyObject()
    {
        // Play destruction sound
        if (destructionSound != null)
        {
            destructionSound.Play();
        }

        // Spawn small explosion effect
        if (smallExplosionEffect != null)
        {
            Instantiate(smallExplosionEffect, transform.position, transform.rotation);
        }

        // Handle object destruction here
        Destroy(gameObject);
    }
}
