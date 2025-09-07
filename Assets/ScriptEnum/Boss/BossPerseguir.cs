using Unity.VisualScripting;
using UnityEngine;

public class BossPerseguir : BossBase
{
    public override void Enter(BossST boss)
    {
        Debug.Log("Perseguindo");
    }

    public override void Execute(BossST boss)
    {
        boss.t_Boss.position = Vector3.MoveTowards(boss.t_Boss.position, boss.t_Player.position, boss.velocidade * Time.deltaTime);
        boss.t_Boss.LookAt(boss.t_Player.position);
        boss.anim.Play(BossST.WALK);



        if (Vector3.Distance(boss.t_Boss.position, boss.t_Player.position) <= 3f)
        {
            boss.MudarEstado(EstadosBoss.AtaqueNormal);
                        
            
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
