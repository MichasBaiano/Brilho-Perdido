using UnityEngine;

public class InimigoStateMachine
{


    public InimigoState atualState;

    public void Initialize(InimigoState _atualState) 
    {
        atualState = _atualState;
        atualState.Enter();
    }

    public void MudarState(InimigoState _novoState)
    {
        atualState.Exit();
        atualState = _novoState;
        atualState.Enter();
    }
}
