using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrived : MonoBehaviour
{
    public GameObject livesIndicator; // Referencia al objeto que indica las vidas

    // Se llama cuando algo entra en el trigger del collider asociado a este objeto
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Obtener la cantidad de vida del enemigo que ha entrado en el trigger
        int life = collision.GetComponent<EnemyLogic>().life;

        // Remover vida del indicador de vidas usando el componente LivesLogic
        livesIndicator.GetComponent<LivesLogic>().RemoveLife(life);

        // Destruir la bala que ha colisionado con el enemigo
        GameObject.FindObjectOfType<BulletLogic>().Destroy();

        // Destruir el enemigo que ha llegado al destino
        collision.GetComponent<EnemyLogic>().Destroy();
    }
}
