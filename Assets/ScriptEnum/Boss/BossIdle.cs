using UnityEngine;

public class BossIdle : BossBase
{
    public override void Enter(BossST boss)
    {
        Debug.Log("Parado");
    }
    public override void Execute(BossST boss)
    {
        boss.anim.Play(BossST.IDLE);

        if (Vector3.Distance(boss.t_Boss.position, boss.t_Player.position) <= 15f)
        {
            boss.MudarEstado(EstadosBoss.Perseguir);
        }

    }
    public override void Exit(BossST boss)
    {

    }
}
