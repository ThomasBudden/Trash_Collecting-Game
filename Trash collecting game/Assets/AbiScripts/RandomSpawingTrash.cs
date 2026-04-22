using UnityEngine;

public class RandomSpawingTrash : MonoBehaviour
{
    public GameObject trashPrefab;


    private void FixedUpdate()
    {
        //Spawing Positions
        int spawnPointX = Random.Range(0, 0);
        int spawnPointY = Random.Range(0, 30);
        int spawnPointZ = Random.Range(0, 20);

        //creates the spawnposition 
        Vector3 spawnPosition = new Vector3(spawnPointZ, spawnPointX, spawnPointY);
        //spawns the objects 
        Instantiate(trashPrefab, spawnPosition, Quaternion.identity);
    }
}
