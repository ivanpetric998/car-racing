using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

    [SerializeField] float backgroundScrollSpeed = 0.7f; 
    Material myMaterial;
    Vector2 offSet;
        void Awake () 
        {
                myMaterial = gameObject.GetComponent<Renderer>().material;   
                offSet = new Vector2(0f, backgroundScrollSpeed); 
        }
        
        void FixedUpdate () 
        {
                if(!GameManager.instance.gameOver)
                {
                        myMaterial.mainTextureOffset += offSet * Time.deltaTime; 
                }   
        }
}