using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// TODO: Bonus - make this class a Singleton!

[System.Serializable]
public class BulletPoolManager : MonoBehaviour
{
    public GameObject bullet;
    public int MaxBullets;

    //TODO: create a structure to contain a collection of bullets
    private Queue<GameObject> BulletPool;

    // Start is called before the first frame update
    void Start()
    {
        //Create reference to bullet controller
        bullet.GetComponent<BulletController>().BPM = this;
        // TODO: add a series of bullets to the Bullet Pool
        //Creates queue
        BulletPool = new Queue<GameObject>();
        //Call functions below
        _BuildBulletPool();


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsPoolEmpty()
    {
        if (BulletPool.Count == 0)
        {
            return true;
        }
        else
            return false;
    }

    public int SizeOfBulletPool()
    {
        return BulletPool.Count;
    }

    private void _BuildBulletPool()
    {
        for (int i = 0; i < MaxBullets; i++)
        {
            var tempBullet = Instantiate(bullet);
            tempBullet.transform.parent = transform;
            tempBullet.SetActive(false);
            BulletPool.Enqueue(tempBullet);
        }
    }

    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet()
    {
        GameObject tempBullet;
        if (IsPoolEmpty() == true)
        {
            tempBullet = Instantiate(bullet);
            tempBullet.transform.parent = transform;
        }
        else
        {
            tempBullet = BulletPool.Dequeue();
            tempBullet.SetActive(true);
        }
        return tempBullet;
    }

    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        BulletPool.Enqueue(bullet);        
    }
}
