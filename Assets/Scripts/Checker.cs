using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    public static int scoreCounter;
    public static bool isLose = false;
    public Movement movement;
    public Canvas gameOverCanvas;

    private bool safeMove;
    private Animator animator;
    private int nextSpawner;

    private void Start()
    {
        animator = GetComponent<Animator>();
        scoreCounter = 0;
        gameOverCanvas.enabled = false;

        // condition for spawning new street
        nextSpawner = 15;
    }

    private void Update()
    {
        // check if the next step is clear or not
        if (safeMove == true)
        {
            scoreCounter++;
            safeMove = false;
        }

        // spawn next street every multiple of 15
        if(nextSpawner == scoreCounter)
        {
            nextSpawner += 15;
            Spawner.isNext = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // check if the next tile is safe or not using collider
        if (other.gameObject.tag == "Safe")
        {
            safeMove = true;
        }
        else if (other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<AudioManager>().Play("HitDamage");
            movement.enabled = false;
            isLose = true;
            animator.SetBool("isMove", false);
            gameOverCanvas.enabled = true;
            Time.timeScale = 0;
            if (PlayerPrefs.GetInt("HighScore", 0) < scoreCounter)
            {
                PlayerPrefs.SetInt("HighScore", scoreCounter);
            }
        }
        else if (other.gameObject.tag == "Zombies")
        {
            FindObjectOfType<AudioManager>().Play("ZombieEat");
            movement.enabled = false;
            isLose = true;
            animator.SetBool("isMove", false);
            gameOverCanvas.enabled = true;
            if (PlayerPrefs.GetInt("HighScore", 0) < scoreCounter)
            {
                PlayerPrefs.SetInt("HighScore", scoreCounter);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Safe")
        {
            safeMove = false;
        }
    }
}
