using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class DialogoManager : MonoBehaviour
{
    public Queue<string> frases;
    public TextMeshProUGUI nomeTexto;
    public TextMeshProUGUI dialogoTexto;
    [SerializeField] public GameObject canvas;

    void Start()
    {
        frases = new Queue<string>();

    }

    public void comecarDialogo(Dialogo dialogo)
    {
        frases.Clear();
        canvas.SetActive(true);

        nomeTexto.text = dialogo.nome;

        foreach (string frase in dialogo.frases)
        {
            frases.Enqueue(frase);
        }
        mostrarProximaFrase();

    }

    public void mostrarProximaFrase()
    {
        if (frases.Count == 0)
        {
            finalizarDialogo();
            return;

        }


        string frase = frases.Dequeue();
        dialogoTexto.text = frase;
    }

    public void finalizarDialogo()
    {
        canvas.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && frases.Count >= 0) {
            mostrarProximaFrase();
        }
    }
}
