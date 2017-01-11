using UnityEngine;
using System.Collections;

public class Objective : MonoBehaviour {

    // Use this for initialization
    public Controller controller;
    private Transform transform;
    

	void Start () {
        transform = GetComponent<Transform>();
	}

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collected");
            controller.addToPointCount();
            controller.moveObjective(transform);
            Debug.Log("Total Points: " + controller.getPointCount());
        }
    }
}
