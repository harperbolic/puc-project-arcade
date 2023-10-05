using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public GameObject inimigoPrefab1;
    public GameObject posicao1;
    public float tempoParaInstanciar1 = 15f;
    public GameObject inimigoPrefab2;
    public GameObject posicao2;
    public float tempoParaInstanciar2 = 37f;
    public GameObject inimigoPrefab3;
    public GameObject posicao3;
    public float tempoParaInstanciar3 = 62f;
    public GameObject inimigoPrefab4;
    public GameObject posicao4;
    public float tempoParaInstanciar4 = 62f;
    public GameObject inimigoPrefab5;
    public GameObject posicao5;
    public float tempoParaInstanciar5 = 62f;
    public GameObject inimigoPrefab6;
    public GameObject posicao6;
    public float tempoParaInstanciar6 = 62f;
    public GameObject inimigoPrefab7;
    public GameObject posicao7;
    public float tempoParaInstanciar7 = 62f;
    public GameObject inimigoPrefab8;
    public GameObject posicao8;
    public float tempoParaInstanciar8 = 62f;
    public GameObject inimigoPrefab9;
    public GameObject posicao9;
    public float tempoParaInstanciar9 = 62f;
    public GameObject inimigoPrefab10;
    public GameObject posicao10;
    public float tempoParaInstanciar10 = 62f;
    public GameObject inimigoPrefab11;
    public GameObject posicao11;
    public float tempoParaInstanciar11 = 62f;
    public GameObject inimigoPrefab12;
    public GameObject posicao12;
    public float tempoParaInstanciar12 = 62f;
    public GameObject inimigoPrefab13;
    public GameObject posicao13;
    public float tempoParaInstanciar13 = 62f;
    public GameObject inimigoPrefab14;
    public GameObject posicao14;
    public float tempoParaInstanciar14 = 62f;
    public GameObject inimigoPrefab15;
    public GameObject posicao15;
    public float tempoParaInstanciar15 = 62f;
    public GameObject inimigoPrefab16;
    public GameObject posicao16;
    public float tempoParaInstanciar16 = 62f;
    public GameObject inimigoPrefab17;
    public GameObject posicao17;
    public float tempoParaInstanciar17 = 62f;
    public GameObject inimigoPrefab18;
    public GameObject posicao18;
    public float tempoParaInstanciar18 = 62f;
    public GameObject inimigoPrefab19;
    public GameObject posicao19;
    public float tempoParaInstanciar19 = 62f;
    public GameObject inimigoPrefab20;
    public GameObject posicao20;
    public float tempoParaInstanciar20 = 62f;
   

    private GameObject posicao;

    private bool instanciouInimigo1 = false;
    private bool instanciouInimigo2 = false;
    private bool instanciouInimigo3 = false;
    private bool instanciouInimigo4 = false;
    private bool instanciouInimigo5 = false;
    private bool instanciouInimigo6 = false;
    private bool instanciouInimigo7 = false;
    private bool instanciouInimigo8 = false;
    private bool instanciouInimigo9 = false;
    private bool instanciouInimigo10 = false;
    private bool instanciouInimigo11 = false;
    private bool instanciouInimigo12 = false;
    private bool instanciouInimigo13 = false;
    private bool instanciouInimigo14 = false;
    private bool instanciouInimigo15 = false;
    private bool instanciouInimigo16 = false;
    private bool instanciouInimigo17 = false;
    private bool instanciouInimigo18 = false;
    private bool instanciouInimigo19 = false;
    private bool instanciouInimigo20 = false;

    private void Update()
    {
        float tempoDecorrido = Time.time;

        if (!instanciouInimigo1 && tempoDecorrido >= tempoParaInstanciar1)
        {
            posicao = posicao1;
            InstanciarInimigo(inimigoPrefab1);
            instanciouInimigo1 = true;
        }

        if (!instanciouInimigo2 && tempoDecorrido >= tempoParaInstanciar2)
        {
            posicao = posicao2;
            InstanciarInimigo(inimigoPrefab2);
            instanciouInimigo2 = true;
        }

        if (!instanciouInimigo3 && tempoDecorrido >= tempoParaInstanciar3)
        {
            posicao = posicao3;
            InstanciarInimigo(inimigoPrefab3);
            instanciouInimigo3 = true;
        }

        if (!instanciouInimigo4 && tempoDecorrido >= tempoParaInstanciar4)
        {
            posicao = posicao4;
            InstanciarInimigo(inimigoPrefab4);
            instanciouInimigo4 = true;
        }

        if (!instanciouInimigo5 && tempoDecorrido >= tempoParaInstanciar5)
        {
            posicao = posicao5;
            InstanciarInimigo(inimigoPrefab5);
            instanciouInimigo5 = true;
        }

        if (!instanciouInimigo6 && tempoDecorrido >= tempoParaInstanciar6)
        {
            posicao = posicao6;
            InstanciarInimigo(inimigoPrefab6);
            instanciouInimigo6 = true;
        }

        if (!instanciouInimigo7 && tempoDecorrido >= tempoParaInstanciar7)
        {
            posicao = posicao7;
            InstanciarInimigo(inimigoPrefab7);
            instanciouInimigo7 = true;
        }

        if (!instanciouInimigo8 && tempoDecorrido >= tempoParaInstanciar8)
        {
            posicao = posicao8;
            InstanciarInimigo(inimigoPrefab8);
            instanciouInimigo8 = true;
        }

        if (!instanciouInimigo9 && tempoDecorrido >= tempoParaInstanciar9)
        {
            posicao = posicao9;
            InstanciarInimigo(inimigoPrefab9);
            instanciouInimigo9 = true;
        }

        if (!instanciouInimigo10 && tempoDecorrido >= tempoParaInstanciar10)
        {
            posicao = posicao10;
            InstanciarInimigo(inimigoPrefab10);
            instanciouInimigo10 = true;
        }

        if (!instanciouInimigo11 && tempoDecorrido >= tempoParaInstanciar11)
        {
            posicao = posicao11;
            InstanciarInimigo(inimigoPrefab11);
            instanciouInimigo11 = true;
        }

        if (!instanciouInimigo12 && tempoDecorrido >= tempoParaInstanciar12)
        {
            posicao = posicao12;
            InstanciarInimigo(inimigoPrefab12);
            instanciouInimigo12 = true;
        }

        if (!instanciouInimigo13 && tempoDecorrido >= tempoParaInstanciar13)
        {
            posicao = posicao13;
            InstanciarInimigo(inimigoPrefab13);
            instanciouInimigo13 = true;
        }

        if (!instanciouInimigo14 && tempoDecorrido >= tempoParaInstanciar14)
        {
            posicao = posicao14;
            InstanciarInimigo(inimigoPrefab14);
            instanciouInimigo14 = true;
        }

        if (!instanciouInimigo15 && tempoDecorrido >= tempoParaInstanciar15)
        {
            posicao = posicao15;
            InstanciarInimigo(inimigoPrefab15);
            instanciouInimigo15 = true;
        }

        if (!instanciouInimigo16 && tempoDecorrido >= tempoParaInstanciar16)
        {
            posicao = posicao16;
            InstanciarInimigo(inimigoPrefab16);
            instanciouInimigo16 = true;
        }

        if (!instanciouInimigo17 && tempoDecorrido >= tempoParaInstanciar17)
        {
            posicao = posicao17;
            InstanciarInimigo(inimigoPrefab17);
            instanciouInimigo17 = true;
        }

        if (!instanciouInimigo18 && tempoDecorrido >= tempoParaInstanciar18)
        {
            posicao = posicao18;
            InstanciarInimigo(inimigoPrefab18);
            instanciouInimigo18 = true;
        }

        if (!instanciouInimigo19 && tempoDecorrido >= tempoParaInstanciar19)
        {
            posicao = posicao19;
            InstanciarInimigo(inimigoPrefab19);
            instanciouInimigo19 = true;
        }

        if (!instanciouInimigo20 && tempoDecorrido >= tempoParaInstanciar20)
        {
            posicao = posicao20;
            InstanciarInimigo(inimigoPrefab20);
            instanciouInimigo20 = true;
        }
    }

    private void InstanciarInimigo(GameObject inimigoPrefab)
    {
        Vector3 posicaoDeInstancia = posicao.transform.position; 
        GameObject novoInimigo = Instantiate(inimigoPrefab, posicaoDeInstancia, Quaternion.identity);

    }
}
