using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mejoras;
    public float tiempoEspera;
    private int metal;
    private int valorMultiplicador;
    private bool generandoMetal;

    private void Start()
    {
        tiempoEspera = 1;
        generandoMetal = true;
        valorMultiplicador = 1;
        StartCoroutine(GenerarMetal(1));
    }

    public void AcelerarX2 ()
    {
        valorMultiplicador *= 2;
    }
    public void DescontarMetal (int costo)
    {
        metal -= costo;
        mejoras.GetComponent<Mejoras>().ActivarBotones();
    }
    private IEnumerator  GenerarMetal (int multiplicador)
    {
        while (generandoMetal)
        {
            multiplicador = valorMultiplicador;
            metal += 50 * multiplicador;
            mejoras.GetComponent<Mejoras>().ActivarBotones();
            yield return new WaitForSeconds(tiempoEspera);
        }
    }

    #region Singleton
    private static ResourceManager instance;
    private ResourceManager() { }

    public static ResourceManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("ScoreManager.Instance es nula pero se esta intentando accederla");
            }

            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(this);
        }
        else
        {
            if (this != instance)
                DestroyImmediate(this.gameObject);
        }
    }
    #endregion
    public int Metal
    {
        get
        {
            return metal;
        }
    }
    public int ValorMultiplicador
    {
        get
        {
            return valorMultiplicador;
        }
    }
}
