using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiguienteNivel : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Pelota")
        {
            GameManager.Instancia.SiguienteNivel();
        }
    }
}
