using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

        Guid guid;

        public Learner()
        {
            guid = Guid.NewGuid();
        }

        public void AddSkillset(Skillset skillset)
        {
            foreach (Skill skill in skillset.GetSkills())
            {
                skillMasteries.Add(skill, 0);
            }
        }

        public void LogPractice(Item item, float outcome)
        {
            DateTime now = DateTime.UtcNow;
            itemHistories[item].TimestampsToOutcomes[now] = outcome;

            foreach (Skill skill in item.GetSkills())
            {
                skillHistories[skill].TimestampsToOutcomes[now] = outcome;
            }
        }
    }
}