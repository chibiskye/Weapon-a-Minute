using UnityEngine;
using UnityEngine.UI;

public class DebugLogScript : MonoBehaviour
{
    private Text debugLog = null;

    void Awake()
    {
        debugLog = GetComponent<Text>();
        if (!GameManager.DebugMode) {
            gameObject.SetActive(false);
        }
    }

    public void AddLog(string text)
    {
        debugLog.text += (text + "\n");
    }

    public void ClearLog()
    {
        debugLog.text = "";
    }
}
