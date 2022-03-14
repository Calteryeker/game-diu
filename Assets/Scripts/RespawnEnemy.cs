using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnemy : MonoBehaviour
{
    public bool iniciar;
    public int initialLife;
    private int frameCount;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        initialLife = 1;
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
        Instantiate(enemy, this.gameObject.transform.position, Quaternion.identity);
        enemy.GetComponent<Target>().life = initialLife;
    }
}