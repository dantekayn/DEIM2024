using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClone : MonoBehaviour
{
    //Zona de variables globales
    public GameObject Flower;
    public Transform PosRotFlower;

    public float ThrustY,
                 ThrustZ;

    private float _timeFlower = 3.0f;
    private float _timeInvoke = 2.0f;
    private float _timeRepeating = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

        //"InvokeRepeating" llama al método y usa dos tiempos:
        //"_timeInvoke" = cuándo va a llamarlo por primera vez
        //_"timeRepeating = cada cuánto va a llamarlo
        InvokeRepeating("CreateFlower", _timeInvoke, _timeRepeating);

    }

    // Update is called once per frame
    void Update()
    {
        //Llamamos al método
        CreateFlower();

    }

    private void CreateFlower()
    {

        if (Input.GetMouseButtonDown(0))
        {

            //creo la variable local de tipo "Gameobject" para que cada una de las flores que se 
            //instancien se llamen así
            //Utilizo el método Instantiate() 
            //Se crean clones del prefabicado de la flor
            GameObject cloneFlower = Instantiate(Flower, PosRotFlower.position, PosRotFlower.rotation);

            //obtengo el componente "Rigidbody" para cada flor creada
            Rigidbody rbFlower = cloneFlower.GetComponent<Rigidbody>();

            //Creo la fuerza
            //"Vector3.up" hace referencia al eje Y y global de la escena
            rbFlower.AddForce(Vector3.up * ThrustY);
            //"Vector3.forward" hace referencia al eje z local de "PosRotFlower"
            rbFlower.AddForce(transform.forward * ThrustZ);


            //Se destruyen las flores con un tiempo de espera
            Destroy(cloneFlower, _timeFlower);


        }

    }
}
