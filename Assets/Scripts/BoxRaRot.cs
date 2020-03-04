using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRaRot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // randomly rotating boxes so it doesn't feel boring
        float random;
        random = UnityEngine.Random.Range(-70f, 70f);
        transform.localRotation = Quaternion.Euler(0f, random, 0f);
    }
}
