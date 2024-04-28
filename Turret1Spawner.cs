using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret1Spawner : MonoBehaviour
{
    public int cost = 100;
    public GameObject turret1;

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
                Instantiate(turret1, transform.position, transform.rotation);
                spawned = true;
            }
        }
    }
}
