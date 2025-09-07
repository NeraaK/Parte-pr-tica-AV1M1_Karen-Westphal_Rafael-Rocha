using UnityEngine;
using static Atividade2;

public class GuardiaoPerseguir : GuadiaoBase
{
    public override void Enter(GuardiaoST guardiao)
    {
        Debug.Log("Perseguindo");
    }

    public override void Execute(GuardiaoST guardiao)
    {
        
        guardiao.anim.Play(GuardiaoST.WALK);
        guardiao.t_Guardiao.LookAt(guardiao.t_Player.position);
        guardiao.t_Guardiao.position = Vector3.MoveTowards(guardiao.t_Guardiao.position, guardiao.t_Player.position,   guardiao.velocidade * Time.deltaTime);

        if (Vector3.Distance(guardiao.t_Guardiao.position, guardiao.t_Player.position) <= 3f)
        {
            guardiao.MudarEstado(EstadosGuardiao.AtaqueNormal);
        }
        else if (guardiao.vidaAtual <= 0)
        {
            guardiao.MudarEstado(EstadosGuardiao.Morrer);
        }
        else if (guardiao.vidaAtual == 80f)
        {
            guardiao.MudarEstado(EstadosGuardiao.ChamarAmigos);
        }
        else if (guardiao.vidaAtual <= 40)
        {
            guardiao.MudarEstado(EstadosGuardiao.Fugir);
        }

    }

    public override void Exit(GuardiaoST guardiao)
    {
        
    }
}
