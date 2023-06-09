using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using TMPro;

public class PlayerCharacterController : MonoBehaviour
{
    [SerializeField] LayerMask groundLayers;
    [Header("Player Properties")]
    [SerializeField] public float runSpeed = 0;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private GameObject playerRunSprite;
    [SerializeField] private GameObject playerJumpSprite;
    [SerializeField] private GameObject playerDeathSprite;
    [SerializeField] private Transform[] groundChecks;
    [SerializeField] private Transform[] wallChecks;
 
    private float gravity = -50f;
    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;
    private float horizontalInput;
    private ScoreSystem score;

    private AudioDamper audioDamp;

    private AudioSource jumpSFX;

    public GameObject GameOverPanel, scoreText;
    public TextMeshProUGUI FinalScoreText, HighScoreText;

    [Header("Game State")]
    public bool isGameOver = false;

    private PlayerActionControls playerActionControls;
    private PlayerHealth health;

    private void Awake()
    {
        playerActionControls = new PlayerActionControls();
    }
    private void OnEnable()
    {
        playerActionControls.Enable();
    }
    private void OnDisable()
    {
        playerActionControls.Disable(); 
    }

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        score = FindObjectOfType<ScoreSystem>();
        health = FindObjectOfType<PlayerHealth>();
        jumpSFX = GetComponent<AudioSource>();
        audioDamp = FindObjectOfType<AudioDamper>();

        StartCoroutine("IncreaseGameSpeed");

    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver) 
        {
            //Face Forward
            transform.forward = new Vector3(horizontalInput, 0, Mathf.Abs(horizontalInput) - 1);

        }

        horizontalInput = 1;

        //IsGrounded
        isGrounded = false;

        foreach (var groundCheck in groundChecks)
        {
            if (Physics.CheckSphere(groundCheck.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore))
            {
                isGrounded = true;
                break;
            }
        }

        

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
            playerRunSprite.SetActive(true);
            playerJumpSprite.SetActive(false);
        }
        else
        {
            //Adds gravity
            velocity.y += gravity * Time.deltaTime;
        }

        //Wallchecker - Will stop player from getting stuck to a wall
        var blocked = false;
        foreach (var wallCheck in wallChecks)
        {
            if (Physics.CheckSphere(wallCheck.position, 0.01f, groundLayers, QueryTriggerInteraction.Ignore))
            {
                blocked = true;
                break;
            }
        }
        if (!blocked)
        {
            characterController.Move(new Vector3(horizontalInput * runSpeed, 0, 0) * Time.deltaTime);
        }

        if(isGrounded && playerActionControls.Land.Jump.triggered && !isGameOver)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
            playerRunSprite.SetActive(false);
            playerJumpSprite.SetActive(true);
            jumpSFX.Play();
        }

        //vertical Velocity
        characterController.Move(velocity * Time.deltaTime);

    }

    public void GameOver()
    {
        isGameOver = true;
        isGrounded = false;
        groundLayers = 0;
        playerRunSprite.SetActive(false);
        playerJumpSprite.SetActive(false);
        playerDeathSprite.SetActive(true);
        StopCoroutine("IncreaseGameSpeed");
        score.scoreIsOn = false;
        health.staminaDrain = false;
        audioDamp.AudioLower();

        StartCoroutine("ShowGameOverPanel");
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
        if (collision.gameObject.CompareTag("BottomDetector"))
        {
            GameOver();
        }


    }

    IEnumerator IncreaseGameSpeed()
    {
        while(true)
        {
            yield return new WaitForSeconds(10);

            if(runSpeed < 20)
            {
                runSpeed += 0.5f;
            }
            if (GameObject.Find("GroundSpawner").GetComponent<ObstacleSpawner>().obstacleSpawnInterval > 1)
            {
                GameObject.Find("GroundSpawner").GetComponent<ObstacleSpawner>().obstacleSpawnInterval -= 0.1f;
            }
            

        }

    }
    IEnumerator ShowGameOverPanel()
    {
        yield return new WaitForSeconds(2);
        GameOverPanel.SetActive(true);
        scoreText.SetActive(false);

        FinalScoreText.text = "Score : " + GameObject.Find("ScoreDetector").GetComponent<ScoreSystem>().score;
        HighScoreText.text = "High Score : " + PlayerPrefs.GetInt("HighScore");
    }

}
