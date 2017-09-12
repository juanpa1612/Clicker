using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mejoras : MonoBehaviour
{
    [SerializeField]
    private Text txtMetal;
    [SerializeField]
    private Color mejoraColor;
    [SerializeField]
    private ParticleSystem particulaMetal;
    private Button[] botonesMejoras;

    private int nivelActual;

    private void Awake()
    {
        nivelActual = 0;
        botonesMejoras = new Button[4];
        botonesMejoras = GetComponentsInChildren<Button>();
        botonesMejoras[0].interactable = false;
        botonesMejoras[1].interactable = false;
        botonesMejoras[2].interactable = false;
        botonesMejoras[3].interactable = false;
    }

    public void ActivarBotones()
    {
        if (ResourceManager.Instance.Metal >= 200 && nivelActual == 0)
        {
            botonesMejoras[0].interactable = true;
        }
        else
        {
            botonesMejoras[0].interactable = false;
        }
        if (ResourceManager.Instance.Metal >= 500 && nivelActual == 1)
        {
            botonesMejoras[1].interactable = true;
        }
        else
        {
            botonesMejoras[1].interactable = false;
        }
        if (ResourceManager.Instance.Metal >= 1000 && nivelActual == 2)
        {
            botonesMejoras[2].interactable = true;
        }
        else
        {
            botonesMejoras[2].interactable = false;
        }
        if (ResourceManager.Instance.Metal >= 2000 && nivelActual == 3)
        {
            botonesMejoras[3].interactable = true;
        }
        else
        {
            botonesMejoras[3].interactable = false;
        }
    }

    public void Level1 ()
    {
        if (ResourceManager.Instance.Metal >= 200 && nivelActual ==0)
        {
            nivelActual = 1;
            ResourceManager.Instance.DescontarMetal(200);
            txtMetal.GetComponent<Animator>().SetInteger("Level", 1);
        }
    }
    public void Level2 ()
    {
        if (ResourceManager.Instance.Metal >= 500 && nivelActual == 1)
        {
            nivelActual = 2;
            ResourceManager.Instance.DescontarMetal(500);
            ResourceManager.Instance.AcelerarX2();
        }
    }
    public void Level3()
    {
        if (ResourceManager.Instance.Metal >= 1000 && nivelActual == 2)
        {
            nivelActual = 3;
            ResourceManager.Instance.DescontarMetal(1000);
            ResourceManager.Instance.AcelerarX2();
            txtMetal.GetComponent<Animator>().SetInteger("Level", 3);
            particulaMetal.Play();
        }
    }
    public void Level4()
    {
        if (ResourceManager.Instance.Metal >= 2000 && nivelActual == 3)
        {
            nivelActual = 4;
            ResourceManager.Instance.DescontarMetal(2000);
            ResourceManager.Instance.AcelerarX2();
        }
    }
}
