using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class DepthController : MonoBehaviour {

    public Renderer cachedSpriteRenderer;

    private void Start()
    {
        cachedSpriteRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        cachedSpriteRenderer.sortingOrder = (int)(transform.position.y * -10);
    }
}
