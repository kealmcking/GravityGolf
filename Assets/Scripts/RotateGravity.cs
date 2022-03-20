using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGravity : MonoBehaviour
{

    [SerializeField] bool rotationDirection;
    [SerializeField] int rotationSpeed;

    [SerializeField] bool isNotChildOfPlanet;
    [SerializeField] GameObject planetToRotate;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        if (!isNotChildOfPlanet)
        {
            if (rotationDirection == false)
            {
                transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
                // Rotate Left
            }
            else
            {
                transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
                // Rotate Right
            }
        }
        else
        {
            if (rotationDirection == false)
            {
                transform.RotateAround(planetToRotate.transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
                // Rotate Left
            }
            else
            {
                transform.RotateAround(planetToRotate.transform.position, Vector3.forward, -rotationSpeed * Time.deltaTime);
                // Rotate Right
            }
        }

    }
}
