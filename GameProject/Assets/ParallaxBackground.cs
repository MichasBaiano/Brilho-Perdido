using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Transform cam; 
    [SerializeField] private float parallaxEffect = 0.5f;

    private Vector3 lastCamPosition;

    void Start()
    {
        lastCamPosition = cam.position;
    }

    void LateUpdate()
    {
        Vector3 deltaMovement = cam.position - lastCamPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffect, deltaMovement.y * parallaxEffect, transform.position.z);
        lastCamPosition = cam.position;
    }
}
