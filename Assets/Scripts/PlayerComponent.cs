using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerComponent : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;

    public GameObject gameWonPanel, gameLostPanel;

    public float speed;

    private bool isGameOver = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (isGameOver == true){
            return;
        }
        if (Input.GetAxis("Horizontal") > 0) //Positive- d or right
        {
            rigidbody2D.velocity = new Vector2(speed, 0f);
        }    
        else if (Input.GetAxis("Horizontal") < 0) //Negative- a or left
        {
            rigidbody2D.velocity = new Vector2(-speed, 0f);
        }
        else if (Input.GetAxis("Vertical") > 0) //Positive- w or up
        {
            rigidbody2D.velocity = new Vector2(0f, speed);
        }
        else if (Input.GetAxis("Vertical") < 0) //Negative- s or down
        {
            rigidbody2D.velocity = new Vector2(0f, -speed);
        }
        else if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        { 
            rigidbody2D.velocity = new Vector2(0f, 0f);
        }else if (Input.GetAxis("Jump")>0){
            rigidbody2D.velocity = new Vector2(0f, 0f);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.tag == "Door"){
            gameWonPanel.SetActive(true);
            Debug.Log("Level complete!!");
            isGameOver = true;
        }

        if (other.tag == "Enemy"){
            gameLostPanel.SetActive(true);
            Debug.Log("Level Lost!!");
            isGameOver = true;
        }
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Button clicked!!!");
    }

}
