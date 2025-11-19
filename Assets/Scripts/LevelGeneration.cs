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
    [SerializeField] private int levelLength = 5; // Number of segments to spawn    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int completedSegments = 0;
    private int currentSegment = 0;
    private Queue<GameObject> activeSegments = new Queue<GameObject>();
    private float endingX=0;

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

    public void IncrementCompletedSegments()
    {
        currentSegment++;
    }

    public void SpawnNewSegment(int index)
    {
        int randomIndex = Random.Range(0, levelSegments.Length);
        Vector2 spawnPos = new Vector2(endingX, 0);
        GameObject newestSegment = Instantiate(levelSegments[randomIndex], spawnPos, Quaternion.identity);
        Tilemap newestTilemap = newestSegment.transform.Find("PhysicalTileMap").GetComponent<Tilemap>();
        newestTilemap.CompressBounds();
        activeSegments.Enqueue(newestSegment);
        endingX += newestTilemap.localBounds.size.x;
        Debug.Log(newestTilemap.localBounds.size.x);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}