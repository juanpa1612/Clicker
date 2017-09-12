using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Acelerar : MonoBehaviour
{
    public float tiempoGracia;
    private bool acelerando;

    [SerializeField]
    CanvasGroup barraAcelerar;
    [SerializeField]
    private Slider progressBar;

    private void Start()
    {
        tiempoGracia = 10;
    }
    private void Update()
    {
        if (tiempoGracia > 0 && acelerando == true)
        {
            tiempoGracia -= 1 * Time.deltaTime;
            progressBar.value = tiempoGracia;
        }
        if (tiempoGracia <= 0)
        {
            barraAcelerar.GetComponent<Animator>().SetBool("Active", false);
            tiempoGracia = 10;
            acelerando = false;
            ResourceManager.Instance.tiempoEspera = 1f;
        }
    }

    public void AcelerarGeneracion ()
    {
        if (tiempoGracia == 10)
        {
            acelerando = true;
            ResourceManager.Instance.tiempoEspera = 0.5f;
            barraAcelerar.GetComponent<Animator>().SetBool("Active", true);
        }
    }

}
