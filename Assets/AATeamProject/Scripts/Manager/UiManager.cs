using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    // Ÿ��Ʋ��
    public void OnClickGameSlot(int slotNum)
    {
        Debug.Log($"[UiManager] {slotNum}�� ���� ����");

        GameManager.instance.sceneMgr.LoadGameScene();
    }

    // ���Ӿ�

}
