using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    public GameObject camera;
    [Tooltip("This variable controls the speed of the moving background, best to have it slower than Player so it looks like a parallax effect")]
    [Header("Parallax Effect Speed")]
    public float parallaxEffect;
    private float width, positionX;

    // Start is called before the first frame update
    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        positionX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float parallaxDistance = camera.transform.position.x * parallaxEffect;
        float remainingDistance = camera.transform.position.x * (1  - parallaxEffect);

        transform.position = new Vector3(positionX + parallaxDistance, transform.position.y, transform.position.z);

        if (remainingDistance > positionX + width)
        {
            positionX += width;
        }
    }
}
