using UnityEngine;
using UnityEngine.AI;

public class Ai_Nav_Script : MonoBehaviour
{
    public GameObject bin; // the bin that the ai brings the trash back to
    public NavMeshAgent agent; // the ai nav mesh agent

    public bool goingToBin; // a bool for when the ai is going back to tht bin
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>(); // sets agent to the ai's nav mesh agent
    }

    // Update is called once per frame
    void Update()
    {
        if (goingToBin == true) // when it should go back to the bin
        {
            agent.destination = bin.transform.position; // navigate to the bin's possition
        }
    }
}
