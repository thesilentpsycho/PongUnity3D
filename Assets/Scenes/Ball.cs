using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    [SerializeField]
    float speed;

    #region
    public Rigidbody2D ballRB;
    public Transform ballTransform;
    #endregion

    public GameManager manager;
    float radius;
    public Vector2 direction;
    public bool isInPlay = false;
    //private GameManager gm;

    // Use this for initialization
    void Start () {
        ballTransform = this.transform;
        radius = transform.localScale.x / 2;
        ServeBall();
    }

    public void ServeBall()
    {
        ballTransform.position = new Vector3(0, 0);
        direction = Vector2.one.normalized;
        isInPlay = true;
        //ballRB.AddForce(new Vector2(1, 0), ForceMode2D.Impulse);
    }


	// Update is called once per frame
	void Update () {
        transform.Translate(direction * speed * Time.deltaTime);

        //Logic for top and bottom
        if (transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0)
            {
                direction.y = -direction.y;
            }
        if (transform.position.y > GameManager.topRight.y - radius && direction.y > 0)
        {
            direction.y = -direction.y;
        }

        //Logic when ball goes out of boundary in x axis
        if (transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0)
        {
            Debug.Log("left side");
            manager.UpdateScore("right");
            StopAndRepositionBall();
        }
        if (transform.position.x > GameManager.topRight.x - radius && direction.x > 0)
        {
            Debug.Log("right side hit");
            manager.UpdateScore("left");
            StopAndRepositionBall();
            //Game over
            //Debug.Log("Game over. Left Player Wins");
            //GameManager.rightPlayerLife -= 1;
        }

    }

    public void StopAndRepositionBall()
    {
        ballTransform.position = new Vector3(0, 0);
        ServeBall();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Paddle")
        {
            bool isRight = other.GetComponent<Paddle>().isRight;
            if(isRight && direction.x > 0)
            {
                direction.x = -direction.x;
            }
            if (isRight == false && direction.x < 0)
            {
                direction.x = -direction.x;
            }
        }
    }
}
