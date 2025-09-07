using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Rendering;

public class BossST : MonoBehaviour
{
    private BossBase estadoAtual;
    private EstadosBoss estadoEnum;

    [Header("Atributos")]
    public int velocidade;
    public float vidaMaxima;
    public float vidaAtual;
    public int danoAtaqueBase;
    public int danoAtaqueProjetil;
    public int danoAtaqueEspecial;
    public Transform t_Boss;
    public Transform t_Player;
    public Transform spawnPointProjetil;
    public GameObject projetilPrefab;
    public Transform t_Alvo;
    public Transform t_Recover;
    public float taxaDeRegeneracao = 10f;
    public float tempoRegeneracao;
    public float intervaloRegeneracao = 1f;
    public float tempoParaEspecial = 10f;
    private float ultimoAtaqueEspecial;

    public Animator anim;

    public const string IDLE = "Idle";
    public const string WALK = "Walk";
    public const string RUN = "Run";
    public const string ATAQUENORMAL = "AtaqueBase";
    public const string ATAQUEDISTANCIA = "AtaqueDistancia";
    public const string MORRER = "Morrer";
    public const string ESPECIAL = "Especial";


    private void Start()
    {
        vidaAtual = vidaMaxima;

        MudarEstado(EstadosBoss.Idle);

    }
    private void Update()
    {
        if (estadoAtual != null)
        {
            estadoAtual.Execute(this);
        }
    }
    public void MudarEstado(EstadosBoss novoEstado)
    {
        VerConsole();
        if (estadoAtual != null)
        {
            estadoAtual.Exit(this);
        }
        estadoEnum = novoEstado;

        switch (estadoEnum)
        {
            case EstadosBoss.Perseguir:
                estadoAtual = new BossPerseguir();
                break;

            case EstadosBoss.AtaqueNormal:
                estadoAtual = new BossAtaqueNormal();
                break;

            case EstadosBoss.AtaqueProjetil:
                estadoAtual = new BossAtaqueProjetil();
                break;

            case EstadosBoss.AtaqueEspecial:
                
                if(!PodeDaEspecial() &&  Vector3.Distance(t_Boss.position, t_Player.position) <= 3)
                {
                    estadoAtual = new BossAtaqueNormal();
                }
                else
                {
                    estadoAtual = new BossAtaqueEspecial();
                }
                break;

            case EstadosBoss.Curar:
                estadoAtual = new BossCurar();
                break;

            case EstadosBoss.Morrer:
                estadoAtual = new BossMorrer();
                break;

            case EstadosBoss.Fugir:
                estadoAtual = new BossFugir();
                break;

            case EstadosBoss.Idle:
                estadoAtual = new BossIdle();
                break;
        }
        if(estadoAtual != null)
        {
            estadoAtual.Enter(this);
        }
      
    }
    public GameObject Instanciar(GameObject objeto, Vector3 posicao, Quaternion rotacao)
    {
        GameObject novoObjeto = Instantiate(objeto, posicao, rotacao);
        return novoObjeto;
    }
    public void ReceberDano(float dano)
    {
        vidaAtual -= dano;

        if (vidaAtual <= 0)
        {
            Debug.Log("Morri");
            
        }

    }
   
    public void VerConsole()
    {
        if (vidaAtual == vidaMaxima)
        {
            Debug.Log("Vida Cheia");
        }
        else if (vidaAtual <= 100f)
        {
            Debug.Log("Vida pela metade");
        }
        else if (vidaAtual <= 50f)
        {
            Debug.Log("Vida abaixo de 50");
        }
    }
    public bool PodeDaEspecial()
    {
        return Time.time >= ultimoAtaqueEspecial + tempoParaEspecial;
    }
    public void EspecialUsado()
    {
        ultimoAtaqueEspecial = Time.time;
    }

}
