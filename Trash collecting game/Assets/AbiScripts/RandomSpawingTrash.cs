using UnityEngine;
using System.Collections.Generic; 

public class RandomSpawingTrash : MonoBehaviour
{
    [Header("Trash settings")]
    [SerializeField] private GameObject trashPrefab;
    [SerializeField] private int maxTrash = 20;
    [SerializeField] private int currentTrash = 0;
    public List <GameObject> trashList; // public for the AI Nav Script 

    [Header("Timer settings")]
    [SerializeField] private float spawnInterval;
    private float _timer; 

    private void FixedUpdate()
    {
        _timer += Time.deltaTime; //creates a frame-rate independent timer
        if (_timer >= spawnInterval)  // if timer is less than spaw interval do span logic 
        {
            _timer = 0f; 

            if (currentTrash >= maxTrash) return; // stop spawing the objects if there is more than the max 

            //----------SPAWN LOGIC DO NOT TOUCH-----------------
            //Spawing Positions
            int spawnPointX = Random.Range(50, 30); 
            int spawnPointY = Random.Range(50, 30);
            int spawnPointZ = Random.Range(50, 20);

            //creates the spawnposition randomly in the square 
            Vector3 spawnPosition = new Vector3(spawnPointZ, spawnPointX, spawnPointY);
            //spawns the objects 
            GameObject spawnedTrash = Instantiate(trashPrefab, spawnPosition, Quaternion.identity);

            // add to list
            trashList.Add(spawnedTrash);

            currentTrash++; //add spawned trash to the current trash
        }
    }

}
