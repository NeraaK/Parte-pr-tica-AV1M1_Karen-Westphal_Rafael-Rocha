using UnityEngine;

public class GuardiaoMorrer : GuadiaoBase
{
    public override void Enter(GuardiaoST guardiao)
    {
        Debug.Log("Estou Morto");
        guardiao.anim.Play(StateMachineBossManager.MORRER);
    }

    public override void Execute(GuardiaoST guardiao)
    {
        
    }

    public override void Exit(GuardiaoST guardiao)
    {
        
    }
}
