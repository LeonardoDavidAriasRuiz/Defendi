using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LivesLogic : MonoBehaviour
{
    int livesScore = 15;
    public Text livesText;

    // Inicializacion de 15 vidas iniciales
    void Start()
    {
        livesScore = 15;
        livesText.text = livesScore.ToString();
    }

    // Funcion para establecer la pantalla de perdida cuando no quedan mas vidas
    private void Update()
    {
        if (livesScore <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    // Funcion para quitar vida
    public void RemoveLife(int livesToRemove)
    {
        livesScore -= livesToRemove;
        livesText.text = livesScore.ToString();
    }
}
