using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionSetup : MonoBehaviour
{
    [SerializeField] private Text q;
    [SerializeField] private Text a0;
    [SerializeField] private Text a1;
    [SerializeField] private Text a2;
    [SerializeField] private Text a3;

    private int correctAnswer = 0;

    public int CorrectAnswer { get => correctAnswer; }

    public void SetQuestion(int category)
    {

        switch (category)
        {
            case 0:
                q.text = "Peru ist ein wahres Paradies für Wanderer und Bergsteiger, zu den berühmtesten Bergketten zählen die Cordillera Blanca und die Cordillera Huayhuash.\nWie heißt der mit 6.768 Metern höchste Berg Perus?";
                a2.text = "Huascarán";
                a1.text = "Vinicunca";
                a0.text = "Machu Picchu";
                a3.text = "Misti";
                correctAnswer = 2;
                break;
            case 1:
                q.text = "Peru besticht durch seine landschaftliche und klimatische Vielfalt.\nWelche drei geographischen Zonen findet man in Peru ? ";
                a0.text = "Anden, Pazifikküste, Amazonasregenwald";
                a1.text = "Pazifikküste, Nebelwald, Titicacasee";
                a2.text = "Berge, Vulkane, Amazonasregenwald";
                a3.text = "Wüste, Anden, Titicacasee";
                correctAnswer = 0;
                break;
            case 2:
                //fix this later
                q.text = "Peru besticht durch seine landschaftliche und klimatische Vielfalt.\nWelche drei geographischen Zonen findet man in Peru ? ";
                a0.text = "Anden, Pazifikküste, Amazonasregenwald";
                a1.text = "Pazifikküste, Nebelwald, Titicacasee";
                a2.text = "Berge, Vulkane, Amazonasregenwald";
                a3.text = "Wüste, Anden, Titicacasee";
                correctAnswer = 0;
                break;
            case 3:
                q.text = "Die peruanische Küche ist weit über die Landesgrenzen bekannt.\nWie heißt eines der beliebtesten peruanischen Gerichte, das auch hierzulande gerade voll im Trend ist?";
                a3.text = "Ceviche";
                a1.text = "Causa";
                a2.text = "Anticucho";
                a0.text = "Lomo saltado";
                correctAnswer = 3;
                break;
            case 4:
                q.text = "Lima an der Pazifikküste ist der wirtschaftliche Dreh- und Angelpunkt des Landes.\nWie wird die Hauptstadt von Peru noch genannt?";
                a1.text = "Stadt der Könige";
                a0.text = "Stadt des ewigen Frühlings";
                a2.text = "Stadt in den Wolken";
                a3.text = "Die weiße Stadt";
                correctAnswer = 1;
                break;
            case 5:
                q.text = "Peru gilt als das Land der Inka, doch schon lange vor den Inka lebten vor allem im Norden des Landes zahlreiche hochentwickelte Kulturen.\nWelche Prä-Inka Kultur, die auch „Nebelmenschen“ genannt wird, erbaute die Festung Kuélap in Nordperu ? ";
                a2.text = "Chachapoyas";
                a1.text = "Chimú";
                a0.text = "Moche";
                a3.text = "Chavin";
                correctAnswer = 2;
                break;
            default:
                break;
        }
    }
}
