using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadDisplay1 : MonoBehaviour
{
    [SerializeField]
    private Sprite[] digits;

    [SerializeField]
    private Image[] characters;

    private string codeSequence;
    public string passcode;
 
    public GameObject keypadUI;
    public GameObject lockedDoor;

    void Start()
    {
        codeSequence = "";
        for (int i = 0; i <= characters.Length - 1; i++)
        {
            //Default digit should be in tenth position
            characters[i].sprite = digits[10];
        }
        KeypadButton1.ButtonPressed += AddDigitToCodeSequence;
        keypadUI.SetActive(false);
    }

    private void AddDigitToCodeSequence(string digitEntered)
    {
        if (codeSequence.Length < 4)
        {
            switch (digitEntered)
            {
                case "Zero":
                    codeSequence += "0";
                    DisplayCodeSequence(0);
                    break;

                case "One":
                    codeSequence += "1";
                    DisplayCodeSequence(1);
                    break;

                case "Two":
                    codeSequence += "2";
                    DisplayCodeSequence(2);
                    break;

                case "Three":
                    codeSequence += "3";
                    DisplayCodeSequence(3);
                    break;

                case "Four":
                    codeSequence += "4";
                    DisplayCodeSequence(4);
                    break;

                case "Five":
                    codeSequence += "5";
                    DisplayCodeSequence(5);
                    break;

                case "Six":
                    codeSequence += "6";
                    DisplayCodeSequence(6);
                    break;

                case "Seven":
                    codeSequence += "7";
                    DisplayCodeSequence(7);
                    break;

                case "Eight":
                    codeSequence += "8";
                    DisplayCodeSequence(8);
                    break;

                case "Nine":
                    codeSequence += "9";
                    DisplayCodeSequence(9);
                    break;
            }
        }

        switch (digitEntered)
        {
            case "Reset":
                ResetDisplay();
                break;

            case "Enter":
                if (codeSequence.Length > 0)
                {
                    CheckResults();
                }
                break;
        }
    }

    private void DisplayCodeSequence(int digitValueEntered)
    {
        switch (codeSequence.Length)
        {
            case 1:
                characters[0].sprite = digits[10];
                characters[1].sprite = digits[10];
                characters[2].sprite = digits[10];
                characters[3].sprite = digits[digitValueEntered];
                break;

            case 2:
                characters[0].sprite = digits[10];
                characters[1].sprite = digits[10];
                characters[2].sprite = characters[3].sprite;
                characters[3].sprite = digits[digitValueEntered];
                break;

            case 3:
                characters[0].sprite = digits[10];
                characters[1].sprite = characters[2].sprite;
                characters[2].sprite = characters[3].sprite;
                characters[3].sprite = digits[digitValueEntered];
                break;

            case 4:
                characters[0].sprite = characters[1].sprite;
                characters[1].sprite = characters[2].sprite;
                characters[2].sprite = characters[3].sprite;
                characters[3].sprite = digits[digitValueEntered];
                break;
        }
    }

    private void CheckResults()
    {
        if (codeSequence == passcode)
        {
           
            keypadUI.SetActive(false);
            Destroy(lockedDoor);
            ExitKeypadUI();
            OnDestroy();
        }
        else
        {
          
            ResetDisplay();
        }
    }

    private void ResetDisplay()
    {
        for (int i = 0; i <= characters.Length - 1; i++)
        {
            characters[i].sprite = digits[10];
        }
        codeSequence = "";
    }

    private void OnDestroy()
    {
        KeypadButton1.ButtonPressed -= AddDigitToCodeSequence;
    }

    public void StartKeypadUI()
    {
        Player2Movement state = FindObjectOfType<Player2Movement>();
        state.currentState = Player2State.interact;
        keypadUI.SetActive(true);
    }
    public void ExitKeypadUI()
    {
        Player2Movement state = FindObjectOfType<Player2Movement>();
        state.currentState = Player2State.walk;
        keypadUI.SetActive(false);
    }
}
