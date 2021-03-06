﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;
using MaterialXAMLDialogs.Framework;

namespace MaterialXAMLDialogs.Examples.ViewModels
{
	public class ProgressDialogViewModel : ViewModelBase
	{
		// Fields
		private PaletteHelper _paletteHelper;

		// Properties
		public string Title { get; set; }
		public string SupportingText { get; set; }
		public bool ShowTitleSeparator { get; set; }
		public bool ShowIcon { get; set; }
		public bool IsIndeterminate { get; set; }
		public bool Cancellable { get; set; }
		public Color IconColor { get; set; }
		public IEnumerable<PackIconKind> Icons { get; set; }
		public PackIconKind SelectedIcon { get; set; }
		public RelayCommand ShowDialogCommand { get; set; }
		public RelayCommand ShowIndeterminateDialogCommand { get; set; }

		// Constructors
		public ProgressDialogViewModel()
		{
			_paletteHelper = new PaletteHelper();
			Title = "Some descriptive title!";
			SupportingText = "Here you can put some text about the current process in progress.";
			ShowTitleSeparator = true;
			ShowIcon = true;
			IsIndeterminate = false;
			Cancellable = true;
			IconColor = _paletteHelper.GetTheme().SecondaryMid.Color;
			Icons = Enum.GetValues(typeof(PackIconKind)).Cast<PackIconKind>();
			ShowDialogCommand = new RelayCommand(x => true, ShowDialog);
			ShowIndeterminateDialogCommand = new RelayCommand(x => true, ShowIndeterminateDialog);
			SelectedIcon = PackIconKind.Information;
		}

		// Methods
		private async void ShowDialog()
		{
			var config = new ProgressDialogConfiguration
			{
				Cancellable = Cancellable,
				IconBrush = new SolidColorBrush(IconColor),
				IconKind = ShowIcon ? SelectedIcon : (PackIconKind?)null,
				IsIndeterminate = IsIndeterminate,
				ShowTitleSeparator = ShowTitleSeparator,
				SupportingText = SupportingText,
				Title = Title,
				MaxWidth = 360,
				MinWidth = 360
			};

			var dialog = new ProgressDialog(config);
			CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

			// Simulate some work with progress.
			Progress<int> progress = new Progress<int>(x =>
			{
				dialog.ShowProgress(x, $"{x}%");
				if (x == 100)
				{
					dialog.UpdateDialog(false, true);
					dialog.UpdateText("Finishing up...");
				}
			});

			var dialogTask = dialog.Show("Root", cancellationTokenSource);

			try
			{
				await SomeIntensiveWork(progress, cancellationTokenSource.Token);
			}
			catch (OperationCanceledException)
			{
				// free up resources / log or something 
			}
			finally
			{
				dialog.Close();
			}

			await dialogTask;
		}
		private async void ShowIndeterminateDialog()
		{
			var dialog = new IndeterminateDialog();

			var dialogTask = dialog.Show("Root", Title, SupportingText, ShowTitleSeparator);

			await Task.Delay(6000);

			dialog.Close();

			await dialogTask;
		}
		private async Task SomeIntensiveWork(IProgress<int> progress, CancellationToken cancellationToken)
		{
			for (int i = 0; i <= 100; i++)
			{
				cancellationToken.ThrowIfCancellationRequested();
				await Task.Delay(25);
				progress.Report(i);
			}
			// Simulate some indeterminate progress
			await Task.Delay(5000);
		}
	}
}
