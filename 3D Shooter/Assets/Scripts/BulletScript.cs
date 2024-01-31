﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 8f;
    public float lifeTimer = 3.5f;
    

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f)
		{
            Destroy(gameObject);
		}

    }



    void OnCollisionEnter(Collision col)
	{
        if (col.gameObject.name == "Enemy")
		{
            Destroy(col.gameObject);
		}
	}
}
