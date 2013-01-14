using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MiniBrowser
{
    class SecondPresenter
    {
        internal Image createCirculeImage(System.Windows.Controls.Grid MainAnimationGrid, double offsetX)
        {
            Image myImage = new Image();
            myImage.Source = new BitmapImage(new Uri("/res/2.png", UriKind.RelativeOrAbsolute));
            myImage.Margin = new Thickness(offsetX, 0, 0, 0);
            myImage.Height = 50.0;
            myImage.Width = 50.0;
            myImage.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            myImage.VerticalAlignment = System.Windows.VerticalAlignment.Center;

            //For Animation
            myImage.RenderTransform = new CompositeTransform();

            MainAnimationGrid.Children.Add(myImage);

            return myImage;
        }

        internal void createCheckImage(System.Windows.Controls.Grid MainAnimationGrid, double offsetX)
        {
            Image checkImage = new Image();
            checkImage.Source = new BitmapImage(new Uri("/res/1.png", UriKind.RelativeOrAbsolute));
            checkImage.Margin = new Thickness(offsetX, 0, 0, 0);
            checkImage.Height = 13.5;
            checkImage.Width = 13.5;
            checkImage.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            checkImage.VerticalAlignment = System.Windows.VerticalAlignment.Center;

            MainAnimationGrid.Children.Add(checkImage);
        }

        internal Image createProgressBarImage(System.Windows.Controls.Grid MainAnimationGrid, double offsetX)
        {
            Image progressBarImage = new Image();
            progressBarImage.Source = new BitmapImage(new Uri("/res/4.png", UriKind.RelativeOrAbsolute));
            progressBarImage.Margin = new Thickness(offsetX, 0, 0, 0);
            progressBarImage.Height = 7.5;
            progressBarImage.Width = 3;
            progressBarImage.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            progressBarImage.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            progressBarImage.Stretch = Stretch.Fill;

            MainAnimationGrid.Children.Add(progressBarImage);

            return progressBarImage;
        }
    }
}
