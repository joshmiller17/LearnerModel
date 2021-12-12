using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JoshAaronMiller.LearnerModel
{
    /// <summary>
    /// A History object contains the timestamps and outcomes of Learners practicing on Items.
    /// </summary>
    [Serializable]
    public class History
    {
        public Dictionary<DateTime, float> TimestampsToOutcomes = new Dictionary<DateTime, float>();
    }
}