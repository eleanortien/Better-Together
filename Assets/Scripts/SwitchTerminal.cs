using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTerminal : MonoBehaviour
{
    public bool summonsKeypad = true;
    public int keypadNumber;
    public KeypadDisplay1 keypad1;
    public KeypadDisplay2 keypad2;
    public GameObject door;
    public void TriggerSwitch()
    {
            if (summonsKeypad)
            {
                if (keypadNumber == 1)
                {
                    keypad1.StartKeypadUI();
                }
                else if (keypadNumber == 2)
                {
                   keypad2.StartKeypadUI();
                }
            }
            else
            {
                Destroy(door);
            }
        

    }
}
