using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereController : MonoBehaviour
{
    public Rigidbody sphereplayer;

    public GameObject sphere;

    public GameObject obj;

    private float y_pos= -2.0f;
    private float z_pos= -63.0f;

    private Vector3 newposition;

  //  float speed = 10.0f;


    
    void Start()
    {
        sphereplayer = GetComponent<Rigidbody>();

      //  Input.gyro.enabled = true;
    }
   
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            restart();

        }

        
    }

      void FixedUpdate()
      {

        /*
          float moveH = Input.GetAxis("Horizontal");
          float moveV = Input.GetAxis("Vertical");

          Vector3 movement = new Vector3(moveH, 0.0f, moveV);

          sphereplayer.AddForce(movement*50);
          */

        Vector3 dir = Vector3.zero;
        

        dir.x = Input.acceleration.y;
        dir.z = -Input.acceleration.x;
        

        
        if (dir.sqrMagnitude > 1)
            dir.Normalize();

       
       // dir *= Time.deltaTime;

        
      // transform.Translate(dir * speed);

        sphereplayer.AddForce(dir * 50);
        
       

    }

    void OnTriggerExit(Collider other)
     {
         if(other.gameObject.CompareTag("Trigger"))
         {
           GameObject clone;

             clone = Instantiate(obj);

         

             newposition.y = y_pos;
             newposition.z = z_pos;

             clone.transform.position = new Vector3(obj.transform.position.x, newposition.y, newposition.z) + new Vector3(0,-40,-26);

             Debug.Log(clone.transform.position + "Позиция объекта");

             y_pos = clone.transform.position.y;
             z_pos = clone.transform.position.z;

             Debug.Log(y_pos+"Позиция у");
             Debug.Log(z_pos+"Позиция z");

         }
     }
     
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

}
