# App specifications

Covers the following features

## Collection Sort (Ascending and Descending)

| Ascending  | Descending |
| ------------- | ------------- |
| ![Asc](/screenshots/sort-asc.png)  | ![D](/screenshots/sort-desc.png)  |

#### Filtering and Searching

Notice the filtering by Letter 'A'

![F](/screenshots/filter.png {width=200px height=250px}) 

## Renderer

The button has a gradient with start and end color.

*  `GradientButtonRenderer`

![Button](/screenshots/home.png = 250x250)

## Converter

The app uses `IntToBoolConverter` to disable the button when there is no data.

![Converter](/screenshots/converter.png)

## Effect 

The app uses `LabelShadowEffect` to display a label with a shadow on the footer.

![LabelShadowEffect](/screenshots/footer.png)

## Behavior

The app uses the following behavior `NumericValidationBehavior`. When an invalid data is entered onto the Textbox the color changes to Red.

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

![LabelShadowEffect](/screenshots/behavior.png)


