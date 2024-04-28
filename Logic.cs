using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
    // Funcion para cambiar hacia el nivel
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    // Funcion para salir de la partida
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
