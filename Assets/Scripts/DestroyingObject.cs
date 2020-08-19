using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyingObject : Obstacles
{
    [SerializeField] GameObject particleEff;
    [SerializeField] float durationEffect;
    [SerializeField] AudioClip sound;
    DataController dataController;

    void Awake()
    {
        dataController=FindObjectOfType<DataController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(!GameManager.instance.gameOver)
        {
            DestroyObjectOnTrigger();
        }
    }

    void DestroyObjectOnTrigger(){

            Destroy(gameObject);
            GameObject sparkles=Instantiate(particleEff, gameObject.transform.position, gameObject.transform.rotation); 
            Destroy(sparkles,durationEffect);
            GameManager.instance.IncrementScore(points);
            AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position, dataController.GetVolume()); 
    }
}
