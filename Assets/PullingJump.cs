using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 clickPosition;
    [SerializeField]
    private float jumpPower = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb=gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition=Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            //�N���b�N�������W�Ɨ��������W�̍������擾
            Vector3 dist=clickPosition-Input.mousePosition;
        }
    }
}
