using UnityEngine;

public class GuardiaoCurar : GuadiaoBase
{
    public override void Enter(GuardiaoST guardiao)
    {
        Debug.Log("Curando");
        guardiao.anim.Play(GuardiaoST.IDLE);
    }

    public override void Execute(GuardiaoST guardiao)
    {
        if (Vector3.Distance(guardiao.t_Guardiao.position, guardiao.t_Recover.position) < 0.5)
        {
            guardiao.tempoRegeneracao += Time.deltaTime;
            if (guardiao.tempoRegeneracao >= guardiao.intervaloRegeneracao)
            {
                Debug.Log("Curando");
                guardiao.vidaAtual += guardiao.taxaDeRegeneracao;
                if (guardiao.vidaAtual > guardiao.vidaMaxima)
                {
                    guardiao.vidaAtual = guardiao.vidaMaxima;
                }
                guardiao.tempoRegeneracao = 0f;
            }
        }

        if (guardiao.vidaAtual == guardiao.vidaMaxima)
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
