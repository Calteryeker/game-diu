using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{   
    private Animator anim;
    public GameObject respawn;
    public GameObject shootProjectile;
    private int frameCount;
    public int limiar;
    void Start()
    {

        anim = GetComponent<Animator>();
        respawn = GameObject.FindGameObjectWithTag("RespawnPointEnemy");
        shootProjectile = GameObject.FindGameObjectWithTag("ShootPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if(frameCount == limiar){
            Shoot();
            frameCount = 0;
        }
        else{
            frameCount++;
        }
    
    }

    public void Shoot(){
        shootProjectile.GetComponent<ShootProjectile>().Spawn();
    }

    void OnDestroy(){
        GameObject.FindGameObjectWithTag("RespawnPointEnemy").GetComponent<RespawnEnemy>().initialLife += 2;
        LevelManager.instance.respawnEnemy = true;
        LevelManager.instance.OpenDoor();
    }
}
