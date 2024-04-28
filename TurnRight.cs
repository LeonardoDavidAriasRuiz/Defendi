using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnRight : MonoBehaviour
{
    // Funcion para voltear hacia la derecha cuando se llegue al tope
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<EnemyLogic>().TurnRight();
    }
}
