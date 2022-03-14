using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{   
    public static LevelManager instance;
    public Text textPontuacao;
    public int pontuacao;
    public GameObject door;
    public GameObject caixa1;
    public GameObject caixa2;
    public int numCaixas;
    public GameObject player;
    public bool respawnPlayer;
    public bool playerReturned;
    public GameObject enemy;
    public bool respawnEnemy;
    private int enemyLife;
    private float projectileSpeed;

    void Start()
    {
        numCaixas = 2;
        respawnEnemy = false;
        respawnPlayer = false;
    }

    private void Awake(){
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(respawnPlayer)
            RespawnPlayer();
        
        MyPoints();
        
    }

    void RespawnCaixas(){
        caixa1.GetComponent<RespawnCaixa>().iniciar = true;
        caixa2.GetComponent<RespawnCaixa>().iniciar = true;
        numCaixas = 2;
    }
    void RespawnPlayer(){
        player.GetComponent<RespawnPlayer>().iniciar = true;
        
        enemy.GetComponent<RespawnEnemy>().initialLife = 0;
        RespawnEnemy();
        enemy.GetComponent<RespawnEnemy>().enemy.GetComponent<Inimigo>().GetComponent<Target>().life = 1;

        if(numCaixas == 1){
            caixa1.GetComponent<RespawnCaixa>().iniciar = true;
        }

        pontuacao = 0;
        respawnPlayer = false;
    }
    void RespawnEnemy(){
        enemy.GetComponent<RespawnEnemy>().iniciar = true;
        CloseDoor();
        respawnEnemy = false;
    }

    public void OpenDoor(){
        door.SetActive(false);
    }

    void CloseDoor(){
        door.SetActive(true);
    }

    void MyPoints(){
        textPontuacao.text = "Pontuação: " + pontuacao.ToString();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            if(numCaixas == 0 && respawnEnemy){
                RespawnCaixas();
                RespawnEnemy();
            }
        }    
    }
}
