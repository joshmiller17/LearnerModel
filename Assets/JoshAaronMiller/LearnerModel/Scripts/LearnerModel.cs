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

        public Skill RecommendSkill(Learner learner)
        {
            //TODO
            return null;
        }

        public Item RecommendItem(Learner learner, List<Skill> requiredSkills = null)
        {
            //TODO
            return null;
        }

        public List<Item> GetCommonConfusions(Item item, int howMany = 3)
        {
            //TODO
            return null;
        }

        public List<Item> GetSimilarItems(Item item, int howMany = 3)
        {
            //TODO
            // sort items by number of overlapping skills, return highest
            return null;
        }
    }
}