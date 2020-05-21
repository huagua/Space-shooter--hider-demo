using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// boundary绑定此脚本，用于限定对象的生存范围，避免无用对象长时间占用资源
public class DestroyByBoundary : MonoBehaviour
{
	/*
		OnTriggerExit is called when the Collider other has stopped touching the trigger.
		当其他碰撞体停止碰撞时调用
	*/
    void OnTriggerExit(Collider other)
    {
    	Destroy(other.gameObject);
    }
}
