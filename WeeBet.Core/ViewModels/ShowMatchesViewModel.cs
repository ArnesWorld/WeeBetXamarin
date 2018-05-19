using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using WeeBet.Core.Contracts.Services;
using WeeBet.Core.Messages;
using WeeBet.Core.Models;
using WeeBet.Core.Services.General;

namespace WeeBet.Core.ViewModels
{
    public class ShowMatchesViewModel : MvxViewModel
    {
        private readonly IMatchDataService _matchDataService;
        private readonly ICombinationCalculatorService _comboCalcService;

        private List<Match> matchList;
        private Dictionary<Match, string> matchOutcomes;

        public String CompName { get; set; }

        public IMvxMessenger Messenger;
        private readonly MvxSubscriptionToken _token;

        private bool isComboResVisible;

        public bool IsComboResVisible
        {
            get { return isComboResVisible; }
            set { isComboResVisible = value;
                RaisePropertyChanged(() => IsComboResVisible);
            }
        }


        private VendorValue vendorValue;
        public VendorValue VendorValue
        {
            get { return vendorValue; }
            set
            {
                vendorValue = value;
                RaisePropertyChanged(() => VendorValue);
            }
        }


        private MvxObservableCollection<MatchHeader> _matches;
        public MvxObservableCollection<MatchHeader> Matches
        {
            get { return _matches; }
            set
            {
                SetProperty(ref _matches, value);
            }
        }

  

        public ShowMatchesViewModel(IMatchDataService matchDataService,  IMvxMessenger messenger)
        {
            _comboCalcService = new CombinationCalculator();
            matchOutcomes = new Dictionary<Match, string>();
            _matchDataService = matchDataService;
            _token = messenger.Subscribe<OutcomeSelectedMessage>(UpdateVendorValue);
            Messenger = messenger;
        }

        private void UpdateVendorValue(OutcomeSelectedMessage message)
        {
            OddsItemViewModel ow = (OddsItemViewModel)message.Sender;
            Match match = GetMatch(ow.Odds.MatchId);
      
            if (!matchOutcomes.ContainsKey(match))
            {
                matchOutcomes.Add(match ,message.OutcomeType);
            }
            else if(!matchOutcomes[match].Equals(message.OutcomeType))
            {
                matchOutcomes[match] = message.OutcomeType;
            }
            else
            {
                matchOutcomes.Remove(match);
            }
            VendorValue = _comboCalcService.CalculateCombination(matchOutcomes);    
            if(VendorValue.Value != 0)
            {
                IsComboResVisible = true;
            }
            else
            {
                IsComboResVisible = false;
            }
        }


        public void Init(string compName, int compId)
        {
            IsComboResVisible = false;
            CompName = compName;
            Matches = new MvxObservableCollection<MatchHeader>();

            //GetMatchesFromDataServiceAsync(compId);
            matchList = _matchDataService.GetMatchesByCompetitionId(compId);
            foreach (var m in matchList)
            {
                MatchHeader currMatchHeader = new MatchHeader(m);
                foreach (Odds o in m.Odds)
                {
                    OddsItemViewModel ow = new OddsItemViewModel(o, Messenger);

                    currMatchHeader.Add(ow);
                }
                Matches.Add(currMatchHeader);

            }

        }


        public async void GetMatchesFromDataServiceAsync(int compId)
        {
           matchList = await _matchDataService.GetMatchesByCompetitionIdAsync(compId);
            foreach (var m in matchList)
            {
                MatchHeader currMatchHeader = new MatchHeader(m);
                foreach (Odds o in m.Odds)
                {
                    OddsItemViewModel ow = new OddsItemViewModel(o, Messenger);

                    currMatchHeader.Add(ow);
                }
                Matches.Add(currMatchHeader);

            }
        }

        private Match GetMatch(int matchId)
        {
            Match res = matchList.FirstOrDefault(m => m.Id == matchId);

            return res;
        }



    }
}
