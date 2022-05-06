using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{   

    //variables to store, rigidbody, UI panels components
    public Rigidbody2D rb;
    public GameObject gamePanelWon;
    public GameObject gamePanelPause;
    public GameObject gameLostPanel;
    // initial userspeed and acceleration
    public float speed = 2.5f; // player moves with 2.5 units per second when game starts
    public float accel = 2f;   // speed increases by 2 units per second every second
    float acc = 0f; // initial acceleration is 0
    
    private bool GameOver = false;
    [SerializeField] private bool pauseToggle = false; //is game paused?

  

    // Update is called once per frame
    void Update()
    {   
        //exit game, if game is won
        if(GameOver)
        {
            return;
        }
        // check for user input
        PlayerInput();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Door")
        {
            gamePanelWon.SetActive(true);
            gamePanelPause.SetActive(false);
            GameOver = true;
            Debug.Log("Level Completed");
        }
        else if (collision.tag == "Enemy")
        {
            //gamePanelWon.SetActive(true);
            //gamePanelPause.SetActive(false);
            GameOver = true;
            Debug.Log("Level Lost");
            gameLostPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void RestartGame()
    {
        Debug.Log("Button Clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1; 
    }
    
    // method with all Input functions, called in update every frame
    private void PlayerInput()
    {
        // movement user input
        if (Input.GetAxis("Horizontal") > 0)
        {
            // increase the current speed by adding acceleration to it
            rb.velocity = new Vector2(speed + acc * Time.deltaTime, 0f);
            // keep increasing the amount added to initial player speed, to simulate acceleration effect
            acc += accel; 
        } 
        if (Input.GetAxis("Horizontal") < 0)
        {
            acc += accel;
            rb.velocity = new Vector2(-(speed + acc * Time.deltaTime), 0f);
        } 
        if (Input.GetAxis("Vertical") < 0)
        {
            acc += accel;
            rb.velocity = new Vector2(0f, -(acc * Time.deltaTime + speed));
        }   
        if (Input.GetAxis("Vertical") > 0)
        {
            acc += accel;
            rb.velocity = new Vector2(0f, speed + acc * Time.deltaTime);
        }
        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            rb.velocity = new Vector2(0f, 0f);
            acc = 0;
        }

        // movement paused
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(0f, 0f);
            acc = 0;
        }
        // game paused
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseToggle = !pauseToggle; // game is paused
            Time.timeScale = 0;
            gamePanelPause.SetActive(true); // open pause UI panel
            gamePanelWon.SetActive(false);  // close restart UI panel 
        }
    }
    public void PauseResume()
    {
        Time.timeScale = 1;
        gamePanelPause.SetActive(false); // close  pause UI panel
        gamePanelWon.SetActive(false);  // close restart UI panel 
        Debug.Log("Resume Button Clicked");
        gamePanelWon.SetActive(false);
        pauseToggle = !pauseToggle;
    }
}
