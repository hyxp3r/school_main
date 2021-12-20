using UnityEngine;
using System.Collections;

public class Fonarik : MonoBehaviour {
public Light Fonar;
void Update() {
    if (Input.GetKeyDown("f"))      
   GetComponent<Light>().enabled = !GetComponent<Light>().enabled; 
 }
}