using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    GameObject par;
    public float fireParSpeedMin = 800;
    public float fireParSpeedMax = 1200;
    public int parCount = 30;

    Rigidbody myRigidBody;

    private void Awake()
    {
        //par = Resources.Load<GameObject>("Prefabs/Par");

        myRigidBody = GetComponent<Rigidbody>();
    }


    private void OnTriggerEnter(Collider other)
    {

        //if (other.tag == "SanJiao")
        //{
        //    Destroy(gameObject);
        //}
        //else if(other.CompareTag("Wall"))
        //{
        //    Vector3 normalDir = Vector3.zero;
        //    normalDir = other.contacts[0].normal;

        //    Debug.Log(normalDir);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SanJiao")
        {
            Destroy(gameObject);
        }
    }


    public void Death()
    {
        //for (int i = 0; i < parCount; i++)
        //{
        //    GameObject g = Instantiate(par,
        //        transform.position,
        //        Quaternion.Euler(Random.Range(-360,360),
        //        Random.Range(-360, 360),
        //        Random.Range(-360, 360)
        //        ))as GameObject;
        //    float fireSpeed = Random.Range(fireParSpeedMin,fireParSpeedMax);
        //    g.GetComponent<Rigidbody>().AddForce(g.transform.up*fireSpeed);
        //}
        //增加分数
        GameManager.Instance.AddScore();
        switch (transform.name) {
            case "UFO1":
                //随机赋值一个字符串
                Data.Instance.showTextStr1 = Data.Instance.
                    showTextList1[Random.Range(0, Data.Instance.showTextList1.Count)];
                Destroy(gameObject);
                break;
            case "UFO2":
                //随机赋值一个字符串
                Data.Instance.showTextStr2 = Data.Instance.
                    showTextList2[Random.Range(0, Data.Instance.showTextList2.Count)];
                Destroy(gameObject);
                break;
            case "UFO3":
                //随机赋值一个字符串
                Data.Instance.showTextStr3 = Data.Instance.
                    showTextList3[Random.Range(0, Data.Instance.showTextList3.Count)];
                Destroy(gameObject);
                break;

        }

        var effect = Instantiate(Resources.Load<GameObject>("UFOEffect"));
        effect.transform.position = transform.position;
    }


    public void BombDeath()
    {

        /*
        for (int i = 0; i < parCount; i++)
        {
            GameObject g = Instantiate(par,
                transform.position,
                Quaternion.Euler(Random.Range(-360, 360),
                Random.Range(-360, 360),
                Random.Range(-360, 360)
                )) as GameObject;
            float fireSpeed = Random.Range(fireParSpeedMin, fireParSpeedMax);
            g.GetComponent<Rigidbody>().AddForce(g.transform.up * fireSpeed);
        }
        */
        GameManager.Instance.GameOver();
        GameObject[] allUFO = GameObject.FindGameObjectsWithTag("UFO");
        for (int i = 0; i < allUFO.Length; i++)
        {
            Destroy(allUFO[i].gameObject);   
        }

        //Destroy(gameObject);

    }

















}
