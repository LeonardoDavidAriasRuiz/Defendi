using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerLogic : MonoBehaviour
{
    public GameObject enemy; // Array para almacenar diferentes tipos de enemigos
    public float initialSpawnDelay = 0.5f; // Retraso inicial antes de que comience la primera oleada
    public float timeBetweenWaves = 18f; // Tiempo entre oleadas
    private int waveNumber = 3; // Número de oleadas
    private int enemiesToSpawn = 12; // Número inicial de enemigos por oleada
    private float timer = 0f;
    private int a, b, c;
    private bool enamiesSpawned = false;
    private int leastLife = 1;

    void Start()
    {
        // Comienza con un retraso antes de que comience la primera oleada
        a = 12;
        b = 0;
        c = 0;
        Invoke("StartNextWave", initialSpawnDelay);
    }

    void Update()
    {
        // Controla el tiempo entre oleadas
        if (waveNumber > 0 && enamiesSpawned)
        {
            timer += Time.deltaTime;
            if (timer >= timeBetweenWaves)
            {
                enamiesSpawned = false;
                StartNextWave();
                timer = 0f;
            }
        }
    }

    void StartNextWave()
    {
        waveNumber++;
        enemiesToSpawn = 10 + waveNumber * 2; // Aumenta la cantidad de enemigos por oleada con cada nueva oleada

        // Genera los enemigos de la oleada actual
        StartCoroutine(SpawnEnemies());
    }

    // Funcion para crear a las oleadas de enemigos
    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            GameObject enemyInstance = Instantiate(enemy, transform.position, transform.rotation);

            // Obtén una referencia al script EnemyLogic del enemigo instanciado
            EnemyLogic enemyLogic = enemyInstance.GetComponent<EnemyLogic>();

            int life = 1;
            // Configura la vida del enemigo
            if ((i + 1) <= a)
            {
                life = leastLife;
            }
            else if ((i + 1) <= (a + b))
            {
                life = leastLife + (leastLife >= 9 ? 0 : 1);
            }
            else if ((i + 1) <= (enemiesToSpawn))
            {
                life = leastLife + (leastLife >= 9 ? 0 : 2);
            }

            // Genera el enemigo en la posición del spawner
            enemyLogic.Initialize(life);

            // Espera un breve tiempo antes de generar el siguiente enemigo
            float timeToRemoveBetwenEnemy = waveNumber / 50;
            if (timeToRemoveBetwenEnemy >= 0.90)
            {
                timeToRemoveBetwenEnemy = 0.09f;
            }
            yield return new WaitForSeconds(0.95f - timeToRemoveBetwenEnemy);
        }

        // Condicionales para establecer el incremento de las oleadas
        a -= 4;
        if (a == 0)
        {
            a = b;
            b = c;
            c = 0;
            leastLife += leastLife >= 9 ? 0 : 1;
        }
        if (waveNumber < 4)
        {
            b += 4;
            c = 0;
        }
        else
        {
            b += 4;
            c = enemiesToSpawn - a - b;
        }
        enamiesSpawned = true;
    }
}