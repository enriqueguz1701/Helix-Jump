using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia;
    HelixControl helix;
    bool cambioNivel;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject fuegosArtificiales;
    [SerializeField] public int mejorPuntuacion, puntuacionActual;

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        mejorPuntuacion = PlayerPrefs.GetInt("mejorPuntuacion");
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void SiguienteNivel()
    {
        if (!cambioNivel)
        {
            cambioNivel = true;
            audioSource.Play();
            Transform posicionPelota = FindAnyObjectByType<PelotaControl>().transform;
            Instantiate(fuegosArtificiales, posicionPelota.position, posicionPelota.rotation);
            Invoke("CambioNivel", 2);
        }
    }

    void CambioNivel()
    {
        cambioNivel = false;
        Scene escena = SceneManager.GetActiveScene();
        if (escena.buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(escena.buildIndex + 1);
        }
    }

    public void ReiniciarNivel()
    {
        puntuacionActual = 0;
        helix = FindFirstObjectByType<HelixControl>();
        helix.ReiniciarHelix();
        for(int i=0; i<helix.transform.childCount; i++)
        {
            helix.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void SumarPuntos()
    {
        puntuacionActual++;
        if (puntuacionActual >= mejorPuntuacion)
        {
            mejorPuntuacion = puntuacionActual;
            PlayerPrefs.SetInt("mejorPuntuacion", mejorPuntuacion);
        }
    }
}
