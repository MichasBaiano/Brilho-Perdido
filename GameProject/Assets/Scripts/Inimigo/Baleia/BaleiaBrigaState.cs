using UnityEngine;

public class BaleiaBrigaState : InimigoState
{
    private Baleia inimigo;
    public BaleiaBrigaState(Inimigo _inimigoBase, InimigoStateMachine _maquina, string _nomeAnimation, Baleia inimigo) : base(_inimigoBase, _maquina, _nomeAnimation)
    {
        this.inimigo = inimigo;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("mudei o state");
    }

    public override void Exit()
    {
        base.Exit();

        if (AudioManager.instance.bgmIndex != 5)
            AudioManager.instance.PlayBGM(5);
    }

    public override void Update()
    {
        base.Update();

        if (PodeAtacar())
        {
            maquina.MudarState(inimigo.ataque);
        }
    }

    private bool PodeAtacar()
    {
        if (Time.time >= inimigo.ultimoAtaque + inimigo.ataquaCooldown)
        {
            inimigo.ultimoAtaque = Time.time;
            return true;
        }

        return false;
    }
}
