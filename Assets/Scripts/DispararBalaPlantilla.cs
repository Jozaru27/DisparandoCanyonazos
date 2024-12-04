using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DispararBala : MonoBehaviour
{
    GameObject posInicial;
    GameObject posFinal;
    GameObject canyon;

    public     GameObject prefabBala;
    GameObject balaInstanciada;

    void Start(){
        // Asignar los objetos desde la jerarquía
        posInicial = GameObject.Find("PuntoDeDisparo"); // Nombre del objeto vacío en la punta del cañón
        posFinal = GameObject.Find("PuntoDeDisparoFinal");     // Nombre del objeto vacío que define la dirección del disparo
        canyon = GameObject.Find("CuerpoCañón");         // Nombre del objeto del cañón (Cilindro en la escena)
    }

    // Update is called once per frame
void Update(){
    // Verificar si la bala ha sido instanciada
    if (balaInstanciada != null && canyon != null)
    {
        // Calcular la distancia entre la bala y el cañón
        float distancia = Vector3.Distance(balaInstanciada.transform.position, canyon.transform.position);

        // Obtener el Renderer del cañón
        Renderer renderer = canyon.GetComponent<Renderer>();

        // Cambiar el color del cañón si la bala está cerca
        if (distancia < 10f)  // Cambiar el 10f a la distancia que desees
        {
            renderer.material.color = Color.red; // Cambiar a rojo si está cerca
        }
        else
        {
            renderer.material.color = Color.white; // Volver a blanco si no está cerca
        }
    }
}


    private void OnMouseDown(){
        // Instanciar el prefab de la bala en la posición inicial
        balaInstanciada = Instantiate(prefabBala, posInicial.transform.position, Quaternion.identity);

        // Agregar un Rigidbody para manejar las físicas
        Rigidbody rb = balaInstanciada.GetComponent<Rigidbody>();
        
        // Calcular la dirección del disparo
        Vector3 direccion = (posFinal.transform.position - posInicial.transform.position).normalized;

        // Aplicar fuerza en la dirección calculada
        rb.AddForce(direccion * 500f, ForceMode.Impulse); // Cambia 500f según la fuerza deseada

        // Avisar al GameManager para incrementar el número de balas
        GameManager.IncNumBalas();
    }

}
