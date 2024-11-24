using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelotaControl : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] float altura = 10;
    [SerializeField] bool ignorarColision;
    [SerializeField] Vector3 posicionInicial;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        posicionInicial = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Perder")
        {
            GameManager.Instancia.ReiniciarNivel();
            transform.position = posicionInicial;
        }

        if (ignorarColision) return;
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(Vector3.up * altura);
        ignorarColision = true;
        Invoke("PermitirColision", 0.3f);

    }

    void PermitirColision()
    {
        ignorarColision = false;
    }
}
