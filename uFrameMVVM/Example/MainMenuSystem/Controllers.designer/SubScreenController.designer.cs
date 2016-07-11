// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace Example {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    
    public class SubScreenControllerBase : uFrame.MVVM.Controller {
        
        private uFrame.MVVM.ViewModels.IViewModelManager _SubScreenViewModelManager;
        
        private MainMenuRootViewModel _MainMenuRoot;
        
        [uFrame.IOC.InjectAttribute("SubScreen")]
        public uFrame.MVVM.ViewModels.IViewModelManager SubScreenViewModelManager {
            get {
                return _SubScreenViewModelManager;
            }
            set {
                _SubScreenViewModelManager = value;
            }
        }
        
        [uFrame.IOC.InjectAttribute("MainMenuRoot")]
        public MainMenuRootViewModel MainMenuRoot {
            get {
                return _MainMenuRoot;
            }
            set {
                _MainMenuRoot = value;
            }
        }
        
        public IEnumerable<SubScreenViewModel> SubScreenViewModels {
            get {
                return SubScreenViewModelManager.OfType<SubScreenViewModel>();
            }
        }
        
        public override void Setup() {
            base.Setup();
            // This is called when the controller is created
        }
        
        public override void Initialize(uFrame.MVVM.ViewModels.ViewModel viewModel) {
            base.Initialize(viewModel);
            // This is called when a viewmodel is created
            this.InitializeSubScreen(((SubScreenViewModel)(viewModel)));
        }
        
        public virtual SubScreenViewModel CreateSubScreen() {
            return ((SubScreenViewModel)(this.Create(Guid.NewGuid().ToString())));
        }
        
        public override uFrame.MVVM.ViewModels.ViewModel CreateEmpty() {
            return new SubScreenViewModel(this.EventAggregator);
        }
        
        public virtual void InitializeSubScreen(SubScreenViewModel viewModel) {
            // This is called when a SubScreenViewModel is created
            viewModel.Close.Action = this.CloseHandler;
            SubScreenViewModelManager.Add(viewModel);
        }
        
        public override void DisposingViewModel(uFrame.MVVM.ViewModels.ViewModel viewModel) {
            base.DisposingViewModel(viewModel);
            SubScreenViewModelManager.Remove(viewModel);
        }
        
        public virtual void Close(SubScreenViewModel viewModel) {
        }
        
        public virtual void CloseHandler(CloseCommand command) {
            this.Close(command.Sender as SubScreenViewModel);
        }
    }
}
