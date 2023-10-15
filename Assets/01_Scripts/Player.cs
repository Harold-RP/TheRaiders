using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
<<<<<<< Updated upstream
    public float Speed = 7f;
=======
    new Renderer renderer;
    public Animator animator;
    Rigidbody2D rb;

    [Header("Estadisticas")]
    public float Speed = 7f;
    public float revives = 3f;
    public bool[] backpack = new bool[4];
    public List<GameObject> powerUpPrefabs;
    public float TopLeft = -5.4f;
    public float BotomWall = -3.5f;
    [Header("UI")]
    public Image lifeBar;
    public float life = 10f;
    public float maxLife = 10f;
    public Image energyBar;
    public float energy = 0f;
    public float maxEnergy = 10f;
    public TextMeshProUGUI livesText;
    [Header("Sounds")]
    public AudioClip punchSound;
    public AudioClip takeDmgSound;
>>>>>>> Stashed changes

    public float Horizontal;
    public float Vertical;
    Animator animator;
    bool facing;
    private void Awake()
    {
<<<<<<< Updated upstream
        animator = GetComponent<Animator>();
=======
        renderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();
>>>>>>> Stashed changes
    }
    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream
        
=======
        lifeBar.fillAmount = life / maxLife;
        energyBar.fillAmount = energy / maxEnergy;
        livesText.text = "Lives = " + revives;
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        animator.SetFloat("Speed",Mathf.Abs(Horizontal!=0? Horizontal: Vertical));
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Horizontal*Speed, Vertical*Speed, 0.0f);
        transform.position = transform.position + movement*Time.deltaTime;
        Flip(Horizontal);
    }
    private void Flip(float Horizontal)
    {
        if (Horizontal<0 && !facing || Horizontal >0 && facing)
=======
        Movement();
        layers();
        UsePowerUp();
        Punch();
        walls();
    }

    void Movement()
    {
        //Mirror
        if (rb.velocity.x < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else if (rb.velocity.x > 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);

        //Movement
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        animator.SetFloat("Speed",Mathf.Abs(x != 0? x: y));
        rb.velocity = new Vector2(x * Speed, y * Speed);
    }

    void Punch()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }

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

    void walls()
    {
        Vector3 posicionActual = transform.position;
        posicionActual.y = Mathf.Clamp(posicionActual.y, TopLeft, BotomWall);
        transform.position = posicionActual;
    }

    public void TakeDamage(float amount)
    {
        life -= amount;
        lifeBar.fillAmount = life / maxLife;
        if (life <= 0)
        {
            AudioManager.instance.PlaySFX(takeDmgSound);
            //Instantiate(explosionEffect, transform.position, transform.rotation);
            if (revives == 0)
            {
                Destroy(gameObject);
                UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
            }
            else
            {
                revives--;
                life = 10f;
                livesText.text = "Lives = " + revives;
                lifeBar.fillAmount = life / maxLife;
            }
        }
    }

    public void CollectPowerUp(PowerUpType powerUpType)
    {
        switch (powerUpType)
>>>>>>> Stashed changes
        {
            facing = !facing;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale=scale;

        }
    }

}
