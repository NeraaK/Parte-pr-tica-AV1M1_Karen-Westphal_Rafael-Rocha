using UnityEngine;

public class BossCurar : BossBase
{
    public override void Enter(BossST boss)
    {
        Debug.Log("Curando");
        boss.anim.Play(StateMachineBossManager.IDLE);
    }

    public override void Execute(BossST boss)
    {
        if (Vector3.Distance(boss.t_Boss.position, boss.t_Recover.position) < 0.5)
        {
            boss.tempoRegeneracao += Time.deltaTime;
            if (boss.tempoRegeneracao >= boss.intervaloRegeneracao)
            {
                Debug.Log("Curando");
                boss.vidaAtual += boss.taxaDeRegeneracao;
                if (boss.vidaAtual > boss.vidaMaxima)
                {
                    boss.vidaAtual = boss.vidaMaxima;
                }
                boss.tempoRegeneracao = 0f;
            }
        }

        if (boss.vidaAtual == boss.vidaMaxima)
        {
           boss.MudarEstado(EstadosBoss.Perseguir);
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
