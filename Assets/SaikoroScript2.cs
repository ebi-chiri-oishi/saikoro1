using UnityEngine;
using UnityEngine.SceneManagement;

public class SaikoroScript2 : MonoBehaviour
{
    Vector2 firstPosition;
    Vector2 secoundPosition;
    public GameObject saikoro;
    Rigidbody rb;
    public WrapperScript wrapperScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firstPosition = new Vector2(0,0);
        secoundPosition = new Vector2(0,0);
        rb = saikoro.GetComponent<Rigidbody>();
        float[] angles = new float[] {0,90,180,360};
        saikoro.transform.eulerAngles = new Vector3(angles[Random.Range(0,angles.Length -1)],0,angles[Random.Range(0,angles.Length -1)]);
    }

    // Update is called once per frame
    void Update()
    {
        if(wrapperScript.OnInputButtonDown()){
            saikoro.transform.position = new Vector3(0,saikoro.transform.position.y,saikoro.transform.position.z);
            firstPosition = wrapperScript.InputPosition();
        }
        if(wrapperScript.OnInputButtonUp()){
            secoundPosition = wrapperScript.InputPosition();
            Vector2 position = firstPosition - secoundPosition;
            var angle = Mathf.Atan2(position.x, position.y);
            saikoro.transform.eulerAngles = new Vector3(0,(angle + 360) % 360,0);
            rb.AddForce(new Vector3(secoundPosition.x - firstPosition.x * 2,secoundPosition.y - firstPosition.y * 2,(secoundPosition.x - firstPosition.x) * (secoundPosition.y - firstPosition.y) * 0.01F));
        }
        
    }
    public void ChangeScene(){
        SceneManager.LoadScene("NormalScene");
    }
}
