﻿using System.Collections.ObjectModel;
using CosmosDBStudio.Messages;
using CosmosDBStudio.Model;
using CosmosDBStudio.Services;
using EssentialMVVM;

namespace CosmosDBStudio.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IMessenger _messenger;

        public MainWindowViewModel(IViewModelFactory viewModelFactory, IMessenger messenger)
        {
            _viewModelFactory = viewModelFactory;
            _messenger = messenger;
            QuerySheets = new ObservableCollection<QuerySheetViewModel>();
            Connections = _viewModelFactory.CreateConnectionsViewModel();

            _messenger.Subscribe(this).To<NewQuerySheetMessage>((vm, message) => vm.OnNewQuerySheetMessage(message));

            //AddDummyQuerySheet();
        }

        private void OnNewQuerySheetMessage(NewQuerySheetMessage message)
        {
            var querySheet = new QuerySheet
            {
                ConnectionId = message.ConnectionId,
                DatabaseId = message.DatabaseId,
                CollectionId = message.CollectionId,
                DefaultOptions = new QueryOptions
                {
                    PartitionKey = null
                }
            };

            var vm = _viewModelFactory.CreateQuerySheetViewModel(querySheet);
            QuerySheets.Add(vm);
            CurrentQuerySheet = vm;
        }

        public ConnectionsViewModel Connections { get; }

        public ObservableCollection<QuerySheetViewModel> QuerySheets { get; }

        private QuerySheetViewModel _currentQuerySheet;

        public QuerySheetViewModel CurrentQuerySheet
        {
            get => _currentQuerySheet;
            set => Set(ref _currentQuerySheet, value);
        }
    }
}
