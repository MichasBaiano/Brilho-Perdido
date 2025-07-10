using UnityEngine;

public class PersonagemStats : MonoBehaviour
{

    public Stat dano;
    public Stat vidaMaxima;

    public int vidaAtual;

    private Entidade entidade;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        vidaAtual = vidaMaxima.getValor();    

        entidade = GetComponent<Entidade>();
    }

    public virtual void TomarDano(int _dano)
    {
        vidaAtual -= _dano;

        if (vidaAtual < 0) {
            Debug.Log("Morreu");
            Morrer();
            entidade.Morrer();
        }

    }

    protected virtual void Morrer()
    {

    }
}
