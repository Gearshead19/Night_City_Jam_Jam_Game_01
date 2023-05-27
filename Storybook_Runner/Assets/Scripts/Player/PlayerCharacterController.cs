using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class PlayerCharacterController : MonoBehaviour
{
    [SerializeField] LayerMask groundLayers;
    [SerializeField] private float runSpeed = 0;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private GameObject playerRunSprite;
    [SerializeField] private GameObject playerJumpSprite;
    [SerializeField] private Transform[] groundChecks;
    [SerializeField] private Transform[] wallChecks;

    private float gravity = -50f;
    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;
    private float horizontalInput;

    private PlayerActionControls playerActionControls;

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



    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = 1;


        //Face Forward
        transform.forward = new Vector3(horizontalInput, 0, Mathf.Abs(horizontalInput) - 1);

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

        if(isGrounded && playerActionControls.Land.Jump.triggered)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
            playerRunSprite.SetActive(false);
            playerJumpSprite.SetActive(true);
        }

        //vertical Velocity
        characterController.Move(velocity * Time.deltaTime);

    }
}
