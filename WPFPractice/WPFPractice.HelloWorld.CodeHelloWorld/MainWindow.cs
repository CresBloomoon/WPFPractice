using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFPractice.HelloWorld.CodeHelloWorld
{
    public class MainWindow : Window
    {
        private Button helloWorldButton;

        private void InitializeComponent()
        {
            this.Title = "MainWindow";
            this.Height = 350;
            this.Width = 525;

            this.helloWorldButton = new Button
            {
                Content = "Hello World",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(10, 10, 0, 0),
                Width = 100,
            };
            this.helloWorldButton.Click += helloWorldButton_Click;

            var grid = new Grid();
            grid.Children.Add(this.helloWorldButton);

            this.Content = grid;
        }

        private void helloWorldButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello world");
        }

        public MainWindow()
        {
            this.InitializeComponent();
        }
    }
}
