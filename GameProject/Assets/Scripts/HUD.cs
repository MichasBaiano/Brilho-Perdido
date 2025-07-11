using UnityEngine;
using TMPro;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI Vida;
    private PersonagemStats jogador;


    
    void Start()
    {
        jogador = JogadorManager.instancia.jogador.stats;
    }

    // Update is called once per frame
    void Update()
    {
        Vida.text = "Vida: " + jogador.vidaAtual;
    }
}
