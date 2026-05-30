using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class SaikoroScripts : MonoBehaviour
{
    GameObject saikoro;
    bool isRoring = false;
    float time;
    float resultTime;
    int mode;

    public WrapperScript wrapperScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        saikoro = this.gameObject;
        float[] angles = new float[] {0,90,180,360};
        saikoro.transform.eulerAngles = new Vector3(angles[Random.Range(0,angles.Length -1)],angles[Random.Range(0,angles.Length -1)],angles[Random.Range(0,angles.Length -1)]);
    }

    // Update is called once per frame
    void Update()
    {
        Keyboard keyboard = Keyboard.current;
        if(keyboard != null && keyboard.aKey.IsPressed() && keyboard.bKey.IsPressed() && keyboard.xKey.IsPressed()){
            SceneManager.LoadScene("SaikoroScene");
        }
        if(wrapperScript.OnInputButtonDown()){
            time = Time.time;
        }
        if(wrapperScript.OnInputButtonUp()){
            resultTime = Time.time - time;
            if(resultTime > 1){
                SceneManager.LoadScene("SaikoroScene");
            }
        }
        if(isRoring == true && mode == 1){
        saikoro.transform.position = new Vector3(0,0,0);
        }
    }
    public void Stop(){
        isRoring = !isRoring;
        if(isRoring == true){
            saikoro.transform.position = new Vector3(0,0,0);
        }
    }
    void FixedUpdate()
    {
        if(isRoring){
            saikoro.transform.eulerAngles= new Vector3(Random.Range(0,360),Random.Range(0,360),Random.Range(0,360));
        }
    }
    
    public void ChangePositionMode(){
        if(mode==0){
            mode = 1;
        }else{
            mode = 0;
        }
    }
    public void ChangeScene(){
        SceneManager.LoadScene("SaikoroScene");
    }

}
