﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public int bulletDamage;
    public float hitForce = 100f;
    public ScoreBoard sb;
    public AudioClip hitSound;
    public Material bulletMaterial;
    public float m_MaxLifeTime = 2f;
//    public ParticleSystem m_ExplosionParticles;

    // Use this for initialization
    void Start()
    {
        sb = GameObject.FindGameObjectWithTag("ScoreBoard").GetComponent<ScoreBoard>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(hitSound, other.transform.position, 1f);
        EnemyHealth health = other.GetComponent<EnemyHealth>();

        if (health != null)
        {
            health.Damage(bulletDamage);
        }
        if (other.GetComponent<Rigidbody>() != null)
        {
            other.GetComponent<Rigidbody>().AddForce(transform.forward * hitForce);
        }

        if (other.gameObject.CompareTag("FloorTile"))
        {
            Renderer rend = other.gameObject.GetComponent<Renderer>();
            sb.UpdateCounts(rend.sharedMaterial, bulletMaterial);
            rend.material = bulletMaterial;
        }
        
        //m_ExplosionParticles.transform.parent = null;
        //m_ExplosionParticles.Play();
        

        Destroy(gameObject);
    }

}
