using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChatLog",menuName = "ChatLogs/chat")]
public class ChatSO : ScriptableObject
{
    public List<string> chat;
}
