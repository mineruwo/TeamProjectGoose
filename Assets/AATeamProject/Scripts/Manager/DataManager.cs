using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

public class DataManager : MonoBehaviour
{
    public List<Quest> currentQuestDataList;

    private FileInfo fileInfo;

    private int currentSlot;

    public void LoadQuestData(int slotNum)
    {
        string fileName = "Quest" + slotNum;
        string path = Application.dataPath + "/" + "AATeamProject" + "/"  + 
            "Json" + "/" + fileName + ".Json";

        fileInfo = new FileInfo(path);

        if (!fileInfo.Exists)
        {
            Debug.Log($"[DataManager] ���̺� ������ ����");

            fileName = "DefaultQuestData";
            path = Application.dataPath + "/" + "AATeamProject" + "/"  +
            "Json" + "/" + fileName + ".Json";

            string json = File.ReadAllText(path);

            currentQuestDataList = JsonConvert.DeserializeObject<List<Quest>>(json);
        }
        else
        {
            string json = File.ReadAllText(path);
            currentQuestDataList = JsonConvert.DeserializeObject<List<Quest>>(json);
        }

        Debug.Log($"[DataManager] �ҷ��� ���ϸ� :  {fileName}");
        currentSlot = slotNum;
    }

    public void SaveQuestData()
    {
        string fileName = "Quest" + currentSlot;
        string path = Application.dataPath + "/" + "AATeamProject" + "/"  +
            "Json" + "/" + fileName + ".Json";

        var setJson = JsonConvert.SerializeObject(currentQuestDataList);
        File.WriteAllText(path, setJson);
        Debug.Log($"[DataManager] ������ ���ϸ� : {fileName}");
    }

    public void DeleteQuestData(int slotNum)
    {
        string fileName = "Quest" + slotNum;
        string path = Application.dataPath + "/" + "AATeamProject" + "/"  +
           "Json" + "/" + fileName + ".Json";

        File.Delete(path);
    }
}
