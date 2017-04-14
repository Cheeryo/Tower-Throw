using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOVer : MonoBehaviour {
    GameObject[] objs;
    int allItems;
    int itemsUsed;
    public Animator overAnim;
    public Text gameScore;
    public Text endScore;

    // Use this for initialization
    void Start () {
        objs = GameObject.FindGameObjectsWithTag("Item");
        allItems = objs.Length;
        Debug.Log(allItems);
    }
	
	// Update is called once per frame
	void Update () {
        if (itemsUsed >= allItems) {
            Debug.Log("GameOVER");
            endScore.text = gameScore.text;
            overAnim.SetBool("over", true);
        }
	}

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Item")
        {
            itemsUsed++;
            //Debug.Log(itemsUsed);
        }
    }
}

