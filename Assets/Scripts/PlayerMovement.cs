using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //Initializing Varibles 
    public float speed = 10;
    public GameObject cameraObj;
    public GameObject animationModel;
    //public GameObject attackCollider;
    //public GameObject PlayerCollider;
    Animator animateCh;


    //InputAction Reference
    PlayerInputActions inputAction;

    //move
    Vector2 movementInput;


    //initialize inputs
    private void Awake()
    {
        inputAction = new PlayerInputActions();
        inputAction.PlayerControls.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        inputAction.PlayerControls.Sprint.performed += ctx => Sprint();
        inputAction.PlayerControls.LightAttack.performed += ctx => LightAttack();
        inputAction.PlayerControls.HeavyAttack.performed += ctx => HeavyAttack();
        inputAction.PlayerControls.Block.performed += ctx => Block();
        inputAction.PlayerControls.Block.canceled += ctx => unBlock();
        inputAction.PlayerControls.Dodge.performed += ctx => Dodge();
    }

    // Start is called before the first frame update
    void Start()
    {
        //initialize variable
        animateCh = animationModel.GetComponent<Animator>();
    }

    // FixedUpdate is called
    void FixedUpdate()
    {
        playerMoveControl();
    }

    private void Update()
    {
        //animator variable modified by players inputs
        float movementAbs = Mathf.Abs(movementInput.y) + Mathf.Abs(movementInput.x);
        animateCh.SetFloat("Speed", movementAbs);
        Vector2 stationary = new Vector2(0f, 0f);
        if (movementInput.Equals(stationary))
        {
            animateCh.SetBool("Sprint", false);
        }
    }


    // Rotates player toward camera direction
    void playerRotation()
    {
        float cameraY = cameraObj.transform.eulerAngles.y;
        Vector3 rotationDirection = new Vector3(transform.eulerAngles.x, cameraY, transform.eulerAngles.z);
        this.transform.rotation = Quaternion.Euler(rotationDirection);
        //brute force solution for character model rotating without permission
        animationModel.transform.rotation = Quaternion.Slerp(animationModel.transform.rotation, this.transform.rotation, Time.deltaTime);
    }

    void Sprint()
    {
        speed = 15;
        animateCh.SetBool("Sprint", true);
    }
    // players movement script based on new input system using 
    // values from player's inputs
    void playerMoveControl()
    {
        
        Vector2 stationary = new Vector2(0f, 0f);
        Vector2 movementValue = movementInput;
        if (!movementValue.Equals(stationary))
        {
            playerRotation();
        }

        float hor = movementInput.x;
        float ver = movementInput.y;
        Vector3 playerMovement = new Vector3(hor, 0f, ver) * speed * Time.deltaTime;
        this.transform.Translate(playerMovement, Space.Self);
    }

    void LightAttack()
    {
        animateCh.SetTrigger("LightAttack");
    }

    void HeavyAttack()
    {
        animateCh.SetTrigger("HeavyAttack");
    }

    void Block()
    {
        animateCh.SetBool("Block", true);
       // PlayerCollider.GetComponent<BoxCollider>().enabled = false;

    }

    void unBlock()
    {
        animateCh.SetBool("Block", false);
        //PlayerCollider.GetComponent<BoxCollider>().enabled = true;

    }

    // activate character dodge
    void Dodge()
    {
        animateCh.SetTrigger("Dodge");
        /*PlayerCollider.GetComponent<BoxCollider>().enabled = false;
        new WaitForSecondsRealtime(5f);
        PlayerCollider.GetComponent<BoxCollider>().enabled = true;*/

    }

    // extra
    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }
}
