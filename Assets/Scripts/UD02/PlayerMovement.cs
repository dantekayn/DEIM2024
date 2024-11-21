using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Zona de variables globales: velocidad
    private float _speed = 1.0f,
                  _turnSpeed = 90.0f;

    //Zona de variables globales: giro
    private float _horizontal,
                  _vertical;

    private Animator _anim;
    private Rigidbody _rb;

    [Header("Raycast")]
    //capa donde quiero que actúe el "raycast"
    public LayerMask GroundMask;
    //longitud del "Raycast"
    public float RayLength; 
    //valor de la fuerza con la que va a saltar
    public float JumpForce;

    private Ray _ray;
    //variable para saber con quien estoy golpeando
    private RaycastHit _hit;
    //variable de tipo booleana para saber si estoy tocando el suelo
    private bool _isGrounded,
                 _canPlayerJump;



    private void Awake()
    {
        //La variable "_anim" apunta al componente Animator
        //del"gameObject" que lleva este script
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {

        InputPlayer();
        Move();
        Turn();
        Animating();
        CanJump();
        
    }


    private void FixedUpdate()
    {
        //Lllamamos al método
        LaunchRaycast();
        //si es igual a true
        if (_canPlayerJump)
        {   //para que no siga saltando
            _canPlayerJump = false;
            //llamar al metodo jump
            Jump();

        }

    }

    private void LaunchRaycast()
    {

        //el punto de pivote origen
        _ray.origin = transform.position;
        //hacia abajo 
        // en negativo "-transform.up" porque no existe "transform.down"
        _ray.direction = -transform.up;

        if (Physics.Raycast(_ray, out _hit, RayLength))
        {
            //Si es verdadero Player puede saltar
            _isGrounded = true;
           

        }
        else
        {
            //Si es falso Player no puede saltar
            _isGrounded = false;

        }
       

    }
    private void CanJump()
    {

        //Si Player quiere saltar y puede saltar
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {

            _canPlayerJump = true;
           
        }


    }

    private void Jump()
    {
        //lo multiplicamos por el valor de la fuerza que le demos
        _rb.AddForce(Vector3.up * JumpForce);


       
    }

    private void InputPlayer()
    {
        //Teclas A y D y las flechas < y >
        _horizontal = Input.GetAxis("Horizontal");
        //Teclas W y S y las flecas arriba y abajo
        _vertical = Input.GetAxis("Vertical");

    }

    //Una acción para cada método para más organización
    private void Move()
    {
        //Eje vertical, su valor será el del translate
        transform.Translate(Vector3.forward * _speed * _vertical * Time.deltaTime);

    }

    private void Turn()
    {
        //Eje horizontal, su valor será el de rotación 
        transform.Rotate(Vector3.up * _turnSpeed * _horizontal * Time.deltaTime);

    }

    //Método relacionado con la animación de Player
    private void Animating()
    {
        //Player se está moviendo si es distinto a 0
        if(_vertical != 0)
        {
            //Se ejecuta el movimiento
            _anim.SetBool("IsMoving", true);
            
        }
        //Player no se moverá si es = 0
        else
        {
            //No se ejecuta el movimiento
            _anim.SetBool("IsMoving", false);
            
        }

        
    }



}
