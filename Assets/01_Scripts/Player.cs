using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    new Renderer renderer;
    Animator animator;
    Rigidbody2D rb;
    //[Header("Referencias")]
    [Header("Estadisticas")]
    public float Speed = 7f;
    public bool canJump = true;
    public float jumpForce = 7f;
    public bool[] backpack = new bool[4];
    public List<GameObject> powerUpPrefabs;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        renderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.Sleep();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        layers();
        Mirror();
        UsePowerUp();
    }
        
    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        animator.SetFloat("Speed",Mathf.Abs(x != 0? x: y));
        rb.velocity = new Vector2(x * Speed, y * Speed);
    }

    void Mirror()
    {
        if (rb.velocity.x < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else if (rb.velocity.x > 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void layers()
    {
        if (transform.position.y <= -3)
            renderer.sortingOrder = 2;
        else if(transform.position.y >= 0)
            renderer.sortingOrder = 0;
        else
            renderer.sortingOrder = 1;
    }

    public void CollectPowerUp(PowerUpType powerUpType)
    {
        switch (powerUpType)
        {
            case PowerUpType.Gun:
                Debug.Log("Collected gun");
                if (!backpack[0])
                    backpack[0] = true;
                break;
            case PowerUpType.Scissors:
                Debug.Log("Collected scissors");
                if (!backpack[1])
                    backpack[1] = true;
                break;
            case PowerUpType.Light:
                Debug.Log("Collected light");
                if (!backpack[2])
                    backpack[2] = true;
                break;
            case PowerUpType.Magnet:
                Debug.Log("Collected magnet");
                if (!backpack[3])
                    backpack[3] = true;
                break;
        }
    }

    void UsePowerUp()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (backpack[0])
            {
                Debug.Log("Used Gun");
                Instantiate(powerUpPrefabs[0], transform.position, Quaternion.Euler(0, 0, 0));
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (backpack[1])
            {
                Debug.Log("Used Scissors");
                Instantiate(powerUpPrefabs[1], transform.position, Quaternion.Euler(0, 0, 0));
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (backpack[2])
            {
                Debug.Log("Used Light");
                Instantiate(powerUpPrefabs[2], transform.position, Quaternion.Euler(0, 0, 0));
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (backpack[3])
            {
                Debug.Log("Used Magnet");
                Instantiate(powerUpPrefabs[3], transform.position, Quaternion.Euler(0, 0, 0));
            }
        }
    }
}
