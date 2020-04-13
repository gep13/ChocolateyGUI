// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Chocolatey" file="AdvancedChocolateyDialog.xaml.cs">
//   Copyright 2017 - Present Chocolatey Software, LLC
//   Copyright 2014 - 2017 Rob Reynolds, the maintainers of Chocolatey, and RealDimensions Software, LLC
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls.Dialogs;

namespace ChocolateyGui.Common.Windows.Controls.Dialogs
{
    /// <summary>
    /// Interaction logic for AdvancedChocolateyDialog.xaml
    /// </summary>
    public partial class AdvancedChocolateyDialog : CustomDialog
    {
        private TaskCompletionSource<bool> tcs;

        public AdvancedChocolateyDialog()
            : base()
        {
            tcs = new TaskCompletionSource<bool>();
            InitializeComponent();
        }

        private void PART_AffirmativeButton_OnClick(object sender, RoutedEventArgs e)
        {
            tcs.SetResult(true);
        }

        private void PART_NegativeButton_OnClick(object sender, RoutedEventArgs e)
        {
            tcs.SetResult(false);
        }

        public Task<bool> WaitForClosingAsync()
        {
            return tcs.Task;
        }
    }
}