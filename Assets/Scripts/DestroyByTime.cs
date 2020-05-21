using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 爆炸效果绑定此脚本，设置时限销毁
public class DestroyByTime : MonoBehaviour
{
	public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, lifetime);
    }
}
