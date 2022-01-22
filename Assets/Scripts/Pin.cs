using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField] private float standingThreshold = 3f;
    private float distanceToRaise = 0.4f;

    public bool IsStanding()
    {
        var rotationInEuler = transform.rotation.eulerAngles;
        
        var tiltInX = Mathf.Abs(rotationInEuler.x);
        tiltInX = tiltInX < 180 ? tiltInX : 360 - tiltInX; 
        var tiltInZ = Mathf.Abs(rotationInEuler.z);
        tiltInZ = tiltInZ < 180 ? tiltInZ : 360 - tiltInZ;
        if (tiltInX < standingThreshold && tiltInZ < standingThreshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Raise()
    {
        if (IsStanding())
        {
            GetComponent<Rigidbody>().useGravity = false;
            transform.Translate(0, distanceToRaise, 0);
        }
    }

    public void Lower()
    {
        transform.Translate(0, -distanceToRaise, 0);
        GetComponent<Rigidbody>().useGravity = true;
    }
}