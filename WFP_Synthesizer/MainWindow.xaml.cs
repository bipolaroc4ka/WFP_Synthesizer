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
using System.Media;
using System.IO;
namespace WFP_Synthesizer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            labelMode.Content = "Active mode: " + mode.ToString();
            
        }
        private const int SAMPLE_RATE = 44100;
        private const short BITS_PER_SAMPLE = 16;
        SoundPlayer player = new SoundPlayer();
        bool flag = true;
        Mode mode = Mode.WhiteNoize;
        enum Mode
        {
            Sin,
            Square,
            Sawtooth,
            Triangle,
            WhiteNoize,

        }
        float frequancy = 0;
        
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            
            short tempSample;
            short[] wave = new short[SAMPLE_RATE];

            byte[] bynaryWave = new byte[SAMPLE_RATE * sizeof(short)];
           
            if(e.Key == Key.A || e.Key==Key.S || e.Key == Key.D || e.Key == Key.F ||
                e.Key == Key.G || e.Key == Key.H || e.Key == Key.J || e.Key == Key.K || 
                e.Key == Key.L) { 
            if (e.Key == Key.A)
                frequancy = 140f;
            if (e.Key == Key.S)
                frequancy = 240f;
            if(e.Key == Key.D)
                frequancy = 340f;
            if (e.Key == Key.F)
                frequancy = 440f;
            if (e.Key == Key.G)
                frequancy = 540f;
            if (e.Key == Key.H)
                frequancy = 640f;
            if (e.Key == Key.J)
                frequancy = 740f;
            if (e.Key == Key.K)
                frequancy = 840f;
            if (e.Key == Key.L)
                frequancy = 940f;
                int samplePerWaveLength = (int)(SAMPLE_RATE / frequancy);
                short ampStep = (short)((short.MaxValue * 2) / samplePerWaveLength);
                switch (mode)
                {
                    case Mode.Sin:
                        for (int i = 0; i < SAMPLE_RATE; i++)
                        {
                            wave[i] = Convert.ToInt16(short.MaxValue * Math.Sin(((Math.PI * 2 * frequancy) / SAMPLE_RATE) * i));

                        }
                        break;
                    case Mode.Square:
                        for (int i = 0; i < SAMPLE_RATE; i++)
                        {
                            wave[i] = Convert.ToInt16(short.MaxValue * Math.Sign(Math.Sin((Math.PI*2*frequancy)/SAMPLE_RATE*i)));
                        }
                        break;
                    case Mode.Sawtooth:
                        for (int i = 0; i < SAMPLE_RATE; i++)
                        {
                            tempSample = -short.MaxValue;
                            for (int j = 0; j < samplePerWaveLength && i < SAMPLE_RATE; j++)
                            {
                                tempSample += ampStep;
                                wave[i++] = Convert.ToInt16(tempSample);

                            }
                            i--;
                        }
                        
                        break;
                    case Mode.Triangle:
                        tempSample = -short.MaxValue;
                        for (int i = 0; i < SAMPLE_RATE; i++)
                        {
                            if (Math.Abs(tempSample + ampStep) > short.MaxValue)
                            {
                                ampStep = (short)-ampStep;

                            }
                            tempSample += ampStep;
                            wave[i] = Convert.ToInt16(tempSample);
                        }

                        break;
                    case Mode.WhiteNoize:
                        Random random = new Random();
                        for (int i = 0; i < SAMPLE_RATE; i++)
                        {
                            wave[i] = (short)random.Next(-short.MaxValue, short.MaxValue);
                        }

                        break;
                    default:
                        break;
                }
            
                Buffer.BlockCopy(wave, 0, bynaryWave, 0, wave.Length * sizeof(short));
                using (MemoryStream memoryStream = new MemoryStream())
                using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
                {
                    short blockAlign = BITS_PER_SAMPLE / 8;
                    int subChunkTwoSize = SAMPLE_RATE * blockAlign;

                    binaryWriter.Write(new[] { 'R', 'I', 'F', 'F' });
                    binaryWriter.Write(36 * subChunkTwoSize);
                    binaryWriter.Write(new[] { 'W', 'A', 'V', 'E', 'f', 'm', 't', ' ' });
                    binaryWriter.Write(16);
                    binaryWriter.Write((short)1);
                    binaryWriter.Write((short)1);
                    binaryWriter.Write(SAMPLE_RATE);
                    binaryWriter.Write(SAMPLE_RATE * blockAlign);
                    binaryWriter.Write(blockAlign);
                    binaryWriter.Write(BITS_PER_SAMPLE);
                    binaryWriter.Write(new[] { 'd', 'a', 't', 'a' });
                    binaryWriter.Write(subChunkTwoSize);
                    binaryWriter.Write(bynaryWave);
                    memoryStream.Position = 0;

                    if (flag == true)
                    {
                        player.Stream = memoryStream;

                        player.PlayLooping();
                        flag = false;
                    }


                    //new SoundPlayer(memoryStream).PlayLooping();            


                }
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            flag = true;
            player.Stop();
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (mode != Mode.Sin)
            {
                mode = Mode.Sin;
                labelMode.Content = "Active mode: " + mode.ToString();
            }
                   
            
        }

        private void buttonSquare_Click(object sender, RoutedEventArgs e)
        {
            if (mode != Mode.Square)
            {
                mode = Mode.Square;
                labelMode.Content =  "Active mode: " + mode.ToString();
            }               

        }

        private void buttonSaw_Click(object sender, RoutedEventArgs e)
        {
            if (mode != Mode.Sawtooth)
            {
                mode = Mode.Sawtooth;
                labelMode.Content = "Active mode: " + mode.ToString();
            }
        }

        private void buttonTriangle_Click(object sender, RoutedEventArgs e)
        {
            if (mode != Mode.Triangle)
            {
                mode = Mode.Triangle;
                labelMode.Content = "Active mode: " + mode.ToString();
            }
        }

        private void buttonWhiteNoize_Click(object sender, RoutedEventArgs e)
        {
            if (mode != Mode.WhiteNoize)
            {

                mode = Mode.WhiteNoize;
                labelMode.Content = "Active mode: " + mode.ToString();
            }
        }

    }
}
