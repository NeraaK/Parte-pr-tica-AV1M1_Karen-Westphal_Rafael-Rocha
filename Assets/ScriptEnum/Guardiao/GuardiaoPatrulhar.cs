using UnityEngine;


public class GuardiaoPatrulhar : GuadiaoBase
{
    public override void Enter(GuardiaoST guardiao)
    {
        Debug.Log("Patrulhando");
    }

    public override void Execute(GuardiaoST guardiao)
    {
        guardiao.t_Guardiao.LookAt(guardiao.pontosDePatrulha[guardiao._index]);
        guardiao.anim.Play(GuardiaoST.WALK);
        guardiao.t_Guardiao.position = Vector3.MoveTowards(guardiao.t_Guardiao.position, guardiao.pontosDePatrulha[guardiao._index].position, guardiao.velocidade * Time.deltaTime);

        if (Vector3.Distance(guardiao.t_Guardiao.position, guardiao.pontosDePatrulha[guardiao._index].position) < 2f)
        {
            guardiao._index = (guardiao._index + 1) % guardiao.pontosDePatrulha.Length;
            
        }
        

        else if (Vector3.Distance(guardiao.t_Guardiao.position, guardiao.t_Player.position) <= 20f)
        {
            guardiao.MudarEstado(EstadosGuardiao.Alerta);
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
