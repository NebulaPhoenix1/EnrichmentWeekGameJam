using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGeneration : MonoBehaviour
{
    /* 
        Takes a set of predesigned level segments and spawns them in a sequence to create a continuous level.
        Each level segment is created using tilemaps for easy design and modification.
    */

    [SerializeField] private GameObject[] levelSegments; // Array of level segment prefabs
    [SerializeField] private int levelLength = 5; // Number of segments to spawn    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int completedSegments = 0;
    private int currentSegment = 0;
    private Queue<GameObject> activeSegments = new Queue<GameObject>();

    void Start()
    {
        if (levelSegments.Length > 0) { SpawnLevel(); }
        else {  Debug.LogError("No level segments assigned to LevelSpawner."); }
    }

    private void SpawnLevel()
    {
        //Spawns each level sequence as a child of the LevelSpawner object (Grid)
        //We need to calculate how many tiles long each segment is to position them correctly
        float segmentWidth = levelSegments[0].GetComponentInChildren<Tilemap>().size.x; 
        for (int i = 0; i < levelLength; i++)
        {
            int randomIndex = Random.Range(0, levelSegments.Length);
            Vector3 spawnPosition = new Vector3(i * segmentWidth, 0, 0);
            var lastSegment = Instantiate(levelSegments[randomIndex], spawnPosition, Quaternion.identity, transform);
            activeSegments.Enqueue(lastSegment);
        }
    }

    public void IncrementCompletedSegments()
    {
        currentSegment++;
    }

    public void SpawnNewSegment()
    {
        //We need a buffer so not the last, the one before that segment gets removed
        //So, the difference between completed segements and current segment should be 2
        if(completedSegments - currentSegment == 2)
        {
            //Despawn oldest segment
            GameObject oldestSegment = activeSegments.Dequeue();
            Destroy(oldestSegment);
            //Add new segment ensuring to add it to queue
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}