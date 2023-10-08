using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Referencias")]
    public EnemyType type = EnemyType.Melee;
    //public GameObject shootPrefab;
    //public GameObject destructionEffect;
    public Transform firePoint;
    public Transform target;
    public bool targetInRange = false;
    public List<GameObject> powerUpPrefabs;

    [Header("Estadisticas")]
    public float timer = 0;
    public float timeBtwAttacks = 3f;
    public float attackDuration = 3f;
    public float attackTimer = 0;
    public float speed = 2f;
    public float life = 3f;
    public float maxLife = 3f;
    public float damage = 1f;
    public float attackRange = 10f;

    //[Header("UI")]
    //public Image lifeBar;

    [Header("Animator")]
    public Animator anim;

    //[Header("Sounds")]
    //public AudioClip explosionSound;
    //public AudioClip shootSound;

    // Start is called before the first frame update
    void Start()
    {
        GameObject targetGo = GameObject.FindGameObjectWithTag("Player");
        if (targetGo != null)
            target = targetGo.transform;
        //lifeBar.fillAmount = life / maxLife;
    }

    // Update is called once per frame
    void Update()
    {
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

            if (type == EnemyType.Melee)
            {
                //trigger melee attack  ->  Collision
                anim.SetTrigger("MeleeAttack");
            }
            else if (type == EnemyType.Ranged)
            {
                //Instantiate(shootPrefab, firePoint.position, firePoint.rotation);
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
        if (transform.position.x < target.position.x)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);
        transform.Translate(speed * Time.deltaTime, 0, 0);
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
        //lifeBar.fillAmount = life / maxLife;
        if (life <= 0)
        {
            //AudioManager.instance.PlaySFX(explosionSound);
            //if (Random.Range(0, 2) == 1)
            //{
            //    int p = Random.Range(0, powerUpPrefabs.Count);
            //    Instantiate(powerUpPrefabs[p], transform.position, Quaternion.Euler(0, 0, 180));
            //}
            //Spawner.instance.addKilledEnemies();
            //Instantiate(destructionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

public enum EnemyType
{
    Melee,
    Ranged
}
