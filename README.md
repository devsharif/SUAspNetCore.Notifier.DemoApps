# SUAspNetCore.Notifier.DemoApps
This Sample demo project is for easy implementation of ASP.NET Core Toast Notifications. Usually we use toast notification for Client-side using Jquery. But now can use this feature in Server-side also!
This is Fully Compatilble with ASP.NET Core 3.1 and .NET 5 Web Application.


## 1. Installation

By Nuget Package Manager>Package manager Console
```
Install-Package SUAspNetCore.Notifier
```
Or

By dotnet CLI
```
dotnet add package SUAspNetCore.Notifier
```
Or 

By using Visual Studio Nuget Package Manager and Search for

```
SUAspNetCore.Notifier
```


## 2. Include Dependency Injection
After Instalation, open your project **Startup.cs** file and add the following line to the **ConfigureServices** method.

```csharp
services.AddNotifier(config => 
{ 
    config.DurationInSeconds = 10; 
    config.IsDismissable = true; 
    config.Position = NotifierPosition.BottomRight; 
});
```



| Key               |Type| Value         
| -------------     |:------:|-------------|
| DurationInSeconds | Numeric| Example 10, 20, 100 etc for defined in second |
| IsDismissable     | Boolean| true for close option, false for none       |
| Position          | Object | Notification Posion (TopRight, BottomRight, BottomLeft, TopLeft, TopCenter, BottomCenter)|

## 3. Add the Middleware
Add the following line to the Configure method.

```csharp
app.UseNotifier();
```


Next, open **_Layout.cshml** file and add the following code at the end of body tag. Make sure that you add this line after loading jquery.
Usually you will place this code below all scripts and above the  **@await RenderSectionAsync("Scripts", required: false)** line.

```
 @await Component.InvokeAsync("Notifier")
```


Now include code below for Constructor Injection. Add the following code to controllers / razor classes where required.

```
public INotifierService _notifier { get; }
public HomeController(INotifierService notifier)
{
    _notifier = notifier;
}

```
Once the Injection is done, you can call the toast notification as. Currently 4 Types of toast notification are supported. In future i will add moreature along with customization.

### Success
```csharp
_notifier.Success("This is a Success Notification");
```

### Error
```csharp
_notifier.Error("This is an Error Notification");
```

### Warning
```csharp
_notifier.Warning("This is a Warning Notification");
```

### Info
```csharp
_notifier.Info("This is an Info Notification");
```
### Set Toast Duration
By default, the toast gets dismissed in 5 seconds. You can set the duration(in seconds) which will be the duration of toast notification.
```csharp
_notifyService.Success("This Notification duration is 10 sec.", 10);
```

# New Feature
More feature will be coming soon..
Stay with us.
