using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHandlerTitle : MonoBehaviour
{
    public void OnClickGameSlot(int slotNum)
    {
        Debug.Log($"[UiManager] {slotNum}�� ���� ����");

        GameManager.instance.uiMgr.OnClickGameSlot(slotNum);
    }

    public void OnClickDelete(int slotNum)
    {
        Debug.Log($"[UiManager] {slotNum} �����");
    }

}
