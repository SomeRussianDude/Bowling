using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        var otherObject = other.gameObject;
        if (otherObject.GetComponent<Pin>())
        {
            Destroy(otherObject, 1f);
        }
    }
}