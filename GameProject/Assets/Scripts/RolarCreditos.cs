using UnityEngine;

public class RolarCreditos : MonoBehaviour
{

    public float velocidade = 50f;
    void Update()
    {
        transform.Translate(Vector3.up * velocidade * Time.deltaTime);
    }
}
