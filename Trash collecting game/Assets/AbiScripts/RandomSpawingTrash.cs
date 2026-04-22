using UnityEngine;

public class RandomSpawingTrash : MonoBehaviour
{
    public GameObject[] trashObjects; //array 
    public GameObject trashObject; //singular object

    void Awake()
    {
        while (trashObject)
        {
            Vector3 position = new Vector3(Random.Range(-100.0f, 100.0f), 0, Random.Range(-100.0f, 100.0f)); //Picks a random place in scene to spawn the trash from
            Instantiate(trashObject, position, Quaternion.identity); // makes the object spawn in scene 
            Debug.Log("Do you spawn?"); 
        }
    }
}
