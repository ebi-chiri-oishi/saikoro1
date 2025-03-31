using UnityEngine;
using UnityEngine.InputSystem;

public class WrapperScript : MonoBehaviour
{
    bool isClicking;
    bool isClicked;

    float mouseSelect;
    bool isMouseButtonDown;
    bool isMouseButtonUp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mouseSelect == 0){
            Mouse mouse = Mouse.current;
            if( mouse != null){
                if(isClicked == false &&  mouse.leftButton.IsPressed()){
                    Debug.Log("A");
                    isClicked = true;
                    isMouseButtonDown = true;
                }else if(isClicked == true &&  mouse.leftButton.IsPressed()){
                    Debug.Log("B");
                    isMouseButtonDown = false;
                }else if(isClicked == true &&  !mouse.leftButton.IsPressed()){
                    Debug.Log("C");
                    isMouseButtonUp = true;
                    isClicked = false;
                }else{
                    isMouseButtonUp = false;
                }
            }

            Touchscreen touch = Touchscreen.current;
            if(touch != null){
                if(isClicked == false &&  touch.primaryTouch.IsPressed()){
                    Debug.Log("A");
                    isClicked = true;
                    isMouseButtonDown = true;
                }else if(isClicked == true &&  touch.primaryTouch.IsPressed()){
                    Debug.Log("B");
                    isMouseButtonDown = false;
                }else if(isClicked == true &&  !touch.primaryTouch.IsPressed()){
                    Debug.Log("C");
                    isMouseButtonUp = true;
                    isClicked = false;
                }else{
                    isMouseButtonUp = false;
                }
            }
        }else if(mouseSelect == 1){
            Mouse mouse = Mouse.current;
            if(isClicked == false &&  mouse.rightButton.IsPressed()){
            Debug.Log("A");
            isClicked = true;
            isMouseButtonDown = true;
            }else if(isClicked == true &&  mouse.rightButton.IsPressed()){
            Debug.Log("B");
            isMouseButtonDown = false;
            }else if(isClicked == true &&  !mouse.rightButton.IsPressed()){
            Debug.Log("C");
            isMouseButtonUp = true;
            isClicked = false;
            }else{
                isMouseButtonUp = false;
            }
        }
    }
    public bool OnInputButtonDown(float button){
        button = mouseSelect;
        return isMouseButtonDown;
    }
    public bool OnInputButtonUp(float button){
        button = mouseSelect;
        return isMouseButtonUp;
    }
    public bool OnInputButtonClicking(float button){
        button = mouseSelect;
        Mouse mouse = Mouse.current;
        Touchscreen touch = Touchscreen.current;
        
        if(mouse != null && touch != null){
            return mouse.leftButton.IsPressed() || touch.primaryTouch.IsPressed();
        }else if(mouse != null){
            return mouse.leftButton.IsPressed();
        }else if(touch != null){
            return touch.primaryTouch.IsPressed();
        }else{
            return false;
        }
    }
    public Vector2 InputPosition(){
        Mouse mouse = Mouse.current;
        Touchscreen touch = Touchscreen.current;
        Vector2 position = mouse.position.value;
        Debug.Log(position);
        return position;
    }
}
