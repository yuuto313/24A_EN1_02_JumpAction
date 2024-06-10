using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
        audioSource=gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        //接触した瞬間に呼ばれる
        animator.SetTrigger("Get");
        audioSource.Play();
        //Debug.Log("Enter");
    }

    private void OnTriggerStay(Collider other)
    {
        //接触してる間に呼ばれる
        Debug.Log("Stay");
    }

    private void OnTriggerExit(Collider other)
    {
        //離れたときに呼ばれる
        Debug.Log("Exit");
    }
    
}
