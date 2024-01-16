using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class MRIAccess : MonoBehaviour
{
    [Space(10)]
    [Header("Toggle for the GUI on/off")]
    public bool GuiOn;

    [Space(10)]
    [Header("Text to Display on Trigger")]
    public string Text = "Press F to start the MRI session";

    [Header("Text to Display when inside MRI machine")]
    public string InsideMRIText = "Press E to leave the MRI machine";

    [Tooltip("This is the window Box's size. It will be mid screen. Add or reduce the X and Y to move the box in Pixels.")]
    public Rect BoxSize = new Rect(0, 0, 200, 100);

    [Tooltip("To edit the look of the text, go to Assets > Create > GUIskin.")]
    public GUISkin customSkin;

    private bool playerInsideMRI = false;

    void OnTriggerEnter()
    {
        GuiOn = true;
    }

    void OnTriggerExit()
    {
        GuiOn = false;
    }

    void OnGUI()
    {
        if (customSkin != null)
        {
            GUI.skin = customSkin;
        }

        if (GuiOn == true)
        {
            GUI.BeginGroup(new Rect((Screen.width - BoxSize.width) / 2, (Screen.height - BoxSize.height) / 2, BoxSize.width, BoxSize.height));

            if (playerInsideMRI)
            {
                GUI.Label(BoxSize, InsideMRIText);
            }
            else
            {
                GUI.Label(BoxSize, Text);
            }

            GUI.EndGroup();
        }
    }

    public void SetPlayerInsideMRI(bool insideMRI)
    {
        playerInsideMRI = insideMRI;
    }
}
