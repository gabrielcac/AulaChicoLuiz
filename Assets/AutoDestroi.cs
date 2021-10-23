using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroi : MonoBehaviour
{
    // Start is called before the first frame update
    public float tempoVida;
    void Start()
    {
        Destroy(gameObject, tempoVida);
    }


}
