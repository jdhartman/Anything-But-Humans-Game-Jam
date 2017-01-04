using UnityEngine;
using System.Collections;

public class Corgi : MonoBehaviour {


    public float speed;
    public float maxSpeed;
    public float friction;
    private Transform player;
    private Animator animator;
    private float newScale;
    private float speedUpdated;

    // Use this for initialization
    void Start ()
    {
        player = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        newScale = player.transform.localScale.x;
        speedUpdated = 0; 
	}
	
    void Animate()
    {

        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            animator.SetTrigger("Idle");
        }
        else animator.SetTrigger("Walk");
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
           // player.transform.localScale = new Vector2(newScale * Input.GetAxisRaw("Horizontal"), player.transform.localScale.y);
        }
        
    }
	// Update is called once per frame
	void Update ()
    {
        speedUpdated += Input.GetAxisRaw("Horizontal") * speed;
        Debug.Log(speedUpdated + " " + friction);
        if (Input.GetAxisRaw("Horizontal") == 0) 
        {
            if(Mathf.Abs(speedUpdated) < friction)
            {
                speedUpdated = 0;
                player.transform.Translate(speedUpdated, Input.GetAxis("Vertical") * speed, 0);
            }
            else if(Mathf.Abs(speedUpdated) > friction)
            {
                speedUpdated -= friction * Mathf.Clamp(speedUpdated, -1, 1);
            }
            
        }
        else
        {
            player.transform.Translate(Mathf.Clamp(speedUpdated, -maxSpeed, maxSpeed), Input.GetAxis("Vertical") * speed, 0);
        }
        Animate();
	}
}
