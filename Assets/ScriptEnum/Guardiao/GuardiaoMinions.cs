using UnityEngine;

public class GuardiaoMinions : GuadiaoBase
{
    private float esperar = 0f;
    private const float ficarNoEstado = 2f;
    public override void Enter(GuardiaoST guardiao)
    {
        Debug.Log("Chamando Amigos");
        guardiao.anim.Play(GuardiaoST.ESPECIAL);
        esperar = 0f;
        guardiao.jaChamouMinions = false;

    }

    public override void Execute(GuardiaoST guardiao)
    {
        esperar += Time.deltaTime;

        if (!guardiao.jaChamouMinions)
        {


            if (guardiao.minions.Length > 0 && guardiao.spawnPointMinions.Length > 0)
            {
                int minionIndex = Random.Range(0, guardiao.minions.Length);
                GameObject minionParaSpawnar = guardiao.minions[minionIndex];

                int spawnIndex = Random.Range(0, guardiao.spawnPointMinions.Length);
                Transform spawnPoint = guardiao.spawnPointMinions[spawnIndex];

                guardiao.Instanciar(minionParaSpawnar, spawnPoint.position, spawnPoint.rotation);
                guardiao.jaChamouMinions = true;
               
            }
        }
        if (esperar >= ficarNoEstado && guardiao.jaChamouMinions)
        {
            Debug.Log("acabou o tempo");
            if (Vector3.Distance(guardiao.t_Guardiao.position, guardiao.t_Player.position) <= 3f)
            {
                guardiao.MudarEstado(EstadosGuardiao.AtaqueNormal);
            }
            else if (Vector3.Distance(guardiao.t_Guardiao.position, guardiao.t_Player.position) >= 3f && Vector3.Distance(guardiao.t_Guardiao.position, guardiao.t_Player.position) <= 10f)
            {
                guardiao.MudarEstado(EstadosGuardiao.AtaqueProjetil);
            }
           else if((Vector3.Distance(guardiao.t_Guardiao.position, guardiao.t_Player.position) >= 10f))
            {
                guardiao.MudarEstado(EstadosGuardiao.Perseguir);
            }
            
        }

    }
    public override void Exit(GuardiaoST guardiao)
    {
       
    }
}
