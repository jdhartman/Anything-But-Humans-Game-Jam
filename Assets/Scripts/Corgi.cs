using UnityEngine;
using System.Collections;

public class Corgi : MonoBehaviour {


    public float speed;
    private Rigidbody2D rb2d;
    //private Vector2 move;

    // Use this for initialization
    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 move = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical"));
        rb2d.velocity = move;
	}
}
