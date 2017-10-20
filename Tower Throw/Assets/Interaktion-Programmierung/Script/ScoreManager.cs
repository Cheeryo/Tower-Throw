using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    private int score;
    
    public void AddScore(int value)
    {
        score += value;
        Debug.Log(value);
        GetComponent<Text>().text = ""+ score;
    }
    private void Start()
    {
        GetComponent<Text>().text = "0";
    }
}
