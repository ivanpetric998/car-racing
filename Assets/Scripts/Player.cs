using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float xPadding = 2f;
    [SerializeField] public float yPos = -4f;
    [SerializeField] float ugaoSkretanja = -85f;
    [SerializeField] AudioClip crashSound;
    DataController dataController;
    [SerializeField] float xMin;
    [SerializeField] float xMax;

    void Awake()
    {
        dataController=FindObjectOfType<DataController>();
    }
    
    void FixedUpdate () 
    {
        if(!GameManager.instance.gameOver)
        {
            Move();
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Car")
        {
            AudioSource.PlayClipAtPoint(crashSound, Camera.main.transform.position, dataController.GetVolume()); 
            GameManager.instance.GameOver();
        }
    }

    void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;       
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        gameObject.transform.position = new Vector2(newXPos, yPos);
        gameObject.transform.rotation=Quaternion.Euler(0,0,deltaX*ugaoSkretanja);
        if(gameObject.transform.position.x==xMin || gameObject.transform.position.x==xMax)
        {
            gameObject.transform.rotation=Quaternion.Euler(0,0,0);
        }
    }
    
}
