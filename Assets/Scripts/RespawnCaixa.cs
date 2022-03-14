using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCaixa : MonoBehaviour
{   
    public bool iniciar;
    private int frameCount;
    public GameObject novaCaixa;
    // Start is called before the first frame update
    void Start()
    {
        frameCount = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        if(iniciar){
            frameCount++;

            if(frameCount == 60){
                Respawn();
                iniciar = false;
                frameCount = 0;
            }
        }
    }

    void Respawn(){
        Instantiate(novaCaixa, this.gameObject.transform.position, Quaternion.identity);
        
    }
}
