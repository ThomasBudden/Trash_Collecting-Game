using UnityEngine;

public class RandomSpawingTrash : MonoBehaviour
{
    [Header("Trash settings")]
    public GameObject trashPrefab;
    public int maxTrash = 20;
    [SerializeField] private int currentTrash = 0;

    [Header("Timer settings")]
    public float spawnInterval = 1f;
    private float timer; 

    private void FixedUpdate()
    {
        timer += Time.deltaTime; //creates a frame-rate independent timer
        if (timer >= spawnInterval)  // if timer is less than spaw interval do span logic 
        {
            timer = 0f; 

            if (currentTrash >= maxTrash) return; // stop spawing the objects if there is more than the max 

            //----------SPAWN LOGIC DO NOT TOUCH-----------------
            //Spawing Positions
            int spawnPointX = Random.Range(0, 0); 
            int spawnPointY = Random.Range(0, 30);
            int spawnPointZ = Random.Range(0, 20);

            //creates the spawnposition 
            Vector3 spawnPosition = new Vector3(spawnPointZ, spawnPointX, spawnPointY);
            //spawns the objects 
            Instantiate(trashPrefab, spawnPosition, Quaternion.identity);

            currentTrash++; //add spawned trash to the current trash
        }
    }
}
