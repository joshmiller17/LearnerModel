using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static JoshAaronMiller.LearnerModel.Utilities;

namespace JoshAaronMiller.LearnerModel
{

    /// <summary>
    /// An Item is a single practice unit, such as a vocabulary word.
    /// </summary>
    public class Item
    {
        Dictionary<Skill, float> skillsToDifficulties = new Dictionary<Skill, float>();
        DefaultDictionary<Item, int> confusionCounts = new DefaultDictionary<Item, int>();
    }
}