using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{

    //Zona de variables globales
    public GameObject Egg;
    public Transform PosRotEgg;

    public float ThrustY,
                 ThrustZ;

    private float _timeEgg = 3.0f;
    private float _timeInvoke = 2.0f;
    private float _timeRepeating = 5.0f;


    // Start is called before the first frame update
    void Start()
    {

        //"InvokeRepeating" llama al método y usa dos tiempos
        //el primero es cuando va a llamarlo ("timeInvoke")
        //y el segundo cada cuando va a llamarlo("timeRepeating);
        InvokeRepeating("CreateEggs", _timeInvoke, _timeRepeating);



    }

    // Update is called once per frame
    void Update()
    {

        CreateEggs();

    }

    private void CreateEggs()
    {

        if(Input.GetMouseButtonDown(0))
        {

            //Creo clones del prefabricado del huevo
            //como no le indico dónde quiero que se genere el clon
            //se crea en el punto (0.0f, 0.0f, 0.0f)
            //creo la variable local "Instantiate" de tipo "GameObject" para cada uno los huevos
            GameObject cloneEgg = Instantiate(Egg, PosRotEgg.position, PosRotEgg.rotation);

            //obtengo el componente "Rigidbody" de cada huevo cloneado
            Rigidbody rbEgg = cloneEgg.GetComponent<Rigidbody>();

            //Creo la fuerza
            //"Vector3.down" hace referencia al eje -Y y global de la escena
            rbEgg.AddForce(Vector3.down * ThrustY);
            //"transform.forward" hace referencia al eje z local de "PosRotEgg"
            rbEgg.AddForce(transform.forward * ThrustZ);

            //Para destruir los huevos con un tiempo de espera
            Destroy(cloneEgg, _timeEgg);


        }

    }


}
