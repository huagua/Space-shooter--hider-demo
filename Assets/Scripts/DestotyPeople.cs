using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 玩家子弹触碰销毁
public class DestotyPeople : MonoBehaviour
{
	public GameController gameController;
	public int score = 10;
	public GameObject explosion;

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
    	if(other.gameObject.tag == "origin people")
    	{
    		Destroy (this.gameObject);
    	}

    	if(other.gameObject.tag == "virus" || other.gameObject.tag == "varient people")
    	{
    		gameController.AddScore(score);
    		Destroy (other.gameObject);
    		Destroy(this.gameObject);
    		Instantiate(explosion, this.transform.position, this.transform.rotation);
    	}
    }
}
