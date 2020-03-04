using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMove : MonoBehaviour
{
    public Vector3 destination;
    private Vector3 firstSpawn;

    // Start is called before the first frame update
    void Start()
    {
        firstSpawn = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // move zombies for menu
        transform.position = Vector3.MoveTowards(transform.position, destination, 1f * Time.deltaTime);
        if(transform.position == destination)
        {
            transform.position = firstSpawn;
        }
    }
}
