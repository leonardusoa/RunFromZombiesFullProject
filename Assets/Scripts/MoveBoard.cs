using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoard : MonoBehaviour
{
    public Transform boardPosition;

    private float posX;
    private float startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = gameObject.transform.position.x;
        InvokeRepeating("ChangeDirection", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        boardPosition.transform.position = Vector3.MoveTowards(boardPosition.transform.position, new Vector3(posX, boardPosition.transform.position.y, boardPosition.transform.position.z), 5f * Time.deltaTime);
    }

    void ChangeDirection()
    {
        // depends on the spawn position where the next move will go
        if (startPos == -0.5f)
        {
            if (boardPosition.transform.position.x > 0)
            {
                posX = -0.5f;
            }
            else
            {
                posX = 0.5f;
            }
        }
        else
        {
            if (boardPosition.transform.position.x < 0)
            {
                posX = 0.5f;
            }
            else
            {
                posX = -0.5f;
            }
        }
    }
}
