using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;
using Unity.VisualScripting;
using NUnit.Framework;
using TMPro;
using UnityEngine.UI;

public class Ai_Nav_Script : MonoBehaviour
{
    public GameObject spawningManager;

    public GameObject bin; // the bin that the ai brings the trash back to
    public NavMeshAgent agent; // the ai nav mesh agent

    public bool goingToBin; // a bool for when the ai is going back to the bin
    public bool goingToTrash; // a bool for when the ai is going to find trash

    public GameObject lastTrash; // the last piece of trash touched

    private List<GameObject> trashList = new List<GameObject>(); // a list containing all of the spawned trash

    public float lowestDistance; // the lowest distance to trash
    public GameObject trashWithLowestDistance; // the trash that has the lowest distance

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>(); // sets agent to the ai's nav mesh agent
        trashWithLowestDistance = null;
        SearchForTrash();
    }

    // Update is called once per frame
    void Update()
    {
        if (goingToBin == true) // when it should go back to the bin
        {
            agent.destination = bin.transform.position; // navigate to the bin's possition
        }

        else if (goingToTrash == true) // when it should go to the closest trash
        {
            if (trashWithLowestDistance == null)
            {
                agent.destination = this.transform.position;
                SearchForTrash();
            }
            else if (trashWithLowestDistance != null)
            {
                agent.destination = trashWithLowestDistance.transform.position; // navigate to the closest trash's position
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bin") // if it touches the bin
        {
            Debug.Log("Bin");
            goingToBin = false;
            trashList.Remove(lastTrash);
            Destroy(lastTrash);
            lastTrash = null;
            trashWithLowestDistance = null;
            SearchForTrash();
        }
        else if (collision.gameObject.tag == "Trash") // if it touches the trash
        {
            Debug.Log("Trash");
            lastTrash = collision.gameObject; // set the trash touched to last trash
            lastTrash.transform.position = this.transform.GetChild(0).transform.position; //  move the trash object to the front of the ai
            lastTrash.transform.SetParent(this.transform.GetChild(0));
            Destroy(lastTrash.GetComponent<Rigidbody>());

            goingToBin = true; // start going to the bin
        }
    }

    void SearchForTrash() // look for the closest trash in the trash list
    {
        trashList = spawningManager.GetComponent<RandomSpawingTrash>().trashList;
        for (int i = 0; i < trashList.Count; i++)
        {
            
            if (i == 0)
            {
                lowestDistance = Vector3.Distance(this.transform.position, trashList[i].transform.position);
                trashWithLowestDistance = trashList[i];
            }
            else if (i > 0 && Vector3.Distance(this.transform.position, trashList[i].transform.position) < lowestDistance)
            {
                lowestDistance = Vector3.Distance(this.transform.position, trashList[i].transform.position);
                trashWithLowestDistance = trashList[i];
            }
        }
        goingToTrash = true;
    }
}
