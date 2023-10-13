using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpType type;
    public float speed = 4f;
    public float timer = 0f;
    public float timeToDestroy = 5f;
    [Header("Sounds")]
    public AudioClip soundEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < timeToDestroy)
        {
            timer += Time.deltaTime;
        }
        else
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.PlaySFX(soundEffect);
            Player p = collision.gameObject.GetComponent<Player>();
            p.CollectPowerUp(type);
            Destroy(gameObject);
        }        
    }
}

public enum PowerUpType
{
    Light,
    Magnet,
    Scissors,
    Gun
}