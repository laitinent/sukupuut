using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace App1
{
    class TextCanvas:Canvas
    {
        string text;
        int width=200;
        int height=100;
        Object content=null;

        TextBlock textBlock = new TextBlock();
        Rectangle rectangle = new Rectangle();

       

        public TextCanvas()
        {
            
            rectangle.Width = width;
            rectangle.Height = height;
            Color color = Colors.AliceBlue;
            rectangle.Fill = new SolidColorBrush(color);
            rectangle.Stroke = new SolidColorBrush(Colors.Black);
            rectangle.StrokeThickness = 2;

            Children.Add(rectangle);
            textBlock.Width = width-2;
            textBlock.Height = height-2;
            Canvas.SetLeft(textBlock, 1);
            Canvas.SetTop(textBlock, 1);
            Children.Add(textBlock);
            
        }

        public TextCanvas(String _text) : this()
        {
            Text = _text;
            
        }

        public TextCanvas(Object  o) : this()
        {
            Text = o.ToString();
            Content = o;
        }

        public string Text
        {
            get { return text; }
            set { text = value;
                textBlock.Text = text;
                
            }
        }

        public int Width1 { get => width;  }
        public int Height1 { get => height;  }
        public object Content { get => content; set => content = value; }
    }
}
