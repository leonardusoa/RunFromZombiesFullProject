using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsDropper : MonoBehaviour
{
    public Transform obstacle;
    public ParticleSystem dustPart;

    private bool isTouch = false;
    private bool isParticle = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTouch == true)
        {
            obstacle.transform.position = Vector3.MoveTowards(obstacle.transform.position, new Vector3(obstacle.transform.position.x, 0.5f, obstacle.transform.position.z), 10f * Time.deltaTime);
        }

        if (obstacle.transform.position.y == 0.5f)
        {
            if (!dustPart.isPlaying && isParticle == true)
            {
                dustPart.Play();
                isParticle = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTouch = true;
        }
    }
}
