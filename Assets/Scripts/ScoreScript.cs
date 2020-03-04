using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    TextMesh score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "" + Checker.scoreCounter;
    }
}
