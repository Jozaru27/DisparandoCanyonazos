using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diana : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Método cuando ocurre una colisión
    private void OnCollisionEnter(Collision collision)
    {
        // (opcional) verificar si el objeto que colisionó tiene la etiqueta "Bala" //tocó cambiar el colision detection a continuous
        if (collision.gameObject.CompareTag("Bala")){ 
            Destroy(gameObject);
        }
    }
}
