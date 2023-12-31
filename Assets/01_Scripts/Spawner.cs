using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timer = 0f;
    public float timeBtwSpawn = 5f;

    [Header("Referencias")]
    public List<GameObject> enemyPrefabs;
    //public GameObject bossPrefab;
    public Transform topPoint;
    public Transform bottomPoint;

    [Header("Estadisticas")]
    public bool spawnNewHorde = false;
    public bool bossSpawned = false;
    public float defeatedHordes = 0f;
    public float hordeKilledEnemies = 0f;
    public float spawnBossAtNHorde = 10f;

    [Header("Sounds")]
    public AudioClip bossTheme;

    public static Spawner instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < timeBtwSpawn)
        {
            timer += Time.deltaTime;
        }
        else
        {

            if (!bossSpawned)
            {
                if (defeatedHordes < spawnBossAtNHorde)
                {
                    timer = 0;

                    if (!spawnNewHorde)//cambiar
                    {
                        int enemy = Random.Range(0, enemyPrefabs.Count);
                        Instantiate(enemyPrefabs[enemy], new Vector3(transform.position.x, topPoint.position.y, 0), Quaternion.Euler(0, 180, 0));
                        Instantiate(enemyPrefabs[enemy], new Vector3(transform.position.x, bottomPoint.position.y, 0), Quaternion.Euler(0, 180, 0));
                    }
                }
                else
                {
                    bossSpawned = true;
                    //Instantiate(bossPrefab, transform.position, Quaternion.Euler(0, 180, 0));
                }
            }

        }
    }

    public void NewHorde()
    {
        if (!spawnNewHorde)//cambiar
        {
            int enemy = Random.Range(0, enemyPrefabs.Count);
            Instantiate(enemyPrefabs[enemy], new Vector3(transform.position.x, topPoint.position.y, 0), Quaternion.Euler(0, 180, 0));
            Instantiate(enemyPrefabs[enemy], new Vector3(transform.position.x, bottomPoint.position.y, 0), Quaternion.Euler(0, 180, 0));
        }
    }

    public void AddDefeatedHorde()
    {
        defeatedHordes++;
        if (!bossSpawned && defeatedHordes >= spawnBossAtNHorde)
        {
            AudioManager.instance.SetMusic(bossTheme);
        }
    }
}
