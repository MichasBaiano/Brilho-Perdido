using UnityEngine;

public class Tracker : MonoBehaviour
{
    [SerializeField] private Transform jogador; // arraste o jogador aqui no Inspector

    void Update()
    {
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, jogador.position.y, pos.z);
    }
}

