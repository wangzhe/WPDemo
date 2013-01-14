using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Media;

namespace MiniBrowser
{
    public partial class Page1 : PhoneApplicationPage
    {
        Image myImage;
        Image progressBarImage;
        SecondPresenter presenter;
        double basicOffsetX;
        int times;
        
        public Page1()
        {
            InitializeComponent();
            InitUI();
        }

        private void InitUI()
        {
            basicOffsetX = 20;
            times = 0;

            presenter = new SecondPresenter();
            myImage = presenter.createCirculeImage(MainAnimationGrid, basicOffsetX-2.75);
        }

        private void NextStageButton_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sb = null;
            Storyboard progressStoryboard = null;
            String resId = "unique_id";

            sb = createCirculeAnimation(myImage, sb, resId);
            EventHandler circuleAnimationHandler = null;
            EventHandler progressBarAnimationHandler = null;

            progressBarAnimationHandler = (s, evt) =>
            {
                basicOffsetX = basicOffsetX + 127.25;
                times += 1;
                myImage = presenter.createCirculeImage(MainAnimationGrid, basicOffsetX - 2.75);
                progressStoryboard.Completed -= progressBarAnimationHandler;
            };

            circuleAnimationHandler = (s, evt) =>
            {
                presenter.createCheckImage(MainAnimationGrid, basicOffsetX + 18.75);

                if (times < 3)
                {
                    progressBarImage = presenter.createProgressBarImage(MainAnimationGrid, basicOffsetX + 39.75);
                    resId = "progress_id";
                    progressStoryboard = createProgressBarAnimation(progressBarImage, progressStoryboard, resId);

                    progressStoryboard.Completed += progressBarAnimationHandler;
                    progressStoryboard.Begin();
                }
                sb.Completed -= circuleAnimationHandler;
            };

            sb.Completed += circuleAnimationHandler;


            // Begin the animation.
            sb.Begin();
            
        }

        private Storyboard createProgressBarAnimation(Image image, Storyboard sb, String resId)
        {
            Duration duration = new Duration(TimeSpan.FromSeconds(1));
            if (sb == null)
            {
                sb = new Storyboard();
                sb.Duration = duration;
            }

            DoubleAnimation imageWidthAnimation = new DoubleAnimation();
            imageWidthAnimation.Duration = duration;
            sb.Children.Add(imageWidthAnimation);
            Storyboard.SetTarget(imageWidthAnimation, progressBarImage);

            Storyboard.SetTargetProperty(imageWidthAnimation, new PropertyPath("Width"));

            imageWidthAnimation.To = 96.25;

            return sb;
        }

        private Storyboard createCirculeAnimation(Image myImage, Storyboard sb, String resId)
        {
            Duration duration = new Duration(TimeSpan.FromSeconds(0.5));
            if (sb == null)
            {
                sb = new Storyboard();
                sb.Duration = duration;
            }

            circuleMoveAnimation(myImage, duration, sb);
            circuleScaleAnimation(myImage, duration, sb);

            return sb;
        }

        private void circuleScaleAnimation(Image myImage, Duration duration, Storyboard sb)
        {
            DoubleAnimation imageScaleX = new DoubleAnimation();
            DoubleAnimation imageScaleY = new DoubleAnimation();

            imageScaleX.Duration = duration;
            imageScaleY.Duration = duration;


            sb.Children.Add(imageScaleX);
            sb.Children.Add(imageScaleY);

            Storyboard.SetTarget(imageScaleX, myImage);
            Storyboard.SetTarget(imageScaleY, myImage);

            Storyboard.SetTargetProperty(imageScaleX, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.ScaleX)"));
            Storyboard.SetTargetProperty(imageScaleY, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.ScaleY)"));

            imageScaleX.To = 0.7;
            imageScaleY.To = 0.7;
        }

        private void circuleMoveAnimation(Image myImage, Duration duration, Storyboard sb)
        {
            // Create two DoubleAnimations and set their properties.
            DoubleAnimation imageTransformX = new DoubleAnimation();
            imageTransformX.Duration = duration;

            sb.Children.Add(imageTransformX);
            Storyboard.SetTarget(imageTransformX, myImage);
            Storyboard.SetTargetProperty(imageTransformX, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.TranslateX)"));

            imageTransformX.To = 8.5;

            DoubleAnimation imageTransformY = new DoubleAnimation();
            imageTransformY.Duration = duration;

            sb.Children.Add(imageTransformY);
            Storyboard.SetTarget(imageTransformY, myImage);
            Storyboard.SetTargetProperty(imageTransformY, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.TranslateY)"));

            imageTransformY.To = 8.5;
        }
    }
}