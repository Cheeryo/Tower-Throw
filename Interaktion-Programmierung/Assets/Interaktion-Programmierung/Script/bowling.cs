using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bowling : MonoBehaviour {

    //public score ScoreScript;
  
    public Text scoreText;
    // Use this for initialization
    void Start()
    {
        scoreText.text = "" + score.Score;

    }
        // Update is called once per frame
        void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bowling")
        {
            score.Score += 6;
        } 
        scoreText.text = "" + score.Score;
        //Debug.Log(Score);
    }
}
