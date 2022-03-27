using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caixa : MonoBehaviour
{  
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {   
        anim = GetComponent<Animator>();
        
    }

    void Update() {
       
    }

    void OnDestroy() {
        if(GetComponent<Target>().life <= 0){
            LevelManager.instance.numCaixas--;
            LevelManager.instance.pontuacao += 100;
        }
        
    }

}
