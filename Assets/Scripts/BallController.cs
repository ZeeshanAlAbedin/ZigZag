using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BallController : MonoBehaviour {


    
    public float speed;
    bool started;
    bool gameOver;
    public AudioSource coinAudio;
    Rigidbody rb;
    public static BallController instance;

   // public GameObject animation;
  
   // public AudioSource OutAudio;
    public AudioSource turnAudio;
    //   public GameObject particle;
    public GameObject imageholder;

    public Text scoretextabove;
    public Text Score;

    int diamondsscore;
    
    String d;





    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        rb = GetComponent<Rigidbody>();
    }

 


    // Use this for initialization
    void Start () {



       // animation.SetActive(false);
        
        imageholder.SetActive(false);
        
        gameOver = false;
        started = false;
	}
	
	// Update is called once per frame
	void Update () {


        if(Application.platform == RuntimePlatform.Android)
        {
            if (!started)
            {
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
                {


                    imageholder.SetActive(true);
                    rb.velocity = new Vector3(speed, 0, 0);
                        started = true;

                        GameManager.instance.StartGame();
                    

                }

            }

        }


        else
        {
            
        if(!started)
        {
            if (Input.GetMouseButtonDown(0))
            {


                    imageholder.SetActive(true);

                    rb.velocity = new Vector3(speed, 0, 0);
                        started = true;

                        GameManager.instance.StartGame();

                    
                
            }

        }
        }



        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {


           
            gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0);

           
          
      
            Camera.main.GetComponent<CameraFollow>().gameOver = true;

            GameManager.instance.GameOver();


        }

        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            turnAudio.Play();
            SwithDirections();
        }

    }

    private void SwithDirections()
    {
       
        if(rb.velocity.z >0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Diamond")
        {


         //   animation.SetActive(true);
            diamondsscore += 1;

            d = diamondsscore.ToString();
            scoretextabove.text =" "+ d;
            // GameObject part = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;

            ScoreManager.instance.score = ScoreManager.instance.score + 10;
         //   animation.GetComponent<Animator>().enabled = true;

         //   animation.GetComponent<Animator>().Play("tenplus",-1,0f);

          //  Invoke("stopanimation", 0.5f);
          

            coinAudio.Play();
         // GameObject part = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(col.gameObject);
          //  Destroy(part, 1f);


        }
    }

  public void  stopanimation()

    {
      //  animation.SetActive(false);

    }
}
