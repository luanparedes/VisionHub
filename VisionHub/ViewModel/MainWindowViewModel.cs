using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage;

namespace VisionHub.ViewModel
{
    public class MainWindowViewModel
    {
        #region Fields & Properties

        private MediaPlayerElement _mediaPlayerElement;
        private MediaPlayer _mediaPlayer;

        #endregion

        #region Constructor

        public MainWindowViewModel()
        {
            //Initialize();
        }

        #endregion

        #region Methods

        private void Initialize()
        {
            _mediaPlayer = new MediaPlayer();
            _mediaPlayerElement.SetMediaPlayer(_mediaPlayer);
            _mediaPlayerElement.IsFullWindow = true;

            _mediaPlayer.Source = MediaSource.CreateFromUri(new Uri("C:\\Users\\luans\\Videos\\Bandicam\\LostSkyTemple_Testing.mp4"));
            
        }

        public void OpenMediaByExternalCommand(StorageFile file)
        {
            if (file != null)
            {
                _mediaPlayer.Source = MediaSource.CreateFromStorageFile(file);
                _mediaPlayer.Play();
            }
        }

        #endregion

        #region Events

        public void MediaPlayerElement_Loaded(object sender, RoutedEventArgs e)
        {
            _mediaPlayerElement = sender as MediaPlayerElement;
            Initialize();
        }

        #endregion
    }
}
