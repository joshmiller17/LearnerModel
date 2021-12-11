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
        List<Skill> postrequisites = new List<Skill>();
        List<Skill> relatedSkills = new List<Skill>();
        Guid guid;

        public Skill()
        {
            guid = Guid.NewGuid();
        }
    }
}