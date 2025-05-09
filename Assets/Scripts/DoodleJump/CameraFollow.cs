using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void LateUpdate()
    {
        if(target.position.y > transform.position.y){
            Vector3 newpos = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = newpos;
        }
        if(target.position.y < transform.position.y){
            Vector3 newpos = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = newpos;
        }
        
    }
}
