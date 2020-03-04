using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetKiller : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        //delete the streets
        if(other.gameObject.tag == "Street")
        {
            Destroy(other.gameObject);
        }
    }
}
