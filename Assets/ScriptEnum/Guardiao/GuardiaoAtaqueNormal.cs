using UnityEngine;
using static Atividade2;

public class GuardiaoAtaqueNormal : GuadiaoBase
{
    public override void Enter(GuardiaoST guardiao)
    {
        Debug.Log("AtaqueBase");
    }

    public override void Execute(GuardiaoST guardiao)
    {
        
        guardiao.anim.Play(GuardiaoST.ATAQUENORMAL);
        guardiao.t_Guardiao.LookAt(guardiao.t_Player.position);

        if (Vector3.Distance(guardiao.t_Guardiao.position, guardiao.t_Player.position) >= 3f && Vector3.Distance(guardiao.t_Guardiao.position, guardiao.t_Player.position) <= 10f)
        {
            guardiao.MudarEstado(EstadosGuardiao.AtaqueProjetil);
        }
        else if (guardiao.vidaAtual <= 0)
        {
            guardiao.MudarEstado(EstadosGuardiao.Morrer);
        }
        if (guardiao.vidaAtual == 80f)
        {
            guardiao.MudarEstado(EstadosGuardiao.ChamarAmigos);
        }
        if (guardiao.vidaAtual <= 40)
        {
            guardiao.MudarEstado(EstadosGuardiao.Fugir);
        }

    }

    public override void Exit(GuardiaoST guardiao)
    {
        
    }
}
