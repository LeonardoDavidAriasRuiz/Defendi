using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret4Spawner : MonoBehaviour
{
    public int cost = 175;
    public GameObject turret4;

    private MoneyLogic moneyLogic;

    public bool spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        moneyLogic = GameObject.FindFirstObjectByType<MoneyLogic>();
    }

    // Funcion para crear una nueva torreta cuando haya suficiente dinero
    void Update()
    {
        if (moneyLogic.moneyScore >= cost)
        {
            if (!spawned)
            {
                Instantiate(turret4, transform.position, transform.rotation);
                spawned = true;
            }
        }
    }
}

