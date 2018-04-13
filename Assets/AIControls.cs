using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControls : MonoBehaviour {
    public float speed = 10.0f;
    public float boundY = 2.25f;

    private GameObject ball;
    private Vector2 ballPos;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move(){
        if (!ball)
            ball = GameObject.FindGameObjectWithTag("Ball");
        //Debug.Log("We've got the ball!");
        //Debug.Log(ball.GetComponent<BallControl>().ballDirection);

        if(ball.GetComponent<BallControl> ().ballDirection == Vector2.right){
            //Debug.Log("Ball to right");
            ballPos = ball.transform.localPosition;

            if(transform.localPosition.y > -boundY && ballPos.y < transform.localPosition.y){
                transform.localPosition += new Vector3(0, -speed * Time.deltaTime, 0);
            }
            if (transform.localPosition.y < boundY && ballPos.y > transform.localPosition.y)
            {
                transform.localPosition += new Vector3(0, speed * Time.deltaTime, 0);
            }
        }
            
    }
}
