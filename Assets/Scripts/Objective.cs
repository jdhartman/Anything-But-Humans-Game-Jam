using UnityEngine;
using System.Collections;

public class Objective : MonoBehaviour {

    // Use this for initialization
    public Corgi Corgi;
    public Transform transform;
    

	void Start () {
        transform = GetComponent<Transform>();
	}

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collected");
            Corgi.addToPointCount();
            transform.Translate(5, 5, 0);
            Debug.Log("Total Points: " + Corgi.getPointCount());
        }
    }
}
