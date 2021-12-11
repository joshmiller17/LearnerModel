using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JoshAaronMiller.LearnerModel
{
    /// <summary>
    /// A Learner is a single user studying Skills.
    /// </summary>
    public class Learner
    {
        Dictionary<Skill, float> skillMasteries = new Dictionary<Skill, float>();
        Dictionary<Item, History> itemHistories = new Dictionary<Item, History>();
        Dictionary<Skill, History> skillHistories = new Dictionary<Skill, History>();
    }
}