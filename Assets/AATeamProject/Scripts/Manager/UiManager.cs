using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    // ≈∏¿Ã∆≤æ¿
    public void OnClickGameSlot(int slotNum)
    {
        Debug.Log($"[UiManager] {slotNum}π¯ ΩΩ∑‘ ¥©∏ß");

        GameManager.instance.sceneMgr.LoadGameScene();
    }

    // ∞‘¿”æ¿

}
