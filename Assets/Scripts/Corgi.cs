using UnityEngine;
using System.Collections;

public class Corgi : MonoBehaviour {


    public float speedH;
    public float speedV;
    public float maxSpeed;
    public float friction;
    [Range(0.0f, 1.0f)]
    public float inputDelay;
    private Transform player;
    private Animator animator;
    private SpriteRenderer sp;
    private float newScale;
    private float speedUpdated;

    // Use this for initialization
    void Start ()
    {
        player = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        newScale = Mathf.Clamp(player.transform.localScale.x, -1, 1);
        speedUpdated = 0; 
	}
	
    void Animate()
    {

        if (speedUpdated == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            animator.SetTrigger("Idle");
        }
        else if((Input.GetAxis("Horizontal") > inputDelay || -inputDelay > Input.GetAxis("Horizontal")) && Input.GetAxisRaw("Horizontal") != 0)
        {
            animator.SetTrigger("Run");
        }
        else if ((Input.GetAxis("Vertical") > inputDelay || -inputDelay > Input.GetAxis("Vertical")) && Input.GetAxisRaw("Horizontal") == 0)
        {
            animator.SetTrigger("Walk");
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            sp.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            sp.flipX = true;
        }
        
    }
	// Update is called once per frame
	void Update ()
    {
        speedUpdated += Input.GetAxisRaw("Horizontal") * speedH;
        speedUpdated = Mathf.Clamp(speedUpdated, -maxSpeed, maxSpeed);
        Debug.Log(Input.GetAxis("Horizontal"));
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            if (Mathf.Abs(speedUpdated) < friction)
            {
                speedUpdated = 0;
                player.transform.Translate(speedUpdated, Input.GetAxis("Vertical") * speedH, 0);
            }
            else if (Mathf.Abs(speedUpdated) > friction)
            {
                speedUpdated -= friction * Mathf.Clamp(speedUpdated, -1, 1);
            }

        } else if ((speedUpdated > 0 && Input.GetAxisRaw("Horizontal") < 0) || (speedUpdated < 0 && Input.GetAxisRaw("Horizontal") > 0))
        {
            speedUpdated -= friction * Mathf.Clamp(speedUpdated, -1, 1);
        }


        player.transform.Translate(speedUpdated, Input.GetAxis("Vertical") * speedV, 0);
        Animate();
	}
}
