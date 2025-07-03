using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField] protected float cooldown;
    protected float cooldownTimer;

    protected Jogador jogador;

    protected virtual void Start()
    {
        jogador = JogadorManager.instancia.jogador;
    }

    protected virtual void Update()
    {
        cooldownTimer -= Time.deltaTime;
    }

    public virtual bool CanUseSkill()
    {
        if(cooldownTimer < 0)
        {
            UseSkill();
            cooldownTimer = cooldown;
            return true;
        }

        Debug.Log("Skill está no cooldown");
        return false;
    }

    public virtual void UseSkill()
    {

    }
}
