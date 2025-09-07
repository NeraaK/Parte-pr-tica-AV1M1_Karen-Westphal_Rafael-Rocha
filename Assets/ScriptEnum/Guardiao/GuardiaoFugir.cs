using UnityEngine;

public class GuardiaoFugir : GuadiaoBase
{
    public override void Enter(GuardiaoST guardiao)
    {
        Debug.Log("Fugindo");
    }

    public override void Execute(GuardiaoST guardiao)
    {

        guardiao.t_Guardiao.position = Vector3.MoveTowards(guardiao.t_Guardiao.position, guardiao.t_Recover.position, guardiao.velocidade * 2 * Time.deltaTime);
        guardiao.t_Guardiao.LookAt(guardiao.t_Recover);
        guardiao.anim.Play(GuardiaoST.WALK);
        if (Vector3.Distance(guardiao.t_Guardiao.position, guardiao.t_Recover.position) < 0.5)
        {
           guardiao.MudarEstado(EstadosGuardiao.Curar);
        }
        else if (guardiao.vidaAtual <= 0)
        {
            guardiao.MudarEstado(EstadosGuardiao.Morrer);
        }
    }

    public override void Exit(GuardiaoST guardiao)
    {
        
    }
}
