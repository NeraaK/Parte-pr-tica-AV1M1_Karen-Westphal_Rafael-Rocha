using UnityEngine;

public class BossFugir : BossBase
{
    public override void Enter(BossST boss)
    {
        Debug.Log("Fugindo");

    }

    public override void Execute(BossST boss)
    {
        boss.t_Boss.position = Vector3.MoveTowards(boss.t_Boss.position, boss.t_Recover.position, boss.velocidade * 2 * Time.deltaTime);
        boss.t_Boss.LookAt(boss.t_Recover);
        boss.anim.Play(BossST.WALK);
        if (Vector3.Distance(boss.t_Boss.position, boss.t_Recover.position) <= 0.5)
        {
            boss.MudarEstado(EstadosBoss.Curar);
        }
        else if (boss.vidaAtual <= 0)
        {
           boss.MudarEstado(EstadosBoss.Morrer);
        }

    }

    public override void Exit(BossST boss)
    {
        
    }
}
