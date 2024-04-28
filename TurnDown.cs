using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnDown : MonoBehaviour
{
    // Funcion para voltear hacia abajo cuando se llegue al tope
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<EnemyLogic>().TurnDown();
    }
}
