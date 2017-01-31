using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour {

    public Renderer shadowee;
    public Renderer cachedSpriteRenderer;
    public bool isMoving;
    public bool isCardinal;
    [Range(-1.0f, 1.0f)]
    public float offset;

    void Start()
    {
        cachedSpriteRenderer = GetComponent<Renderer>();
        cachedSpriteRenderer.sortingOrder = shadowee.sortingOrder - 1;
    }

    void Update()
    {
        if(isMoving)
        {
            cachedSpriteRenderer.sortingOrder = shadowee.sortingOrder - 1;
        }
        if(isCardinal)
        {
            transform.position = new Vector3(shadowee.transform.position.x - offset, transform.position.y, 0);
        }
    }


}
