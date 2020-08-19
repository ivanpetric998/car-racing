using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Obstacles
{
    private bool prosao=false;    
    protected override void Update()
    {
        if (gameObject.transform.position.y < YPosition() && !GameManager.instance.gameOver && !prosao)
        {
            GameManager.instance.IncrementScore(points);
            prosao=true;
        }
        DestroyGameObject();
    }

    private float YPosition(){
        return player.yPos;
    }
}
