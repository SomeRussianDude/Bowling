using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField] private float standingThreshold = 3f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

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
}