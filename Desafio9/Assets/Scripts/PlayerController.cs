using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedPlayer = 5.0f;
    [SerializeField] private float speedRotation = 5.0f;
    [SerializeField] private Vector3 scalePlayer  ;
    [SerializeField] private bool shrink = false;
    [SerializeField] Transform[] Respawn;
    [SerializeField] private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        float ejeHorizontal = Input.GetAxis("Horizontal");
        float ejeVertical = Input.GetAxis("Vertical");
        transform.Translate(0, 0, ejeVertical * Time.deltaTime * speedPlayer);
        transform.Rotate(0, ejeHorizontal * Time.deltaTime * speedRotation, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        Debug.Log("Shrinker");
        if (other.gameObject.layer == 8)
        {
            if(shrink ==false)
            {
                transform.localScale = scalePlayer * 1.3f;
            shrink = true;
            }
         else if(shrink ==true)
        {
            transform.localScale = scalePlayer / 1;
            shrink = false;
        }
        }
        

    }
   
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        
        if(collision.gameObject.layer ==7)
        {
            time += 1;
            if(time >=2)
            {
                Debug.Log("mover pared");
                collision.gameObject.transform.position = Respawn[0].transform.position;
                collision.gameObject.transform.rotation = Respawn[0].transform.rotation;
                time = 0;
            }
            
            
          

        }

        

    }
}
