using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
   
    public AudioSource fireSound;
    public ParticleSystem bulletFire;
    void Start()
    {
       
    }

    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {


        var newFire = Instantiate(bulletFire);
        newFire.transform.position = transform.position;
        newFire.Play();
        gameObject.transform.position= new Vector3(0,20,0);
        gameObject.GetComponent<MeshRenderer>().enabled = (false);
        Destroy(gameObject, 2f);
        fireSound.Play();

       Destroy(newFire.gameObject,2.5f);
       
      

    }

}

