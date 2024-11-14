using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{
    public Data data;

    public TMP_Text leavesText;

    private void Start()
    {
        data = new Data();
    }

    private void Update()
    {
        leavesText.text = data.leaves + " Leaves";
    }

    public void GenerateLeaves()
    {
        data.leaves += 1;
    }
}
