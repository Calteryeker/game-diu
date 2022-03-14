using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{   
    private Animator anim;
    public int life;
    private int frameCount;

    // Start is called before the first frame update
    void Start()
    {   
        anim = GetComponent<Animator>();
        
 
    }

    // Update is called once per frame
    void Update()
    {   
        
        if(frameCount > 0){
            frameCount--;
        }
        else{
            StopHit();
            if(life == 0){
                Destroy(this.gameObject);
            }
        }
    }

    public void GotHited(){
        anim.SetBool("hited", true);
        life--;
        frameCount = 20;
    }

    public void StopHit(){
        anim.SetBool("hited", false);
    }
}   