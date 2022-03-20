using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{

    [SerializeField] int force;
    internal int shotsTaken;
    [SerializeField] GameObject ballSpawn;
    [SerializeField] GameObject arrow;

    [SerializeField] GameObject portalIn;
    [SerializeField] GameObject portalOut;

    internal bool hasShot;
    internal bool hasWon;

    internal Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        RotateBall();
    }

    // Update is called once per frame
    void Update()
    {

        CheckBallVelocity();
    }

    void RotateBall()
    {
        Vector3 arrowTransformZ = new Vector3(arrow.transform.position.x, arrow.transform.position.y, 90);
        if (!hasShot)
            transform.LookAt(arrowTransformZ, Vector3.up);
    }

    internal void ShootBall(Vector2 ballVector)
    {
        shotsTaken += 1;
        StartCoroutine(WaitToSetShotBool(0.5f));
        Vector2 ballVectorMult = ballVector * 100f;
        ballVectorMult = ballVectorMult.normalized;
        rb2D.AddForce(transform.forward * force * Time.deltaTime);
    }

    void CheckBallVelocity()
    {
        if ((!hasWon && hasShot && rb2D.velocity.magnitude <= 0.25f) || Input.GetKeyDown(KeyCode.R) && !hasWon)
        {
            ResetBall();
        }
    }

    void ResetBall()
    {
        Debug.Log("Has slowed");


        hasShot = false;
        ResetPos();
    }

    void ResetPos()
    {
        rb2D.transform.position = ballSpawn.transform.position;
        transform.position = ballSpawn.transform.position;
        rb2D.Sleep();
        rb2D.WakeUp();
    }

    void Goal()
    {
        hasShot = true;
        Debug.Log("You won!");
        rb2D.drag = 50;
        rb2D.mass = 2000;
        hasWon = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Finish")
        {
            Goal();
        }
        else if (other.tag == "PortalIn")
        {
            rb2D.transform.position = portalOut.transform.position;
        }
    }

    IEnumerator WaitToSetShotBool(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        hasShot = true;
        StopAllCoroutines();
    }
}
