using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelResetPosition : MonoBehaviour {


    public float offset;
	// Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void ResetPosition(Vector3 siblingConnectomeGroupPosition, bool isTest)
    {
        if(isTest)
            this.transform.localPosition = new Vector3(siblingConnectomeGroupPosition.x , siblingConnectomeGroupPosition.y + offset, siblingConnectomeGroupPosition.z - this.transform.parent.transform.position.z);
        else
            this.transform.localPosition = new Vector3(siblingConnectomeGroupPosition.x, siblingConnectomeGroupPosition.y + offset, siblingConnectomeGroupPosition.z);
    }
}
