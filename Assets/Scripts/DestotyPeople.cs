using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 玩家子弹绑定该脚本
public class DestotyPeople : MonoBehaviour
{
	public GameController gameController;
	public int score = 10;
	public GameObject explosion;

	/*
		Start is called on the frame when a script is enabled just before any of the Update methods are called the first time.
		最先调用的函数
	*/
	void Start()
	{
		/*
			获取GameController
				1、首先获取到GameController的对象实例
				2、再获取该对象中的GameController组件
				3、即可调用gameController中的方法
		*/
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

	/*
		OnTriggerEnter is called when the GameObject collides with another GameObject.
		该对象与其他对象发生碰撞时调用
	*/
    void OnTriggerEnter(Collider other)
    {
    	// 如果玩家子弹与标签为origin people的对象（也就是普通行人）碰撞时，销毁子弹，普通行人无影响
    	if(other.gameObject.tag == "origin people")
    	{
    		Destroy (this.gameObject);
    	}

    	// 如果玩家子弹与标签为virus病毒或varient people（普通行人中病毒后转化成的携带病毒的人）碰撞时
    	// 玩家加分，并且销毁子弹和碰撞对象
    	if(other.gameObject.tag == "virus" || other.gameObject.tag == "varient people")
    	{
    		gameController.AddScore(score);
    		Destroy (other.gameObject);
    		Destroy(this.gameObject);
    		
    		//创建爆炸实例
    		Instantiate(explosion, this.transform.position, this.transform.rotation);
    	}
    }
}
