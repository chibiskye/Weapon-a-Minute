using UnityEngine;
using UnityEngine.UI;

public class DebugLogScript : MonoBehaviour
{
    private Text debugLog = null;

    void Awake()
    {
        debugLog = GetComponent<Text>();
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
