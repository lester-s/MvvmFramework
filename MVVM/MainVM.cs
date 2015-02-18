using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModelBase;
using System.Collections;
using System.Collections.ObjectModel;

namespace MVVM
{
    public class MainVM: ViewModelBase.ViewModelBase
    {
        private string text = "hello";

        public string Text
        {
            get { return text; }
            set 
            { 
                text = value;
                this.NotifyOfPropertyChanged(() => Text);
            }
        }

        private ObservableCollection<string> nameList;

        public ObservableCollection<string> NameList
        {
            get { return nameList; }
            set { nameList = value; }
        }
        

        private ICommand changeTextCommand;

        public ICommand ChangeTextCommand
        {
            get
            {
                return changeTextCommand;
            }
        }

        private Command<object> saveName;

        public Command<object> SaveName
        {
            get { return saveName; }
        }
        

        public MainVM()
        {
            changeTextCommand = new Command(ChangeText) { IsEnabled = true };
            saveName = new Command<object>(SaveNameCommand) { IsEnabled = true };
            NameList = new ObservableCollection<string>();
            NameList.CollectionChanged += NameList_CollectionChanged;
        }

        void NameList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var t = 0;
        }

        private void SaveNameCommand(object obj)
        {
            this.NotifyOfPropertyChanged(() => this.NameList);
        }

        private void ChangeText()
        {
            Text = "You clicked the button";
            NameList.Add("newItem" + NameList.Count);
        }
        
    }
}
