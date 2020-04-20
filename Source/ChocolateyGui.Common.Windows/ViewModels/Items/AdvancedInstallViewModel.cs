// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Chocolatey" file="AdvancedInstallViewModel.cs">
//   Copyright 2017 - Present Chocolatey Software, LLC
//   Copyright 2014 - 2017 Rob Reynolds, the maintainers of Chocolatey, and RealDimensions Software, LLC
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using ChocolateyGui.Common.Base;
using ChocolateyGui.Common.Windows.Commands;
using NuGet;

namespace ChocolateyGui.Common.Windows.ViewModels.Items
{
    public class AdvancedInstallViewModel : ObservableBase
    {
        private TaskCompletionSource<AdvancedInstallViewModel> tcs;
        private SemanticVersion _selectedVersion;
        private List<SemanticVersion> _availableVersions;
        private string _packageParamaters;
        private string _installArguments;

        public AdvancedInstallViewModel(List<SemanticVersion> availableVersions)
        {
            tcs = new TaskCompletionSource<AdvancedInstallViewModel>();

            this.AvailableVersions = availableVersions;
            this.InstallCommand = new SimpleCommand(o => true, o => tcs.SetResult(this));
            this.CancelCommand = new SimpleCommand(o => true, o => tcs.SetResult(null));
        }

        public SemanticVersion SelectedVersion
        {
            get { return _selectedVersion; }
            set { SetPropertyValue(ref _selectedVersion, value); }
        }

        public List<SemanticVersion> AvailableVersions
        {
            get { return _availableVersions; }
            set { SetPropertyValue(ref _availableVersions, value); }
        }

        public string PackageParameters
        {
            get { return _packageParamaters; }
            set { SetPropertyValue(ref _packageParamaters, value); }
        }

        public string InstallArguments
        {
            get { return _installArguments; }
            set { SetPropertyValue(ref _installArguments, value); }
        }

        public ICommand InstallCommand { get; }

        public ICommand CancelCommand { get; }

        public Task<AdvancedInstallViewModel> WaitForClosingAsync()
        {
            return tcs.Task;
        }
    }
}