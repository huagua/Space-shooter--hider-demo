using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 此函数用于控制使小行星的任意旋转，之后版本或许不需要
public class RandomRotater : MonoBehaviour
{
	public float tumble = 5f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }

}
