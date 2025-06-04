using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorStateMachine
{
    public JogadorState atualState { get; private set; }

    public void Initialize(JogadorState _inicialState)
    {
        atualState = _inicialState;
        atualState.Enter();
    }

    public void MudarState(JogadorState _novoState)
    {
        atualState.Exit();
        atualState = _novoState;
        atualState.Enter();
    }
}