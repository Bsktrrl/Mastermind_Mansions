using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneManager : MonoBehaviour
{
    AudioManager audioManager;
    BoxButton boxButton;

    #region SerializeField
    //Prefabs
    [Header("Prefabs")]
    [SerializeField] GameObject Choice_Prefab;
    [SerializeField] GameObject Box_Prefab;
    [SerializeField] GameObject Answer_Prefab;
    [SerializeField] GameObject Condition_Prefab;

    //Displays
    [Header("Displays")]
    [SerializeField] GameObject Choice_Display;
    [SerializeField] GameObject Input_Display;

    [SerializeField] GameObject Content_Panel;
    [SerializeField] GameObject Answer_Display;

    [SerializeField] GameObject Answer_Panel;

    //Sprites
    [Header("Sprites")]
    [SerializeField] Sprite Choice_nr_1;
    [SerializeField] Sprite Choice_nr_2;
    [SerializeField] Sprite Choice_nr_3;
    [SerializeField] Sprite Choice_nr_4;
    [SerializeField] Sprite Choice_nr_5;
    [SerializeField] Sprite Choice_nr_Green;
    [SerializeField] Sprite Choice_nr_Blue;
    [SerializeField] Sprite Choice_nr_Yellow;
    [SerializeField] Sprite Choice_nr_White;
    [SerializeField] Sprite Choice_nr_Red;
    [SerializeField] Sprite Choice_nr_Purple;

    [SerializeField] Sprite Guess_Right;
    [SerializeField] Sprite Guess_Almost;

    //Buttons
    [Header("Buttons")]
    [SerializeField] Button Guess_Button;
    #endregion

    #region Lists
    [Header("List")]
    List<Sprite> goal = new List<Sprite>();
    List<bool> goalisTaken = new List<bool>();

    List<GameObject> Choice_List = new List<GameObject>();
    List<Sprite> Choice_Sprite_List = new List<Sprite>();

    public List<GameObject> Box_Display_List = new List<GameObject>();
    public List<bool> BoxisTaken = new List<bool>();

    List<GameObject> AnswerPanel_List = new List<GameObject>();

    List<GameObject> Right_List = new List<GameObject>();
    List<GameObject> Left_List = new List<GameObject>();
    #endregion

    #region Variables
    int choices_Amount = 3;
    int box_Amount = 3;
    #endregion

    #region Audio
    AudioSource audioEffects;
    #endregion

    #region Texts
    [Header("Texts")]
    [SerializeField] TextMeshProUGUI GuessText;
    #endregion
    
    int SideScrollSize_Width = 1180;
    int SideScrollSize_Height = 0;

    public bool pause;
    bool reset = true;

    int guessCounter;

    public bool destroyBO;
    bool mode;



    //--------------------


    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        boxButton = FindObjectOfType<BoxButton>();
    }
    private void Start()
    {
        audioEffects = GetComponent<AudioSource>();

        SetupLists();

        SetParameters();
        SetGoal();

        SetupChoiceList();
        SetupBoxList();
    }
    private void Update()
    {
        UpdateTexts();
    }


    //--------------------


    void SetupLists()
    {
        int modeSelect = Random.Range(0, 2);

        switch (modeSelect)
        {
            case 0:
                mode = true;
                break;
            case 1:
                mode = false;
                break;
            default:
                mode = true;
                break;
        }

        //if (modeSelect >= 0.5)
        //{
        //    mode = false;
        //}
        //else
        //{
        //    mode = true;
        //}

        //Add Sprites to list
        if (mode)
        {
            Choice_Sprite_List.Add(Choice_nr_Green);
            Choice_Sprite_List.Add(Choice_nr_Blue);
            Choice_Sprite_List.Add(Choice_nr_Yellow);
            Choice_Sprite_List.Add(Choice_nr_Red);
            Choice_Sprite_List.Add(Choice_nr_White);
            Choice_Sprite_List.Add(Choice_nr_Purple);
        }
        else
        {
            Choice_Sprite_List.Add(Choice_nr_1);
            Choice_Sprite_List.Add(Choice_nr_2);
            Choice_Sprite_List.Add(Choice_nr_3);
            Choice_Sprite_List.Add(Choice_nr_4);
            Choice_Sprite_List.Add(Choice_nr_5);
        }
    }

    void SetParameters()
    {
        if (mode)
        {
            choices_Amount = Random.Range(3, 7);
            box_Amount = Random.Range(3, 7);
        }
        else
        {
            choices_Amount = Random.Range(3, 6);
            box_Amount = Random.Range(3, 6);
        }
        
    }
    void SetGoal()
    {
        //Make Goal.List
        for (int i = 0; i < box_Amount; i++)
        {
            int random = Random.Range(0, choices_Amount);

            switch (random)
            {
                case 0:
                    goal.Add(Choice_Sprite_List[0]);
                    goalisTaken.Add(false);
                    break;
                case 1:
                    goal.Add(Choice_Sprite_List[1]);
                    goalisTaken.Add(false);
                    break;
                case 2:
                    goal.Add(Choice_Sprite_List[2]);
                    goalisTaken.Add(false);
                    break;
                case 3:
                    goal.Add(Choice_Sprite_List[3]);
                    goalisTaken.Add(false);
                    break;
                case 4:
                    goal.Add(Choice_Sprite_List[4]);
                    goalisTaken.Add(false);
                    break;
                case 5:
                    goal.Add(Choice_Sprite_List[5]);
                    goalisTaken.Add(false);
                    break;

                default:
                    goal.Add(Choice_Sprite_List[1]);
                    goalisTaken.Add(false);
                    break;
            }
        }

        //Print Gaol for easier buggtesting
        for (int i = 0; i < goal.Count; i++)
        {
            print("Goal: " + goal[i]);
        }
        print("_______________");


        //while (reset)
        //{
        //    int countTemp = 0;

        //    //Check for similar elements in List
        //    for (int j = 0; j < goal.Count; j++)
        //    {
        //        if (goal[0] == goal[j])
        //        {
        //            countTemp++;
        //        }
        //    }

        //    //Print Gaol for easier buggtesting
        //    for (int i = 0; i < goal.Count; i++)
        //    {
        //        print("Goal: " + goal[i]);
        //    }
        //    print("_______________");

        //    //Reset if the all elements are the same
        //    if (countTemp >= goal.Count)
        //    {
        //        reset = true;

        //        for (int i = box_Amount - 1; i < 0; i--)
        //        {
        //            Destroy(goal[i]);
        //        }
        //    }
        //    else
        //    {
        //        reset = false;
        //    }

        //    countTemp = 0;
        //}
    }

    void SetupChoiceList()
    {
        //Display Number of Choices to be used
        for (int i = 0; i < choices_Amount; i++)
        {
            Choice_List.Add(Instantiate(Choice_Prefab, new Vector3(0, 0, 0), Quaternion.identity));

            Choice_List[i].GetComponent<Image>().sprite = Choice_Sprite_List[i];
            Choice_List[i].transform.parent = Choice_Display.transform;
        }
    }
    void SetupBoxList()
    {
        //Display Number of Choice Displays to be used
        for (int i = 0; i < box_Amount; i++)
        {
            Box_Display_List.Add(Instantiate(Box_Prefab, new Vector3(0, 0, 0), Quaternion.identity));
            Box_Display_List[i].transform.parent = Input_Display.transform;

            BoxisTaken.Add(false);
        }
    }

    void UpdateTexts()
    {
        GuessText.text = "Guesses: " + guessCounter;
    }


    //--------------------


    public void GuessButton_Clicked()
    {
        int counter = 0;

        //Trigger Guess_Button if all boxes are seleced
        if (CheckBoxesSelected(counter) >= Box_Display_List.Count)
        {
            guessCounter += 1;
            int correctCounter = 0;

            //If Guessed Correctly
            if (CheckIfGuessIsCorrect(correctCounter) >= Box_Display_List.Count)
            {
                DisplayAnswer();
                CorrectGuess();
                ClearBoxes();
            }
            else
            {
                DisplayAnswer();
                WrongGuess();
                ClearBoxes();
            }
        }
    }

    int CheckBoxesSelected(int counter)
    {
        //Check if all boxes are seleced
        for (int i = 0; i < Box_Display_List.Count; i++)
        {
            if (Box_Display_List[i].transform.Find("Background").GetComponent<Image>().color == new Color(1f, 1f, 1f, 1f))
            {
                counter++;
            }
        }

        return counter;
    }
    int CheckIfGuessIsCorrect(int correctCounter)
    {
        //Check if the Guess was correct
        for (int i = 0; i < Box_Display_List.Count; i++)
        {
            if (Box_Display_List[i].transform.Find("Background").GetComponent<Image>().sprite == goal[i])
            {
                correctCounter++;
            }
        }

        return correctCounter;
    }

    void CorrectGuess()
    {
        audioEffects.PlayOneShot(audioManager.GetSuccessAudio(), 0.75f);
        print("Correct");

        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        pause = true;

        yield return new WaitForSecondsRealtime(5);

        pause = false;

        ResetLevel();
    }
    void WrongGuess()
    {
        audioEffects.PlayOneShot(audioManager.GetBuzzerAudio(), 0.75f);
    }

    void DisplayAnswer()
    {
        //Expand Content_Panel Height
        SideScrollSize_Height += 150;
        Content_Panel.GetComponent<RectTransform>().sizeDelta = new Vector2(SideScrollSize_Width, SideScrollSize_Height);

        //Add 1 AnswerPanel
        AnswerPanel_List.Add(Instantiate(Answer_Panel, new Vector3(0, 0, 0), Quaternion.identity));
        AnswerPanel_List[AnswerPanel_List.Count - 1].transform.parent = Content_Panel.transform;

        //Add and place Answer_Prefab
        for (int i = 0; i < Box_Display_List.Count; i++)
        {
            Right_List.Add(Instantiate(Answer_Prefab, new Vector3(0, 0, 0), Quaternion.identity));
            Right_List[Right_List.Count - 1].transform.parent = AnswerPanel_List[AnswerPanel_List.Count - 1].GetComponentInChildren<Transform>().Find("Right");

            Right_List[Right_List.Count - 1].GetComponent<Image>().sprite = Box_Display_List[i].transform.Find("Background").GetComponent<Image>().sprite;
        }

        //Add and place Condition_Prefab ----------
        int CorrectOnCorrect = 0;
        int CorrectOnAlmost = 0;

        //Check for right in right position
        for (int i = 0; i < Box_Display_List.Count; i++)
        {
            if (Box_Display_List[i].transform.Find("Background").GetComponent<Image>().sprite == goal[i] && !BoxisTaken[i] && !goalisTaken[i])
            {
                BoxisTaken[i] = true;
                goalisTaken[i] = true;
                CorrectOnCorrect++;
            }
        }

        //Check for right in wrong position
        for (int i = 0; i < Box_Display_List.Count; i++)
        {
            if (Box_Display_List[i].transform.Find("Background").GetComponent<Image>().sprite != goal[i])
            {
                for (int j = 0; j < Box_Display_List.Count; j++)
                {
                    if (Box_Display_List[i].transform.Find("Background").GetComponent<Image>().sprite == goal[j] && !BoxisTaken[i] && !goalisTaken[j])
                    {
                        BoxisTaken[i] = true;
                        goalisTaken[j] = true;

                        CorrectOnAlmost++;
                        j = Box_Display_List.Count;
                    }
                }
            }
        }


        //--------------------


        //Display Conditions
        for (int i = 0; i < CorrectOnCorrect; i++)
        {
            Left_List.Add(Instantiate(Condition_Prefab, new Vector3(0, 0, 0), Quaternion.identity));

            Left_List[Left_List.Count - 1].transform.parent = AnswerPanel_List[AnswerPanel_List.Count - 1].GetComponentInChildren<Transform>().Find("Left");
            Left_List[Left_List.Count - 1].GetComponent<Image>().sprite = Guess_Right;
        }
        for (int i = 0; i < CorrectOnAlmost; i++)
        {
            Left_List.Add(Instantiate(Condition_Prefab, new Vector3(0, 0, 0), Quaternion.identity));

            Left_List[Left_List.Count - 1].transform.parent = AnswerPanel_List[AnswerPanel_List.Count - 1].GetComponentInChildren<Transform>().Find("Left");
            Left_List[Left_List.Count - 1].GetComponent<Image>().sprite = Guess_Almost;
        }
    }

    void ClearBoxes()
    {
        for (int i = 0; i < Box_Display_List.Count; i++)
        {
            Box_Display_List[i].transform.Find("Background").GetComponent<Image>().sprite = null;
            Box_Display_List[i].transform.Find("Background").GetComponent<Image>().color = new Color(0f, 0f, 0f, 1f);
        }

        for (int i = 0; i < goalisTaken.Count; i++)
        {
            goalisTaken[i] = false;
        }

        for (int i = 0; i < BoxisTaken.Count; i++)
        {
            BoxisTaken[i] = false;
        }
    }

    public void ResetLevel()
    {
        //if (pause == true) { return; }

        int tempRemover = 0;

        #region Remove Lists
        tempRemover = Choice_Sprite_List.Count;
        for (int i = 0; i < tempRemover; i++)
        {
            Choice_Sprite_List.Remove(Choice_Sprite_List[0]);
        }

        tempRemover = goal.Count;
        for (int i = 0; i < tempRemover; i++)
        {
            goal.Remove(goal[0]);
        }

        tempRemover = Choice_List.Count;
        for (int i = 0; i < tempRemover; i++)
        {
            Choice_List.Remove(Choice_List[0]);
        }

        tempRemover = Box_Display_List.Count;
        for (int i = 0; i < tempRemover; i++)
        {
            Box_Display_List.Remove(Box_Display_List[0]);
        }

        tempRemover = AnswerPanel_List.Count;
        for (int i = 0; i < tempRemover; i++)
        {
            AnswerPanel_List.Remove(AnswerPanel_List[0]);
        }

        tempRemover = goalisTaken.Count;
        for (int i = 0; i < tempRemover; i++)
        {
            goalisTaken.Remove(goalisTaken[0]);
        }

        tempRemover = BoxisTaken.Count;
        for (int i = 0; i < tempRemover; i++)
        {
            BoxisTaken.Remove(BoxisTaken[0]);
        }

        tempRemover = Right_List.Count;
        for (int i = 0; i < tempRemover; i++)
        {
            Right_List.Remove(Right_List[0]);
        }

        tempRemover = Left_List.Count;
        for (int i = 0; i < tempRemover; i++)
        {
            Left_List.Remove(Left_List[0]);
        }
        #endregion

        #region Remove GameObjects
        destroyBO = true;

        StartCoroutine(WaitReset(0.01f));
        #endregion
    }

    IEnumerator WaitReset(float second)
    {
        yield return new WaitForSecondsRealtime(second);

        destroyBO = false;

        //Add New
        SetupLists();

        SetParameters();
        SetGoal();

        SetupChoiceList();
        SetupBoxList();

        SideScrollSize_Height = 0;
    }
}
