using UnityEngine;

public class BossAtaqueProjetil : BossBase
{
    private float timer;
    private const float cooldown = 1.5f;

    public override void Enter(BossST boss)
    {
        Debug.Log("Projetil");
        timer = 0f;

    }
    public override void Execute(BossST boss)
    {
        boss.t_Boss.LookAt(boss.t_Player);
        timer += Time.deltaTime;

        if (timer >= cooldown)
        {
            GameObject novoProjetil = boss.Instanciar(boss.projetilPrefab, boss.spawnPointProjetil.position, boss.spawnPointProjetil.rotation);
            Projetil scripProjetil = novoProjetil.GetComponent<Projetil>();
            boss.anim.Play(BossST.ATAQUEDISTANCIA);

            if (scripProjetil != null)
            {
                scripProjetil.AlvoPlayer(boss.t_Alvo);
            }
            timer = 0f;
        }

        if (Vector3.Distance(boss.t_Boss.position, boss.t_Player.position) <= 3f)
        {
           boss.MudarEstado(EstadosBoss.AtaqueNormal);
        }
        if (Vector3.Distance(boss.t_Boss.position, boss.t_Player.position) <= 3f && boss.vidaAtual <= 100f && boss.PodeDaEspecial())
        {
            boss.MudarEstado(EstadosBoss.AtaqueEspecial);

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
