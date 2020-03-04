using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform streetSpawnPoint;
    public Transform leftSpawnPoint;
    public Transform rightSpawnPoint;

    public GameObject street;
    public GameObject[] obsPrefabs;

    // for the next Z position of spawn and street
    private float nextSpawn = -1.5f;
    private float nextStreet = 20f;
    
    public static bool isNext;

    // Start is called before the first frame update
    void Start()
    {
        FirstSpawn();
        isNext = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isNext == true)
        {
            NextSpawner();
        }
    }

    void FirstSpawn()
    {
        int random;
        // spawn the first street
        GameObject firstBlocks;
        GameObject firstStreet = Instantiate(street, streetSpawnPoint.transform.position, Quaternion.identity);
        for (int i = 0; i < 20; i++)
        {
            // spawn the obstacles and assign them as the child of street
            random = UnityEngine.Random.Range(0, obsPrefabs.Length-1);
            firstBlocks = Instantiate(obsPrefabs[random], new Vector3(leftSpawnPoint.position.x, leftSpawnPoint.position.y + 0.2f, nextSpawn), Quaternion.identity);
            firstBlocks.transform.parent = firstStreet.transform;
            if (random != 0)
            {
                firstBlocks = Instantiate(obsPrefabs[0], new Vector3(rightSpawnPoint.position.x, rightSpawnPoint.position.y + 0.2f, nextSpawn), Quaternion.identity);
                firstBlocks.transform.parent = firstStreet.transform;
            }
            else if (random == 0)
            {
                random = UnityEngine.Random.Range(1, obsPrefabs.Length-1);
                firstBlocks = Instantiate(obsPrefabs[random], new Vector3(rightSpawnPoint.position.x, rightSpawnPoint.position.y + 0.2f, nextSpawn), Quaternion.identity);
                firstBlocks.transform.parent = firstStreet.transform;
            }
            nextSpawn += 1f;
        }
    }

    void NextSpawner()
    {
        int random;
        // spawn the next street
        GameObject myBlocks;
        GameObject myStreet = Instantiate(street, new Vector3(streetSpawnPoint.position.x, streetSpawnPoint.position.y, nextStreet), Quaternion.identity);
        for (int i = 0; i < 20; i++)
        {
            // spawn the obstacles and assign them as the child of street
            random = UnityEngine.Random.Range(0, obsPrefabs.Length);
            myBlocks = Instantiate(obsPrefabs[random], new Vector3(leftSpawnPoint.position.x, leftSpawnPoint.position.y + 0.2f, nextSpawn), Quaternion.identity);
            myBlocks.transform.parent = myStreet.transform;
            if (random != 0)
            {
                myBlocks = Instantiate(obsPrefabs[0], new Vector3(rightSpawnPoint.position.x, rightSpawnPoint.position.y + 0.2f, nextSpawn), Quaternion.identity);
                myBlocks.transform.parent = myStreet.transform;
            }
            else if (random == 0)
            {
                random = UnityEngine.Random.Range(1, obsPrefabs.Length);
                myBlocks = Instantiate(obsPrefabs[random], new Vector3(rightSpawnPoint.position.x, rightSpawnPoint.position.y + 0.2f, nextSpawn), Quaternion.identity);
                myBlocks.transform.parent = myStreet.transform;
            }
            nextSpawn += 1f;
        }
        nextStreet += 20f;
        isNext = false;
    }
}