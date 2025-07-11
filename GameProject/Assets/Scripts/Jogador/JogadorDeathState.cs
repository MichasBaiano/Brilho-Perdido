using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JogadorDeathState : JogadorState
{

    public JogadorDeathState(Jogador _jogador, JogadorStateMachine _maquina, string _nomeAnimation) : base(_jogador, _maquina, _nomeAnimation)
    {

    }

    public override void Enter()
    {
        base.Enter();

        AudioManager.instance.PlayBGM(3);

        jogador.anim.SetBool(jogador.ultimaAnimBoolname, true);
        jogador.anim.speed = 0;
        jogador.cd.enabled = false;
        jogador.rb.gravityScale = 15;

        tempoState = .1f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        jogador.ZeroVelocity();

        if (tempoState > 0)
        {
            rb.linearVelocity = new Vector2(0, 30);
        }

        jogador.StartCoroutine(RecarregarCenaDepois(1.2f));
    }

    IEnumerator RecarregarCenaDepois(float segundos)
    {
        yield return new WaitForSeconds(segundos);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
