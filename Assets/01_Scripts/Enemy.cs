using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    new Renderer renderer;
    Renderer targetRenderer;
    [Header("Referencias")]
    public EnemyType type = EnemyType.Melee;
    //public GameObject shootPrefab;
    public GameObject destructionEffect;
    public GameObject damageEffect;
    public Transform firePoint;
    public Transform target;
    public GameObject targetGo;
    public bool targetInRange = false;
    public List<GameObject> powerUpPrefabs;

    [Header("Estadisticas")]
    public float timer = 0;
    public float timeBtwAttacks = 3f;
    public float attackDuration = 3f;
    public float attackTimer = 0;
    public float speed = 1f;
    public float life = 3f;
    public float maxLife = 3f;
    public float damage = 1f;
    public float attackRange;

    [Header("Animator")]
    public Animator anim;

    [Header("Sounds")]
    public AudioClip explosionSound;
    public AudioClip shootSound;
    public AudioClip punchSound;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        targetGo = GameObject.FindGameObjectWithTag("Player");
        targetRenderer = targetGo.GetComponent<Renderer>();
        if (targetGo != null)
            target = targetGo.transform;
        if (type == EnemyType.Melee)
            attackRange = 2f;
        else
            attackRange = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        layers();
        CheckRange();
        if (targetInRange)
            Attack();
        else
            Movement();
    }

    void Attack()
    {
        if(attackTimer < attackDuration)
        {
            attackTimer += Time.deltaTime;

            if (type == EnemyType.Melee && renderer.sortingOrder == targetRenderer.sortingOrder)
            {
                anim.SetTrigger("MeleeAttack");
                AudioManager.instance.PlaySFX(punchSound);
            }
            else if (type == EnemyType.Ranged)
            {
                //Instantiate(shootPrefab, firePoint.position, firePoint.rotation);
                //anim.SetTrigger("RangedAttack");
                AudioManager.instance.PlaySFX(shootSound);
            }
        }
        else
        {
            if (timer < timeBtwAttacks)
                timer += Time.deltaTime;
            else
            {
                timer = 0;
                attackTimer = 0;
            }
        }
    }

    void Movement()
    {
        anim.SetTrigger("Walk");

        //Mirror
        if (transform.position.x < target.position.x)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);

        //Movement
        transform.Translate(speed * Time.deltaTime, 0, 0);
        if(transform.position.y < target.position.y)
            transform.Translate(0, speed * Time.deltaTime, 0);
        else if(transform.position.y > target.position.y)
            transform.Translate(0, -(speed * Time.deltaTime), 0);
    }


    void CheckRange()
    {
        if (target != null)
        {
            float distance = Vector2.Distance(transform.position, target.position);
            if (distance <= attackRange)
                targetInRange = true;
            else
                targetInRange = false;
        }
        else
            targetInRange = false;
    }

    public void TakeDamage(float amount)
    {
        life -= amount;
        if (life <= 0)
        {
            AudioManager.instance.PlaySFX(explosionSound);
            if (Random.Range(0, 4) == 1)
            {
                int p = Random.Range(0, powerUpPrefabs.Count);
                Instantiate(powerUpPrefabs[p], transform.position, Quaternion.Euler(0, 0, 0));
            }
            Instantiate(destructionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void layers()
    {
        if (transform.position.y <= -3)
            renderer.sortingOrder = 2;
        else if (transform.position.y >= 0)
            renderer.sortingOrder = 0;
        else
            renderer.sortingOrder = 1;
    }
}

public enum EnemyType
{
    Melee,
    Ranged
}
