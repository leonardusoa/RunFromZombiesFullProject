using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsJumper : MonoBehaviour
{
    public Transform obstacle;

    private float highestPoint = 5f;
    private bool isHigh = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isHigh)
        {
            obstacle.transform.position = Vector3.MoveTowards(obstacle.transform.position, new Vector3(obstacle.transform.position.x, highestPoint, obstacle.transform.position.z), 10f * Time.deltaTime);
            if (obstacle.transform.position.y == highestPoint)
            {
                isHigh = true;
            }
        }
        else
        {
            obstacle.transform.position = Vector3.MoveTowards(obstacle.transform.position, new Vector3(obstacle.transform.position.x, 0f, obstacle.transform.position.z), 5f * Time.deltaTime);
            if (obstacle.transform.position.y == 0f)
            {
                isHigh = false;
            }
        }
    }
}
