using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

    private Rigidbody2D rb2d;
    private Vector2 vel;

    public Vector2 ballDirection;


    public Vector2 forceAdd = new Vector2(20.0f, 0);

    public AudioClip MusicClip;
    public AudioSource source;
    public float hitVol = 1.0f;

    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(20, -15));
        }
        else
        {
            rb2d.AddForce(new Vector2(-20, -15));
        }
    }

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
	}

    void Awake()
    {

        source = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void ResetBall()
    {
        vel = Vector2.zero;
        rb2d.velocity = vel;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            source.Play();
            //vel.x = rb2d.velocity.x;
            //vel.y = (rb2d.velocity.y / 2.0f) + (coll.collider.attachedRigidbody.velocity.y / 3.0f);
            vel.x = (rb2d.velocity.x * 2.0f) + (coll.collider.attachedRigidbody.velocity.x * 3.0f);
            vel.y = rb2d.velocity.y;
            rb2d.velocity = vel;
            //rb2d.AddForce(forceAdd);
        }
    }
}
