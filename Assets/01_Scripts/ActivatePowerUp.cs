using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePowerUp : MonoBehaviour
{
    public PowerUpType type;
    public float speed = 4f;
    public float timer = 0f;
    public float timeToDestroy = 5f;
    [Header("Sounds")]
    public AudioClip activationEffect;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlaySFX(activationEffect);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < timeToDestroy)
        {
            timer += Time.deltaTime;
            switch (type)
            {
                case PowerUpType.Gun:

                    break;
                case PowerUpType.Scissors:

                    break;
                case PowerUpType.Light:

                    break;
                case PowerUpType.Magnet:

                    break;
            }
        }
        else
            Destroy(gameObject);        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy e = collision.gameObject.GetComponent<Enemy>();
            e.TakeDamage(1f);
        }        
    }
}
