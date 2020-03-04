using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    public Animator myAnimator;
    public float moveSpeed = 5f;
    public Transform character;
    public AudioSource moveSound;

    private float screenWidth;
    private bool left, right;
    private float posZ = -2.5f;

    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Screen.width;
        left = false;
        right = false;
    }

    // Update is called once per frame
    void Update()
    {
        //check if the resolution still the same
        if (screenWidth != Screen.currentResolution.width)
        {
            screenWidth = Screen.width;
        }

        //loop over every mouse click found and not paused
        if (Input.GetMouseButtonDown(0) && UIController.isPaused == false)
        {

            //go right if touch the right half of the screen and if its not clicking any UI
            if (Input.mousePosition.x > screenWidth / 2 && !EventSystem.current.IsPointerOverGameObject())
            {
                right = true;
                left = false;
                posZ += 1f;
            }
            //go left if touch the right half of the screen and if its not clicking any UI
            if (Input.mousePosition.x < screenWidth / 2 && !EventSystem.current.IsPointerOverGameObject())
            {
                right = false;
                left = true;
                posZ += 1f;
            }
            moveSound.Play();
            myAnimator.SetBool("isMove", true);
        }
        else
        {
            // left and right using arrow key
            if (Input.GetKeyDown("right"))
            {
                right = true;
                left = false;
                posZ += 1f;
                myAnimator.SetBool("isMove", true);
                moveSound.Play();
            }
            else if (Input.GetKeyDown("left"))
            {
                right = false;
                left = true;
                posZ += 1f;
                myAnimator.SetBool("isMove", true);
                moveSound.Play();
            }
        }

        //move character position
        if (right == true)
        {
            character.transform.position = Vector3.MoveTowards(character.transform.position, new Vector3(0.5f, character.transform.position.y, posZ), moveSpeed * Time.deltaTime);
        }
        else if (left == true)
        {
            character.transform.position = Vector3.MoveTowards(character.transform.position, new Vector3(-0.5f, character.transform.position.y, posZ), moveSpeed * Time.deltaTime);
        }

        //check if player stop for stop animation
        if (character.transform.position.z == posZ)
        {
            myAnimator.SetBool("isMove", false);
        }

        //move camera
        transform.position = new Vector3(transform.position.x, transform.position.y, character.transform.position.z - 3.5f);
    }
}
