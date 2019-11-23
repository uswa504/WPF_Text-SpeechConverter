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
using System.Speech.Synthesis;
using System.Speech.Recognition;

namespace Text_Speech_Converter
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_speak_Click(object sender, RoutedEventArgs e)
        {
            if (textview.Text != "")
            {
                SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
                string text = textview.Text;
                textview.Text="";
                speechSynthesizer.Speak(text);
            }
            else
            {
                SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
                recognizer.SetInputToDefaultAudioDevice();
                recognizer.LoadGrammar(new DictationGrammar());
                recognizer.RecognizeAsync(RecognizeMode.Multiple);
                recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_recognized);
            }
           
        }
        public void recognizer_recognized(object sender, SpeechRecognizedEventArgs e){
            textview.Text = e.Result.Text;
        }
    }
}
