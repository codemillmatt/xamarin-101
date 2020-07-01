# Xamarin.Forms UI with XAML

The most popular way of building a user interface for Xamarin.Forms is with XAML. Or Extensible Application Markup Language. It's kinda like HTML, but it does more.

[Check out the episode](https://channel9.msdn.com/Series/Xamarin-101/XamarinForms-UI-with-XAML-5-of-11?WT.mc_id=xamarin101-github-masoucou), then hop on back for some more details.

## Building up the UI

This episode on building a Xamarin.Forms UI with XAML deals with some very common XAML controls to build a note taking app.

We touched on:

- Layouts - especially the grid. (grid, row, and columns - how to size - how to specify where they go)
- Images background color, pop onto the grid, how to add them
- Editor
- Button
- Label

One of the things you should take away here is that controls have properties, and you can easily set those properties through the XAML. And by doing so you can see how everything is going to build up and look by looking at the code.

Of course it's nice to see how things are really going to look, and that's where Hot Reload comes in. Hot Reload allows you to make changes to XAML, hit save, and then see those changes instantly reflected in the application as it's running on the iOS simulator or Android emulator.

## Some Take Aways

The `Grid` is a very useful control - actually it's a `Layout`. It's used to layout where other controls go on the screen. You can specify how large each row is by using the `RowDefinitions` collection and how wide each column is with the `ColumnDefinitions` collection.

Then you can place each control by using `Grid.Row=XXX` and `Grid.Column=YYY` within that control's XAML. Where `XXX` and `YYY` is the 0-based row or column number. And you can even have control's span multiple rows or columns by using `Grid.RowSpan=ZZZ` or `Grid.ColumnSpan=AAA`.

Finally, where do those images need to reside? They'll need to go into each platform's project. [Check out this documentation for more info on that](https://docs.microsoft.com/xamarin/xamarin-forms/user-interface/images?WT.mc_id=xamarin101-github-masoucou).

## What you didn't see

The finished solution in this repo has a bit more in it than you saw in the video.

- You can give names to controls. So that you can...
- Specify event handlers and access the control's properties in the code-behind file.

What's a code-behind file? Every time you create a XAML page, a XAML.cs file gets created as well. It's in this file that you can create event handlers for the controls defined in the XAML, or handle certain events for the page's lifecycle. (Or a lot more.)

So in this solution, I added a name to the `Editor` control with the following XAML property: `x:Name="noteEditor"`. I also put a name on the `Label` control of `textLabel`.

Then in both buttons for the save and delete I added 2 different event handlers. Buttons have a `Clicked` event. So within those I added a `SaveButton_Clicked` and a `DeleteButton_Clicked`.

Then in the code-behind file, I implemented those.

```c-sharp
protected void SaveButton_Clicked(object sender, EventArgs e)
{
    var noteText = noteEditor.Text;

    noteEditor.Text = string.Empty;

    textLabel.Text = noteText;
}

protected void DeleteButton_Clicked(object sender, EventArgs e)
{
    noteEditor.Text = string.Empty;
    textLabel.Text = string.Empty;
}
```

So we have some simple logic going on. On save, we're taking whatever text is in the editor and popping that into the `Text` property of the `Label`. On the delete event, we're clearing both the `Label`'s and `Editor`'s `Text` property out.

In the next module you'll learn how to not write business logic using MVVM.
