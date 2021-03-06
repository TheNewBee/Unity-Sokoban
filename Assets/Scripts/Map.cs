using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Maps
{
    public List<string> row = new List<string>();
    public int Height { get { return row.Count; } }
    public int Width
    {
        get
        {
            int maxLen = 0;
            foreach (var r in row)
            {
                if (r.Length > maxLen)
                {
                    maxLen = r.Length;
                }
            }
            return maxLen;
        }
    }
}
// This is the game map
// It has the dimension column and row
// There are different types of area in the board (wall, empty space,
// player, box, storage)
// Game map has its own display method
public class Map : MonoBehaviour
{

    public string filename;
    public List<Maps> _map;

    private void Awake()
    {
        TextAsset textAsset = (TextAsset)Resources.Load(filename);
        if (!textAsset)
        {
            Debug.Log("Map Chosen: " + filename + ".txt does not exist");
            return;
        }
        else
        {
            Debug.Log("Map imported ");
        }
        string completeText = textAsset.text;
        string[] lines;
        lines = completeText.Split(new string[] { "\n" }, System.StringSplitOptions.None);
        _map.Add(new Maps());
        for (long i = 0; i < lines.LongLength; i++)
        {
            string line = lines[i];
            if (line.StartsWith(";"))
            {
                Debug.Log("New Map Added");
                _map.Add(new Maps());
                continue;
            }
            _map[_map.Count - 1].row.Add(line);
        }
    }
    /*
    // Fields
    protected int _column, _row;
    protected string[,] _gamemap;

    // Constructor
    public Map() { }

    public Map(string[,] gamemap)
    {
        this._gamemap = gamemap;
    }

    public Map(int col, int row, string[,] gamemap)
    {
        this._column = col;
        this._row = row;
        this._gamemap = gamemap;
    }

    // Methods
    public string get_area_type(int x, int y)
    {
        return "\n";
    }

    public void display_map()
    {

    }
    public void reset_map()
    {

    }

    // Getter and Setter of _column
    public int column
    {
        get { return _column; }
        set { _column = value; }
    }
    // Getter and Setter of _row
    public int row
    {
        get { return _row; }
        set { _row = value; }
    }
    // Getter and Setter of _gamemap
    public string[,] gamemap
    {
        get { return _gamemap; }
        set { _gamemap = value; }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
