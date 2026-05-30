using UnityEngine;

public class UIScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject landscapeCanvas;
    public GameObject portraitCanvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeUIOrientation()
    {
        if(landscapeCanvas.activeSelf == true)
        {
            landscapeCanvas.SetActive(false);
            portraitCanvas.SetActive(true);
        }
        else
        {
            landscapeCanvas.SetActive(true);
            portraitCanvas.SetActive(false);
        }
    }
}
