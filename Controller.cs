using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Controller : MonoBehaviour {
    public float tapForce = 10;
    public Vector3 startPos;
    public bool playerDead = false;
    public Text gameOverTxt;
    public Text scoreText;
    
    public int score = 0;

    public AudioSource dieAudio;
    public AudioSource scoreAudio;
    public AudioSource idleMusic;


    Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        scoreText.text = "Score: " + score;
        idleMusic.Play();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rigidbody.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "DeadZone")
        {
            rigidbody.simulated = false;
            playerDead = true;
            dieAudio.Play();
            gameOverTxt.text = "OOF!";
            idleMusic.Stop();

            //restart game
        }
        if (col.gameObject.tag == "ScoreZone")
        {
            score++;
            scoreAudio.Play();
            scoreText.text = "Score: " + score;

        }


    }

}
