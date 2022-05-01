using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class birdController : MonoBehaviour
{
    public static birdController instance;

    [SerializeField]
    private Rigidbody2D myBody;

    [SerializeField]
    private Animator ani;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip fly, ping, die, teleport;

    private GameObject spawnerPipe;
    private GameObject spawnerZoombie;

    public int score = 0;

    // status player
    private bool isAlive;
    private bool didFlap;

    // info skill
    public float cooldownTime;
    public float effectiveSkill;
    public float displayTime;
    private float timeAcctiveSkill;

    // physics
    public float bounceFore;
    public float flag = 0;

    // status acctive skill
    private bool ActiveImmotalSkill;
    public bool immortalSkill;

    // flag player when use skill
    public int StatusPlayer;
    public int statusImmotalSkill;
    const int NORMAL = 0;
    const int USINGSKILL = 1;

    /**
     * initialization
     */
    void Awake() {
        myBody = GetComponent<Rigidbody2D> ();
        ani = GetComponent<Animator> ();
        isAlive = true;
        didFlap = false;
        _makeInstance();
        spawnerPipe = GameObject.Find("spawnerPipe");
        spawnerZoombie = GameObject.Find("spawnerZoombie");
    }

    void _makeInstance() {
        if(instance == null) {
            instance = this;
        }
    }

    void FixedUpdate()
    {
        _jump();
        _immortalSkill();
    }

    // function hand player jump
    void _jump() {
        if(isAlive == true && StatusPlayer == NORMAL)
        {
            if (didFlap == true)
             {
                //Debug.Log("case_1")
                didFlap = false;
                myBody.velocity = new Vector2(myBody.velocity.x, bounceFore);
                audioSource.PlayOneShot(fly);
                ani.SetTrigger("jump");
                ani.SetTrigger("goku");
            }
        }
    }
    // function hand collision
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "boxBlockTop" || other.gameObject.tag == "dragon")
        {
            audioSource.PlayOneShot(die);
            isAlive = false;
            flag = 1;
            Destroy(spawnerPipe);
            Destroy(spawnerZoombie);
            ani.SetTrigger("Died");

            if (gamePlay.instance != null)
            {
                gamePlay.instance.showGameOverPanel();
            }
        }
        score++;
        if(gamePlay.instance != null) {
            gamePlay.instance.setScore(score);
        }
        audioSource.PlayOneShot(ping);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "pipe" || other.gameObject.tag == "boxBlockTop") {
            audioSource.PlayOneShot(die);
            isAlive = false;
            flag = 1;
            Destroy(spawnerPipe);
            Destroy(spawnerZoombie);
            ani.SetTrigger("Died");

            if(gamePlay.instance != null) {
                gamePlay.instance.showGameOverPanel();
            }
        }
    }

    // acctive skill
    void _immortalSkill()
    {
        if(ActiveImmotalSkill == false)
        {
            bool isKeyDown = Input.GetKeyDown(KeyCode.F);
            if (isKeyDown == true)
            {
                isKeyDown = false;
                StatusPlayer = USINGSKILL;
                statusImmotalSkill = USINGSKILL;
                InvokeRepeating("_processImmotalSkill", effectiveSkill, 0.02f);
                immortalSkill = true;
                if (immortal.instance != null)
                {
                    immortal.instance.updateTriggerBird(immortalSkill);
                    ani.SetTrigger("teleport");
                }
                
                audioSource.PlayOneShot(teleport);
                timeAcctiveSkill = Time.time;

                myBody.bodyType = RigidbodyType2D.Static;
            }
        }
        
    }

    void _processImmotalSkill()
    {
        //Debug.Log("case_2");

        float time = Time.time;
        if (statusImmotalSkill == USINGSKILL)
        {
            float effectiveTime = timeAcctiveSkill + effectiveSkill;
            float nextTimeSkill = timeAcctiveSkill + effectiveSkill + cooldownTime;
            //Debug.Log("time: " + time + " isAcctiveSkill: " + isAcctiveSkill + " nextTime: " + nextTimeSkill);

            if (time < effectiveTime && ActiveImmotalSkill == false)
            {
                ActiveImmotalSkill = true;
            }
            else if (time > effectiveSkill && time < nextTimeSkill)
            {
                //Debug.Log(ActiveImmotalSkill);
                if (immortalSkill == true)
                {
                    //Debug.Log("case_1");
                    immortalSkill = false;
                    immortal.instance.updateTriggerBird(immortalSkill);
                    ani.SetTrigger("fly");
                }
                else if (time > effectiveTime + displayTime)
                {
                    myBody.bodyType = RigidbodyType2D.Dynamic;
                    StatusPlayer = NORMAL;
                }
            }
            else if (time >= nextTimeSkill)
            {
                ActiveImmotalSkill = false;
                statusImmotalSkill = NORMAL;  
            }
        }
       
    }

    // button jump
    public void flapButton() {
        didFlap = true;
    }
}
