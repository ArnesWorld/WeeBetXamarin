using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.UI;
using MvvmCross.Plugins.Messenger;
using System;
using System.Collections.Generic;
using System.Text;
using WeeBet.Core.Contracts.ViewModels;
using WeeBet.Core.Messages;

namespace WeeBet.Core.Models
{
    public class OddsItemViewModel : MvxViewModel, IOddsItemViewModel
    {
        public Odds Odds { get; set; }
        public IMvxMessenger Messenger { get; set; }
        private MvxColor UnSelected = new MvxColor(175, 174, 168);
        private MvxColor Selected = new MvxColor(58, 165, 65);

        private bool isButtonsVisible;
        public bool IsButtonsVisible
        {
            get { return isButtonsVisible; }
            set
            {
                isButtonsVisible = value;
                RaisePropertyChanged(() => IsButtonsVisible);
            }
        }

        private MvxColor _backgroundColor1;
        public MvxColor BackgroundColor1
        {
            get { return _backgroundColor1; }
            set
            {
                _backgroundColor1 = value;
                RaisePropertyChanged(() => BackgroundColor1);
            }
        }
        private MvxColor _backgroundColorX;
        public MvxColor BackgroundColorX
        {
            get { return _backgroundColorX; }
            set
            {
                _backgroundColorX = value;
                RaisePropertyChanged(() => BackgroundColorX);
            }
        }
        private MvxColor _backgroundColor2;
        public MvxColor BackgroundColor2
        {
            get { return _backgroundColor2; }
            set
            {
                _backgroundColor2 = value;
                RaisePropertyChanged(() => BackgroundColor2);
            }
        }
        public IMvxCommand<string> BtnClickedCommand { get; set; }

        public OddsItemViewModel(Odds odds, IMvxMessenger messenger)
        {
            IsButtonsVisible = false;
            SetAllBtnsToUnSelected();
            Messenger = messenger; 
            this.Odds = odds;
            BtnClickedCommand = new MvxCommand<string>(ButtonClicked);         
        }

        private void ButtonClicked(string outcomeType)
        {
            //Handle button color change
            switch (outcomeType)
            {
                case "1":
                    BackgroundColor1 = BackgroundColor1.Equals(Selected) ? UnSelected : Selected ;BackgroundColorX = UnSelected; BackgroundColor2 = UnSelected;
                    break;
                case "x":
                    BackgroundColorX = BackgroundColorX.Equals(Selected) ? UnSelected : Selected; BackgroundColor1 = UnSelected; BackgroundColor2 = UnSelected;
                    break;
                case "2":
                    BackgroundColor2 = BackgroundColor2.Equals(Selected) ? UnSelected : Selected; BackgroundColor1 = UnSelected; BackgroundColorX = UnSelected;
                    break;
            }
            //Send message to ShowMatchesViewModel holding data
            Messenger.Publish(new OutcomeSelectedMessage(this, outcomeType));


        }

        private void SetAllBtnsToUnSelected()
        {
            BackgroundColor1 = UnSelected;
            BackgroundColorX = UnSelected;
            BackgroundColor2 = UnSelected;
        }


    }
}
