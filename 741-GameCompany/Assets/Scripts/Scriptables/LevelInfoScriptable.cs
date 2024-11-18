using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Info", menuName = "SDITO/Level Info Scriptable", order = 0)]
public class LevelInfoScriptable : MonoBehaviour
{
    public string levelName;
    public string levelDescription;
    public Sprite levelImage;
    public int levelToLoad;
}
