using System.Collections;
using UnityEngine;

public class BossAtaqueEspecial : BossBase
{
    public override void Enter(BossST boss)
    {
        Debug.Log("EstadoAtaqueForte");
       
        boss.anim.Play(BossST.ESPECIAL);
        boss.t_Boss.LookAt(boss.t_Player);
    }

    public override void Execute(BossST boss)
    {

        if(!boss.PodeDaEspecial() && Vector3.Distance(boss.t_Boss.position, boss.t_Player.position) <= 3f)
        {
            boss.MudarEstado(EstadosBoss.AtaqueNormal);
        }
       
        if (Vector3.Distance(boss.t_Boss.position, boss.t_Player.position) >= 3f && (Vector3.Distance(boss.t_Boss.position, boss.t_Player.position) <= 10))
        {
            boss.MudarEstado(EstadosBoss.AtaqueProjetil);

        }
        else if (boss.vidaAtual <= 50f)
        {
            boss.MudarEstado(EstadosBoss.Fugir);
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
