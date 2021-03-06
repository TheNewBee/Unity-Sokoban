using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    public List<string> row = new List<string>();

    public int Height { get { return row.Count; } }
    public int Width
    {
        get
        {
            int maxLen = 0;
            foreach(var r in row)
            {
                if(r.Length > maxLen)
                {
                    maxLen = r.Length;
                }
            }
            return maxLen;
        }
    }

}

public class Levels : MonoBehaviour
{
    public string filename;
    public List<Level> _levels;

    private void Awake()
    {
        TextAsset textAsset = (TextAsset)Resources.Load(filename);
        if (!textAsset)
        {
            Debug.Log("Levels: " + filename + ".txt does not exist");
            return;
        }
        else
        {
            Debug.Log("Levels imported ");
        }
        string completeText = textAsset.text;
        string[] lines;
        lines = completeText.Split(new string[] { "\n" }, System.StringSplitOptions.None);
        _levels.Add(new Level());
        for(long i = 0; i < lines.LongLength; i++)
        {
            string line = lines[i];
            if (line.StartsWith(";"))
            {
                Debug.Log("New Level Added");
                _levels.Add(new Level());
                continue;
            }
            _levels[_levels.Count - 1].row.Add(line);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
