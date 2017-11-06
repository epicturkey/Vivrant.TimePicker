# Vivrant.TimePicker
A Native HTML5 TimePicker control for CSHTML5 (http://cshtml5.com/)

This uses the input[type=time] (-webkit-timepicker), as defined by Moz MDN Web Docs: https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input/time

# Milestones:
**11-06-2017: Initial Release**
Tested against CSHTML5 BETA 12.4

# Limitations:
- Input-Mask (and EDGE popup) DO NOT work in Simulator! (Simulator does not appear to support webkit timepicker)
- Works in **Microsoft Edge**, **Google Chrome**, **Opera**, **Chrome on Android** and **Firefox BETA** *
- Does not work in Firefox Public Release or IE11 (Firefox* and IE have not yet implemented the -webkit-calendarpicker appearance on input[type=date])
* Firefox is working to implement input[type=date], but it is currently only supported in the current Firefox BETA, available here: https://www.mozilla.org/en-US/firefox/quantum/. You must download the latest Nightly BETA from Mozilla. 

# Usage:

 - Add a reference to *Vivrant.TimePicker.dll*
 
 - Create a new XAML window or Control
 
 - Add a XAML Namespace for the control: 
 
    `xmlns:control="clr-namespace:Vivrant.Controls;assembly=Vivrant.TimePicker`
    
 - (OPTIONAL) Use the included TimePresenter class for out-of-the-box MVVM support: 
 
    `xmlns:presenter="clr-namespace:Vivrant.Presenter;assembly=Vivrant.TimePicker"`
    
 - Add the the following to your window or Control (this can replace any existing Canvas or Grid objects)
 
`<control:TimePicker
    Margin="16"
    VerticalAlignment="Top"
    HorizontalAlignment="Center"
    Time="{Binding Path=Time, Mode=TwoWay}">
    <control:TimePicker.DataContext><!-- OPTIONAL -->
        <presenter:TimePresenter />
    </control:TimePicker.DataContext>
</control:TimePicker>`
