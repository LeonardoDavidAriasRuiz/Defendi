using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret2Spawner : MonoBehaviour
{
    public int cost = 125;
    public GameObject turret2;

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
                Instantiate(turret2, transform.position, transform.rotation);
                spawned = true;
            }
        }
    }
}
