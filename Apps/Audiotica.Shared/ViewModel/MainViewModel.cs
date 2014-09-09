#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Audiotica.Data.Model;
using Audiotica.Data.Service.Interfaces;
using GalaSoft.MvvmLight;
using Microsoft.Xbox.Music.Platform.Contract.DataModel;

#endregion

namespace Audiotica.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IXboxMusicService _service;
        private List<XboxAlbum> _featuredReleases;
        private List<XboxAlbum> _newAlbums;
        private List<XboxItem> _spotlightItems;
        private bool _isFeaturedLoading;
        private bool _isSliderLoading;
        private bool _isNewLoading;

        /// <summary>
        ///     Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IXboxMusicService service)
        {
            _service = service;

            //Load data automatically
            LoadChartDataAsync();
        }

        public List<XboxAlbum> NewAlbums
        {
            get { return _newAlbums; }
            set { Set(ref _newAlbums, value); }
        }

        public List<XboxAlbum> FeatureAlbums
        {
            get { return _featuredReleases; }
            set { Set(ref _featuredReleases, value); }
        }

        public bool IsFeaturedLoading
        {
            get { return _isFeaturedLoading; }
            set { Set(ref _isFeaturedLoading, value); }
        }

        public bool IsSliderLoading
        {
            get { return _isSliderLoading; }
            set { Set(ref _isSliderLoading, value); }
        }

        public bool IsNewLoading
        {
            get { return _isNewLoading; }
            set { Set(ref _isNewLoading, value); }
        }

        public List<XboxItem> SpotlightItems
        {
            get { return _spotlightItems; }
            set { Set(ref _spotlightItems, value); }
        }

        public async Task LoadChartDataAsync()
        {
            try
            {
                IsSliderLoading = true;
                IsFeaturedLoading = true;
                IsNewLoading = true;

                SpotlightItems = await _service.GetSpotlight();
                IsSliderLoading = false;

                FeatureAlbums = (await _service.GetFeaturedAlbums()).Items;
                IsFeaturedLoading = false;

                NewAlbums = (await _service.GetNewAlbums()).Items;
                IsNewLoading = false;
            }
            catch (Exception e)
            {
<<<<<<< HEAD
                //Debugger.Break();         // Good for debugging, but not so much for release
                Windows.UI.Popups.MessageDialog msg = new Windows.UI.Popups.MessageDialog(e.Message, "An Error has occured");
                msg.ShowAsync();
=======
                new MessageDialog("not really... probably a network issue", "oops, some nasty SHIT happened.").ShowAsync();
>>>>>>> upstream/develop
            }
        }
    }
}