using Sukupuut;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Sukupuu sukupuu;
        public MainPage()
        {
            this.InitializeComponent();
            sukupuu = Sukupuu.getInstance();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Henkilö toni = new Henkilö("Toni", "Laitinen");
            Henkilö pertti = new Henkilö("Pertti", "Laitinen");

            Henkilö emil = new Henkilö("Emil", "Laitinen");
            emil.Syntymäaika = new DateTime(1894, 5, 18);

            Henkilö elvi = new Henkilö("Elvi", "Laitinen");
            elvi.Syntymäaika = new DateTime(1900, 1, 1);
            pertti.Äiti = elvi;

            Henkilö albin = new Henkilö("Albin", "Laitinen");
            albin.Syntymäaika = new DateTime(1871, 11, 21);

            Henkilö hilda = new Henkilö("Hilda", "Matilainen");
            hilda.Syntymäaika = new DateTime(1872,5,14);
            emil.Äiti = hilda;

            Henkilö herman = new Henkilö("Herman", "Laitinen");
            herman.Patronyymi = "Elias";
            herman.Syntymäaika = new DateTime(1849, 2, 18);

            Henkilö annakaisa = new Henkilö("Anna Kaisa", "Matilainen");
            annakaisa.Syntymäaika = new DateTime(1828,2,27);
            albin.Äiti = annakaisa;

            Henkilö elias = new Henkilö("Elias", "Eliasson");
            elias.Patronyymi = "Elias";
            elias.Syntymäaika = new DateTime(1812, 3, 20);

            Henkilö elias2  = new Henkilö("Elias", "Henricsson");
            elias2.Syntymäaika = new DateTime(1782, 5, 8);
            elias2.Patronyymi = "Henric";

            toni.Isä = pertti;
            pertti.Isä = emil;
            pertti.Äiti = elvi;
            emil.Isä = albin;
            emil.Äiti = hilda;
            albin.Isä = herman;
            albin.Äiti = annakaisa;
            herman.Isä = elias;
            elias.Isä = elias2;
            sukupuu.Add(toni);
            sukupuu.Add(pertti);
            sukupuu.Add(emil);
            sukupuu.Add(albin);
            sukupuu.Add(herman);
            sukupuu.Add(elias);
            sukupuu.Add(elias2);

        }

        int y = 100;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            y = 100;
            testRect.Text = "Testi";
            StringBuilder sb = new StringBuilder();
            List<Henkilö> kaikki = sukupuu.GetAll();
            Henkilö eka = kaikki.Find(x => x.Etunimi.Contains("Toni"));

            sb.Append(eka);

            do
            {
                sb.Append("\n<- ");
                sb.Append(eka.Isä);
                sb.Append(", ");
                sb.Append(eka.Äiti);

                TextCanvas tc = new TextCanvas(eka);
                                
                Canvas.SetTop(tc, y);
                mainCanvas.Children.Add(tc);

                y += tc.Height1 + 20;
                // äiti
                if (eka.Äiti != null)
                { 
                    Henkilö mama = eka.Äiti;
                    TextCanvas tcm = new TextCanvas(mama);
                    
                    Canvas.SetTop(tcm, y);
                    Canvas.SetLeft(tcm, 210);
                    mainCanvas.Children.Add(tcm);
                }

                //
                
                eka = eka.Isä;
            } while (eka.Isä != null);
            textBlock.Text = sb.ToString();
            textCanvas.Text = "Moi2";
        }

        

        private async void button1_Click_1(object sender, RoutedEventArgs e)
        {
            ContentDialog1 cd = new ContentDialog1();
            ContentDialogResult r = await cd.ShowAsync();
            Henkilö h = cd.GetDetails();
            if(r==ContentDialogResult.Primary)
            {

            }
            else if(r == ContentDialogResult.Secondary)
            {

            }
        }



        private async void  mainCanvas_PointerPressedAsync(object sender, PointerRoutedEventArgs e)
        {
            foreach (TextCanvas t in mainCanvas.Children)
            {
                                
                Rect r = new Rect(new Point(Canvas.GetLeft(t), Canvas.GetTop(t)), new Size(t.Width1,t.Height1));                

                if(r.Contains(e.GetCurrentPoint(mainCanvas).Position))
                {
                    var messageDialog = new MessageDialog("HIT " + t.Text);
                    // Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers

                    // Show the message dialog
                    //await messageDialog.ShowAsync();

                    ContentDialog1 cd = new ContentDialog1();
                    cd.PrimaryButtonText = "Lisää isänä";
                    cd.SecondaryButtonText = "Lisää äitinä";
                    Henkilö uusi = cd.GetDetails();
                    Henkilö origin = t.Content as Henkilö;
                    cd.Year = origin.Syntymäaika.Year - 20;

                    ContentDialogResult res = await cd.ShowAsync();
                    
                    int indeksi = sukupuu.GetAll().IndexOf(origin);

                    // dialogissa "Lisää isänä" ja "Lisää äitinä"
                    if (!sukupuu.GetAll().Contains(uusi))
                    {
                        if (res == ContentDialogResult.Primary)
                        {
                            sukupuu.Add(uusi);
                            sukupuu.GetAll()[indeksi].Isä = uusi;
                            this.button_Click(sender, e);
                        }
                        else if (res == ContentDialogResult.Secondary)
                        {
                            sukupuu.Add(uusi);
                            sukupuu.GetAll()[indeksi].Äiti = uusi;
                            this.button_Click(sender, e);
                        }
                    }
                }                
            }
        }
    }
}
