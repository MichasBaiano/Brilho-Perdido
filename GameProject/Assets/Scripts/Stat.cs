using UnityEngine;

[System.Serializable]
public class Stat 
{
    [SerializeField] private int valorBase;

    public int getValor()
    {
        return valorBase;
    }
}
