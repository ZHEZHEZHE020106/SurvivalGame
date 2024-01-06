using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftItems 
{
    public string itemName;
    public string Req1;
    public string Req2;

    public int Req1amount;
    public int Req2amount;

    public int total_Req;

    public CraftItems(string Name, int totalReq, string R1, int R1num, string R2, int R2num)
    {
        itemName = Name;
        Req1 = R1;
        Req2 = R2;
        Req1amount = R1num;
        Req2amount = R2num;
        total_Req = totalReq;
    } 

}
