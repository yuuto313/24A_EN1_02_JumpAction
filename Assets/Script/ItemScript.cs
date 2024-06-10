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
        //�ڐG�����u�ԂɌĂ΂��
        animator.SetTrigger("Get");
        audioSource.Play();
        //Debug.Log("Enter");
    }

    private void OnTriggerStay(Collider other)
    {
        //�ڐG���Ă�ԂɌĂ΂��
        Debug.Log("Stay");
    }

    private void OnTriggerExit(Collider other)
    {
        //���ꂽ�Ƃ��ɌĂ΂��
        Debug.Log("Exit");
    }
    
}
