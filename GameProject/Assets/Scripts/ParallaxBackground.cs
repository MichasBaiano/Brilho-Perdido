using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private GameObject cam; 
    [SerializeField] private float parallaxEffect = 0.5f;
    [SerializeField] private float parallaxEffectUP = 0.5f;

    private float xPosicao;
    private float yPosicao;
    private float comprimento;

    void Start()
    {
        cam = GameObject.Find("Main Camera");

        comprimento = GetComponentInChildren<SpriteRenderer>().bounds.size.x;
        xPosicao = transform.position.x;
        yPosicao = transform.position.y;
    }

    void LateUpdate()
    {
        float distanceToMove = cam.transform.position.x * parallaxEffect;
        float distanceToMoveUP = cam.transform.position.y * parallaxEffectUP;

        float distanceMoved = cam.transform.position.x * (1 - parallaxEffect);

        transform.position = new Vector3(xPosicao + distanceToMove, yPosicao + distanceToMoveUP, transform.position.z);

        if (distanceMoved > xPosicao + comprimento)
            xPosicao = xPosicao + comprimento;
        else if (distanceMoved < xPosicao - comprimento)
            xPosicao = xPosicao - comprimento;

    }
}
