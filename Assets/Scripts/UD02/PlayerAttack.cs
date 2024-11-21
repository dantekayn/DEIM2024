using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Zona de variables globales
    private Animator _anim;
    
    private void Awake()
    {
        
        _anim = GetComponent<Animator>();

    }



    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //LLamo al método "attack" al mismo tiempo que lanzo las flores
            Attack();

        }
    }
    private void Attack()
    {

         //ejecutar la animación
         _anim.SetTrigger("Attack");


    }



}
