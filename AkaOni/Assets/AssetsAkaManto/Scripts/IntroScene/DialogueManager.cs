using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private string[] sentences;
    [SerializeField] private Text DialogueText;
    [SerializeField] private GameObject choiceCanvas;
    [SerializeField] private GameObject DialogueCanvas;
    private int i =0;
    // Start is called before the first frame update
    void Start()
    {
        choiceCanvas.SetActive(false);
        DialogueText.text = "";
        sentences = new string[12];
        sentences[0] = "It was a regular afternoon at Hope Springs Academy, when Maya and her friend Lily were planning their next sleepover...";
        sentences[1] = "Maya: \n What should we do tonight? I have this cool horror movie my brother showed me, something about some demon? ";
        sentences[2] = "Lily: \n that sounds great! is it that new one? I've heard its pretty scary... I've even seen people online talk about some kind of curse?";
        sentences[3] = "Maya: \n Yeah, my brother mentioned that to me, something similar to bloody Mary where if you say the demons name three times in front of a mirror, something terrible will happen to you!";
        sentences[4] = "Lily \n Something terrible already did happen to me today! The stupid elevator broke and I had to walk up 3 whole flights of stairs.";
        sentences[5] = "Lily: Did you want to try it? We can use the bathroom after school, my club got cancelled today.";
        sentences[6] = "Maya: \n Sounds good, I'll see you in the third floor bathroom after school";
        //enter bathroom
        sentences[7] = "Maya: \n Alright, are you ready to try this?";
        sentences[8] = "Lily: \n I read about this some more online, it seems we just need to call his name, 'Aka Oni', 3 times and something will happen.";
        sentences[9] = "Maya: \n I'm excited! Let's do this.";
        sentences[10] = "Maya and Lily: \n Aka Oni \t Aka Oni \t Aka Oni";
        //black static bg, scary music
        sentences[11] = "?: \n -wha-ts you--\t\t favou-rite\n color?-";
        //display buttons
        DisplayNextText();
    }

    public void DisplayNextText() {
        if (i < sentences.Length) { DialogueText.text = sentences[i]; }
        else { 
            GameObject.Find("BackgroundImage").GetComponent<BackgroundManager>().DoRitual();
            MakeChoice();
        }
        
        i++;
        if (i == 6) {
            GameObject.Find("BackgroundImage").GetComponent<BackgroundManager>().EnterBathroom();
        }
        if (i == 11)
        {
            GameObject.Find("BackgroundImage").GetComponent<BackgroundManager>().DoRitual();
        }
    }


    public void ContinueButton() {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

        DisplayNextText();
    }

    public void MakeChoice() {
        GameObject.Find("BackgroundImage").GetComponent<BackgroundManager>().DoRitual();
        choiceCanvas.SetActive(true);
        DialogueCanvas.SetActive(false);
    }
}
