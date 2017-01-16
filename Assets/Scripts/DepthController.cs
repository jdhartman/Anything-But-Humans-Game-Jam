using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class DepthController : MonoBehaviour {

    public Renderer cachedSpriteRenderer;
    public bool isMoving;
    public int offset;

    private void Start()
    {
        cachedSpriteRenderer = GetComponent<Renderer>();
        cachedSpriteRenderer.sortingOrder = (int)(transform.position.y * -10) + offset;
    }

    void Update()
    {
        if(isMoving)
        {
            cachedSpriteRenderer.sortingOrder = (int)(transform.position.y * -10);
        }
    }
}
