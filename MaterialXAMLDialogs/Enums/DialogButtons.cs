using MaterialXAMLDialogs.Buttons;
using System;
using System.Windows.Controls;

namespace MaterialXAMLDialogs.Enums
{
    public enum DialogButtons
    {
        OK,
        YesNo,
        OKCancel,
        RetryCancel,
        YesNoCancel,
        AbortRetryIgnore
    }

    internal static class DialogButtonsEx
    {
        internal static UserControl GetButtons(this DialogButtons dialogButtons)
        {
            switch (dialogButtons)
            {
                case DialogButtons.OK:
                    return new OKButtons();
                case DialogButtons.YesNo:
                    return new YesNoButtons();
                case DialogButtons.OKCancel:
                    return new OKCancelButtons();
                case DialogButtons.RetryCancel:
                    return new RetryCancelButtons();
                case DialogButtons.YesNoCancel:
                    return new YesNoCancelButtons();
                case DialogButtons.AbortRetryIgnore:
                    return new AbortRetryIgnoreButtons();
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
