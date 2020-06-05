using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMoveOnSphere : MonoBehaviour
{
    public SphereCollider Sphere;

    public float speed = 5;
    public bool rotatePlayer = true;
    public float rotationDamping = 10f;
    private float flowerScore = 0f; 

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (input.magnitude > 0)
        {
            input = Camera.main.transform.rotation * input;
            if (input.magnitude > 0.001f)
            {
                transform.position += input * (speed * Time.deltaTime);
                if (rotatePlayer)
                {
                    float t = Cinemachine.Utility.Damper.Damp(1, rotationDamping, Time.deltaTime);
                    Quaternion newRotation = Quaternion.LookRotation(input.normalized, transform.up);
                    transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, t);
                }
            }
        }

        // Stick to sphere surface
        if (Sphere != null)
        {
            var up = transform.position - Sphere.transform.position;
            up = up.normalized;
            var fwd = transform.forward.ProjectOntoPlane(up);
            transform.position = Sphere.transform.position + up * (Sphere.radius + transform.localScale.y / 2);
            transform.rotation = Quaternion.LookRotation(fwd, up);
        }
    }
    private void OnTriggerEnter(Collider other)  // para los objetos que tengan triger, pasa lo de abajo cuando lo atravesamos
    {
        if (other.gameObject.CompareTag("PickUp")) //para que solo pase el tema de desaparecer con los objetos que tengan el tag que le he concretado
        {
            other.gameObject.SetActive(false);  //hace que desaparezca el objeto cuando colisiona si tiene trigger   , si es un pick up, lo desactivo.

            SceneManager.LoadScene("LVL_2");

            
        }

        if (other.gameObject.CompareTag("PU_2")) //para que solo pase el tema de desaparecer con los objetos que tengan el tag que le he concretado
        {
            other.gameObject.SetActive(false);  //hace que desaparezca el objeto cuando colisiona si tiene trigger   , si es un pick up, lo desactivo.

            SceneManager.LoadScene("LVL_3");


        }

        if (other.gameObject.CompareTag("PU_4")) //para que solo pase el tema de desaparecer con los objetos que tengan el tag que le he concretado
        {
            other.gameObject.SetActive(false);  //hace que desaparezca el objeto cuando colisiona si tiene trigger   , si es un pick up, lo desactivo.

            SceneManager.LoadScene("LVL_5");


        }
        if (other.gameObject.CompareTag("LRoja")) //para que solo pase el tema de desaparecer con los objetos que tengan el tag que le he concretado
        {
            other.gameObject.SetActive(false);  //hace que desaparezca el objeto cuando colisiona si tiene trigger   , si es un pick up, lo desactivo.

            SceneManager.LoadScene("LVL_2");


        }
        if (other.gameObject.CompareTag("Flowers")) //para que solo pase el tema de desaparecer con los objetos que tengan el tag que le he concretado
        {
            flowerScore += 1;
            other.gameObject.SetActive(false);

            if (flowerScore == 4f)
            {
                SceneManager.LoadScene("LVL_5");
                
            }
            


        }
        if (other.gameObject.CompareTag("Laptop")) //para que solo pase el tema de desaparecer con los objetos que tengan el tag que le he concretado
        {
            other.gameObject.SetActive(false);  //hace que desaparezca el objeto cuando colisiona si tiene trigger   , si es un pick up, lo desactivo.

            SceneManager.LoadScene("LVL1");


        }
    }
}
