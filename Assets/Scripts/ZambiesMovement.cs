using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZambiesMovement : MonoBehaviour
{
    public Transform player;
    public float speed = 1f;
    public Slider slider;

    float realSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = transform.position.z - player.transform.position.z;
        // add speed corresponding with score
        realSpeed = speed + (0.05f * Checker.scoreCounter);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, realSpeed * Time.deltaTime);
    }
}
