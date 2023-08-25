using Boff.KeywordTools.AppServices;
using CommonServiceLocator;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using System.ComponentModel;
using System.Windows;

namespace Boff.KeywordTools.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            //ServiceLocator.SetLocatorProvider(() =>Ioc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}
            //SimpleIoc.Default.Register<IChangeNameService, ChangeNameService>();
            //SimpleIoc.Default.Register<MainTabViewModel>();
        }


        private DependencyObject dummy = new DependencyObject();

        private bool IsInDesignMode()
        {
            return DesignerProperties.GetIsInDesignMode(dummy);
        }

        public ExtractKeywordPageViewModel ExtractKeywordPageViewModel
        {
            get
            {
                var vm = Ioc.Default.GetRequiredService<ExtractKeywordPageViewModel>();
                return vm;
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}