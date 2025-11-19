using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGeneration : MonoBehaviour
{
    /* 
        Takes a set of predesigned level segments and spawns them in a sequence to create a continuous level.
        Each level segment is created using tilemaps for easy design and modification.
    */

    [SerializeField] private GameObject[] levelSegments; // Array of level segment prefabs
    [SerializeField] private GameObject startingSegment;
    [SerializeField] private int levelLength = 5; // Number of segments to spawn  
    [SerializeField] private int maxSpawnedSegments = 7;  
    [SerializeField] private float segmentWidth = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int completedSegments = 0;
    private int spawnedSegmentCount = 0;
    private Queue<GameObject> activeSegmentsQueue = new Queue<GameObject>();
    private float endingX=0;
    private GameObject newestSegment;

    void Start()
    {
        if (levelSegments.Length > 0) { SpawnLevel(); }
        else {  Debug.LogError("No level segments assigned to LevelSpawner."); }
    }

    private void SpawnLevel()
    {
        for(int i = 0; i < 5; i++)
        {
            SpawnNewSegment(i);
        }
    }


    public void SpawnNewSegment(int index)
    {
        if(spawnedSegmentCount > 0) //Spawn random segments
        {
            int randomIndex = Random.Range(0, levelSegments.Length-1);
            Vector2 spawnPos = new Vector2(endingX, 0);
            newestSegment = Instantiate(levelSegments[randomIndex], spawnPos, Quaternion.identity, transform);
        }
        else //Ensure the first segment is always the same to stop softlock
        {
            Vector2 spawnPos = new Vector2(endingX, 0);
            newestSegment = Instantiate(startingSegment, spawnPos, Quaternion.identity, transform);
        }
        activeSegmentsQueue.Enqueue(newestSegment);
        spawnedSegmentCount++;
        //Setting up unity events
        LevelSegment segment = newestSegment.GetComponentInChildren<LevelSegment>();
        segment.SegmentNumber = index;
        segment.SegmentComplete.AddListener(() => {
            ExtendLevel();
        });
        //Debug.Log("Spawned:" + index);
        endingX += segmentWidth;
        if(activeSegmentsQueue.Count > maxSpawnedSegments)
        {
            GameObject oldest = activeSegmentsQueue.Dequeue();
            Destroy(oldest);
        }
    }

    private void ExtendLevel()
    {
        SpawnNewSegment(spawnedSegmentCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}