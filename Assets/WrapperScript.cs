using UnityEngine;
using UnityEngine.InputSystem;

public class WrapperScript : MonoBehaviour
{
    bool isClicked;

    float mouseSelect;
    bool isMouseButtonDown;
    bool isMouseButtonUp;



    // Update is called once per frame
    void Update()
    {
        if(mouseSelect == 0){
            Mouse mouse = Mouse.current;
            if( mouse != null){
                if(isClicked == false &&  mouse.leftButton.IsPressed()){
                    isClicked = true;
                    isMouseButtonDown = true;
                }else if(isClicked == true &&  mouse.leftButton.IsPressed()){
                    isMouseButtonDown = false;
                }else if(isClicked == true &&  !mouse.leftButton.IsPressed()){
                    isMouseButtonUp = true;
                    isClicked = false;
                }else{
                    isMouseButtonUp = false;
                }
            }

            Touchscreen touch = Touchscreen.current;
            if(touch != null){
                if(isClicked == false &&  touch.primaryTouch.IsPressed()){
                    isClicked = true;
                    isMouseButtonDown = true;
                }else if(isClicked == true &&  touch.primaryTouch.IsPressed()){
                    isMouseButtonDown = false;
                }else if(isClicked == true &&  !touch.primaryTouch.IsPressed()){
                    isMouseButtonUp = true;
                    isClicked = false;
                }else{
                    isMouseButtonUp = false;
                }
            }
        }else if(mouseSelect == 1){
            Mouse mouse = Mouse.current;
            if(isClicked == false &&  mouse.rightButton.IsPressed()){
                isClicked = true;
                isMouseButtonDown = true;
            }else if(isClicked == true &&  mouse.rightButton.IsPressed()){
                isMouseButtonDown = false;
            }else if(isClicked == true &&  !mouse.rightButton.IsPressed()){
                isMouseButtonUp = true;
                isClicked = false;
            }else{
                isMouseButtonUp = false;
            }
        }
    }
    public bool OnInputButtonDown(){
        return isMouseButtonDown;
    }
    public bool OnInputButtonUp(){
        return isMouseButtonUp;
    }
    public bool OnInputButtonClicking(){
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
        if(mouse != null && touch != null){
            Vector2 position = mouse.position.value + touch.position.value;
            Debug.Log(position);
        return position;
        }else if(mouse != null){
            Vector2 position = mouse.position.value;
            return position;
        }else if(touch != null){
            Vector2 position = touch.position.value;
            return position;
        }else{
            return Vector2.zero;
        }
    }
}
