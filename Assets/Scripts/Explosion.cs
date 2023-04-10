using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explosion : MonoBehaviour
{
    public ParticleSystem bulletFire;


    private void OnCollisionEnter(Collision collision)
    {
       
        var newFire = Instantiate(bulletFire);
        newFire.transform.position = transform.position;
       
        newFire.Play();
        gameObject.transform.position= new Vector3(0,20,0);
        gameObject.GetComponent<MeshRenderer>().enabled = (false);
        Destroy(gameObject, 2f);

       Destroy(newFire.gameObject,2.5f);
       

    }
  
}

