using UnityEngine;

public class PersonagemStats : MonoBehaviour
{

    public Stat dano;
    public Stat vidaMaxima;

    public int vidaAtual;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaAtual = vidaMaxima.getValor();    
    }

    public void TomarDano(int _dano)
    {
        vidaAtual -= _dano;
    }
}
