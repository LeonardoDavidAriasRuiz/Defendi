using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLogic : MonoBehaviour
{
    //private Transform target;
    public float speed = 1;
    public int damage = 3;
    private GameObject target;
    public float maxScale = 3f; // Escala máxima que quieres alcanzar
    public float totalDistance;
    private Vector2 initialScale; // Escala inicial del objeto

    // Método para inicializar la bomba con un objetivo
    public void Initialize(GameObject enemy)
    {
        target = enemy;
        initialScale = transform.localScale;
        totalDistance = Vector3.Distance(transform.position, target.transform.position);
    }

    void Update()
    {
        if (target != null)
        {
            // Mueve el disparo hacia el objetivo
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, 20 * Time.deltaTime);

            float remainingDistance = Vector2.Distance(transform.position, target.transform.position);

            // Calcula la escala en función de la distancia utilizando una función parabólica inversa
            float scale;
            if (remainingDistance <= totalDistance / 2)
            {
                // Escala aumenta gradualmente hasta llegar a maxScale en la mitad del recorrido
                scale = Mathf.Lerp(1, maxScale, Mathf.Pow(remainingDistance / (totalDistance / 2), 2));
            }
            else
            {
                // Escala disminuye gradualmente desde maxScale hasta 1 en la segunda mitad del recorrido
                float remainingDistanceSecondHalf = remainingDistance - totalDistance / 2;
                scale = Mathf.Lerp(maxScale, 1, Mathf.Pow(remainingDistanceSecondHalf / (totalDistance / 2), 2));
            }

            // Establece la escala del objeto
            transform.localScale = initialScale * scale;

            // Logica para cuando el disparo llega al objetivo
            if (target.transform.position.x == transform.position.x && target.transform.position.y == transform.position.y)
            {
                EnemyLogic enemyLogic = target.GetComponent<EnemyLogic>();
                int enemyLife = enemyLogic.life;
                enemyLogic.GotAttacted(damage);
                GameObject moneyIndicator = GameObject.FindGameObjectWithTag("MoneyTag");
                moneyIndicator.GetComponent<MoneyLogic>().AddMoney(enemyLife > damage ? damage : enemyLife);
                Destroy(gameObject);
            }
        }
        else // Si ya no existe el objetivo se destruye el disparo
        {
            Destroy();
        }
    }

    // Método para destruir la bomba
    public void Destroy()
    {
        Destroy(gameObject);
    }
}