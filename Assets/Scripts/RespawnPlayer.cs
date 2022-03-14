using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    public bool iniciar;
    public GameObject player;
    private int frameCount;
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
        Instantiate(player, this.gameObject.transform.position, Quaternion.identity);
    }
}
