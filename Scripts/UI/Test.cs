using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update()
    {
        TestProjectile();
    }
    private GameObject objectz;
    private void TestProjectile(){
         objectz = GameObject.FindGameObjectWithTag("Player");
        if (Input.GetKey(KeyCode.F))
        {
            //Destroy(gameObject);

            transform.parent = objectz.transform.GetChild(0).gameObject.transform;
        
        }       
    }
    
}
