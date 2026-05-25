using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using Tomo.Core;
using UnityEngine;
using UnityEngine.EventSystems;

[Flags]
public enum FurnitureType
{ 
    Chair = 1 << 0,
    Table = 1 << 1,
    Bed = 1 << 2
}

[Flags]
public enum Colours
{
    Red = 1 << 0,
    Blue = 1 << 1,
    Green = 1 << 2
}


public class FurnitureController : ControllerBase<FurnitureController>
{
    private Furniture[] m_furnitures;

    protected override void ControllerAwake()
    {
        m_furnitures = Resources.LoadAll<Furniture>("New Furniture");
        SetControllerToReady();
    }

    public List<Furniture> GetAllFurnitureByType(FurnitureType type)
    {
        List<Furniture> result = new List<Furniture>();
        foreach(Furniture furniture in m_furnitures)
        {
            if (furniture.furnitureType.HasFlag(type))
            {
                result.Add(furniture);
            }
        }
        return result;
    }

    public List<Furniture> GetAllFurnitureByColor(Colours c)
    {
        List<Furniture> result = new List<Furniture>();
        foreach (Furniture furniture in m_furnitures)
        {
            if (furniture.colour.HasFlag(c))
            {
                result.Add(furniture);
            }
        }
        return result;
    }
}
