using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace JoshAaronMiller.LearnerModel
{
    /// <summary>
    /// A Skill is a conceptual unit of knowledge.
    /// </summary>
    public class Skill
    {
        List<Skill> prerequisites = new List<Skill>();
        List<Skill> relatedSkills = new List<Skill>();
        public readonly Guid guid;

        public Skill()
        {
            guid = Guid.NewGuid();
        }

        public static bool operator ==(Skill a, Skill b)
        {
            return a.guid == b.guid;
        }

        public static bool operator !=(Skill a, Skill b)
        {
            return !(a == b);
        }
    }

    public class Skillset
    {
        List<Skill> skills = new List<Skill>();

        public List<Skill> GetSkills()
        {
            return skills;
        }

        public void AddSkill(Skill s)
        {
            skills.Add(s);
        }

        public void UpdateSkill(Skill s)
        {
            for (int i = 0; i < skills.Count; i++)
            {
                if (skills[i] == s)
                {
                    skills[i] = s;
                }
            }
        }

        public void RemoveSkill(Skill s)
        {
            skills.Remove(s);
        }

    }
}