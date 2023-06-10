using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    public WeaponController wc;
   

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && wc.isAttacking)
        {
            Debug.Log(other.name);
            other.GetComponent<Animator>().SetTrigger("Hit");
            //Instantiate(HitParticle, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);
        }
    }
}
