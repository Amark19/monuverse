using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class all_quizzes_dict : MonoBehaviour
{
    // {question,op1,op2,op3,op4,right_ans}
    
    public static string[,] tajMahalQuiz = new string[4, 6] {
         {"Q1) In how many years Taj Mahal was built?","a)1632 to 1653","b)1630  to 1653","c)1631  to 1652","d)1631  to 1653","a)1632 to 1653"},
         {"Q2) What is the colour of  taj mahal during full moon night?","a)pink","b)blue","c)black","d)orange","b)blue"},
         {"Q3) Taj mahal is a Representation of Paradise:","a)Hindu","b)Muslim","c)Paradise","d)Christian","b)Muslim"},
         {"Q4) The Taj Mahal demonstrates the links between ?:","a)India-Pakistan","b)India - Bangladesh","c)India-Europe","d)Europe - Russia","c)India-Europe"},
    };
    public static string[,] charminar = new string[4, 6] {
         {"Q1) From how many year a mosque on charminar floor is present ?","a)420","b)432","c)445","d)425","d)425"},
         {"Q2) Charminar is situated on which bank river ?","a)Krishna river","b)mahanadi river","c)Musi river","d)kaveri","c)Musi river"},
         {"Q3) Underground tunnel built connect to which fort ?","a)Golconda","b)Gingee","c)Ajengo","d)Badami","a)Golconda"},
         {"Q4) What is length of each side of charminar ?","a)21 meters","b)22 meters","c)20 meters","d)24 meters","c)20 meters"},
    };
     
}
