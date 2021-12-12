using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JoshAaronMiller.LearnerModel
{
    public class LearnerModel
    {
        List<Learner> learners;

        public void AddLearner(Learner learner)
        {
            learners.Add(learner);
        }

        public List<Skill> RecommendSkills(Learner learner, int howMany = 1)
        {
            DateTime now = DateTime.UtcNow;

            //TODO
            return null;
        }

        public List<Item> RecommendItems(Learner learner, List<Skill> requiredSkills = null, int howMany = 1)
        {
            //TODO
            return null;
        }

        public List<Item> GetCommonConfusions(Item item, int howMany = 3)
        {
            //TODO
            // ensure this item is never returned as confused with
            return null;
        }

        public List<Item> GetSimilarItems(Item item, int howMany = 3)
        {
            //TODO
            // sort items by number of overlapping skills, return highest
            // ensure this item is never returned as similar
            return null;
        }
    }
}