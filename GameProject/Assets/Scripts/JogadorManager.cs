using UnityEngine;

public class JogadorManager : MonoBehaviour
{
    public static JogadorManager instancia;
    public Jogador jogador;
    private void Awake()
    {
        if (instancia != null)
            Destroy(instancia.gameObject);
        else
            instancia = this;
    }
}
