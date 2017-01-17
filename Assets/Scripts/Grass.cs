using UnityEngine;
using System.Collections;

public class Grass : MonoBehaviour {


    public float animSpeed;
    private Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        anim.speed = 0;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" )
        {
            anim.speed = animSpeed;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.speed = 0;
        }
    }
}
