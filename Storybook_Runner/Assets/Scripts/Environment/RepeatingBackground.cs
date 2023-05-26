using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    public GameObject camera;
    public float parallaxEffect;
    public float width, positionX;

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
