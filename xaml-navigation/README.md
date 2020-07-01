# Xamarin.Forms Navigation with XAML

Navigation in Xamarin.Forms - and any mobile app really - is composed of 2 things:

1. Pushing a new page onto the navigation stack.
1. Popping that page off the stack to reveal the previous one.

The push and pop could be broken down further to include modal push and pop - modals do not have a back button in the toolbar. But the concept overall is the same.

## Code Setup

The code for this episode changed a tiny bit from the last episode.

A new page called `DetailPage.xaml`. It's already built for you, but it has a single `Label` on it that's bound to a `NoteText` property on its view model. It also has a `Button` whose `Command` is set to `ExitCommand`.

Of course there's that view model then. The `NoteText` is already there. You'll learn about the `ExitCommand` in the video.

Then in the `MainPage.xaml` there were some changes to the `CollectionView`. Namely a new bound property. With this, a property in the view model gets set every time a cell in the `CollectionView` is selected. And there's a `Command` that fires whenever a selection on the `CollectionView` is made.

So now you can [checkout the video](https://channel9.msdn.com/Series/Xamarin-101/XamarinForms-Navigation-with-XAML-7-of-11?WT.mc_id=xamarin101-github-masoucou) for more info.

### One More Thing!

You'll also notice one more thing within the `DetailPage` ... and that's an additional way to setup the `BindingContext` of a XAML page to its view model.

The code is located in the code-behind. Instead of doing everything in the XAML - it's done with `BindingContext` in C#. In the case of `DetailPage` the view model is passed into the constructor, but there are many times when you'd create the view model in the page itself, and this is a perfectly valid way of setting it up instead of using `<ContentPage.BindingContext>` in XAML.

## Take Aways

So the big takeaway here is the concept of pushing and popping.

The other one - and one that should not be forgotten - is that to do any sort of navigation within Xamarin.Forms, make sure you wrap your main page (no matter what you call it) inside a `NavigationPage`.

It's that `NavigationPage` which provides the `Navigation` property for all the navigation goodness.

I hope you enjoyed and learned a lot from this series. If you have any questions - feel free to reach out to me on Twitter, my DMs are open at [@codemillmatt](https://twitter.com/codemillmatt).
