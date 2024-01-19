using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GhostDataContainer
{
    public List<GhostPosition> myGhostPos;
    int index;
    
    public GhostDataContainer()
    {
        myGhostPos = new List<GhostPosition>();
    }

    public void Reset()
    {
        myGhostPos.Clear();
    }

    public void AddPosition(Vector3 position, Quaternion rotation)
    {
        GhostPosition newGhostPos = new GhostPosition();
        newGhostPos.xPos = position.x;
        newGhostPos.yPos = position.y;
        newGhostPos.zPos = position.z;
        newGhostPos.xRot = rotation.eulerAngles.x;
        newGhostPos.yRot = rotation.eulerAngles.y;
        newGhostPos.zRot = rotation.eulerAngles.z;
        myGhostPos.Add(newGhostPos);
    }
    public bool GetNextPosition(ref Vector3 vec, ref Quaternion rot)
    {
        index++;
        
        if (index >=0 && index < myGhostPos.Count)
        {
            vec = new Vector3(myGhostPos[index].xPos, myGhostPos[index].yPos, myGhostPos[index].zPos);
            rot = Quaternion.Euler(myGhostPos[index].zRot, myGhostPos[index].yRot, myGhostPos[index].zRot);
            return true;
        }
        else
        {
            return false;
        }        
    }

    public bool GetFirstPosition(ref Vector3 vec, ref Quaternion rot)
    {
        if (myGhostPos.Count > 0)
        {
            index = 0;

            vec = new Vector3(myGhostPos[index].xPos, myGhostPos[index].yPos, myGhostPos[index].zPos);
            rot = Quaternion.Euler(myGhostPos[index].xRot, myGhostPos[index].yRot, myGhostPos[index].zRot);
            return true;
        }
        else
        {
            return false;
        }
    }
}

public struct GhostPosition
{
    public float xPos, yPos, zPos, xRot, yRot, zRot;
}
