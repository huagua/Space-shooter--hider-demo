using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //可序列化
public class Boundary {
    public float xMin = -6f;
    public float xMax = 6f;
    public float zMin = -1f;
    public float zMax = 17f;
}

public class PlayerController : MonoBehaviour
{
	public float speed = 10f;
	public Boundary bound;
	Rigidbody r;

    public GameObject bolt; // 发射子弹
    public Transform spawnPos;  // 发射位置

    private float fireRate = 0.5f; // 发射时间间隔
    private float nextFire; // 下次发射时间

    public AudioClip fire;

    void Start()
    {
        r = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 间断开火
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bolt, spawnPos.position, spawnPos.rotation);

            GetComponent<AudioSource>().PlayOneShot(fire);
        }

        // 不间断开火
        // Instantiate(bolt, spawnPos.position, spawnPos.rotation);

        // 鼠标点击开火
        // if (Input.GetButton ("Fire1") && Time.time > nextFire)
        // {
        //     nextFire = Time.time + fireRate;
            
        //     Instantiate(bolt, spawnPos.position, spawnPos.rotation);
            
        // }
    }

    void FixedUpdate()
    {
        
        // //单点触摸， 水平上下移动
        // if (Input.touchCount ==1&& Input.GetTouch(0).phase == TouchPhase.Moved)
        // {
        //     // if (!GetComponent<EventSystem>().current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        //     // if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        //     var deltaposition = Input.GetTouch(0).deltaPosition;
        //     transform.Translate(-deltaposition.x * 0.01f, 0f, -deltaposition.y * 0.1f);
        //     r.position = new Vector3 (
        //         Mathf.Clamp(r.position.x, bound.xMin, bound.xMax),
        //         0,
        //         Mathf.Clamp(r.position.z, bound.zMin, bound.zMax)
        //     );
            
        // }else {

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(h, 0f, v);
            // rigidbody.velocity = speed*move;
            // GetComponent<Rigidbody>().velocity = speed*move;
            r.velocity = speed*move;
            r.position = new Vector3 (
                Mathf.Clamp(r.position.x, bound.xMin, bound.xMax),
                -1,
                Mathf.Clamp(r.position.z, bound.zMin, bound.zMax)
                );
        // }
    	
    }

    void OnMouseDrag()
    {
        Debug.Log("mouse drag");
        Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        r.position = new Vector3 (
                Mathf.Clamp(targetPos.x, bound.xMin, bound.xMax),
                -1,
                Mathf.Clamp(targetPos.z, bound.zMin, bound.zMax)
                );
        // targetPos.y = 0;
        // targetPos.x = Mathf.Clamp(targetPos.x, bound.xMin, bound.xMax);
        // targetPos.z = Mathf.Clamp(targetPos.z, bound.zMin, bound.zMax);
        // transform.position = targetPos;
    }
}
