using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ColorCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public Button check1;
    public Button check2;
    public Button check3;
    public Button check4;
    public Button check5;
    public GameObject wrongInputWindow;
    private GameObject clickedButton;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void ColorChange()
    {
        clickedButton = EventSystem.current.currentSelectedGameObject;
        Color clickedcolor = clickedButton.GetComponent<Image>().color;
        if (GameObject.Find("Empty1").GetComponent<Image>().color == Color.white)
        {
            GameObject.Find("Empty1").GetComponent<Image>().color = clickedcolor;
        }
        else if (GameObject.Find("Empty2").GetComponent<Image>().color == Color.white && GameObject.Find("Empty1").GetComponent<Image>().color != clickedcolor)
        {
            GameObject.Find("Empty2").GetComponent<Image>().color = clickedcolor;
        }
        else if (GameObject.Find("Empty3").GetComponent<Image>().color == Color.white && GameObject.Find("Empty1").GetComponent<Image>().color != clickedcolor && GameObject.Find("Empty2").GetComponent<Image>().color != clickedcolor)
        {
            GameObject.Find("Empty3").GetComponent<Image>().color = clickedcolor;
        }
        else if (GameObject.Find("Empty4").GetComponent<Image>().color == Color.white && GameObject.Find("Empty1").GetComponent<Image>().color != clickedcolor && GameObject.Find("Empty2").GetComponent<Image>().color != clickedcolor && GameObject.Find("Empty3").GetComponent<Image>().color != clickedcolor)
        {
            GameObject.Find("Empty4").GetComponent<Image>().color = clickedcolor;
        }
        else if (GameObject.Find("Empty5").GetComponent<Image>().color == Color.white && GameObject.Find("Empty1").GetComponent<Image>().color != clickedcolor && GameObject.Find("Empty2").GetComponent<Image>().color != clickedcolor && GameObject.Find("Empty3").GetComponent<Image>().color != clickedcolor && GameObject.Find("Empty4").GetComponent<Image>().color != clickedcolor) 
        {
            GameObject.Find("Empty5").GetComponent<Image>().color = clickedcolor;
        }
    }
    public void RevertColor()
    {
        EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = Color.white;

    }

    public void CheckSequence()
    {
        if (check1.GetComponent<Image>().color == GameObject.Find("Red").GetComponent<Image>().color && check2.GetComponent<Image>().color == GameObject.Find("Blue").GetComponent<Image>().color && check3.GetComponent<Image>().color == GameObject.Find("Green").GetComponent<Image>().color && check4.GetComponent<Image>().color == GameObject.Find("Yellow").GetComponent<Image>().color && check5.GetComponent<Image>().color == GameObject.Find("Black").GetComponent<Image>().color)
        {
            SceneManager.LoadScene("Continue3");
        }
        else
        {
            wrongInputWindow.SetActive(true);
        }
    }

    public void Goback()
    {
        wrongInputWindow.SetActive(false);
    }
}
