using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infinitry : Character {
    
 
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void Move(Vector3 posittion)
    {
        BasicMovement(posittion);
        anim.SetBool("Move", true);
    }
}
