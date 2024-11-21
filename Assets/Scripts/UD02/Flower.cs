using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{

    private void OnTriggerEnter(Collider infoAcces)
    {

        Debug.Log("Estoy haciendo una colisión Trigger con:" + infoAcces.gameObject.name);

        //El condicional nos permite identificar mediante etiqueta el objeto contra el que está chocando
        if (infoAcces.CompareTag("Enemies"))
        {

            //Ese "infoAcces.gameObject" está haciendo referencia a los zombies 
            Destroy(infoAcces.gameObject);

        }

    }
}
