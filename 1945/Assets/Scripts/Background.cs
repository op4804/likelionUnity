using UnityEngine;

public class Background : MonoBehaviour
{
    public float scrollSpeed = 0.01f;
    Material myMaterial;

    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        float newOffsetY = myMaterial.mainTextureOffset.y + scrollSpeed * Time.deltaTime;

        myMaterial.mainTextureOffset = new Vector2(0, newOffsetY);
    }
}
