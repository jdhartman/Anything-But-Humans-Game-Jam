using UnityEngine;
using System.Collections;

public class Grass : MonoBehaviour {


    public float animSpeed;
    private Animator anim;
    private AudioSource walk;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        walk = GetComponent<AudioSource>();
        anim.speed = 0;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" )
        {
            anim.speed = animSpeed;
            if(!walk.isPlaying)
            {
                walk.Play();
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.speed = 0;
            walk.Stop();
        }
    }
}
