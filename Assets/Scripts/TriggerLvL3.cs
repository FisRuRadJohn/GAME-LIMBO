using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerLvL3 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)  // para los objetos que tengan triger, pasa lo de abajo cuando lo atravesamos
    {
        if (other.gameObject.CompareTag("Cacti")) //para que solo pase el tema de desaparecer con los objetos que tengan el tag que le he concretado
        {
            other.gameObject.SetActive(false);  //hace que desaparezca el objeto cuando colisiona si tiene trigger   , si es un pick up, lo desactivo.

            SceneManager.LoadScene("LVL_4");


        }

     
    }
}
