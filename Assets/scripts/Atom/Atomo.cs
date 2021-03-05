using System.Collections.Generic;
using UnityEngine;

public class Atomo : MonoBehaviour
{



    public List<Atomo> atomosConectados;
    [SerializeField]
    private Atomo atomoPai;
    private Transform referencia;
    public float distanciaAtomo = 40;
    private GameObject ligacao;
    private bool ligacoesCriadas;
    private bool ligacoesExistem;
    [SerializeField]
    private char simb;

    private int numLig;

    void Start()
    {
        referencia = GameObject.Find("Referencia").transform;
        ligacao = GameObject.Find("Ligacao");
        ligacoesCriadas = false;
        ligacoesExistem = false;
        if (name.Contains("Carbono"))
        {
            this.simb = 'C';
            this.numLig = 4;
        }
        else
        {
            this.simb = 'H';
            this.numLig = 1;
        }
    }

    void Update()
    {

        if (simb == 'C' && atomosConectados.Count >= 3)
        {
            CorrigirPosicoes();
            if (!ligacoesCriadas)
            {
                criarLigacoes();
            }
        }

    }

    private void CorrigirPosicoes()
    {
        if (atomosConectados != null && atomosConectados.Count > 0 && simb == 'C')
        {
            Vector3[] conexoes = new Vector3[atomosConectados.Count];
            referencia.forward = transform.forward;

            if (conexoes.Length == 1)
            {
                conexoes[0] = referencia.GetChild(1).GetChild(0).position;
            }
            else if (conexoes.Length == 2)
            {
                conexoes[0] = referencia.GetChild(2).GetChild(0).position;
                conexoes[1] = referencia.GetChild(2).GetChild(1).position;
            }
            else if (conexoes.Length == 3)
            {
                conexoes[0] = referencia.GetChild(3).GetChild(0).position;
                conexoes[1] = referencia.GetChild(3).GetChild(1).position;
                conexoes[2] = referencia.GetChild(3).GetChild(2).position;
            }
            else if (conexoes.Length == 4)
            {
                conexoes[0] = referencia.GetChild(4).GetChild(0).position;
                conexoes[1] = referencia.GetChild(4).GetChild(1).position;
                conexoes[2] = referencia.GetChild(4).GetChild(2).position;
                conexoes[3] = referencia.GetChild(4).GetChild(3).position;
            }

            for (int i = 0; i < conexoes.Length; i++)
            {
                if (atomosConectados[i].simb == 'H')
                {
                    distanciaAtomo = 2;
                }
                else
                {
                    distanciaAtomo = 4;
                }
                atomosConectados[i].transform.position = transform.position + (conexoes[i] * distanciaAtomo);
                atomosConectados[i].transform.LookAt(transform.position);
            }
        }

    }

    private void criarLigacoes()
    {
        if (ligacoesExistem)
        {
            destruirLigacoes();
        }
        if (atomosConectados != null && atomosConectados.Count > 0)
        {
            Vector3[] conexoes = new Vector3[atomosConectados.Count];
            referencia.forward = transform.forward;

            if (conexoes.Length == 1)
            {
                conexoes[0] = transform.position + referencia.GetChild(1).GetChild(0).position;
            }
            else if (conexoes.Length == 2)
            {
                conexoes[0] = transform.position + referencia.GetChild(2).GetChild(0).position;
                conexoes[1] = transform.position + referencia.GetChild(2).GetChild(1).position;
            }
            else if (conexoes.Length == 3)
            {
                conexoes[0] = transform.position + referencia.GetChild(3).GetChild(0).position;
                conexoes[1] = transform.position + referencia.GetChild(3).GetChild(1).position;
                conexoes[2] = transform.position + referencia.GetChild(3).GetChild(2).position;
            }
            else if (conexoes.Length == 4)
            {
                conexoes[0] = transform.position + referencia.GetChild(4).GetChild(0).position;
                conexoes[1] = transform.position + referencia.GetChild(4).GetChild(1).position;
                conexoes[2] = transform.position + referencia.GetChild(4).GetChild(2).position;
                conexoes[3] = transform.position + referencia.GetChild(4).GetChild(3).position;
            }

            for (int i = 0; i < conexoes.Length; i++)
            {
                GameObject lig = Instantiate(ligacao, (transform.position + atomosConectados[i].transform.position) / 2, Quaternion.identity);

                Vector3 rotationDirection = (atomosConectados[i].transform.position - transform.transform.position); //Change Rotation
                lig.transform.rotation = Quaternion.LookRotation(rotationDirection);
                lig.transform.SetParent(atomosConectados[i].transform);
                lig.transform.localEulerAngles = new Vector3(90f, 0f, 0f);

                float distance = Vector3.Distance(transform.transform.position, atomosConectados[i].transform.position); //Change Scale
                if (atomosConectados[i].getSimb() == 'C')
                {
                    lig.transform.localScale = new Vector3(0.3f, distance / 40f, 0.3f);
                }
                else
                {
                    lig.transform.localScale = new Vector3(0.3f, distance/20f, 0.3f);
                    lig.transform.localPosition = new Vector3(0,0,0.85f);
                }
                print("Estou colocando");
            }
            ligacoesExistem = true;
            ligacoesCriadas = true;
        }
    }
    void destruirLigacoes()
    {
        float i = 0;
        bool achou = true;
        foreach (Atomo conectado in atomosConectados)
        {
            i++;
            print("numAtomoConectato:" + i);
            try
            {
                if (conectado.gameObject.transform.GetChild(0))
                {
                    achou = true;
                }
            }
            catch (UnityException)
            {
                achou = false;
            }
            if (achou)
            {
                if (conectado.gameObject.transform.GetChild(0).name.Contains("Ligacao"))
                {
                    conectado.gameObject.transform.GetChild(0).GetComponent<SelfDestroy>().selfDestroy();
                }
            }
        }
        ligacoesExistem = false;
    }

    public Atomo getAtomoById(int id)
    {
        return this.atomosConectados[id];
    }

    public void addAtomo(Atomo atomo)
    {
        this.atomosConectados.Add(atomo);
    }
    public void setAtomoById(int id, Atomo atomo)
    {
        this.atomosConectados[id] = atomo;

    }

    public void setAllAtomos(List<Atomo> atomos)
    {
        this.atomosConectados = atomos;
    }

    public char getSimb()
    {
        return this.simb;
    }

    public int getNumLig()
    {
        return this.numLig;
    }

    public void substituirAtomo(Atomo velho, Atomo novo)
    {
        for (int i = 0; i < atomosConectados.Count; i++)
        {
            if (velho == atomosConectados[i])
            {
                atomosConectados[i] = novo;
            }
        }

    }

    public List<Atomo> getAllAtomos()
    {
        return atomosConectados;
    }

    public void setAtomoPai(Atomo pai)
    {
        this.atomoPai = pai;
    }

    public Atomo getAtomoPai()
    {
        return atomoPai;
    }

    public int findAtomoId(Atomo lig)
    {
        for (int i = 0; i < atomosConectados.Count; i++)
        {
            if (atomosConectados[i] == lig)
            {
                return i;
            }
        }
        return -1;
    }

    public void recriarLig()
    {
        this.ligacoesCriadas = false;
    }
}


