using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{

    private float movementSpeed = 8f;
    private float xDirection, zDirection;
    public Vector3 initialPosition;
    Vector3 forward, right;    

    public GameObject Panel1;
    public GameObject Panel2;
    public Material playerColor;
    public Properties_Controller Props;
    public GameStatus gs;

    public string Current_User;
    public int mapIndex;

    Animator animate;


    public int getCurrentMapIndex()
    {
        return this.mapIndex;
    }

    public void setCurrenMapIndex(int nIndex)
    {
        this.mapIndex = nIndex;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        initialPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        

        animate = GetComponent<Animator>();

        setCurrenMapIndex(-1);

        // switch scene
        if (gs.getCurrentUser() == "") {
            playerColor.color = Color.black;
            Props.show("No Data");
        } else {
            Props.show(gs.getCurrentUser());
        }
    }

    // Update is called once per frame
    void Update()
    {
    
        if (Input.anyKey && !Input.GetKey(KeyCode.E) && !Input.GetKey(KeyCode.Q)) {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)
                || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) {
                    move();
                    animate.SetBool("isWalk", true);
                }
        } else {
            animate.SetBool("isWalk", false);
        }

        fixPosition();
        changePersonality();
        changeMap();

        
    }

    void fixPosition()
    {
        if (GameObject.FindGameObjectWithTag("Player").transform.position.y < -5) {
            transform.position = initialPosition;
        }
    }


    void changePersonality()
    {
        if (Panel1 != null) {
            if (Input.GetKey(KeyCode.E) && !Input.GetKey(KeyCode.Q)) {
                Panel1.SetActive(true);
                string cmd = gs.getCurrentUser();
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)) {
                    if (gs.getIsCharSelected() == 1) {
                        Props.show(cmd);
                        if (cmd == "Plant") {
                            playerColor.color = Color.green;
                        } else if (cmd == "Engineer"){
                            playerColor.color = Color.red;
                        }
                    }
                     else {
                        Props.show("No Data");
                        gs.setCurrentUser("No Data");
                        playerColor.color = Color.black;
                    }
                    Panel1.SetActive(false);
                    gs.setIsCharSelected(0);
                }
            } else {
                Panel1.SetActive(false);
            }
        }

    }

    void changeMap()
    {
        if (Panel2 != null) {
            if (Input.GetKey(KeyCode.Q)&& !Input.GetKey(KeyCode.E)) {
                Panel2.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)) {
                    int sceneIndex = getCurrentMapIndex();
                    if (sceneIndex != -1) {
                         SceneManager.LoadScene(sceneIndex);
                    } 
                }
            } else {
                Panel2.SetActive(false);
            }
        }

    }

    void move()
    {

        xDirection = Input.GetAxis("Horizontal");
        zDirection = Input.GetAxis("Vertical");

        Vector3 movingDirection = new Vector3(xDirection, 0f, zDirection);
        Vector3 rightMove = right * movementSpeed * Time.deltaTime * xDirection;
        Vector3 upMove = forward * movementSpeed * Time.deltaTime * zDirection;

        Vector3 heading = Vector3.Normalize(rightMove + upMove);
        transform.forward = heading;
        transform.position += rightMove;
        transform.position += upMove;
        
    }

}
