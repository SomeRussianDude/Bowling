using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GutterBall : MonoBehaviour
{
   private PinSetter pinSetter;

   private void Start()
   {
      pinSetter = FindObjectOfType<PinSetter>();
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.GetComponent<Ball>())
      {
         pinSetter.BallLeftBox();
      }
   }
}
