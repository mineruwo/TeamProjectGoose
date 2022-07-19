using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    // Å¸ÀÌÆ²¾À
    public void OnClickGameSlot(int slotNum)
    {
        Debug.Log($"[UiManager] {slotNum}¹ø ½½·Ô ´©¸§");

        GameManager.instance.dataMgr.LoadQuestData(slotNum);
        GameManager.instance.sceneMgr.LoadGameScene();
    }

    // °ÔÀÓ¾À

    private int currentCursor = 1;

    private Vector2 sizeUp = new Vector2(1.3f, 1.3f);
    private Vector2 sizeDown = new Vector2(1f, 1f);

    private bool Stage1SubQuest = false;
    private bool Stage2SubQuest = false;

    public void OnClickQuestButton(GameObject upMenu, GameObject downMenu)
    {
        if (upMenu.activeSelf)
        {
            upMenu.SetActive(false);
            downMenu.SetActive(false);
        }
        else
        {
            //WirteQuestNote();
            upMenu.SetActive(true);
            downMenu.SetActive(true);
        }
    }

    public void OnClickLeftArrow(GameObject[] cursors)
    {
        if (currentCursor > 0)
        {
            CursorSizeDown(cursors);
            //questNoteLists[currentCursor].SetActive(false);

            currentCursor--;

            CursorSizeUp(cursors);
            //questNoteLists[currentCursor].SetActive(true);
        }
    }

    //public void OnClickRightArrow()
    //{
    //    if (currentCursor < cursors.Length - 1)
    //    {
    //        CursorSizeDown(currentCursor);
    //        questNoteLists[currentCursor].SetActive(false);

    //        currentCursor++;

    //        CursorSizeUp(currentCursor);
    //        questNoteLists[currentCursor].SetActive(true);
    //    }
    //}

    public void CursorSizeUp(GameObject[] cursors)
    {
        cursors[currentCursor].gameObject.transform.localScale = sizeUp;
    }

    public void CursorSizeDown(GameObject[] cursors)
    {
        cursors[currentCursor].gameObject.transform.localScale = sizeDown;
    }

    GameObject questTextObj;
    GameObject subQuestTextObj;
    public void WriteQuestNote(GameObject[] questNoteLists)
    {
        //GameObject[] allChildren = questNoteLists[1].GetComponentsInChildren<GameObject>();
        //foreach (GameObject child in allChildren)
        //{
        //    child.SetActive(false);
        //}

        foreach (var quest in GameManager.instance.dataMgr.currentQuestDataList.FindAll(x => x.stage == 1))
        {
            if(quest.id.ToString().Length != 4)
            {
                questTextObj = GameManager.instance.objpoolMgr.GetObject("QuestText");
                questTextObj.transform.parent = questNoteLists[1].transform;
                questTextObj.GetComponent<TextMeshProUGUI>().text = quest.questName;
                if(quest.isClear)
                {
                    questTextObj.GetComponent<TextMeshProUGUI>().text = "<s>" + quest.questName + "</s>";
                }
            }
            else
            {
                //if (!Stage1SubQuest)
                //{
                //    subTextObj = Instantiate(questCollectTexts[0], questNoteLists[1].transform.GetChild(0));
                //    subTextObj.GetComponent<TextMeshProUGUI>().text += DataManager.currentQuestDataList[i].questName;
                //    if (DataManager.currentQuestDataList[i].isClear)
                //    {
                //        subTextObj.GetComponent<TextMeshProUGUI>().text += "<s>" + subTextObj.GetComponent<TextMeshProUGUI>().text + "</s>";
                //    }
                //    Stage1SubQuest = true;
                //}
                //else
                //{
                //    subTextObj.GetComponent<TextMeshProUGUI>().text += (", " + DataManager.currentQuestDataList[i].questName);
                //    if (DataManager.currentQuestDataList[i].isClear)
                //    {
                //        subTextObj.GetComponent<TextMeshProUGUI>().text += (", " +"<s>" + subTextObj.GetComponent<TextMeshProUGUI>().text + "</s>");
                //    }
                //}
            }
        }


        //for (int i = 0; i < DataManager.currentQuestDataList.Count; i++)
        //{
        //    if (DataManager.currentQuestDataList[i].stage == 1 && !DataManager.currentQuestDataList[i].isMainQuest)
        //    {
        //        if (DataManager.currentQuestDataList[i].id.ToString().Length != 4)
        //        {
        //            textObj = Instantiate(questText, questNoteLists[1].transform.GetChild(0));
        //            textObj.GetComponent<TextMeshProUGUI>().text = DataManager.currentQuestDataList[i].questName;
        //            if (DataManager.currentQuestDataList[i].isClear)
        //            {
        //                textObj.GetComponent<TextMeshProUGUI>().text = "<s>" + textObj.GetComponent<TextMeshProUGUI>().text + "</s>";
        //            }
        //            //questTextDic.Add(DataManager.currentQuestDataList[i].id, textObj);
        //        }
        //        else // ?? ?¥ê? ????
        //        {
        //            if (!Stage1SubQuest)
        //            {
        //                subTextObj = Instantiate(questCollectTexts[0], questNoteLists[1].transform.GetChild(0));
        //                subTextObj.GetComponent<TextMeshProUGUI>().text += DataManager.currentQuestDataList[i].questName;
        //                if (DataManager.currentQuestDataList[i].isClear)
        //                {
        //                    subTextObj.GetComponent<TextMeshProUGUI>().text += "<s>" + subTextObj.GetComponent<TextMeshProUGUI>().text + "</s>";
        //                }
        //                Stage1SubQuest = true;
        //            }
        //            else
        //            {
        //                subTextObj.GetComponent<TextMeshProUGUI>().text += (", " + DataManager.currentQuestDataList[i].questName);
        //                if (DataManager.currentQuestDataList[i].isClear)
        //                {
        //                    subTextObj.GetComponent<TextMeshProUGUI>().text += (", " +"<s>" + subTextObj.GetComponent<TextMeshProUGUI>().text + "</s>");
        //                }
        //            }
        //        }
        //    }
        //}
        //subTextObj.GetComponent<TextMeshProUGUI>().text += ")";
    }
}

