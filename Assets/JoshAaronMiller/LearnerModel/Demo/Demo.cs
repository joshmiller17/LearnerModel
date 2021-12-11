using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    public TextAsset DataCsv;

    enum Column
    {
        Infinitive = 0,
        InfinitiveEnglish,
        Mood,
        MoodEnglish,
        Tense,
        TenseEnglish,
        VerbEnglish,
        FirstSingularForm,
        SecondSingularForm,
        ThirdSingularForm,
        FirstPluralForm,
        SecondPluralForm,
        ThirdPluralForm,
        Gerund,
        GerundEnglish,
        PastParticiple,
        PastParticipleEnglish
    };

    static readonly int rowsPerVerb = 18;

    List<List<string>> verbs = new List<List<string>>();

    void Start()
    {
        verbs = ReadCsv(DataCsv);
        verbs.RemoveAt(0); //delete header
    }

    List<List<string>> ReadCsv(TextAsset file)
    {
        List<string> rows = new List<string>(DataCsv.text.Split(new char[] { '\r', '\n' }));
        List<List<string>> ret = new List<List<string>>();
        foreach (string row in rows)
        {
            List<string> cells = new List<string>(row.Split(','));
            ret.Add(cells);
        }
        return ret;
    }

}
