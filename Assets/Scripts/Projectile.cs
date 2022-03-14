using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move(){
        Vector3 movement = new Vector3(-1f, 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player"){
            collision.gameObject.GetComponent<Target>().GotHited();  
        }

        Destroy(this.gameObject);
        
    }


    
}
