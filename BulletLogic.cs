using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    //private Transform target;
    public float speed = 4;
    public int damage = 1;
    private GameObject target;

    // Método para inicializar el disparo con un objetivo
    public void Initialize(GameObject enemy)
    {
        target = enemy;
    }

    void Update()
    {
        if (target != null)
        {
            // Mueve el disparo hacia el objetivo
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, 50 * Time.deltaTime);

            // Rota el disparo hacia el objetivo
            Vector3 direction = target.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            Quaternion lookRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 20);

            // Logica para cuando el disparo llega al objetivo
            if (target.transform.position.x == transform.position.x && target.transform.position.y == transform.position.y)
            {
                target.GetComponent<EnemyLogic>().GotAttacted(damage);
                GameObject moneyIndicator = GameObject.FindGameObjectWithTag("MoneyTag");
                moneyIndicator.GetComponent<MoneyLogic>().AddMoney(1);
                Destroy(gameObject);
            }
        }
        else // Si ya no existe el objetivo se destruye el disparo
        {
            Destroy();
        }
    }

    // Método para destruir el disparo
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
