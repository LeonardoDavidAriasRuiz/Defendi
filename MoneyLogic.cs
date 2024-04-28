using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyLogic : MonoBehaviour
{
    public int moneyScore = 150;
    public Text moneyText;

    void Start()
    {
        moneyText.text = moneyScore.ToString();
    }

    // Funcion para agregar dinero al indicador
    public void AddMoney(int moneyToAdd)
    {
        moneyScore += moneyToAdd;
        moneyText.text = moneyScore.ToString();
    }

    // Funcion para quitar dinero al indicador
    public void RemoveMoney(int moneyToRemove)
    {
        moneyScore -= moneyToRemove;
        moneyText.text = moneyScore.ToString();
    }
}
