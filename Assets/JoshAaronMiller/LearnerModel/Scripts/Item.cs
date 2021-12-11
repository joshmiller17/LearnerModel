using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static JoshAaronMiller.LearnerModel.Utilities;

namespace JoshAaronMiller.LearnerModel
{

    /// <summary>
    /// An Item is a single practice unit, such as a vocabulary word.
    /// </summary>
    public class Item
    {
        //TODO define the range and expected values of difficulty

        /// <summary>
        /// A map of skills used/required by this Item to the relative difficulty this Item presents in testing this skill
        /// </summary>
        Dictionary<Skill, float> skillsToDifficulties = new Dictionary<Skill, float>();

        /// <summary>
        /// A map of Items that have been confused with this item (i.e., the correct answer was this but a Learner guessed the other Item) to counts of times these items were confused
        /// Applications may choose to log this symmetrically by also recording the other Item being confused with this Item.
        /// </summary>
        DefaultDictionary<Item, int> confusionCounts = new DefaultDictionary<Item, int>();

        Guid guid;

        public Item()
        {
            guid = Guid.NewGuid();
        }
    }
}