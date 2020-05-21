using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// virus / varient people
public class DestroyByContact : MonoBehaviour
{
    public GameObject asteroid;
	public GameObject explosion;
	public GameObject playerExplosion;
    public GameController gameController;
    // private int score = 10;

    void Start() 
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        if(gameController == null)
        {
            Debug.Log("Counld not find the GameController");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // switch(other.gameObject.tag)
        // {
        //     case "Boundary":
        //     case "background":
        //     case "varient people":
        //     case "virus":
        //     case "blot":
        //         return;
        //     case "origin people":
        //         Instantiate(asteroid, this.transform.position, this.transform.rotation);
        //         break;
        //     case "Player":
        //         Instantiate(playerExplosion, this.transform.position, this.transform.rotation);
        //         gameController.GameOver();
        //         break;
        // }


    	// if(other.gameObject.tag == "Boundary" || other.gameObject.tag == "background")
    	// {
    	// 	return;
    	// }

    	if(other.gameObject.tag == "Player")
    	{
    		Instantiate(playerExplosion, this.transform.position, this.transform.rotation);
            gameController.GameOver();
            Destroy (other.gameObject);
            Destroy(this.gameObject);
            Instantiate(explosion, this.transform.position, this.transform.rotation);
    	}

        if(other.gameObject.tag == "origin people")
        {
            if(this.gameObject.tag != "varient people")
                Destroy(this.gameObject);
            Destroy (other.gameObject);
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            Instantiate(asteroid, this.transform.position, this.transform.rotation);
            return;
        }
    	
     //    if(other.gameObject.tag == "varient people" || other.gameObject.tag == "virus")
     //    {
     //        return;
     //    }

    	// Destroy (other.gameObject);
        // if(!gameController.gameOver && other.gameObject.tag != "origin people"){
        //     gameController.AddScore(score);

        //     } 
    	// Destroy(this.gameObject);
    	// Instantiate(explosion, this.transform.position, this.transform.rotation);
    }
}
