using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().color = Color.red;
    }
}
