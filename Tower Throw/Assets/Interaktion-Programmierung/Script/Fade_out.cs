using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade_out : MonoBehaviour {
    public Animator fadeAnim;
	// Use this for initialization
	void Start () {
        fadeAnim.SetBool("fade_out", true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
