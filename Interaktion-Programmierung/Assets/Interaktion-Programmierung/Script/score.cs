using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

    public static int Score = 0;
    public ScoreManager scoreManager;
    [SerializeField]
    private int points;
    [SerializeField]
    private bool targetAction;
    [SerializeField]
    private bool catapultAction;
    [SerializeField]
    private Transform catapult;
    [SerializeField]
    private Rigidbody catapultMonster;
    private float angle;
    public Animator fadeAnim;

    private void Update()
    {
        if(targetAction)
        {
            transform.Rotate(new Vector3(0, 0, Time.deltaTime * -200f));
            angle += Time.deltaTime * 200f;
            if(angle > 360)
            {
                targetAction = false;
                this.enabled = false;
            }
        }
        if (catapultAction)
        {
            catapult.Rotate(new Vector3(Time.deltaTime * 200f, 0, 0));
            angle += Time.deltaTime * 200f;
            if (angle > 90)
            {
                catapultAction = false;
                this.enabled = false;
                //catapultMonster.AddForce(new Vector3(50, 250, 0), ForceMode.Impulse);
                catapultMonster.GetComponent<Animation>().Play();
                
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.tag == "Item" && gameObject.tag == "LoadLevel")
        {
            Debug.Log("");
            StartCoroutine(MyCoroutine());
            
        }
            if (other.tag == "Item")
        {
            if (tag == "Target")
            {
                InteractableItem item = other.GetComponent<InteractableItem>();
                if (item.enabled)
                {
                    scoreManager.AddScore(points);
                    item.enabled = false;

                    targetAction = true;
                }
            }
            else if (tag == "TargetCatapult")
            {
                InteractableItem item = other.GetComponent<InteractableItem>();
                if (item.enabled)
                {
                    scoreManager.AddScore(points);
                    item.enabled = false;
                    catapultAction = true;
                }
            }
            else
            {
                InteractableItem item = other.GetComponent<InteractableItem>();
                if (item.enabled)
                {
                    scoreManager.AddScore(points);
                    item.enabled = false;
                }

            }
        }
        //Debug.Log(Score);
    }

    private void OnTriggerExit(Collider other)
    {
        if (tag == "PointExit" && other.tag == "Item")
        {
            scoreManager.AddScore(-points);
            other.GetComponent<InteractableItem>().enabled = true;
        }
        //Debug.Log("Close, try it again");
    }

   
    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(3);
        fadeAnim.SetBool("fade_in", true);
        yield return new WaitForSeconds(2);
        Application.LoadLevel("Main_scene_01");
    }

}
