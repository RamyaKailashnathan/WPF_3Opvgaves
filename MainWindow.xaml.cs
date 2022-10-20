//Jeg har hentet inspiration fra quiz wpf eksempel på youtube

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace Quiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6 };

        //  qNum - vil kontrollere, hvilket spørgsmål der vises på skærmen
        int qNum = 0;
        int i, score;
        public MainWindow()
        {
            InitializeComponent();
            NextQuestion();
        }
        private void checkAnswer(object sender, RoutedEventArgs e)
        {
            // dette er checkAnswer event, denne hændelse er knyttet til hver knap på lærredet
            // når der trykkes på en af knapperne, kører vi denne event

            Button senderButton = sender as Button; // tjek først hvilken Button der sendte denne event og link den til en lokal button inde i denne event

            // i if-loop nedenfor vil vi kontrollere, om den knap, der klikkes på, har et 1-tag (tjek tag-værdi i XAML-filen) inde i det, hvis det gør, vil vi tilføje 1 til scoren
            if (senderButton.Tag.ToString() == "1")
            {
                score++;
            }
            //qNum - vil kontrollere, hvilket spørgsmål der vises på skærmen
            // hvis qnum er mindre end 0, nulstilles qnum heltal til 0
            if (qNum < 0)
            {
                qNum = 0;
            }
            else
            {
                // hvis qnum er større end 0, vil vi increment qnum
                qNum++;
            }

            // opdatere score text label , hver gang der trykkes på buttons
            scoreText.Content = "Rigtigt Svar :" + score + "/" + questionNumbers.Count;
            if (qNum >= 6)
            {
                MessageBox.Show("Quiz Over", "Quiz Over");
                this.Close();
            }
            // kør den  NextQuestion function
            NextQuestion();

        }
        private void RestartGame()
        {
            // genstart spil-funktionen vil indlæse alle standardværdierne for dette spil
            score = 0; // set score to 0
            qNum = -1; // set qnum to -1
            i = 0; // set i to 0
          
        }

        private void NextQuestion()
        {
            // denne funktion vil kontrollere, hvilket spørgsmål der skal vises næste gang, og det vil have alle spørgsmål og svar 

            // i if-sætningen nedenfor vil den kontrollere, om qnum value er mindre end det samlede antal spørgsmål, hvis det, så vil vi sætte værdien af i til value af qnum

            if (qNum < questionNumbers.Count) //questionNumber er the list på line number:25
            {
                i = questionNumbers[qNum];
            }
            else
            {
                //hvis vi har alle de spørgsmål, vi har på list(questionNumbers), så genstarter vi quiz
                RestartGame();
            }

            // nedenfor kører vi en foreach loop, hvor vi tjekker for hver knap inde i lærredet, og når vi finder dem, sætter vi deres tag til 0 og baggrunden til din yndlingsfarve
            foreach (var x in myCanvas.Children.OfType<Button>())
            {
                x.Tag = "0";
                x.Background = Brushes.DeepSkyBlue;
            }


            switch (i)
            {
                case 1:

                    txtQuestion.Text = "Danmarks hovedstad ?"; //  quiz spørgsmål
                    ans1.Content = "America"; // hver af knapperne kan have deres egne svar i dette spil
                    ans2.Content = "Copenhagen";
                    ans3.Content = "Hawai";
                    ans4.Content = "Singapore";
                    ans2.Tag = "1"; // her fortæller vi programmet, hvilket af svarene ovenfor, der er det rigtige svar, ved at tilføje 1'eren inde i tag for button.
                                    // i dette eksempel tilføjer vi 1 inde i ans2 eller Button 2
                                    // så når der trykkes på knappen vil spillet vide, hvad der er det rigtige svar, og det tilføjer 1 til scoren for spillet
                    break; 

                case 2:

                    txtQuestion.Text = "Hvem malede Monalisa?";
                    ans1.Content = "Picasso";
                    ans2.Content = "Steve Jobs";
                    ans3.Content = "My Neighbour";
                    ans4.Content = "Tom Cruise";
                    ans1.Tag = "1";
                    break;

                case 3:

                    txtQuestion.Text = "Hvor lang er New Zealands Ninety Mile Beach";
                    ans1.Content = "2 cms";
                    ans2.Content = "500 feet";
                    ans3.Content = "90 miles";
                    ans4.Content = "10 inches";
                    ans3.Tag = "1";
                    break;

                case 4:

                    txtQuestion.Text = "Hvor mange måneder har 28 dage?";
                    ans1.Content = "6";
                    ans2.Content = "2";
                    ans3.Content = "3";
                    ans4.Content = "1";
                    ans4.Tag = "1";
                    break;

                case 5:

                    txtQuestion.Text = "Hvad omtaler danskerne ’rugbrød?";
                    ans1.Content = "Rugbrød";
                    ans2.Content = "Cake";
                    ans3.Content = "Chips";
                    ans4.Content = "Fruit";
                    ans1.Tag = "1";
                    break;

                case 6:

                    txtQuestion.Text = "I hvilken måned fejres den tyske festival Oktoberfest?";
                    ans1.Content = "Alle 12 måneder";
                    ans2.Content = "July";
                    ans3.Content = "October";
                    ans4.Content = "Næste måned";
                    ans3.Tag = "1";
                    break;
             
            }
        }
       
    }
}
