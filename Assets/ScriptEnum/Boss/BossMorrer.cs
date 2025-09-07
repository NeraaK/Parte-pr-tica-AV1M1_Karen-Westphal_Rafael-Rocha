using UnityEngine;

public class BossMorrer : BossBase
{
    public override void Enter(BossST boss)
    {
        Debug.Log("Estou Morto");
        boss.anim.Play(StateMachineBossManager.MORRER);

    }

    public override void Execute(BossST boss)
    {
        
    }

    public override void Exit(BossST boss)
    {
        
    }
}
