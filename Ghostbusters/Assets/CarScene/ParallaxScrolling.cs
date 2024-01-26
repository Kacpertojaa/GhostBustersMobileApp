using UnityEngine;

public class ParallaxScrolling : MonoBehaviour
{
    public float backgroundSpeed = 0.5f;
    private Renderer backgroundRenderer;

    void Start()
    {
        backgroundRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        Vector2 backgroundOffset = new Vector2(0, Time.time * backgroundSpeed);
        backgroundRenderer.material.mainTextureOffset = backgroundOffset;
    }
}
