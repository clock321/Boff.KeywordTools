using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Boff.KeywordTools.AppServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boff.KeywordTools.ViewModel
{
    public partial class ExtractKeywordPageViewModel : ObservableObject
    {
        [ObservableProperty]
        public string _FilePath;

        [ObservableProperty]
        public string _Suffix;

        [ObservableProperty]
        private ObservableCollection<NameValue> _KeywordList;

        [ObservableProperty]
        public string _KeywordInput;

        [ObservableProperty]
        public string _KeywordOutput;

        [ObservableProperty]
        private string result;

        [ObservableProperty]
        private bool showResult;


        public IKeywordService _KeywordService;

        public string _filenname;

        public ExtractKeywordPageViewModel(IKeywordService KeywordService)
        {
            _KeywordService = KeywordService;
        }

        public bool CanExtractKeyword()
        {
            return true;
            if (string.IsNullOrEmpty(FilePath))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        [RelayCommand(CanExecute = nameof(CanExtractKeyword))]
        public void ExtractKeyword()
        {
            this.ShowResult = false;
            string result;
            this.KeywordOutput = _KeywordService.ExtractKeyword(this.FilePath,this.Suffix,this.KeywordInput, out result);
            this.Result = result;
            this.ShowResult = true;
        }

    }
}
