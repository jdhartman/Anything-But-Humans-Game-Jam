using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public float maxX;
    public float maxY;
    public float minX;
    public float minY;

    public Transform target;
    public Vector3 Camera;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if(target != null)
        {
            transform.position = new Vector3(Mathf.Clamp(target.position.x, minX, maxX), Mathf.Clamp(target.position.y, minY, maxY), target.position.z - 800);

        }
    }
}
