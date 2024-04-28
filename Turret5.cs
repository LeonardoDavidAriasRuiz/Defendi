using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Turret5 : MonoBehaviour
{
    public float range;
    public GameObject toxicPrefab;
    private GameObject toxic;
    private int targetCount;
    private GameObject[] targets;
    private float timer;
    private bool set = false;

    Vector3 offset;
    Collider2D collider2d;

    private MoneyLogic moneyLogic;

    void Update()
    {
        if (set)
        {
            FindNearestEnemy();
        }
    }

    // Funcion para encontrar al objetivo mas adelantado en el rango
    void FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("EnemyTag");
        timer += Time.deltaTime;
        if (timer >= 1.8) {
            foreach (GameObject enemy in enemies)
            {
                if (Vector2.Distance(transform.position, enemy.transform.position) <= range)
                {
                    EnemyLogic enemyLogic = enemy.GetComponent<EnemyLogic>();
                    int enemyLife = enemyLogic.life;
                    enemyLogic.GotAttacted(1);
                    GameObject moneyIndicator = GameObject.FindGameObjectWithTag("MoneyTag");
                    moneyIndicator.GetComponent<MoneyLogic>().AddMoney(1);
                }
            }
            timer = 0;
        }
    }

    // Metodos para el movimiento de la torreta con el mouse
    void Awake()
    {
        moneyLogic = GameObject.FindObjectOfType<MoneyLogic>();
        if (!set && moneyLogic.moneyScore >= 250)
        {
            collider2d = GetComponent<Collider2D>();
        }
    }

    void OnMouseDown()
    {
        if (!set && moneyLogic.moneyScore >= 250)
        {
            offset = transform.position - MouseWorldPosition();
        }
    }

    void OnMouseDrag()
    {
        if (!set && moneyLogic.moneyScore >= 250)
        {
            transform.position = MouseWorldPosition() + offset;
        }
    }

    void OnMouseUp()
    {
        if (!set && moneyLogic.moneyScore >= 250)
        {
            toxic = Instantiate(toxicPrefab, transform.position, transform.rotation);
            set = true;
            Turret5Spawner turretSpawner = GameObject.FindFirstObjectByType<Turret5Spawner>();
            turretSpawner.spawned = false;
            moneyLogic.RemoveMoney(250);
        }
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }

    // Método para destruir la torre
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
