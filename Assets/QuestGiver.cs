using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public Transform grabSource;
    public Transform ItemtoDeliver;

    bool hasPlayer = false;
    bool isDialogue = true;
    bool thisQuest = false; 

    public GameObject Panel;

   // public int numSelectors = 5;
    public GameObject[] selectorArr;



    // Update is called once per frame
    void Update()
    {
        //  float dist =
        //    Vector3.Distance(gameObject.transform.position, grabSource.position);

        float dist = Vector3.Distance(grabSource.position, this.transform.position);
       // print("Are you active ?" + Panel.activeSelf);

        if (dist < 50f)
        {
            hasPlayer = true;
           print("Is Player " + hasPlayer);
        }
        else
        {
            hasPlayer = false;
        }

        if (hasPlayer && Input.GetButtonDown("Use") && isDialogue)
        {
           
            if (Panel != null)
            {
                Panel.SetActive(true); 
            }
            StartCoroutine(waiter());

        }

        if (hasPlayer && Input.GetButtonDown("Use") && !isDialogue)
        {
            if (Panel != null)
            {
                Panel.SetActive(false);
            }

        }



        float dist1 =
           Vector3.Distance(gameObject.transform.position, ItemtoDeliver.position);

        if (dist1 < 50f && thisQuest==false)
        {
            
            if (Panel != null)
            {
              //  Panel.SetActive(true);
            }
            thisQuest = true;
        }
       
        // public Player player; 
    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(3f);
        isDialogue = false;
    }

}
