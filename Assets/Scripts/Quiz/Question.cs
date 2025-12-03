using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "Scriptable Objects/Question")]
public class Question : ScriptableObject
{
    public string questionText;
    public string A;
    public string B;
}
