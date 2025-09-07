using UnityEngine;
using static Atividade2;

public class GuardiaoAlerta : GuadiaoBase
{
    public override void Enter(GuardiaoST guardiao)
    {
        Debug.Log("Atençao");
    }

    public override void Execute(GuardiaoST guardiao)
    {

        guardiao.anim.Play(GuardiaoST.IDLE);

        guardiao.t_Guardiao.LookAt(guardiao.t_Player.position);

        if (Vector3.Distance(guardiao.t_Guardiao.position, guardiao.t_Player.position) <= 10f)
        {
            guardiao.MudarEstado(EstadosGuardiao.Perseguir);
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
