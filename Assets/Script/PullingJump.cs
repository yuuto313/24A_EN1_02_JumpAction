using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 clickPosition;
    [SerializeField]
    private float jumpPower = 10;

    //�W�����v�s�̔��f
    private bool isCanJump;



    // Start is called before the first frame update
    void Start()
    {
        rb=gameObject.GetComponent<Rigidbody>();
        Physics.gravity=new Vector3(0,-9.8f,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition=Input.mousePosition;
        }
        if (isCanJump && Input.GetMouseButton(0))
        {
            //�N���b�N�������W�Ɨ��������W�̍������擾
            Vector3 dist=clickPosition-Input.mousePosition;
            //�N���b�N�ƃ����[�X���������W�Ȃ�Ζ���
            if (dist.sqrMagnitude == 0)
            {
                return;
            }
            //������W�������AjumpPower���|�����킹���l���ړ��ʂƂ���
            rb.velocity = dist.normalized * jumpPower;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("�Փ˂���");
    }

    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log("�ڐG��");
        //isCanJump = true;
        //�Փ˂��Ă�_�̏�񂪕����i�[����Ă���
        ContactPoint[] contacts = collision.contacts;
        //0�Ԗڂ̏Փˏ�񂩂�A�Փ˂��Ă���_�̖@�����擾
        Vector3 otherNormal = contacts[0].normal;
        //������������x�N�g���B������1
        Vector3 upVector = new Vector3(0, 1, 0);
        //������Ɩ@���̓��ρB2�̃x�N�g���͒�����1�Ȃ̂ŁAcos�Ƃ̌��ʂ�dotUN�ϐ��ɓ���
        float dotUN = Vector3.Dot(upVector, otherNormal);
        //���ϒl�ɋt�O�p�֐�arccos���|���Ċp�x���Z�o�B�����x���@�֕ϊ�����B����Ŋp�x���Z�o�ł���
        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;
        //2�̃x�N�g�����Ȃ��p�x��45�x��菬������΍ĂуW�����v�\�Ƃ���
        if (dotDeg <= 45)
        {
            isCanJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log("���E����");
        isCanJump = false;
    }
}

