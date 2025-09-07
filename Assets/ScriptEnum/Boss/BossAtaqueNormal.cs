using UnityEngine;

public class BossAtaqueNormal : BossBase
{
    public override void Enter(BossST boss)
    {
        Debug.Log("AtaqueBase");
    }

    public override void Execute(BossST boss)
    {
        boss.anim.Play(StateMachineBossManager.ATAQUENORMAL);
        boss.t_Boss.LookAt(boss.t_Player);
        if (Vector3.Distance(boss.t_Boss.position, boss.t_Player.position) >= 3f && (Vector3.Distance(boss.t_Boss.position, boss.t_Player.position) <= 10))
        {
           boss.MudarEstado(EstadosBoss.AtaqueProjetil);
        }
        else if (boss.vidaAtual <= 100 && Vector3.Distance(boss.t_Boss.position, boss.t_Player.position) <= 3f && boss.PodeDaEspecial())
        {
            boss.MudarEstado(EstadosBoss.AtaqueEspecial);
            return;
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
