using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformAttach : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "PurpleObject")
        {
            transform.parent = other.transform;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "PurpleObject")
        {
            transform.parent = null;
        }
    }

}
