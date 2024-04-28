using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Turret2 : MonoBehaviour
{
    public float range;
    public GameObject bombPrefab;

    private GameObject target;
    private float timer;
    private bool set = false;

    Vector3 offset;
    Collider2D collider2d;
    public string destinationTag = "DropArea";

    private MoneyLogic moneyLogic;

    void Update()
    {

        if (set)
        {
            // Busca al enemigo más cercano dentro del rango
            FindNearestEnemy();

            // Si hay un objetivo, apunta y dispara


            if (target != null)
            {
                Fire();
            }
        }
    }

    // Funcion para encontrar al objetivo mas adelantado en el rango
    void FindNearestEnemy()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("EnemyTag");

        foreach (GameObject enemy in enemies)
        {
            if (Vector2.Distance(transform.position, enemy.transform.position) <= range)
            {
                target = enemy;
                break;
            }

            target = null;
        }
    }

    void Fire()
    {
        // Dispara un proyectil hacia el objetivo

        timer += Time.deltaTime;

        // Si el contador de tiempo supera el tiempo de disparo deseado
        if (timer >= 1.6)
        {
            // Dispara una bala si hay un objetivo
            if (target != null)
            {
                GameObject bulletInstance = Instantiate(bombPrefab, transform.position, transform.rotation);
                BombLogic bullet = bulletInstance.GetComponent<BombLogic>();
                bullet.Initialize(target);
            }

            // Reinicia el contador de tiempo
            timer = 0f;
        }
    }

    // Metodos para el movimiento de la torreta con el mouse
    void Awake()
    {
        moneyLogic = GameObject.FindObjectOfType<MoneyLogic>();
        if (!set && moneyLogic.moneyScore >= 125)
        {
            collider2d = GetComponent<Collider2D>();
        }
    }

    void OnMouseDown()
    {
        if (!set && moneyLogic.moneyScore >= 125)
        {
            offset = transform.position - MouseWorldPosition();
        }
    }

    void OnMouseDrag()
    {
        if (!set && moneyLogic.moneyScore >= 125)
        {
            transform.position = MouseWorldPosition() + offset;
        }
    }

    void OnMouseUp()
    {
        if (!set && moneyLogic.moneyScore >= 125)
        {
            set = true;
            Turret2Spawner turretSpawner = GameObject.FindFirstObjectByType<Turret2Spawner>();
            turretSpawner.spawned = false;
            moneyLogic.RemoveMoney(125);
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
