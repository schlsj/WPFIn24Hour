using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using MediaViewer.Model;

namespace MediaViewer.UserControls
{
    /// <summary>
    /// Interaction logic for MediaPlayer.xaml
    /// </summary>
    public partial class MediaPlayer 
    {
        public static readonly DependencyProperty MediaProperty=DependencyProperty.Register("Media",typeof(Media),typeof(MediaPlayer));

        public Media Media
        {
            get { return GetValue(MediaProperty) as Media;}
            set { SetValue(MediaProperty, value); }
        }

        private bool _userMovingSlider;

        public MediaPlayer()
        {
            InitializeComponent();
        }

        private void MediaElement_OnMediaOpened(object sender, RoutedEventArgs e)
        {
            ProgressSlide.Maximum = MediaElement.NaturalDuration.TimeSpan.TotalMilliseconds;
        }

        private void Play_Clicked(object sender, RoutedEventArgs e)
        {
            MediaClock clock = MediaElement.Clock;
            if (clock != null)
            {
                if (clock.IsPaused)
                {
                    clock.Controller.Resume();
                }
                else
                {
                    clock.Controller.Pause();
                }
            }
            else
            {
                if (Media == null)
                {
                    return;
                }
                MediaTimeline timeline = new MediaTimeline(Media.Uri);
                clock = timeline.CreateClock();
                clock.CurrentTimeInvalidated += Clock_CurrentTimeInvalidated;
                MediaElement.Clock = clock;
            }
        }

        private void Stop_Clicked(object sender, RoutedEventArgs e)
        {
            MediaElement.Clock = null;
        }

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            MediaElement.Clock = null;
        }

        private void Clock_CurrentTimeInvalidated(object sender, EventArgs e)
        {
            if (MediaElement.Clock == null || _userMovingSlider)
            {
                return;
            }
            ProgressSlide.Value = MediaElement.Clock.CurrentTime.Value.TotalMilliseconds;
        }

        private void ProgressSlider_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _userMovingSlider = true;
        }

        private void ProgressSlider_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MediaClock clock = MediaElement.Clock;
            if (clock != null)
            {
                TimeSpan offset = TimeSpan.FromMilliseconds(ProgressSlide.Value);
                clock.Controller.Seek(offset,TimeSeekOrigin.BeginTime);
            }
            _userMovingSlider = false;
        }
    }
}
