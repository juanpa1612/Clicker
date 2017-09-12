using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    private Text txtMetal;
    [SerializeField]
    private Text txtTasa;
    [SerializeField]
    private CanvasGroup mejoras;
    [SerializeField]
    private Vector3[] posiciones;

    private Color[] colores;
    private Animator animMejoras;


    private void Start()
    {
        colores = new Color[4];
        colores[0] = Color.red;
        colores[1] = Color.blue;
        colores[2] = Color.yellow;
        colores[3] = Color.green;

        animMejoras = mejoras.GetComponent<Animator>();
    }

    void Update ()
    {
        txtMetal.text = "Metal " + ResourceManager.Instance.Metal.ToString();
        txtTasa.text = "X " + ResourceManager.Instance.ValorMultiplicador.ToString();
	}

    public void MostrarMejoras ()
    {
        if (animMejoras.GetBool("Active") == false)
        {
            animMejoras.SetBool("Active", true);
        }
        else
        {
            animMejoras.SetBool("Active", false);
        }
    }

    public void MostrarTasa ()
    {
        txtTasa.gameObject.SetActive(true);
        txtTasa.GetComponent<Animator>().Play("Fall",0,0);
        txtTasa.rectTransform.localPosition = posiciones[Random.Range(0, 4)];
        txtTasa.color = colores[Random.Range(0, 4)];
    }

    
}
