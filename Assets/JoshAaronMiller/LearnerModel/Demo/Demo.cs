using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JoshAaronMiller.LearnerModel;

public class Demo : MonoBehaviour
{
    public TextAsset DataCsv;
    public TextAsset FormSkills;
    public TextAsset MoodSkills;
    public TextAsset TenseSkills;

    public GameObject QuestionObj;
    public GameObject OptionPanelObj;

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

    /* Question types:
     * 1. Given InfinitiveEnglish, choose correct Infinitive
     * 2. Given Infinitive, choose correct InfinitiveEnglish
     * 3. Given InfinitiveEnglish, MoodEnglish, and TenseEnglish, number and person, choose correct form
     *   3a. Options are only correct mood and tense
     *   3b. Options are only correct mood
     *   3c. Options are only correct tense
     *   3d. Options can be any mood or tense
     * 4. Given correct form, choose English translation (based on VerbEnglish with I swapped for correct number and person) -- TODO account for special cases in Indicative
     *   4a. Options are only correct mood and tense
     *   4b. Options are only correct mood
     *   4c. Options are only correct tense
     *   4d. Options can be any mood or tense
     */
    enum QuestionType
    {
        EnToEsInfinitive,
        EsToEnInfinitive,
        EntoEsFormEasy,
        EnToEsFormTensePractice,
        EnToEsFormMoodPractice,
        EnToEsFormHard,
        EsToEnFormEasy,
        EsToEnFormTensePractice,
        EsToEnFormMoodPractice,
        EsToEnFormHard
    };

    static readonly int numOptions = 4;

    List<List<string>> verbs = new List<List<string>>();
    int countQuestionTypes;

    Text question;
    List<Text> options;
    int correctOption;

    Learner learner;
    Skillset spanish;
    List<SpanishPracticeItem> allItems = new List<SpanishPracticeItem>();

    void Start()
    {
        verbs = ReadCsv(DataCsv);
        verbs.RemoveAt(0); //delete header

        countQuestionTypes = System.Enum.GetValues( typeof(QuestionType)).Length;

        question = QuestionObj.GetComponent<Text>();
        for (int child = 0; child < numOptions; child++)
        {
            Transform button = OptionPanelObj.transform.GetChild(child);
            Text option = button.GetChild(0).gameObject.GetComponent<Text>();
            options.Add(option);
        }

        //TODO try loading, only define these if no load available
        learner = new Learner();
        spanish = new Skillset();
        DefineSkills();
        DefineItems();
    }

    void DefineSkills()
    {
        // add every word as a skill
        foreach (List<string> row in verbs)
        {
            string infinitive = row[(int)Column.Infinitive];
            if (!spanish.HasSkill(infinitive))
            {
                Skill word = new Skill();
                word.Name = infinitive;
                spanish.AddSkill(word);
            }
        }

        // add tenses, moods, and forms as skills
        Skillset tenses = Skillset.SkillsetFromJson(TenseSkills.text);
        Skillset moods = Skillset.SkillsetFromJson(MoodSkills.text);
        Skillset forms = Skillset.SkillsetFromJson(FormSkills.text);
        spanish += tenses + moods + forms;
    }

    void DefineItems()
    {
        Dictionary<int, string> formRows = new Dictionary<int, string> {
            {(int)Column.FirstSingularForm, "FirstSingular" },
            {(int)Column.SecondSingularForm, "SecondSingular" },
            {(int)Column.ThirdSingularForm, "ThirdSingular" },
            {(int)Column.FirstPluralForm, "FirstPlural" },
            {(int)Column.SecondPluralForm, "SecondPlural" },
            {(int)Column.ThirdPluralForm, "ThirdPlural" }
        };

        // every form of every row is an item
        foreach (List<string> row in verbs)
        {
            foreach (KeyValuePair<int, string> form in formRows)
            {
                Skill formSkill = spanish.GetSkillByName(form.Value);
                Skill tenseSkill = spanish.GetSkillByName(row[(int)Column.TenseEnglish]);
                Skill moodSkill = spanish.GetSkillByName(row[(int)Column.MoodEnglish]);
                Skill wordSkill = spanish.GetSkillByName(row[(int)Column.Infinitive]);
                List<Skill> allSkills = new List<Skill>() { formSkill, tenseSkill, moodSkill, wordSkill };

                SpanishPracticeItem item = new SpanishPracticeItem(allSkills, row);
                allItems.Add(item);
            }
        }
    }

    /// <summary>
    /// Given a TextAsset representing a CSV, return it as a 2D list of strings.
    /// </summary>
    /// <param name="file">The CSV file.</param>
    /// <returns>The CSV as a 2D list of strings.</returns>
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

    /// <summary>
    /// Log the user's selection, show the right answer, and construct a new question.
    /// </summary>
    /// <param name="optionSelected">The index of their selected option.</param>
    public void AnswerCallback(int optionSelected)
    {
        //TODO log the answer with the learner model

        // TODO visual feedback for right or wrong with correct answer

        //TODO construct new question

        // TODO save data
    }

    /// <summary>
    /// Choose a question type, then set the visuals and backend logic for the question.
    /// </summary>
    void ConstructQuestion()
    {
        //TODO pick a question type using learner model

        //TODO generate options using learner model

        //TODO call DisplayQuestion

        //TODO set correctOption
    }

    /// <summary>
    /// Show the question.
    /// </summary>
    /// <param name="q">Question text.</param>
    /// <param name="os">Option texts.</param>
    void DisplayQuestion(string q, List<string> o)
    {
        question.text = q;
        for (int opt = 0; opt < numOptions; opt++)
        {
            options[opt].text = o[opt];
        }
    }
}
