using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cardinal : MonoBehaviour {

    public Animator anim;

    public GameObject start;
    public GameObject end;
    public GameObject player;

    public float flySpeed;

    private float someScale;
    private float peckTime;
    private string flyState;
    private AudioSource flap;

    private bool startWait;
    private bool peckWait;

    // Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
        flap = GetComponent<AudioSource>();

        someScale = transform.localScale.x;
        transform.position = start.transform.position;
        flyState = "Idle";
        startWait = false;
    }
	 
    IEnumerator Wait()
    {
        startWait = true;
        Debug.Log("Coroutine Started");
        yield return new WaitForSeconds(Random.Range(10, 20));
        flyState = "toStart";
        transform.localScale = new Vector2(-someScale, transform.localScale.y);
        startWait = false;
        peckWait = false;
    }

    IEnumerator Peck()
    {
        int i = Random.Range(1, 3);
        peckWait = true;
        Debug.Log("Coroutine Started");
        yield return new WaitForSeconds(Random.Range(1, 3));
        if(i == 1)
        {
            anim.SetTrigger("Peck");
        }
        else if(i == 2)
        {
            anim.SetTrigger("Idle");
        }
        peckWait = false;


    }
// Update is called once per frame
    void Fly()
    {
        if (player == null)
        {
            anim.enabled = false;
        }

        else if ((Vector2.Distance(player.transform.position, transform.position) < 5) )
        {
            transform.localScale = new Vector2(someScale, transform.localScale.y);
            flyState = "toEnd";

        }
        else if (!startWait && Vector2.Distance(player.transform.position, transform.position) > 25 && transform.position == end.transform.position)
        {
            StartCoroutine(Wait());
        }
        else if(transform.position == start.transform.position)
        {
            flyState = "Idle";
        }
    }


    void Animate()
    {
        switch(flyState)
        {
            case "Idle":
                {
                    if(!peckWait)
                    {
                        StartCoroutine(Peck());
                    }
                    
                    break;
                }
            case "toStart":
                {
                    StopCoroutine(Peck());
                    if (Vector2.Distance(start.transform.position, transform.position) < 11)
                    {
                        anim.SetTrigger("Idle");
                    }
                    else
                    {
                        anim.SetTrigger("Fly");
                    } 
                    break;
                }
            case "toEnd":
                {
                    StopCoroutine(Peck());
                    anim.SetTrigger("Fly");
                    break;
                }
        }
    }
    void Update()
    {
        Fly();
        Animate();
        //Debug.Log(flyState);
        if (flyState == "toEnd")
        {
            transform.position = Vector2.MoveTowards(transform.position, end.transform.position, flySpeed * Time.deltaTime);
            if(!flap.isPlaying)
            {
                flap.Play();
            }
            

        }
         else if(flyState == "toStart")
        {
            transform.position = Vector2.MoveTowards(transform.position, start.transform.position, flySpeed * Time.deltaTime);
            if (!flap.isPlaying)
            {
                flap.Play();
            }
        }
        else
        {
            flap.Stop();
        }
        

        
    }
   }
