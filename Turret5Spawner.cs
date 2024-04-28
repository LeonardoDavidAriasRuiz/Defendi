using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret5Spawner : MonoBehaviour
{
    public int cost = 250;
    public GameObject turret5;

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
                Instantiate(turret5, transform.position, transform.rotation);
                spawned = true;
            }
        }
    }
}

