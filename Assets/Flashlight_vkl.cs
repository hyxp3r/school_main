using UnityEngine;
using System.Collections;

public class Flashlight_vkl : MonoBehaviour {
    public AudioClip Vkl;
	public AudioSource Source;
    void Update() {
			if (Input.GetKeyDown("f")){
            GetComponent<AudioSource>().clip = Vkl;
        GetComponent<AudioSource>().PlayOneShot(Vkl, 0.7F);
        }
	}
}