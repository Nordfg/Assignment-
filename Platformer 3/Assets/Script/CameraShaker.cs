using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{

    public float power = 0.7f;
    public float duaration = 1.0f;
    public Transform camera;
    public float slowDownAmount = 1.0f;
    public static bool shouldShake = false;

    Vector3 startPosition;
    float initialDuration;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
        startPosition = camera.localPosition;
        initialDuration = duaration;


    }

    // Update is called once per frame
    void Update()
    {
        if (shouldShake)
        {
            if (duaration > 0)
            {
                camera.localPosition = startPosition + Random.insideUnitSphere * power;
                duaration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                shouldShake = false;
                duaration = initialDuration;
                camera.localPosition = startPosition;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //shouldShake = true;
        }
     
    }
}
