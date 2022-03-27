using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{   
    public static LevelManager instance;
    public Text textPontuacao;
    public Text textLife;
    public int pontuacao;
    public GameObject door;
    public GameObject caixa1;
    public GameObject caixa2;
    public GameObject caixa3;
    public GameObject caixa4;
    public int numCaixas;
    public GameObject player;
    public bool respawnPlayer;
    public bool playerReturned;
    public GameObject enemy;
    public bool respawnEnemy;
    private int enemyLife;
    private float projectileSpeed;
    private bool pause;
    public GameObject pauseMenu;

    void Start()
    {
        numCaixas = 4;
        respawnEnemy = false;
        respawnPlayer = false;
        pause = false;
    }

    private void Awake(){
        instance = this;
        pontuacao = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(respawnPlayer)
            RespawnPlayer();
        
        MyPoints();
        MyLife();
        PauseMenu();
        
        
    }

    void RespawnCaixas(){
        caixa1.GetComponent<RespawnCaixa>().iniciar = true;
        caixa2.GetComponent<RespawnCaixa>().iniciar = true;
        caixa3.GetComponent<RespawnCaixa>().iniciar = true;
        caixa4.GetComponent<RespawnCaixa>().iniciar = true;
        numCaixas = 4;
    }
    void RespawnPlayer(){
        player.GetComponent<RespawnPlayer>().iniciar = true;
        
        enemy.GetComponent<RespawnEnemy>().initialLife = 1;
        RespawnEnemy();
        enemy.GetComponent<RespawnEnemy>().enemy.GetComponent<Inimigo>().GetComponent<Target>().life = 1;
        enemy.GetComponent<RespawnEnemy>().enemy.GetComponent<Inimigo>().limiar = 500;

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
    void MyLife(){
        textLife.text = "Vida: " + 
        GameObject.FindGameObjectWithTag("Player").GetComponent<Target>().life;
    }

    void PauseMenu(){
        if(Input.GetButtonDown("Cancel")){
            if(!pause){
                pause = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
            else{
                pause = false;
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            if(numCaixas == 0 && respawnEnemy){
                RespawnCaixas();
                RespawnEnemy();
                GameObject.FindGameObjectWithTag("Player").GetComponent<Target>().life += 1;
            }
        }    
    }

    public void GameOver(){
        SceneManager.LoadScene("GameOver");
    }
}
