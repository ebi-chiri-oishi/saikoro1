using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject gameobject;
    public Vector3 vector3;
    bool cameraScriptEnabled = true;

    // Update is called once per frame
    void Update()
    {
        if (cameraScriptEnabled){
            this.transform.position = gameobject.transform.position + vector3;
        }
    }
    public void EnableCameraScript(){
        cameraScriptEnabled = !cameraScriptEnabled;
    }
}
