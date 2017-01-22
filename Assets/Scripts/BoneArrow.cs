using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneArrow : MonoBehaviour {

    // Use this for initialization
    public GameObject bone;
    public GameObject arrow;
    public SpriteRenderer renderer;
    private Vector3 rotationMask;
    private Vector3 difference;
    private float angle;

	
	// Update is called once per frame
	void Update () {
        if(!renderer.isVisible)
        {
            arrow.layer = 0;
            renderer.sortingLayerName = "Default";

            difference = transform.position - bone.transform.position;
            angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + 90;
            transform.rotation = Quaternion.AngleAxis(angle, transform.forward);
        }
        else
        {
            arrow.layer = 8;
        }
        
    }
}
