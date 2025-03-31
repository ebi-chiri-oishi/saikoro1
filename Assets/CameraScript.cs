using TMPro;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject gameobject;
    public Vector3 vector3;
    bool cameraScriptEnabled = true;
    public TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraScriptEnabled){
            this.transform.position = gameobject.transform.position + vector3;
        }
    }
    public void EnableCameraScript(){
        cameraScriptEnabled = !cameraScriptEnabled;
        if(cameraScriptEnabled){
            text.text = "CamMode:" +0;
        }else{
            text.text = "CamMode:" +1;
        }
        
    }
}
