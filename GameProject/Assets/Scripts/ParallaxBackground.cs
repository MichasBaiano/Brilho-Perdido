using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private GameObject cam; 
    [SerializeField] private float parallaxEffect = 0.5f;

    private float xPosicao;
    private float comprimento;

    void Start()
    {
        cam = GameObject.Find("Main Camera");

        comprimento = GetComponentInChildren<SpriteRenderer>().bounds.size.x;
        xPosicao = transform.position.x;
    }

    void LateUpdate()
    {
        float distanceToMove = cam.transform.position.x * parallaxEffect;
        float distanceMoved = cam.transform.position.x * (1 - parallaxEffect);

        transform.position = new Vector3(xPosicao + distanceToMove,transform.position.y, transform.position.z);

        if (distanceMoved > xPosicao + comprimento)
            xPosicao = xPosicao + comprimento;
        else if (distanceMoved < xPosicao - comprimento)
            xPosicao = xPosicao - comprimento;

    }
}
