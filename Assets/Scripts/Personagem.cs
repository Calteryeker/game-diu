using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{   
    public float Speed;
    public float JumpForce;
    public float JumpMultiplier;
    public bool isJumping;
    public bool isDoubleJumping;
    public bool canHit;
    private Rigidbody2D rig;
    private Animator anim;
    private GameObject target;
    private int power;

    // Start is called before the first frame update
    void Start()
    {   
        power = 1;
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
 
    }

    // Update is called once per frame
    void Update()
    {   
        if(Time.timeScale != 0){
            Move();
            Jump();
            Hit();
            PowerUp();
        }

    }

    void Move(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
        
        if(Input.GetAxis("Horizontal") > 0f){
            anim.SetBool("walk",true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }
        if(Input.GetAxis("Horizontal") < 0f){
            anim.SetBool("walk",true);
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }
         if(Input.GetAxis("Horizontal") == 0f){
            anim.SetBool("walk",false);
        }

        
    }

    void Jump(){
        if (Input.GetButtonDown("Jump")){
            if(!isJumping){
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                anim.SetBool("jump",true);
            }
            else if(!isDoubleJumping){
                rig.AddForce(new Vector2(0f, JumpForce*JumpMultiplier), ForceMode2D.Impulse);
                isDoubleJumping = true;
                anim.SetBool("double_jump",true);
            }
                
        }
    }

    void Hit(){
        if(canHit){
            if(Input.GetButtonDown("Fire1")){
               target.GetComponent<Target>().GotHited(power);
                
            }
        }
    }

    void PowerUp(){
        if(Input.GetKeyDown(KeyCode.E)){
            if(this.GetComponent<Target>().life >= 3){
                power += 2;
                this.GetComponent<Target>().life -= 2;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.layer == 6){
            isJumping = false;
            isDoubleJumping = false;
            anim.SetBool("jump",false);
            anim.SetBool("double_jump",false);
        }

        if(collision.gameObject.tag == "Box" || collision.gameObject.tag == "Enemy"){
            canHit = true;
            target = collision.gameObject;
        }

    }

    void OnCollisionExit2D(Collision2D collision) {
        if(collision.gameObject.layer == 6){
            isJumping = true;
        }

        if(collision.gameObject.tag == "Box" || collision.gameObject.tag == "Enemy"){
            canHit = false;
            
        }

    }

    void OnDestroy(){
        if(GetComponent<Target>().life <= 0){
            LevelManager.instance.GameOver();
        }
        
    }
}
