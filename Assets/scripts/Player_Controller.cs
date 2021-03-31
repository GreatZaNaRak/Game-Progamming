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

    public string Current_User;
    public int mapIndex;

    Animator animate;

    public string getCurrentUser()
    {
        return this.Current_User;
    }

    public void setCurrentUser(string nText)
    {
        this.Current_User = nText;
    }

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
        playerColor.color = Color.black;
        setCurrentUser("No Data");
        setCurrenMapIndex(-1);
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
                string cmd = this.getCurrentUser();
                if (Input.GetKeyDown(KeyCode.Return)) {
                    if (cmd == "Plant") {
                        playerColor.color = Color.green;
                    } else if (cmd == "Engineer"){
                        playerColor.color = Color.red;
                    } else if (cmd == "No Data") {
                        playerColor.color = Color.black;
                    }
                    Panel1.SetActive(false);
                    this.setCurrentUser("No Data");
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
                if (Input.GetKeyDown(KeyCode.Return)) {
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
