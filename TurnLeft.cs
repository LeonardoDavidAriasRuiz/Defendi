using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLeft : MonoBehaviour
{
    // Funcion para voltear hacia la izquierda cuando se llegue al tope
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<EnemyLogic>().TurnLeft();
    }
}
