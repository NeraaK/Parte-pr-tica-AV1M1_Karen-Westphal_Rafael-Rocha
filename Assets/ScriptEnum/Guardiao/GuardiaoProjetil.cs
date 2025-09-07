using Unity.VisualScripting;
using UnityEngine;
using static Atividade2;

public class GuardiaoProjetil : GuadiaoBase
{
    private float timer;
    private const float cooldown = 1.5f;
    public override void Enter(GuardiaoST guardiao)
    {
        Debug.Log("Projetil");
        timer = 0f;
    }

    public override void Execute(GuardiaoST guardiao)
    {
        guardiao.t_Guardiao.LookAt(guardiao.t_Player);
        timer += Time.deltaTime;

        if (timer >= cooldown)
        {
            GameObject novoProjetil = guardiao.Instanciar(guardiao.projetilPrefab, guardiao.spawnPointProjetil.position, guardiao.spawnPointProjetil.rotation);
            ProjetilGuardiaoLanca scripProjetil = novoProjetil.GetComponent<ProjetilGuardiaoLanca>();
            guardiao.anim.Play(GuardiaoST.ATAQUEDISTANCIA);

            if (scripProjetil != null)
            {
                scripProjetil.AlvoPlayer(guardiao.t_Alvo);
            }
            timer = 0f;
        }

        if (Vector3.Distance(guardiao.t_Guardiao.position, guardiao.t_Player.position) <= 3f)
        {
            guardiao.MudarEstado(EstadosGuardiao.AtaqueNormal);
        }
        else if (guardiao.vidaAtual == 80)
        {
            guardiao.MudarEstado(EstadosGuardiao.ChamarAmigos);

        }
        else if (guardiao.vidaAtual <= 40)
        {
            guardiao.MudarEstado(EstadosGuardiao.Fugir);
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
