using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnUp : MonoBehaviour
{
    // Funcion para voltear hacia arriba cuando se llegue al tope
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<EnemyLogic>().TurnUp();
    }
}
