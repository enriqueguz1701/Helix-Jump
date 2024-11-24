using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugar : MonoBehaviour
{
    public void IniciarJuego()
    {
        SceneManager.LoadScene(1);
    }

    public void Salir()
    {
        Application.Quit(); 
    }
}
