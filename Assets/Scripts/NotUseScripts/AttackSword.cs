using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSword : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("“G‚É“–‚½‚Á‚½");
            
            
        }
    }
   
}
