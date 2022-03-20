using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{

    [SerializeField] GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        SpawnBallOnStart();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnBallOnStart()
    {
        ball.transform.position = transform.position;
    }
}
