using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineFollowMouse : MonoBehaviour
{

    [SerializeField] BallControl ballControl;

    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] internal GameObject arrowHeadSprite;
    [SerializeField] GameObject ball;

    [SerializeField] public Vector2 mouseDistance;

    // Start is called before the first frame update
    void Start()
    {
        arrowHeadSprite = GameObject.Find("Arrow_Head");
        ballControl = GameObject.Find("Ball").GetComponent<BallControl>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        EndOfLine();
        if (Input.GetMouseButton(0) && ballControl.hasShot == false)
        {
            lineRenderer.enabled = true;
            arrowHeadSprite.GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (Input.GetMouseButtonUp(0) && ballControl.hasShot == false)
        {
            ballControl.ShootBall(arrowHeadSprite.transform.position);
            lineRenderer.enabled = false;
            arrowHeadSprite.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            arrowHeadSprite.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void EndOfLine()
    {
        arrowHeadSprite.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        lineRenderer.SetPosition(0, ball.transform.position);
        lineRenderer.SetPosition(1, arrowHeadSprite.transform.position);
    }
}
