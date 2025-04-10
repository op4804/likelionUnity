using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private GameObject cam;

    [SerializeField]
    private float parallaxEffectMultiplier;

    private float xPosition;
    private float length;

    private void Start()
    {
        cam = Camera.main.gameObject;
        xPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float distanceMoved = cam.transform.position.x * (1- parallaxEffectMultiplier);
        float distanceToMove = cam.transform.position.x * parallaxEffectMultiplier;

        transform.position = new Vector3(xPosition + distanceToMove, transform.position.y, transform.position.z);

        if (distanceMoved > xPosition + length)
        {
            xPosition += length;
        }
        else if (distanceMoved < xPosition - length)
        {
            xPosition -= length;
        }
    }
}
