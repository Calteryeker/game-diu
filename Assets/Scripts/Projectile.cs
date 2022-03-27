using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;
    public Vector3 targetPosition;
    void Start()
    {
        targetPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        Speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {   
        Move();

    }

    void Move(){
        Vector3 direction = targetPosition - this.transform.position;
        direction.Normalize();
        targetPosition += direction;
        transform.position += direction * Speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player"){
            collision.gameObject.GetComponent<Target>().GotHited(1);  
        }
        
        if(collision.gameObject.tag != "Enemy")
            Destroy(this.gameObject);
        
    }


    
}
