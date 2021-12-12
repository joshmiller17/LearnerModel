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
        public Skillset Prerequisites = new Skillset();
        public Skillset RelatedSkills = new Skillset();
        public readonly Guid guid;
        public string Name = "";

        public Skill(string name = "")
        {
            guid = Guid.NewGuid();
            Name = name;
        }

        public static bool operator ==(Skill a, Skill b)
        {
            return a.guid == b.guid;
        }

        public static bool operator !=(Skill a, Skill b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType())){
                return false;
            }
            else
            {
                Skill s = (Skill)obj;
                return this == s;
            }
        }

        public override int GetHashCode()
        {
            return guid.GetHashCode();
        }
    }

    [Serializable]
    public class SkillsetJson
    {
        public List<SkillJson> Skills;
    }

    [Serializable]
    public class SkillJson
    {
        public List<string> Prerequisites;
        public List<string> RelatedSkills;
        public string Name;
    }

    public class Skillset
    {
        List<Skill> skills = new List<Skill>();

        public static Skillset SkillsetFromJson(string jsonText)
        {
            Skillset skillset = new Skillset();
            SkillsetJson skillTree = JsonUtility.FromJson<SkillsetJson>(jsonText);

            // first pass to define the Skills
            foreach (SkillJson skill in skillTree.Skills)
            {
                Skill s = new Skill(skill.Name);
                skillset.AddSkill(s);
            }

            // second pass to set prerequisites and related skills
            // now that we have object references
            foreach (SkillJson skill in skillTree.Skills)
            {
                Skill s = skillset.GetSkillByName(skill.Name);
                foreach (string prereq in skill.Prerequisites)
                {
                    s.Prerequisites.AddSkill(skillset.GetSkillByName(prereq));
                }
                foreach (string related in skill.RelatedSkills)
                {
                    s.RelatedSkills.AddSkill(skillset.GetSkillByName(related));
                }
            }

            return skillset;
        }

        public List<Skill> GetSkills()
        {
            return skills;
        }

        public Skill GetSkillByName(string name)
        {
            foreach (Skill s in skills)
            {
                if (s.Name == name)
                {
                    return s;
                }
            }
            return null;
        }

        public bool HasSkill(string name)
        {
            return GetSkillByName(name) != null;
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

        public static Skillset operator +(Skillset a, Skillset b)
        {
            Skillset ab = a;
            foreach (Skill s in b.skills)
            {
                ab.AddSkill(s);
            }
            return ab;
        }

    }

}