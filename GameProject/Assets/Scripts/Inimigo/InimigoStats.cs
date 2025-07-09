using UnityEngine;

public class InimigoStats : PersonagemStats
{
    Inimigo inimigo { get; set; }
    protected override void Start()
    {
        base.Start();
        inimigo = GetComponent<Inimigo>();
    }

    protected override void Morrer()
    {
        base.Morrer();
        inimigo.Morrer();
    }
}
