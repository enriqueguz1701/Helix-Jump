using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntosControl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Pelota")
        {
            GameManager.Instancia.SumarPuntos();
        }
        gameObject.SetActive(false);    
    }
}
