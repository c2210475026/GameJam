using UnityEngine;
using static GameManager;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 startpos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startpos = new Vector3(transform.position.x, target.position.y, transform.position.z);
    }

    void LateUpdate()
    {
        if(index==3){
            if(target.position.y > transform.position.y){
                Vector3 newpos = new Vector3(transform.position.x, target.position.y, transform.position.z);
                transform.position = newpos;
            }
            if(target.position.y < transform.position.y){
                Vector3 newpos = new Vector3(transform.position.x, target.position.y, transform.position.z);
                transform.position = newpos;
            }   
        }else{
            transform.position = startpos;
        }
        
    }
}
