# MaterialXAMLDialogs
![Build](https://github.com/Proless/MaterialXAMLDialogs/workflows/Build/badge.svg)
[![NuGet](https://img.shields.io/nuget/v/MaterialXAMLDialogs?label=NuGet&style=flat-square)](https://www.nuget.org/packages/MaterialXAMLDialogs/)

A small helper Library to use with MaterialDesignInXamlToolkit, it allows displaying some common dialogs and returning a result.

## Usage

For each dialog type there are a specific class, which you can instansiate and configure depending on the dialog type.

Example:

```c#
var config = new AlertDialogConfiguration
{
  Title = "Confirm",
  SupportingText = "This is a Alert dialog which requires User intervention to proceed",
  DialogButtons = DialogButtons.YesNo,
  IconKind = PackIconKind.Alert,
  ShowAdditionalOption = true,
  AdditionalOptionText = "Don't show this again",
  IsAdditionalOptionCheched = false
};
var dialog = new AlertDialog(config);
var result = await dialog.Show("Root");
Result = $"{result}, {dialog.AdditionalOptionChecked}";
```

### Dialog Types

#### Alert Dialog
![Alert](https://i.imgur.com/gNSVyhs.png)

Buttons can be :
- OK,
- YesNo
- OKCancel
- RetryCancel
- YesNoCancel
- AbortRetryIgnore

Icon is of type PackIcon so you can use any icon kind from [MaterialDesigninXamlToolkit](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit).
It is also possible to set the foreground brush of the Icon. 

#### Selection Dialog
![Selection](https://i.imgur.com/zQ3g2Tj.png)

#### Progress Dialog
![Determinate](https://i.imgur.com/r4zjWqI.png)

![InDeterminate](https://i.imgur.com/JFR0HP7.png)

#### Circular Indeterminate Progress Dialog

![Circular InDeterminate Progress](https://i.imgur.com/4q2EUwo.png)

## Plans

- Add localization support for different languages
- Add support for custom Dialog with up to three buttons
