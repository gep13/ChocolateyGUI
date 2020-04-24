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
        private int _executionTimeoutInSeconds;
        private string _logFile;
        private bool _preRelease;
        private bool _forcex86;
        private bool _overrideArguments;
        private bool _notSilent;
        private bool _applyInstallArgumentsToDependencies;
        private bool _applyPackageParametersToDependencies;
        private bool _allowDowngrade;
        private bool _allowMultipleVersions;
        private bool _ignoreDependencies;
        private bool _forceDependencies;
        private bool _skipPowerShell;
        private bool _ignoreChecksums;
        private bool _allowEmptyChecksums;
        private bool _allowEmptyChecksumsSecure;
        private bool _requireChecksums;
        private string _downloadChecksum;
        private string _downloadChecksum64bit;
        private string _downloadChecksumType;
        private string _downloadChecksumType64bit;

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

        public int ExecutionTimeoutInSeconds
        {
            get { return _executionTimeoutInSeconds; }
            set { SetPropertyValue(ref _executionTimeoutInSeconds, value); }
        }

        public string LogFile
        {
            get { return _logFile; }
            set { SetPropertyValue(ref _logFile, value); }
        }

        public bool PreRelease
        {
            get { return _preRelease; }
            set { SetPropertyValue(ref _preRelease, value); }
        }

        public bool Forcex86
        {
            get { return _forcex86; }
            set { SetPropertyValue(ref _forcex86, value); }
        }

        public bool OverrideArguments
        {
            get { return _overrideArguments; }
            set { SetPropertyValue(ref _overrideArguments, value); }
        }

        public bool NotSilent
        {
            get { return _notSilent; }
            set { SetPropertyValue(ref _notSilent, value); }
        }

        public bool ApplyInstallArgumentsToDependencies
        {
            get { return _applyInstallArgumentsToDependencies; }
            set { SetPropertyValue(ref _applyInstallArgumentsToDependencies, value); }
        }

        public bool ApplyPackageParametersToDependencies
        {
            get { return _applyPackageParametersToDependencies; }
            set { SetPropertyValue(ref _applyPackageParametersToDependencies, value); }
        }

        public bool AllowDowngrade
        {
            get { return _allowDowngrade; }
            set { SetPropertyValue(ref _allowDowngrade, value); }
        }

        public bool AllowMultipleVersions
        {
            get { return _allowMultipleVersions; }
            set { SetPropertyValue(ref _allowMultipleVersions, value); }
        }

        public bool IgnoreDependencies
        {
            get { return _ignoreDependencies; }
            set { SetPropertyValue(ref _ignoreDependencies, value); }
        }

        public bool ForceDependencies
        {
            get { return _forceDependencies; }
            set { SetPropertyValue(ref _forceDependencies, value); }
        }

        public bool SkipPowerShell
        {
            get { return _skipPowerShell; }
            set { SetPropertyValue(ref _skipPowerShell, value); }
        }

        public bool IgnoreChecksums
        {
            get { return _ignoreChecksums; }
            set { SetPropertyValue(ref _ignoreChecksums, value); }
        }

        public bool AllowEmptyChecksums
        {
            get { return _allowEmptyChecksums; }
            set { SetPropertyValue(ref _allowEmptyChecksums, value); }
        }

        public bool AllowEmptyChecksumsSecure
        {
            get { return _allowEmptyChecksumsSecure; }
            set { SetPropertyValue(ref _allowEmptyChecksumsSecure, value); }
        }

        public bool RequireChecksums
        {
            get { return _requireChecksums; }
            set { SetPropertyValue(ref _requireChecksums, value); }
        }

        public string DownloadChecksum
        {
            get { return _downloadChecksum; }
            set { SetPropertyValue(ref _downloadChecksum, value); }
        }

        public string DownloadChecksum64bit
        {
            get { return _downloadChecksum64bit; }
            set { SetPropertyValue(ref _downloadChecksum64bit, value); }
        }

        public string DownloadChecksumType
        {
            get { return _downloadChecksumType; }
            set { SetPropertyValue(ref _downloadChecksumType, value); }
        }

        public string DownloadChecksumType64bit
        {
            get { return _downloadChecksumType64bit; }
            set { SetPropertyValue(ref _downloadChecksumType64bit, value); }
        }

        public ICommand InstallCommand { get; }

        public ICommand CancelCommand { get; }

        public Task<AdvancedInstallViewModel> WaitForClosingAsync()
        {
            return tcs.Task;
        }
    }
}