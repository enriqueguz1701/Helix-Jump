using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixControl : MonoBehaviour
{
    [SerializeField] Vector2 ultimaPosicion;
    [SerializeField] Vector3 ultimaRotacion;
    // Start is called before the first frame update
    void Start()
    {
        ultimaRotacion = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Vector2 posicionClic = Input.mousePosition;
            if(ultimaPosicion == Vector2.zero)
            {
                ultimaPosicion = posicionClic;
            }
            float distancia = ultimaPosicion.x - posicionClic.x;
            ultimaPosicion = posicionClic;
            transform.Rotate(Vector3.up * distancia);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            ultimaPosicion = Vector2.zero;
        }
    }

    public void ReiniciarHelix()
    {
        transform.localEulerAngles = ultimaRotacion;
        Debug.Log("Reinicio el helix");
    }
}
