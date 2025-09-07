using System.Collections.Generic;
using UnityEngine;


public class GuardiaoST : MonoBehaviour
{
    private GuadiaoBase estadoAtual;
    private EstadosGuardiao estadoEnum;


    [Header("Atributos")]
    public int velocidade;
    public float vidaMaxima;
    public float vidaAtual;
    public int danoAtaqueBase;
    public int danoAtaqueProjetil;
   
    public Transform t_Guardiao;
    public Transform t_Player;
    public Transform spawnPointProjetil;
    public GameObject projetilPrefab;
    public GameObject[] minions;
    public Transform[] spawnPointMinions;
    public Transform t_Alvo;
    public Transform t_Recover;
    //public Transform[] spawnMinions;
    public float taxaDeRegeneracao = 10f;
    public float tempoRegeneracao;
    public float intervaloRegeneracao = 1f;
    public Transform[] pontosDePatrulha;
    public int _index;
    

    public Animator anim;

    public const string IDLE = "Idle";
    public const string WALK = "Walk";
    public const string RUN = "Run";
    public const string ATAQUENORMAL = "AtaqueBase";
    public const string ATAQUEDISTANCIA = "AtaqueDistancia";
    public const string MORRER = "Morrer";
    public const string ESPECIAL = "Covarde";


    public bool jaChamouMinions = false;

    private void Start()
    {
        vidaAtual = vidaMaxima;

        MudarEstado(EstadosGuardiao.Patrulhar);

    }
    private void Update()
    {
       

        if (estadoAtual != null)
        {
            estadoAtual.Execute(this);
        }
    }
    public void MudarEstado(EstadosGuardiao novoEstado)
    {
        
        if (estadoAtual != null)
        {
            estadoAtual.Exit(this);
        }
        estadoEnum = novoEstado;

        switch (estadoEnum)
        {
            case EstadosGuardiao.Patrulhar:
                estadoAtual = new GuardiaoPatrulhar();
                break;

            case EstadosGuardiao.Alerta:
                    estadoAtual = new GuardiaoAlerta();
                break;

            case EstadosGuardiao.Perseguir:
                estadoAtual = new GuardiaoPerseguir();
                break;

            case EstadosGuardiao.AtaqueNormal:
                estadoAtual = new GuardiaoAtaqueNormal();
                break;

            case EstadosGuardiao.AtaqueProjetil:
                estadoAtual = new GuardiaoProjetil();
                break;

            case EstadosGuardiao.ChamarAmigos:
                estadoAtual = new GuardiaoMinions();
               
                break;

            case EstadosGuardiao.Curar:
                estadoAtual = new GuardiaoCurar();
                break;

            case EstadosGuardiao.Morrer:
                estadoAtual = new GuardiaoMorrer();
                break;

            case EstadosGuardiao.Fugir:
                estadoAtual = new GuardiaoFugir();
                break;
        }
        if (estadoAtual != null)
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
   
}
