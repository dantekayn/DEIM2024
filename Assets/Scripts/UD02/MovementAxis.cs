using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAxis : MonoBehaviour
{
    //Zona de variables globales
    private float _horizontal;
    private float _vertical;
    private float _speed = 1.0f;
    private float _turnSpeed = 90.0F;



  

    // Update is called once per frame
    void Update()
    {


        InputCube();
        Move();
        Turn();

    }

    private void InputCube()
    {

        //Teclas A y D y las flechas < y > 
        _horizontal = Input.GetAxis("Horizontal");
        //Teclas W y S y las flechas arriba y abajo 
        _vertical = Input.GetAxis("Vertical");



    }

    private void Move()
    {
        //Aplicamos el valor del eje vertical al translate
        transform.Translate(Vector3.forward * _vertical * _speed * Time.deltaTime);

    }

    private void Turn()
    {

        //Aplicamos el valor del eje horizontal al rotate
        transform.Rotate(Vector3.up * _horizontal * _turnSpeed * Time.deltaTime);

    }

}
