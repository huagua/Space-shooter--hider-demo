using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	敌机

	1.随机左右移动（仅改变x的值）
		移动规则：
		- 给定移动范围		✅
		- 给定移动时间间隔 ✅
		- 任意左移或右移	✅
		- 移动速度任意		✅
		- 若是超过范围，则只能到达边缘
		- 若是当前已在边缘位置，则下次只能左移或右移

	2.发射子弹


*/
public class EnemyController : MonoBehaviour
{
	public Boundary bound;
	public GameController gameController;
	private float speed = 0.1f;
	private float timeWait = 0.05f;
	Rigidbody r;

    public GameObject bolt; // 发射子弹
    public Transform spawnPos;  // 发射位置

    private float fireRate = 0.5f; // 发射时间间隔
    private float nextFire; // 下次发射时间

    // private float nextPos = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
    	r = GetComponent<Rigidbody>();
    	StartCoroutine(moveEnemy());
    }

    // Update is called once per frame
    void Update()
    {
    	// 间断开火
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bolt, spawnPos.position, spawnPos.rotation);
        }
    	
    }



    IEnumerator moveEnemy()
    {
        yield return new WaitForSeconds(timeWait);

    	while(!gameController.gameOver){
        	moveLeftOrRight();
        	yield return new WaitForSeconds(timeWait);
    	}
    }

    void moveLeftOrRight()
    {

    	if (r.position.x == bound.xMin)
    	{
    		speed = 0.1f;
    	}else if(r.position.x == bound.xMax)
    	{
    		speed = -0.1f;
    	}
    	// speed = Random.Range(-2, 2);
    	
    	r.MovePosition(GetComponent<Transform>().position+Vector3.right*speed);
    	r.position = new Vector3 (
    		Mathf.Clamp(r.position.x, bound.xMin, bound.xMax),
    		-1,
    		19
    		);
    }
}
