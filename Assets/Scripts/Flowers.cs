using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]

public class Flowers : MonoBehaviour
{

    public GravityAttractor attractor;
    public GravityAttractor attractor2;
    private Transform myTransform;

    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        myTransform = transform;
    }

    void FixedUpdate()
    {
        if (attractor)
        {
            attractor.Attract(myTransform);
        }
    }


    private void OnTriggerEnter(Collider other)  // para los objetos que tengan triger, pasa lo de abajo cuando lo atravesamos
    {
        if (other.gameObject.CompareTag("Player")) //para que solo pase el tema de desaparecer con los objetos que tengan el tag que le he concretado
        {
            //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        attractor = attractor2;
        }



    }



}

