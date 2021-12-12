using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JoshAaronMiller.LearnerModel;

public class SpanishPracticeItem : Item
{
    List<string> data;
   public SpanishPracticeItem(List<Skill> skills, List<string> rowData):
        base(skills)
    {
        data = rowData;
    }
}
