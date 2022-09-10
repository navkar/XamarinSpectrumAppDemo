# App specifications

**NOTE:** I have tested this App on iOS only, NOT on Android. No code is available for Android.

Covers the following features

## Collection Sort (Ascending and Descending)

| Ascending  | Descending |
| ------------- | ------------- |
| ![Asc](/screenshots/sort-asc.png)  | ![D](/screenshots/sort-desc.png)  |

## Navigation (Main Page to Detail Page)

| Home Page  | Detail Page |
| ------------- | ------------- |
| ![Asc](/screenshots/a.png)  | ![D](/screenshots/b.png)  |

## Rest of the features

* Filtering and Searching
* Button Gradient - The button has a gradient with start and end color.
* Converter - The app uses `IntToBoolConverter` to disable the button when there is no data.
* Effects - Label Shadow
* Behavior - The app uses the following behavior `NumericValidationBehavior`. When an invalid data is entered onto the Textbox the color changes to Red.

| Description | Screenshot  
| ------------- | ------------- 
| Filtering and Searching | ![F](/screenshots/filter.png)  
| Button Gradient | ![Button](/screenshots/home.png)   
| `IntToBoolConverter` to disable the button when there is no data | ![Converter](/screenshots/converter.png)   
| `LabelShadowEffect` to display a label with a shadow on the footer | ![Button](/screenshots/footer.png)  
| When an invalid data is entered onto the Textbox the color changes to Red.  | ![Behavior](/screenshots/behavior.png)

## Code snippets

* The app uses the following behavior `NumericValidationBehavior`. When an invalid data is entered onto the Textbox the color changes to Red.

```xml
    <Entry x:Name="universeEntry"
            Text="{Binding AgeOfUniverse}"
            FontSize="Large"
            Placeholder="numeric!">
        <Entry.Behaviors>
            <effect:NumericValidationBehavior />
        </Entry.Behaviors>
    </Entry>
```




