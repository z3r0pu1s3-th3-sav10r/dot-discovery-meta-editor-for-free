# Meta.Editor.dll Breakdown

This document provides a detailed breakdown of the contents and functionality of the `Meta.Editor.dll` file, which is a dynamic link library (DLL) used in the Meta.Editor application. The breakdown includes an analysis of various components such as configuration files, code files, and XAML files to understand their purpose and functionality within the application.

This document is an intentional opening of the code for all to see. Nothing should ever be behind a paywall. This is a public service to help others learn and understand code.

## /app.config

This `app.config` file is a configuration file for a .NET application. It provides settings that control the behavior of the application at runtime. Specifically, this file is used to configure assembly binding redirections. Here's a detailed breakdown of its contents:

1. **XML Declaration:**

   ```xml
   <?xml version="1.0" encoding="utf-8"?>
   ```

   - Declares the XML version and encoding used in the file.

2. **Root Element: `<configuration>`**

   ```xml
   <configuration>
   ```

   - The root element that contains all the configuration settings for the application.

3. **Runtime Element: `<runtime>`**

   ```xml
   <runtime>
   ```

   - Contains settings that affect the runtime behavior of the application.

4. **Assembly Binding Element: `<assemblyBinding>`**

   ```xml
   <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
   ```

   - Configures the binding of assemblies used by the application. The `xmlns` attribute specifies the XML namespace for assembly binding settings.

5. **Dependent Assembly Element: `<dependentAssembly>`**

   - Specifies assemblies that the application depends on, and configures binding redirections for these assemblies.

   Example 1:

   ```xml
   <dependentAssembly>
     <assemblyIdentity name="Microsoft.Win32.Registry" publicKeyToken="b03f5f7f11d50a3a" culture="neutral" />
     <bindingRedirect oldVersion="0.0.0.0-5.0.0.0" newVersion="5.0.0.0" />
   </dependentAssembly>
   ```

   - **`<assemblyIdentity>`**: Identifies the dependent assembly by its name, public key token, and culture.
     - `name="Microsoft.Win32.Registry"`: Specifies the name of the assembly.
     - `publicKeyToken="b03f5f7f11d50a3a"`: Specifies the public key token of the assembly's strong name.
     - `culture="neutral"`: Specifies the culture of the assembly (neutral means it is culture-agnostic).
   - **`<bindingRedirect>`**: Redirects the binding from an old version range to a new version.
     - `oldVersion="0.0.0.0-5.0.0.0"`: Specifies the old version range of the assembly.
     - `newVersion="5.0.0.0"`: Specifies the new version to which the old versions are redirected.

   Example 2:

   ```xml
   <dependentAssembly>
     <assemblyIdentity name="MaterialDesignThemes.Wpf" publicKeyToken="df2a72020bd7962a" culture="neutral" />
     <bindingRedirect oldVersion="0.0.0.0-5.0.0.0" newVersion="5.0.0.0" />
   </dependentAssembly>
   ```

   - The same structure is used for another dependent assembly named `MaterialDesignThemes.Wpf`.

**Summary:**
This `app.config` file redirects any old versions (from `0.0.0.0` to `5.0.0.0`) of the assemblies `Microsoft.Win32.Registry` and `MaterialDesignThemes.Wpf` to the new version `5.0.0.0`. This ensures that the application uses the specified new version of these assemblies, avoiding potential conflicts or issues caused by using different versions.

## /app.xaml

This XAML file defines the `App` class for a WPF (Windows Presentation Foundation) application named "MetaEditor". The file sets up the application resources, including merging several resource dictionaries, which are collections of reusable resources such as styles, templates, and brushes. Here's a breakdown of the key parts:

1. **Root Element: `<Application>`**

   - The root element is `Application`, which represents the WPF application.
   - `x:Class="MetaEditor.App"` specifies the code-behind class for the application, which is `MetaEditor.App`.

2. **XML Namespaces:**

   - `xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"`: This is the default namespace for WPF elements.
   - `xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"`: This is the XAML namespace for XAML language definitions.

3. **Application.Resources:**

   - This section defines resources that are available throughout the application.

4. **ResourceDictionary:**

   - A `ResourceDictionary` is a collection of resources, and it can include other resource dictionaries using `MergedDictionaries`.

5. **MergedDictionaries:**
   - This element allows the application to include multiple resource dictionaries. Each `ResourceDictionary` specifies a `Source`, which is the path to the XAML file containing the resources.

The specific resource dictionaries included in the `MergedDictionaries` are:

1. **`<ResourceDictionary Source="/Themes/Generic.xaml"/>`**

   - Includes the generic theme resources for the application.

2. **`<ResourceDictionary Source="/Controls/Flatbuffer/Themes/Generic.xaml"/>`**

   - Includes theme resources specific to the Flatbuffer controls.

3. **`<ResourceDictionary Source="/Controls/SDB/Themes/Generic.xaml"/>`**

   - Includes theme resources specific to the SDB controls.

4. **`<ResourceDictionary Source="/Controls/CreationSuite/Controls/Games/Editors/Themes/EditorCharacter.xaml"/>`**

   - Includes theme resources specific to the character editor in the CreationSuite controls.

5. **`<ResourceDictionary Source="/Controls/CreationSuite/Controls/Games/Editors/Themes/EditorMapping.xaml"/>`**

   - Includes theme resources specific to the mapping editor in the CreationSuite controls.

6. **`<ResourceDictionary Source="/Controls/CreationSuite/Controls/Games/Editors/Themes/EditorMotion.xaml"/>`**
   - Includes theme resources specific to the motion editor in the CreationSuite controls.

**Summary:**
This XAML file sets up the main application class (`MetaEditor.App`) and merges several resource dictionaries that provide themes and styles for different parts of the application. By doing this, it ensures that the application has a consistent look and feel, with reusable resources defined in separate XAML files.

## /MetaEditor/AssemblyInfo.cs

This C# code defines a series of assembly-level attributes for a .NET application. These attributes provide metadata about the assembly and control various aspects of its behavior and appearance. Here's a breakdown of each attribute and what it does:

1. **[assembly: Extension]**

   - Marks the assembly as an extension, indicating that it can extend other applications or assemblies.

2. **[assembly: ThemeInfo(ResourceDictionaryLocation.None, ResourceDictionaryLocation.SourceAssembly)]**

   - Specifies the locations of theme-specific and generic resource dictionaries for the assembly. In this case, there are no theme-specific resources (`None`), and generic resources are located in the source assembly (`SourceAssembly`).

3. **[assembly: AssemblyAssociatedContentFile("appicon.ico")]**

   - Associates an additional content file, `appicon.ico`, with the assembly. This file could be used as an application icon.

4. **[assembly: AssemblyCompany("Meta.Editor")]**

   - Specifies the company that produced the assembly. Here, it is "Meta.Editor".

5. **[assembly: AssemblyConfiguration("Developer - Debug")]**

   - Specifies the build configuration, such as "Debug" or "Release". Here, it indicates a developer debug build.

6. **[assembly: AssemblyFileVersion("1.0.5.32")]**

   - Specifies the file version of the assembly, which is typically used by the file system and displayed in the file properties. The version here is "1.0.5.32".

7. **[assembly: AssemblyInformationalVersion("1.0.0")]**

   - Provides additional version information, often a human-readable version or product version. Here, it is "1.0.0".

8. **[assembly: AssemblyProduct("Meta.Editor")]**

   - Specifies the product name with which the assembly is associated. In this case, it is "Meta.Editor".

9. **[assembly: AssemblyTitle("Meta.Editor")]**

   - Specifies the title of the assembly, often used in file properties or user interfaces. Here, it is "Meta.Editor".

10. **[assembly: TargetPlatform("Windows10.0.17763.0")]**

    - Indicates the target platform for which the assembly is built. Here, it is Windows 10 with a specific version of 17763.0.

11. **[assembly: SupportedOSPlatform("Windows10.0.17763.0")]**

    - Specifies the operating system platform that the assembly supports. This is also set to Windows 10 version 17763.0.

12. **[assembly: AssemblyVersion("1.0.5.32")]**

    - Specifies the version of the assembly used by the runtime. This is the same as the file version, "1.0.5.32".

13. **[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]**
    - Requests minimum security permission to skip verification, which can improve performance but should be used with caution as it may bypass some security checks.

In summary, these attributes provide essential metadata about the assembly, such as version information, target platform, company, product details, and security permissions. This metadata helps with assembly management, versioning, deployment, and runtime behavior.

## /DiscordRPCManager.cs

This code defines a `DiscordRPCManager` class that uses the DiscordRPC library to manage the connection to Discord's Rich Presence feature, which allows an application to display detailed information about what a user is currently doing within the application. Here's a detailed explanation of the code:

### Class Definition and Constructor

```csharp
public sealed class DiscordRPCManager
{
  private static DiscordRpcClient client;

  public DiscordRPCManager() => this.Initialize();
}
```

- The class `DiscordRPCManager` is declared as `sealed`, which means it cannot be inherited.
- A static `DiscordRpcClient` object named `client` is declared to manage the connection to Discord.
- The constructor `DiscordRPCManager` calls the `Initialize` method when an instance of the class is created.

### Initialize Method

```csharp
public void Initialize()
{
  DiscordRPCManager.client = new DiscordRpcClient("1235982522706563214");
  DiscordRPCManager.client.OnReady += DiscordRPCManager.\u003C\u003Ec.\u003C\u003E9__2_0 ?? (DiscordRPCManager.\u003C\u003Ec.\u003C\u003E9__2_0 = new OnReadyEvent((object) DiscordRPCManager.\u003C\u003Ec.\u003C\u003E9, __methodptr(\u003CInitialize\u003Eb__2_0)));
  DiscordRPCManager.client.Initialize();
}
```

- `DiscordRPCManager.client` is initialized with a new `DiscordRpcClient` object, using a specific client ID ("1235982522706563214").
- The `OnReady` event is subscribed to an event handler. This uses a lambda expression to assign a method to the event handler if it's not already assigned (as indicated by the `??` operator).
- `client.Initialize()` is called to establish the connection to Discord.

### SetPresence Method

```csharp
public void SetPresence(string state)
{
  RichPresence richPresence1 = new RichPresence();
  richPresence1.State = state;
  richPresence1.Details = "DISCOVERY ®";
  richPresence1.Assets = new Assets()
  {
    LargeImageKey = "https://pbs.twimg.com/profile_images/1740042200166068225/lcLreexT_400x400.png",
    LargeImageText = "http://www.discovery.onl"
  };
  richPresence1.Buttons = new Button[2]
  {
    new Button()
    {
      Label = "DISCOVERY Website",
      Url = "https://discovery.onl/"
    },
    new Button()
    {
      Label = "DISCOVERY Patreon",
      Url = "http://www.patreon.com/dotdiscovery"
    }
  };
  RichPresence richPresence2 = richPresence1;
  DiscordRPCManager.client.SetPresence(richPresence2);
}
```

- The `SetPresence` method takes a `string` parameter `state` and uses it to set the presence information.
- A new `RichPresence` object is created, and its `State` property is set to the provided `state`.
- The `Details` property is set to `"DISCOVERY ®"`.
- The `Assets` property is set to a new `Assets` object, which includes:
  - `LargeImageKey`: URL to the large image to display.
  - `LargeImageText`: Text to display when hovering over the large image.
- The `Buttons` property is set to an array of `Button` objects, each with a `Label` and `Url`.
- Finally, the configured `RichPresence` object is set as the current presence using `DiscordRPCManager.client.SetPresence(richPresence2)`.

### Shutdown Method

```csharp
public void Shutdown() => DiscordRPCManager.client.Dispose();
```

- The `Shutdown` method disposes of the `client` object, effectively closing the connection to Discord.

### Nullable Enable

```csharp
#nullable enable
```

- This directive enables nullable reference types, which allows the compiler to enforce nullability rules and help prevent null reference exceptions.

### Summary

1. **Initialization**: Creates and initializes a Discord RPC client with a specific client ID.
2. **Set Presence**: Allows setting detailed presence information, including state, details, large image, and buttons with URLs.
3. **Shutdown**: Disposes of the Discord client, closing the connection.

This code helps manage Discord Rich Presence, providing users with real-time updates about the application's state.

## /MetaEditor/Extensions.cs

This code defines a static class named `Extensions` that provides extension methods for converting lists of various types (specifically `uint`, `ushort`, and `byte`) into byte arrays. Each method is an extension method, meaning it can be called on instances of `List<uint>`, `List<ushort>`, and `List<byte>` respectively. Here’s a detailed explanation of each part of the code:

### Enabling Nullable Context

```csharp
#nullable enable
```

This directive enables nullable reference types and non-nullable reference types for the code following it. It helps with nullability annotations and checking, which is useful for avoiding `NullReferenceException` at runtime.

### Extension Methods Class

```csharp
public static class Extensions
```

Defines a static class named `Extensions`. This class contains extension methods for lists.

### Method for Converting `List<uint>` to `byte[]`

```csharp
public static byte[] ToByteArray(this List<uint> uintList)
{
    byte[] dst = new byte[uintList.Count * 4];
    Buffer.BlockCopy((Array)uintList.ToArray(), 0, (Array)dst, 0, dst.Length);
    return dst;
}
```

This method converts a `List<uint>` to a byte array:

1. It allocates a byte array `dst` with a length four times the count of `uintList` (since a `uint` is 4 bytes).
2. It uses `Buffer.BlockCopy` to copy the bytes from the `uint` array to the byte array. The `uintList.ToArray()` converts the list to an array, and `Buffer.BlockCopy` performs the copy operation efficiently.
3. It returns the resulting byte array.

### Method for Converting `List<ushort>` to `byte[]`

```csharp
public static byte[] ToByteArray(this List<ushort> ushortList)
{
    byte[] byteArray = new byte[ushortList.Count * 2];
    for (int index = 0; index < ushortList.Count; ++index)
    {
        byte[] bytes = BitConverter.GetBytes(ushortList[index]);
        byteArray[index * 2] = bytes[0];
        byteArray[index * 2 + 1] = bytes[1];
    }
    return byteArray;
}
```

This method converts a `List<ushort>` to a byte array:

1. It allocates a byte array `byteArray` with a length two times the count of `ushortList` (since a `ushort` is 2 bytes).
2. It iterates through each `ushort` in the list, converts each `ushort` to a byte array using `BitConverter.GetBytes`, and stores the bytes in `byteArray`.
3. It manually assigns each byte to the correct position in the `byteArray`.
4. It returns the resulting byte array.

### Method for Converting `List<byte>` to `byte[]`

```csharp
public static byte[] ToByteArray(this List<byte> uintList)
{
    byte[] dst = new byte[uintList.Count * 4];
    Buffer.BlockCopy((Array)uintList.ToArray(), 0, (Array)dst, 0, dst.Length);
    return dst;
}
```

This method has a bug because it incorrectly handles a list of bytes:

1. It allocates a byte array `dst` with a length four times the count of `uintList` (which is incorrect since each byte is already a single byte).
2. It uses `Buffer.BlockCopy` to copy the bytes from the byte array to the new byte array, but the length is incorrectly set to `uintList.Count * 4`.
3. This should ideally not multiply by 4 and should directly return the array or create a copy with the same length as `uintList`.

### Summary

- The first method efficiently converts a `List<uint>` to a byte array using `Buffer.BlockCopy`.
- The second method converts a `List<ushort>` to a byte array using a loop and `BitConverter`.
- The third method incorrectly attempts to convert a `List<byte>` to a byte array, likely due to a copy-paste error. It should not multiply the count by 4 for the byte array size.

## /FNV1A.cs

The code provided is an implementation of the FNV-1a hash algorithm, which is used to generate a hash value from a given string. The implementation includes several methods that take into account certain filtering and formatting rules before generating the hash. Here's a detailed breakdown of what each part does:

1. **Namespaces and Using Directives:**

   - `using System;`
   - `using System.Collections.Generic;`
   - `using System.Diagnostics;`
   - `using System.Linq;`
   - `using System.Text;`
   - `using System.Text.RegularExpressions;`
   - These directives import various namespaces required for the operations in the code.

2. **Class and Methods:**

   - The class `FNV1A` is declared as `public static`, meaning it cannot be instantiated and its members must be accessed statically.

3. **Method: `Hash(this string name, string[] filter)`**

   - **Purpose:** Computes the FNV-1a hash of the provided `name` string after applying certain filtering rules.
   - **Parameters:**
     - `name`: The string to be hashed.
     - `filter`: An array of strings used to filter parts of the `name`.
   - **Steps:**
     - If `name` is `null` or empty, it is set to `"0"`.
     - If `name` consists only of numeric characters, it is directly converted to a `ulong` and returned.
     - `name` replaces backslashes (`\`) with forward slashes (`/`).
     - It finds the last index of any keyword in `filter` that is part of `name` and uses this index to substring `name` from the matching keyword onwards.
     - Converts the `name` to lowercase and then to a byte array.
     - Initializes the hash value (`num2`) to a specific FNV-1a offset basis.
     - Iterates through each byte, applies the FNV-1a hashing algorithm, and returns the resulting hash value.

4. **Method: `Hash(this string name, string[] filter, out string formatted)`**

   - **Purpose:** Similar to the previous `Hash` method but also outputs a formatted version of the `name`.
   - **Parameters:**
     - `name`: The string to be hashed.
     - `filter`: An array of strings used to filter parts of the `name`.
     - `formatted`: An output parameter that returns the formatted `name`.
   - **Steps:**
     - Similar to the previous `Hash` method with an additional step of formatting `name` by converting it to lowercase and replacing `.dds` with `.tex`.

5. **Method: `HashTexture(this string name, string[] filter)`**
   - **Purpose:** Computes the FNV-1a hash of the provided texture `name` string after ensuring the extension is `.tex`.
   - **Parameters:**
     - `name`: The string to be hashed.
     - `filter`: An array of strings used to filter parts of the `name`.
   - **Steps:**
     - If `name` is `null` or empty, it is set to `"0"`.
     - Ensures that `.dds` extensions in `name` are replaced with `.tex`.
     - Calls the `Hash` method with the filtered `name` and `filter` to compute and return the hash.

### Summary

The `FNV1A` class provides methods to compute FNV-1a hash values for strings, with additional handling for specific filters and formatting rules. The class is designed to be used in contexts where consistent, case-insensitive hashing is required, such as in asset management or file identification in a game engine or similar application.

## /controls/creationsuite/creationwindow.xaml

This code is a XAML (Extensible Application Markup Language) file used to define the user interface for a window in a WPF (Windows Presentation Foundation) application. Here's a detailed breakdown of the code:

### Root Element

```xml
<controls:MetaWindow x:Class="Meta.Editor.Controls.CreationWindow"
                     xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                     xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                     xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
                     xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
                     xmlns:controls="clr-namespace:Meta.Editor.Controls"
                     xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes"
                     Loaded="MetaWindow_Loaded" Title="Creation Suite" Height="900" Width="1500" EnableDropShadow="True"
                     ResizeBorderWidth="7" DropShadowOpacity=".5" ResizeMode="CanResize"
                     Background="{StaticResource WindowBackground}" Topmost="False" WindowStartupLocation="CenterScreen"
                     SnapsToDevicePixels="True">
```

- **`<controls:MetaWindow>`**: Custom window control derived from a base WPF window.
- **`x:Class`**: Code-behind class associated with this XAML file.
- **Namespaces**: Includes various namespaces required for the XAML schema and custom controls.
- **Properties**: Sets window properties like title, size, drop shadow, resize mode, background, startup location, etc.
- **Events**: `Loaded="MetaWindow_Loaded"` specifies an event handler for the window loaded event.

### Grid Layout

```xml
  <Grid x:Name="mainGrid" Background="{StaticResource ListBackground}">
    <Grid.RowDefinitions>
      <RowDefinition Height="22"/>
      <RowDefinition Height="30"/>
      <RowDefinition Height="*"/>
      <RowDefinition Height=".15*"/>
    </Grid.RowDefinitions>
```

- **`<Grid>`**: Main container for the window's content.
- **`<Grid.RowDefinitions>`**: Defines the rows in the grid with specific heights.

### Menu

```xml
    <Grid Row="0">
      <Grid.ColumnDefinitions>
        <ColumnDefinition Width="*"/>
      </Grid.ColumnDefinitions>
      <Menu x:Name="menu" Height="22" Grid.Column="0" VerticalAlignment="Top">
        <MenuItem Header="File" Height="22">
          <MenuItem x:Name="NewCreationProfile" Header="New" Height="22" InputGestureText="Ctrl+O">
            <MenuItem.Icon>
              <PackIcon Kind="File" FrameworkElement.Width="16" FrameworkElement.Height="16"/>
            </MenuItem.Icon>
            <MenuItem Click="CreateCharacterProfile_Click" x:Name="CreateCharacterProfile" Header="Character" Height="22">
              <MenuItem.Icon>
                <PackIcon Kind="FaceAgent" FrameworkElement.Width="16" FrameworkElement.Height="16"/>
              </MenuItem.Icon>
            </MenuItem>
            <MenuItem Click="CreateBeltProfile_Click" x:Name="CreateBeltProfile" Header="Belt" Height="22">
              <MenuItem.Icon>
                <PackIcon Kind="Trophy" FrameworkElement.Width="16" FrameworkElement.Height="16"/>
              </MenuItem.Icon>
            </MenuItem>
          </MenuItem>
          <!-- Additional MenuItems omitted for brevity -->
        </MenuItem>
      </Menu>
    </Grid>
```

- **`<Menu>`**: Top-level menu containing various menu items.
- **`<MenuItem>`**: Defines individual menu items such as "File" with sub-items like "New", "Open", "Save As", and "Exit".
- **`PackIcon`**: Uses icons from the MaterialDesign library for menu items.

### Tab Control (Top)

```xml
    <Grid Row="1">
      <Border BorderBrush="{StaticResource ControlBackground}" BorderThickness="0" Margin="0, 0, 0, 0">
        <controls:MetaTabControl x:Name="tabControl" SelectionChanged="tabControl_SelectionChanged" Margin="2,4,2,0">
          <!-- Control Template for customizing the TabControl's appearance and behavior -->
        </controls:MetaTabControl>
      </Border>
    </Grid>
```

- **`<controls:MetaTabControl>`**: Custom tab control with an event handler for selection changes.
- **`<Border>`**: Provides styling and margin for the tab control.

### Tab Content (Middle)

```xml
    <Grid Row="2">
      <Border BorderThickness="0" BorderBrush="Transparent" Margin="2 0">
        <controls:MetaDetachedTabControl x:Name="tabContent" Foreground="{StaticResource FontColor}"/>
      </Border>
    </Grid>
```

- **`<controls:MetaDetachedTabControl>`**: Custom tab control for displaying the main content.
- **`<Border>`**: Provides styling and margin for the tab content.

### Miscellaneous Tab Control (Bottom)

```xml
    <Grid Row="3">
      <Border BorderThickness="0" BorderBrush="{StaticResource ControlBackground}" Margin="2">
        <controls:MetaTabControl x:Name="miscTabControl" Grid.Row="2" BorderThickness="0">
          <controls:MetaTabItem Header="Log" CloseButtonVisible="False">
            <Grid>
              <Border BorderBrush="{StaticResource ControlBackground}" RenderOptions.EdgeMode="Aliased" BorderThickness="0">
                <TextBox TextChanged="LogTextBox_TextChanged" x:Name="log" FontFamily="Consolas" IsReadOnly="True"
                         VerticalScrollBarVisibility="Auto" HorizontalScrollBarVisibility="Auto"
                         Background="{StaticResource ListBackground}" Padding="4"/>
              </Border>
            </Grid>
          </controls:MetaTabItem>
        </controls:MetaTabControl>
      </Border>
    </Grid>
```

- **`<controls:MetaTabControl>`**: Additional tab control for miscellaneous content, such as logs.
- **`<controls:MetaTabItem>`**: Individual tab item for displaying logs.
- **`<TextBox>`**: Read-only text box for displaying log messages.

### Summary

This XAML code defines a complex WPF window with a structured layout using grids, custom controls, and a rich set of menu items and tab controls. The window is designed to provide a user-friendly interface for creating and managing profiles, with sections for menus, tabbed content, and logs, all styled with custom resources and material design icons.

## /controls/creationsuite/controls/games/editors/themes/editorcharacter.xaml

This XAML file defines a `ResourceDictionary` that contains styles for various custom controls in a WPF (Windows Presentation Foundation) application. These styles specify the templates used to render the controls, which dictate their appearance and layout. Here's a detailed explanation:

### Root Element: `<ResourceDictionary>`

```xml
<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                    xmlns:local="clr-namespace:Meta.Editor.Controls.CreationSuite"
                    xmlns:pt="http://propertytools.org/wpf">
```

- **xmlns**: Default namespace for WPF elements.
- **xmlns:x**: Namespace for XAML language features.
- **xmlns:local**: Maps to the `Meta.Editor.Controls.CreationSuite` namespace in the project, allowing use of custom controls defined there.
- **xmlns:pt**: Maps to the `http://propertytools.org/wpf` namespace, possibly used for `PropertyGrid` control.

### Merged Dictionaries

```xml
<ResourceDictionary.MergedDictionaries>
  <ResourceDictionary Source="/Meta.Editor;component/Themes/Generic.xaml"/>
</ResourceDictionary.MergedDictionaries>
```

- Merges another resource dictionary (`Generic.xaml`) into this one, making its resources available here.

### Styles for Custom Controls

The file defines styles for several custom controls (`EditorCharacter`, `EditorCharacter_WWE2K24`, `EditorBelt`, `EditorBelt_WWE2K24`). Each style sets the control template, specifying the visual structure.

#### Style for `EditorCharacter`

```xml
<Style TargetType="{x:Type local:EditorCharacter}">
  <Setter Property="Control.Template">
    <Setter.Value>
      <ControlTemplate TargetType="{x:Type local:EditorCharacter}">
        <Grid>
          <Grid.ColumnDefinitions>
            <ColumnDefinition Width="5*"/>
            <ColumnDefinition Width="5*"/>
          </Grid.ColumnDefinitions>
          <Border BorderThickness="0,2,2,2" BorderBrush="{StaticResource ControlBackground}"
                  Background="{StaticResource ScrollbarBackground}">
            <PropertyGrid FrameworkElement.Name="PART_GeneralInfoPropertyGrid" FrameworkElement.Margin="-8,0,0,0"
                          Control.Background="Transparent" TabVisibility="VisibleIfMoreThanOne"
                          CategoryControlType="GroupBox"/>
          </Border>
          <Border Grid.Column="1" BorderThickness="0,2" BorderBrush="{StaticResource ControlBackground}"
                  Background="{StaticResource ScrollbarBackground}">
            <PropertyGrid FrameworkElement.Name="PART_SecondaryInfoPropertyGrid" FrameworkElement.Margin="-8,0,0,0"
                          Control.Background="Transparent" TabVisibility="VisibleIfMoreThanOne"
                          CategoryControlType="GroupBox"/>
          </Border>
        </Grid>
      </ControlTemplate>
    </Setter.Value>
  </Setter>
</Style>
```

- **`<Style TargetType="{x:Type local:EditorCharacter}">`**: Targets the `EditorCharacter` control.
- **`<ControlTemplate>`**: Defines the visual structure for the control.
  - **`<Grid>`**: Main layout container with two columns.
  - **`<Border>`**: First column with a `PropertyGrid` for general info.
  - **`<Border Grid.Column="1">`**: Second column with a `PropertyGrid` for secondary info.

#### Similar Styles for Other Controls

- **`EditorCharacter_WWE2K24`**: Identical structure as `EditorCharacter` but targets a different control.
- **`EditorBelt`**: Similar structure, but the `PropertyGrid` is named `PART_PrimaryInfoPropertyGrid` and `PART_SecondaryInfoPropertyGrid`.
- **`EditorBelt_WWE2K24`**: Identical structure as `EditorBelt` but targets a different control.

### Common Elements

- **`Grid`**: Used to arrange the layout with two equal-width columns.
- **`Border`**: Provides borders and backgrounds for sections.
- **`PropertyGrid`**: Custom control, possibly from the PropertyTools library, used for displaying and editing properties of objects.

**Summary:**
This `ResourceDictionary` defines styles for custom controls used in the `Meta.Editor` application. Each style sets the control template to define how the control is visually structured and styled, using a combination of `Grid`, `Border`, and `PropertyGrid` elements. The merged dictionary makes additional styles and resources available for use within these templates.

## /controls/creationsuite/controls/games/editors/themes/editormapping.xaml

This XAML (Extensible Application Markup Language) code defines a resource dictionary for a WPF (Windows Presentation Foundation) application. Let's break down each part:

### 1. **ResourceDictionary Declaration**

```xml
<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                    xmlns:local="clr-namespace:Meta.Editor.Controls.CreationSuite"
                    xmlns:pt="http://propertytools.org/wpf">
```

- **ResourceDictionary**: This is the root element that contains the styles and resources.
- **xmlns**: These are XML namespaces. They define the scope for the elements and attributes used in the XAML.
  - `http://schemas.microsoft.com/winfx/2006/xaml/presentation`: Standard WPF presentation namespace.
  - `http://schemas.microsoft.com/winfx/2006/xaml`: Standard XAML namespace.
  - `clr-namespace:Meta.Editor.Controls.CreationSuite`: Custom namespace for controls defined in the `Meta.Editor.Controls.CreationSuite` namespace.
  - `http://propertytools.org/wpf`: Namespace for PropertyTools WPF library.

### 2. **Merged Dictionaries**

```xml
<ResourceDictionary.MergedDictionaries>
    <ResourceDictionary Source="/Meta.Editor;component/Themes/Generic.xaml"/>
</ResourceDictionary.MergedDictionaries>
```

- **MergedDictionaries**: This element is used to include other resource dictionaries.
- **Source**: Specifies the location of another XAML file (`Generic.xaml`) to be merged into this dictionary.

### 3. **Style Definitions**

- The styles define the visual appearance of the custom controls `EditorMapping` and `EditorMapping_WWE2K24`.

#### **Style for EditorMapping**

```xml
<Style TargetType="{x:Type local:EditorMapping}">
  <Setter Property="Control.Template">
    <Setter.Value>
      <ControlTemplate TargetType="{x:Type local:EditorMapping}">
        <Grid>
          <Grid.ColumnDefinitions>
            <ColumnDefinition Width="5*"/>
            <ColumnDefinition Width="5*"/>
          </Grid.ColumnDefinitions>
          <Border BorderThickness="0,2" BorderBrush="{StaticResource ControlBackground}" Background="{StaticResource ScrollbarBackground}">
            <PropertyGrid x:Name="PART_GeneralInfoPropertyGrid" FrameworkElement.Margin="-8,0,0,0" Control.Background="Transparent" TabVisibility="VisibleIfMoreThanOne" CategoryControlType="GroupBox"/>
          </Border>
          <Border Grid.Column="1" BorderThickness="0,2" BorderBrush="{StaticResource ControlBackground}" Background="{StaticResource ScrollbarBackground}">
            <PropertyGrid x:Name="PART_SecondaryInfoPropertyGrid" FrameworkElement.Margin="-8,0,0,0" Control.Background="Transparent" TabVisibility="VisibleIfMoreThanOne" CategoryControlType="GroupBox"/>
          </Border>
        </Grid>
      </ControlTemplate>
    </Setter.Value>
  </Setter>
</Style>
```

- **Style**: Defines a style for the `EditorMapping` control.
- **TargetType**: Specifies the control type this style targets (`local:EditorMapping`).
- **Setter**: Sets a property value. Here, it sets the `Control.Template` property.
- **ControlTemplate**: Defines the visual structure of the control.
- **Grid**: Layout panel that organizes the child elements in a grid.
- **Grid.ColumnDefinitions**: Defines two equal-width columns.
- **Border**: Provides a border around each `PropertyGrid`.
- **PropertyGrid**: Custom control used within the `EditorMapping` control.

#### **Style for EditorMapping_WWE2K24**

```xml
<Style TargetType="{x:Type local:EditorMapping_WWE2K24}">
  <Setter Property="Control.Template">
    <Setter.Value>
      <ControlTemplate TargetType="{x:Type local:EditorMapping_WWE2K24}">
        <Grid>
          <Grid.ColumnDefinitions>
            <ColumnDefinition Width="5*"/>
            <ColumnDefinition Width="5*"/>
          </Grid.ColumnDefinitions>
          <Border BorderThickness="0,2" BorderBrush="{StaticResource ControlBackground}" Background="{StaticResource ScrollbarBackground}">
            <PropertyGrid x:Name="PART_GeneralInfoPropertyGrid" FrameworkElement.Margin="-8,0,0,0" Control.Background="Transparent" TabVisibility="VisibleIfMoreThanOne" CategoryControlType="GroupBox"/>
          </Border>
          <Border Grid.Column="1" BorderThickness="0,2" BorderBrush="{StaticResource ControlBackground}" Background="{StaticResource ScrollbarBackground}">
            <PropertyGrid x:Name="PART_SecondaryInfoPropertyGrid" FrameworkElement.Margin="-8,0,0,0" Control.Background="Transparent" TabVisibility="VisibleIfMoreThanOne" CategoryControlType="GroupBox"/>
          </Border>
        </Grid>
      </ControlTemplate>
    </Setter.Value>
  </Setter>
</Style>
```

- This style is almost identical to the previous one but targets the `EditorMapping_WWE2K24` control instead.

### Key Points

- **Styles**: Both styles define how `EditorMapping` and `EditorMapping_WWE2K24` controls should look and behave.
- **ControlTemplate**: Provides a template for the visual structure of the controls.
- **Grid Layout**: Uses a grid to arrange elements in two columns.
- **PropertyGrid**: Custom control used within the borders to display properties.

This resource dictionary centralizes the styles for these controls, making it easier to manage and maintain their appearance and behavior consistently across the application.

## /controls/creationsuite/controls/games/editors/themes/editormotion.xaml

This XAML snippet defines a `ResourceDictionary` that contains styles for custom controls used in a WPF (Windows Presentation Foundation) application. Here is a detailed breakdown of the various elements and their purposes:

1. **ResourceDictionary Declaration**:

   ```xml
   <ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                       xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                       xmlns:local="clr-namespace:Meta.Editor.Controls.CreationSuite"
                       xmlns:pt="http://propertytools.org/wpf">
   ```

   - `xmlns`: The default namespace for WPF controls.
   - `xmlns:x`: The XAML namespace for XAML-specific attributes.
   - `xmlns:local`: The namespace for local controls defined in the `Meta.Editor.Controls.CreationSuite` namespace.
   - `xmlns:pt`: The namespace for controls from the PropertyTools library.

2. **Merged Resource Dictionary**:

   ```xml
   <ResourceDictionary.MergedDictionaries>
       <ResourceDictionary Source="/Meta.Editor;component/Themes/Generic.xaml"/>
   </ResourceDictionary.MergedDictionaries>
   ```

   - This section merges another resource dictionary located at the specified path, allowing reuse of styles and resources defined in `Generic.xaml`.

3. **Style for `EditorMotion` Control**:

   ```xml
   <Style TargetType="{x:Type local:EditorMotion}">
       <Setter Property="Control.Template">
           <Setter.Value>
               <ControlTemplate TargetType="{x:Type local:EditorMotion}">
                   <Grid>
                       <Grid.ColumnDefinitions>
                           <ColumnDefinition Width="5*"/>
                           <ColumnDefinition Width="5*"/>
                       </Grid.ColumnDefinitions>
                       <Border BorderThickness="0,2,2,2" BorderBrush="{StaticResource ControlBackground}"
                               Background="{StaticResource ScrollbarBackground}">
                           <PropertyGrid x:Name="PART_PrimaryPropertyGrid" FrameworkElement.Margin="-8,0,0,0"
                                         Control.Background="Transparent" TabVisibility="VisibleIfMoreThanOne"
                                         CategoryControlType="GroupBox"/>
                       </Border>
                       <Border Grid.Column="1" BorderThickness="0,2" BorderBrush="{StaticResource ControlBackground}"
                               Background="{StaticResource ScrollbarBackground}">
                           <PropertyGrid x:Name="PART_SecondaryInfoPropertyGrid" FrameworkElement.Margin="-8,0,0,0"
                                         Control.Background="Transparent" TabVisibility="VisibleIfMoreThanOne"
                                         CategoryControlType="GroupBox"/>
                       </Border>
                   </Grid>
               </ControlTemplate>
           </Setter.Value>
       </Setter>
   </Style>
   ```

   - `Style TargetType="{x:Type local:EditorMotion}"`: Defines a style for the `EditorMotion` control.
   - `ControlTemplate`: Defines the visual structure of the `EditorMotion` control.
   - The template includes a `Grid` with two columns of equal width (`5*`).
   - Each column contains a `Border` with a `PropertyGrid` inside it, setting properties like `Margin`, `Background`, and `TabVisibility`.

4. **Style for `EditorMotion_WWE2K24` Control**:

   ```xml
   <Style TargetType="{x:Type local:EditorMotion_WWE2K24}">
       <Setter Property="Control.Template">
           <Setter.Value>
               <ControlTemplate TargetType="{x:Type local:EditorMotion_WWE2K24}">
                   <Grid>
                       <Grid.ColumnDefinitions>
                           <ColumnDefinition Width="5*"/>
                           <ColumnDefinition Width="5*"/>
                       </Grid.ColumnDefinitions>
                       <Border BorderThickness="0,2,2,2" BorderBrush="{StaticResource ControlBackground}"
                               Background="{StaticResource ScrollbarBackground}">
                           <PropertyGrid x:Name="PART_PrimaryPropertyGrid" FrameworkElement.Margin="-8,0,0,0"
                                         Control.Background="Transparent" TabVisibility="VisibleIfMoreThanOne"
                                         CategoryControlType="GroupBox"/>
                       </Border>
                       <Border Grid.Column="1" BorderThickness="0,2" BorderBrush="{StaticResource ControlBackground}"
                               Background="{StaticResource ScrollbarBackground}">
                           <PropertyGrid x:Name="PART_SecondaryInfoPropertyGrid" FrameworkElement.Margin="-8,0,0,0"
                                         Control.Background="Transparent" TabVisibility="VisibleIfMoreThanOne"
                                         CategoryControlType="GroupBox"/>
                       </Border>
                   </Grid>
               </ControlTemplate>
           </Setter.Value>
       </Setter>
   </Style>
   ```

   - This style is almost identical to the previous one but is specifically for the `EditorMotion_WWE2K24` control.
   - The visual structure and properties set are the same as those for the `EditorMotion` control.

### Key Elements and Concepts

- **ResourceDictionary**: A container for XAML resources like styles, templates, and brushes, allowing them to be reused throughout the application.
- **MergedDictionaries**: Enables the inclusion of resources from other dictionaries, promoting modular and maintainable XAML.
- **Styles**: Define the look and feel of controls. Here, two styles are defined for `EditorMotion` and `EditorMotion_WWE2K24`.
- **ControlTemplate**: Specifies the visual structure of a control, allowing for complex layouts and custom appearances.
- **PropertyGrid**: A control from the PropertyTools library, used here to display and edit properties of objects.

This XAML sets up custom styles and templates for the `EditorMotion` and `EditorMotion_WWE2K24` controls, defining how they should appear and behave within the WPF application.

## /controls/flatbuffer/themes/generic.xaml

This XAML code defines a `ResourceDictionary` for a WPF application, specifically for styling a custom control named `FlatbufferControl`. Here’s a detailed breakdown of each part of the code:

### 1. **ResourceDictionary Declaration**

```xml
<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                    xmlns:local="clr-namespace:Meta.Editor.Controls"
                    xmlns:fb="clr-namespace:Meta.Structures.Flatbuffers;assembly=Meta.Structures.Flatbuffers"
                    xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes">
```

- **ResourceDictionary**: The root element that contains styles and resources.
- **xmlns**: XML namespaces for WPF, XAML, custom controls, and material design.
  - `local`: Refers to the namespace `Meta.Editor.Controls`.
  - `fb`: Refers to the namespace `Meta.Structures.Flatbuffers` from the assembly `Meta.Structures.Flatbuffers`.
  - `materialDesign`: Refers to Material Design themes in XAML.

### 2. **Merged Dictionaries**

```xml
<ResourceDictionary.MergedDictionaries>
    <ResourceDictionary Source="/Meta.Editor;component/Themes/Generic.xaml"/>
</ResourceDictionary.MergedDictionaries>
```

- **MergedDictionaries**: Merges other resource dictionaries, in this case, `Generic.xaml`.

### 3. **Converters**

```xml
<local:NullToZeroConverter x:Key="NullToZeroConverter"/>
<local:BoolToVisibilityConverter x:Key="BoolToVisibilityConverter"/>
```

- **NullToZeroConverter**: A custom converter that converts null values to zero.
- **BoolToVisibilityConverter**: A custom converter that converts boolean values to visibility values.

### 4. **Style for FlatbufferControl**

```xml
<Style TargetType="{x:Type local:FlatbufferControl}">
  <Setter Property="Control.Template">
    <Setter.Value>
      <ControlTemplate TargetType="{x:Type local:FlatbufferControl}">
        <Grid>
          <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*"/>
          </Grid.ColumnDefinitions>
          <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
          </Grid.RowDefinitions>
          <Border Grid.Row="0" Margin="1" BorderBrush="{StaticResource ListBackground}" BorderThickness="1" Visibility="Collapsed">
            <local:MetaWatermarkTextbox x:Name="PART_FilterTextBox" WatermarkText="Filter" Padding="4,2,4,2"/>
          </Border>
          <Border Grid.Row="1" BorderThickness="0,2,0,0" BorderBrush="{StaticResource ControlBackground}" FocusManager.FocusedElement="{Binding ElementName=PART_JsonTreeView}">
            <Grid>
              <Grid.RowDefinitions>
                <RowDefinition x:Name="RowDefinition0" Height="auto"/>
                <RowDefinition x:Name="RowDefinition1" Height="*"/>
              </Grid.RowDefinitions>
              <Border Grid.Row="0" Margin="1" BorderBrush="{StaticResource ListBackground}" BorderThickness="1" Visibility="Collapsed">
                <local:MetaWatermarkTextbox x:Name="BookmarkFilterTextBox" WatermarkText="Filter" Padding="4,2,4,2"/>
              </Border>
              <Border Grid.Row="1" BorderThickness="1">
                <TreeView x:Name="PART_JsonTreeView" VirtualizingPanel.IsVirtualizing="True" VirtualizingPanel.VirtualizationMode="Recycling" Background="#FF1D1D1D" ItemsSource="{Binding Items}">
                  <FrameworkElement.Resources>
                    <ContextMenu x:Key="SolutionContext" StaysOpen="true"/>
                  </FrameworkElement.Resources>
                  <ItemsControl.ItemContainerStyle>
                    <Style TargetType="{x:Type TreeViewItem}" BasedOn="{StaticResource baseTreeViewItemStyle}">
                      <Setter Property="Control.Foreground" Value="{StaticResource FontColor}"/>
                      <Setter Property="TreeViewItem.IsExpanded" Value="{Binding Path=IsExpanded, Mode=TwoWay}"/>
                    </Style>
                  </ItemsControl.ItemContainerStyle>
                  <ItemsControl.ItemTemplate>
                    <HierarchicalDataTemplate ItemsSource="{Binding Children}">
                      <Grid>
                        <Grid.ColumnDefinitions>
                          <ColumnDefinition Width="Auto"/>
                          <ColumnDefinition Width="Auto"/>
                          <ColumnDefinition Width="Auto"/>
                        </Grid.ColumnDefinitions>
                        <PackIcon x:Name="imageRect" Grid.Column="0" FrameworkElement.Width="18" FrameworkElement.Height="18" FrameworkElement.Margin="0,4,2,0" Kind="{Binding Icon}"/>
                        <TextBlock Grid.Column="1" Foreground="{StaticResource FontColor}" VerticalAlignment="Center" Margin="8,0,3,0" Text="{Binding Name}"/>
                        <Border Grid.Column="2" Background="{StaticResource ControlBackground}" Width="auto" Height="16" CornerRadius="2" Margin="5,0" Padding="5 0">
                          <TextBlock Foreground="White" HorizontalAlignment="Center" VerticalAlignment="Center" FontSize="10" FontWeight="Bold" Text="{Binding Children, Converter={StaticResource NullToZeroConverter}}"/>
                        </Border>
                      </Grid>
                      <DataTemplate.Triggers>
                        <DataTrigger Value="True" Binding="{Binding IsExpanded, RelativeSource={RelativeSource AncestorType={x:Type TreeViewItem}}}">
                          <Setter TargetName="imageRect" Value="{Binding IconExpand}" Property="PackIcon.Kind"/>
                        </DataTrigger>
                      </DataTemplate.Triggers>
                    </HierarchicalDataTemplate>
                  </ItemsControl.ItemTemplate>
                </TreeView>
              </Border>
            </Grid>
          </Border>
        </Grid>
      </ControlTemplate>
    </Setter.Value>
  </Setter>
</Style>
```

- **Style**: Defines the style for the `FlatbufferControl`.
- **TargetType**: Specifies the control type, `FlatbufferControl`, this style targets.
- **Setter**: Sets properties, here it sets the `Control.Template` property.
- **ControlTemplate**: Defines the visual structure of the `FlatbufferControl`.
- **Grid**: Layout panel organizing the elements in rows and columns.
- **Grid.ColumnDefinitions**: Defines one column with width stretched to fill the available space.
- **Grid.RowDefinitions**: Defines two rows, one with automatic height and one filling the remaining space.
- **Border**: Provides a border around elements, with various properties like `Grid.Row`, `Margin`, `BorderBrush`, and `Visibility`.
- **local:MetaWatermarkTextbox**: Custom text box with watermark text.
- **TreeView**: Displays hierarchical data, with properties for virtualization and binding to `Items`.
  - **FrameworkElement.Resources**: Contains resources like context menus.
  - **ItemsControl.ItemContainerStyle**: Styles for the items in the tree view.
  - **ItemsControl.ItemTemplate**: Template for the items, using `HierarchicalDataTemplate`.
    - **Grid**: Layout within the template with three columns.
    - **PackIcon**: Displays an icon, with properties bound to data.
    - **TextBlock**: Displays text, with properties bound to data.
    - **DataTemplate.Triggers**: Triggers for changing the template based on conditions, like item expansion.

### Key Points

- **Converters**: Provides custom logic for value conversion in bindings.
- **Styles**: Centralizes the visual definitions for `FlatbufferControl`, ensuring consistency.
- **Templates**: Defines the detailed layout for controls, using grids, borders, and custom elements.
- **Binding**: Connects the control properties to data sources for dynamic updates.

This resource dictionary enhances the modularity and maintainability of the WPF application by defining reusable styles and templates for custom controls.

## /controls/sdb/themes/generic.xaml

This XAML file is defining a `ResourceDictionary` that includes styles and templates for custom controls in a WPF (Windows Presentation Foundation) application. Let's break down the different sections:

### Root `ResourceDictionary`

```xml
<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                    xmlns:local="clr-namespace:Meta.Editor.Controls"
                    xmlns:fb="clr-namespace:Meta.Structures.Flatbuffers;assembly=Meta.Structures.Flatbuffers"
                    xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes">
```

- **xmlns**: Specifies XML namespaces used in the XAML file.
- **local**: References the `Meta.Editor.Controls` namespace.
- **fb**: References the `Meta.Structures.Flatbuffers` namespace and its assembly.
- **materialDesign**: References the Material Design in XAML toolkit themes.

### Merged Dictionaries

```xml
  <ResourceDictionary.MergedDictionaries>
    <ResourceDictionary Source="/Meta.Editor;component/Themes/Generic.xaml"/>
  </ResourceDictionary.MergedDictionaries>
```

- **MergedDictionaries**: Allows inclusion of other resource dictionaries. Here, it includes `Generic.xaml` from the `Meta.Editor` assembly.

### Custom Style for `MetaSDBControl`

```xml
  <Style TargetType="{x:Type local:MetaSDBControl}">
    <Setter Property="Control.Template">
      <Setter.Value>
        <ControlTemplate TargetType="{x:Type local:MetaSDBControl}">
          <Grid>
```

- **Style**: Defines a style for the `MetaSDBControl` type.
- **Control.Template**: Sets the control template for `MetaSDBControl`.

### Grid and Layout

```xml
            <Grid.ColumnDefinitions>
              <ColumnDefinition Width="*"/>
            </Grid.ColumnDefinitions>
            <Border BorderBrush="{StaticResource ControlBackground}" BorderThickness="0" Margin="2,0,2,0"
                    FocusManager.FocusedElement="{Binding ElementName=PART_DataGrid}">
              <Grid>
                <Grid.RowDefinitions>
                  <RowDefinition Height="Auto"/>
                  <RowDefinition Height="*"/>
                  <RowDefinition Height="Auto"/>
                </Grid.RowDefinitions>
```

- **Grid.ColumnDefinitions**: Defines a single column layout.
- **Border**: Adds a border around the control.
- **FocusManager.FocusedElement**: Sets the element that should receive focus initially.
- **Grid.RowDefinitions**: Defines three rows for the inner grid.

### Filter TextBox

```xml
                <Border Grid.Row="0" Margin="1" BorderBrush="{StaticResource ListBackground}" BorderThickness="1">
                  <local:MetaWatermarkTextbox x:Name="PART_FilterTextBox" WatermarkText="Filter" Padding="4,2,4,2"/>
                </Border>
```

- **Border**: Surrounds the filter textbox.
- **MetaWatermarkTextbox**: A custom textbox with a watermark, likely defined in `Meta.Editor.Controls`.

### DataGrid

```xml
                <DataGrid x:Name="PART_DataGrid" Grid.Row="1" AutoGenerateColumns="False" CanUserAddRows="False"
                          CanUserDeleteRows="False" CanUserReorderColumns="False" ScrollViewer.CanContentScroll="True"
                          SelectionMode="Single" ScrollViewer.VerticalScrollBarVisibility="Auto"
                          ScrollViewer.HorizontalScrollBarVisibility="Auto"
                          VirtualizingPanel.IsVirtualizingWhenGrouping="False" VirtualizingPanel.IsVirtualizing="true"
                          VirtualizingPanel.VirtualizationMode="Recycling" BorderBrush="{StaticResource ControlBackground}"
                          HeadersVisibility="Column" GridLinesVisibility="All" SelectionUnit="FullRow" IsReadOnly="False"
                          HorizontalAlignment="Stretch" Background="Transparent" Foreground="{StaticResource FontColor}">
```

- **DataGrid**: Displays data in a tabular format.
- **AutoGenerateColumns**: Disabled, meaning columns are manually defined.
- **VirtualizingPanel.IsVirtualizing**: Enables virtualization for performance optimization.
- **SelectionMode, ScrollViewer, VirtualizingPanel, HeadersVisibility, etc.**: Configure various properties of the `DataGrid`.

### DataGrid Columns

```xml
                  <DataGrid.Columns>
                    <DataGridTextColumn Header="Index" Width="50" IsReadOnly="True" Visibility="Collapsed" Binding="{Binding Index}"/>
                    <DataGridTextColumn Header="ID" Width=".7*" Binding="{Binding Id}">
                      <DataGridBoundColumn.EditingElementStyle>
                        <Style TargetType="{x:Type TextBox}" BasedOn="{StaticResource {x:Type TextBox}}"/>
                      </DataGridBoundColumn.EditingElementStyle>
                    </DataGridTextColumn>
                    <DataGridTextColumn Header="Text (Assigned String Data)" Width="6*" Binding="{Binding String}">
                      <DataGridBoundColumn.EditingElementStyle>
                        <Style TargetType="{x:Type TextBox}" BasedOn="{StaticResource {x:Type TextBox}}"/>
                      </DataGridBoundColumn.EditingElementStyle>
                    </DataGridTextColumn>
                    <DataGridTextColumn Header="Offset" Width="*" Visibility="Hidden" IsReadOnly="True" Binding="{Binding Offset}"/>
                  </DataGrid.Columns>
                </DataGrid>
```

- **DataGrid.Columns**: Defines the columns within the `DataGrid`.
- **DataGridTextColumn**: Represents a text column with various properties like header, width, binding, etc.
- **EditingElementStyle**: Specifies the style for the editing element.

### StackPanel for Input and Button

```xml
                <StackPanel Grid.Row="2" Orientation="Horizontal" Margin="5">
                  <Label Content="Text:" VerticalAlignment="Center"/>
                  <TextBox x:Name="PART_StringText" Width="400" Margin="0,5,0,0"/>
                  <Label Content="ID:" VerticalAlignment="Center"/>
                  <TextBox x:Name="PART_StringID" Width="180" Margin="0,5,0,0"
                           IsEnabled="{Binding ElementName=checkBox, Path=IsChecked}"/>
                  <Label Content="Override ID" VerticalAlignment="Center"/>
                  <CheckBox Name="checkBox" VerticalAlignment="Center" IsChecked="{Binding GUIDOverride}"/>
                  <Button x:Name="PART_NewSDB" Margin="10,0,0,0" Width="200">
                    <StackPanel Orientation="Horizontal">
                      <PackIcon Kind="ArchiveArrowUp" FrameworkElement.Margin="0,0,5,0"/>
                      <TextBlock Text="Add New"/>
                    </StackPanel>
                  </Button>
                </StackPanel>
              </Grid>
            </Border>
          </Grid>
        </ControlTemplate>
      </Setter.Value>
    </Setter>
  </Style>
</ResourceDictionary>
```

- **StackPanel**: Contains a series of input elements and a button.
- **Labels, TextBoxes, CheckBox, Button**: Elements for user input and actions.
- **Button**: Configured with an icon and text for adding new entries.

This `ResourceDictionary` customizes the appearance and behavior of the `MetaSDBControl` to create a user interface that includes a filterable `DataGrid` and input fields for text and IDs, with support for adding new entries.

## /images/

This directory contains image files used in the application. The images are typically used for icons, logos, backgrounds, or other visual elements within the user interface. The images are referenced in the XAML files or code to display them in the application.

## /Meta/Core/MetaLogger.cs

This C# code defines a `MetaLogger` class in the `Meta.Core` namespace, implementing the `ILogger` and `INotifyPropertyChanged` interfaces. This class provides logging functionality, including methods to log general information, warnings, and errors. Additionally, it supports data binding to UI elements to display log messages.

Here's a detailed explanation:

1. **Namespace and Usings**:

   - `Meta.Core.Interfaces`: This namespace likely contains the `ILogger` interface, which `MetaLogger` implements.
   - Standard namespaces like `System`, `System.ComponentModel`, `System.Reflection`, `System.Text`, `System.Windows`, and `System.Windows.Data` provide necessary classes and interfaces for the logger's functionality.

2. **Nullable Context**:

   - `#nullable enable`: Enables nullable reference types to help catch potential `null` reference issues at compile time.

3. **Class Definition**:

   - `public class MetaLogger : ILogger, INotifyPropertyChanged`: Declares the `MetaLogger` class implementing `ILogger` for logging and `INotifyPropertyChanged` for property change notifications.

4. **Private Field**:

   - `private StringBuilder sb = new StringBuilder();`: A `StringBuilder` instance to accumulate log messages efficiently.

5. **Property**:

   - `public string LogText => this.sb.ToString();`: A read-only property that returns the current log text as a string.

6. **Log Methods**:

   - `public void Log(string text, params object[] vars)`: Logs a general message. It appends the message to the `StringBuilder` with a timestamp and raises a property change notification.
   - `public void LogWarning(string text, params object[] vars)`: Logs a warning message in a similar manner, with "(WARNING)" prefix.
   - `public void LogError(string text, params object[] vars)`: Logs an error message with "(ERROR)" prefix.

   Each logging method uses `Assembly.GetCallingAssembly()` to retrieve the calling assembly, although the retrieved assembly is not used in the current implementation.

7. **AddBinding Method**:

   - `public void AddBinding(UIElement elementToBind, DependencyProperty propertyToBind)`: Sets up a one-way data binding between the `LogText` property and a specified property of a UI element. This enables the log text to be automatically updated in the UI when new log entries are added.

8. **INotifyPropertyChanged Implementation**:
   - `public event PropertyChangedEventHandler PropertyChanged;`: Declares an event for property change notifications.
   - `protected void RaisePropertyChanged(string name)`: Raises the `PropertyChanged` event to notify subscribers that a property value has changed. This is used after updating the `LogText` property to ensure the UI is updated.

Here is a simplified summary:

- The `MetaLogger` class logs messages (info, warning, error) with timestamps.
- It supports data binding to UI elements to display log messages.
- It implements `INotifyPropertyChanged` to notify the UI of changes to the log text.

This class is designed to be used in applications where logging and displaying log messages in the UI are needed, such as WPF applications.

## /Meta/Core/PluginManager.cs

This code is a C# implementation of a `PluginManager` class within the `Meta.Core` namespace. The `PluginManager` is responsible for loading, managing, and initializing plugins, specifically targeting a directory named "plug-ins". Here's a detailed breakdown of its components and functionalities:

### Namespaces and Libraries

- **Meta.Core.Interfaces, Meta.Editor, Meta.Editor.Plugin.Attributes**: These namespaces likely contain interfaces, classes, and attributes related to the core functionality and plugin architecture.
- **System, System.Collections.Generic, System.IO, System.Reflection, System.Runtime.CompilerServices**: Standard .NET libraries for basic system operations, collections, file handling, reflection, and compiler services.

### Nullable Context

- **#nullable enable**: Enables nullable reference types to enhance null safety.

### Class Definition: `PluginManager`

- **Private Fields**:

  - `m_plugins`: List of all plugins.
  - `m_loadedPlugins`: List of plugins that have been loaded.
  - `m_menuExtensions`: List of menu extensions.

- **Public Properties**:
  - `MenuExtensions`: Exposes the list of menu extensions.
  - `Plugins`: Exposes the list of all plugins.

### Constructor: `PluginManager(ILogger logger)`

- Checks if the "plug-ins" directory exists.
- Loads definitions from the entry assembly and executing assembly.
- Enumerates all `.dll` files in the "plug-ins" directory and adds them to `m_plugins`.

### Methods

#### `Initialize()`

- Loads definitions from each plugin's assembly and adds them to `m_loadedPlugins`.

#### `GetPluginAssembly(string name)`

- Searches for a plugin by name and returns its assembly.

#### `LoadPlugin(string pluginPath)`

- Creates a new `Plugin` object with the specified path.
- Attempts to load the assembly from the path.
- If successful, loads definitions from the assembly, updates the plugin status, logs the loading event, and sets the assembly in the plugin.
- If there is an exception, it stores the exception in the plugin's `LoadException` property.
- Returns the `Plugin` object.

#### `LoadDefinitionsFromAssembly(Assembly assembly)`

- Loads custom attributes from the assembly.
- Specifically looks for `RegisterMenuExtensionAttribute`.
- Validates that the type specified by the attribute extends `MenuExtension`.
- Creates an instance of the menu extension and adds it to `m_menuExtensions`.

### Plugin Class (Referenced but not Defined)

- **Meta.Editor.Plugin.Plugin**: Represents a plugin, containing properties like `Assembly`, `SourcePath`, `Status`, and `LoadException`.

### Attributes

- **RegisterMenuExtensionAttribute**: Custom attribute used to register menu extensions, ensuring they derive from the `MenuExtension` base class.

### Example Log Handling

- **ILogger**: Interface for logging events, such as loading plugins.

### Key Points

- **Reflection**: Used extensively to load assemblies and retrieve custom attributes.
- **Error Handling**: Exceptions during plugin loading are caught and stored in the `Plugin` object.
- **Directory and File Operations**: The class interacts with the file system to locate and load plugins.

### Usage Scenario

The `PluginManager` class is designed to be part of an extensible application, where functionality can be added or modified by adding new plugins. It ensures that plugins are loaded, their definitions are extracted, and any extensions to the menu system are registered and available for use.

This architecture allows for dynamic addition and management of plugins, making the application flexible and extensible.

## /Meta/Core/Converters/StatusToImageConverter.cs

This code defines a class `StatusToImageConverter` within the `Meta.Core.Converters` namespace. It implements the `IValueConverter` interface, which is part of the WPF (Windows Presentation Foundation) data binding infrastructure. This interface provides a way to apply custom logic in the process of converting a bound value from the source type to the target type and vice versa. Here's a detailed breakdown of the class and its methods:

### Namespaces and Libraries

- **System**: Provides basic classes and base classes that define commonly-used value and reference data types, events and event handlers, interfaces, attributes, and processing exceptions.
- **System.Globalization**: Contains classes that define culture-related information, including language, country/region, calendars, format patterns for dates, currency, and numbers, and sort order for strings.
- **System.Windows**: Contains WPF classes, including `DependencyProperty`.
- **System.Windows.Data**: Contains classes related to data binding in WPF, including `IValueConverter`.

### Nullable Context

- **#nullable enable**: Enables nullable reference types to enhance null safety.

### Class Definition: `StatusToImageConverter`

- Implements the `IValueConverter` interface.

### Methods

#### `Convert`

- **Parameters**:
  - `value`: The value produced by the binding source. Not used in this implementation.
  - `targetType`: The type of the binding target property. Not used in this implementation.
  - `parameter`: An optional parameter to use in the converter logic.
  - `culture`: The culture to use in the converter. Not used in this implementation.
- **Functionality**:
  - Checks if the `parameter` is null or empty after converting it to uppercase.
  - If the `parameter` is null or empty, it returns an empty string.
  - Otherwise, it returns the string `"FolderAccountOutline"`.
- **Return Value**:
  - Returns an empty string or `"FolderAccountOutline"` based on the condition.

```csharp
public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
{
  if (string.IsNullOrEmpty(parameter.ToString().ToUpper()))
    return (object) string.Empty;
  string empty = string.Empty;
  return (object) "FolderAccountOutline";
}
```

#### `ConvertBack`

- **Parameters**:
  - `value`: The value that is produced by the binding target.
  - `targetType`: The type to convert to.
  - `parameter`: An optional parameter to use in the converter logic.
  - `culture`: The culture to use in the converter. Not used in this implementation.
- **Functionality**:
  - This method is not implemented for actual conversion. It simply returns `DependencyProperty.UnsetValue`, indicating that no value conversion back to the source is provided or supported.
- **Return Value**:
  - Returns `DependencyProperty.UnsetValue`.

```csharp
public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
{
  return DependencyProperty.UnsetValue;
}
```

### Usage Scenario

The `StatusToImageConverter` class would be used in a WPF application where the status of an item needs to be converted to an image representation. For example, in a data-bound scenario, where the status value is bound to a UI element that displays an image based on the status.

### Key Points

- **IValueConverter Interface**: Provides the `Convert` and `ConvertBack` methods for custom value conversion in data binding.
- **Nullable Reference Types**: Ensures that the code handles null values safely.
- **Simple Conversion Logic**: The `Convert` method checks the parameter and returns a predefined string, whereas `ConvertBack` is not implemented and returns `DependencyProperty.UnsetValue`.

This converter is fairly basic and could be extended to include more complex logic as needed for different status values and corresponding images.

########################################################################
########################################################################

## /Meta/Editor/Controls/AccentPolicy.cs

### Code Explanation

1. **#nullable disable**

   - This directive disables nullable reference type warnings for this file. Nullable reference types are a feature in C# 8.0 and later that allows you to explicitly specify whether a reference type (such as a class) can be null or not. Disabling this feature means the compiler will not warn you about potential null reference exceptions.

2. **namespace Meta.Editor.Controls**

   - A namespace is a way to organize code and prevent naming conflicts. Here, `Meta.Editor.Controls` is the namespace that contains the `AccentPolicy` struct. It's a hierarchical way of grouping related classes, structs, and other types.

3. **internal struct AccentPolicy**

   - `internal` means that the `AccentPolicy` struct is accessible only within the same assembly (project). It cannot be accessed from other assemblies.
   - `struct` defines a value type, which is typically used for small data structures that contain primarily data and little or no behavior (methods).

4. **public AccentState AccentState;**

   - This is a public field of type `AccentState` within the `AccentPolicy` struct. The `AccentState` type is likely defined elsewhere in the code. Being public, it can be accessed from other classes or structs within the same assembly.

5. **public int AccentFlags;**

   - This is a public field of type `int` (integer) within the `AccentPolicy` struct. It can be accessed from other parts of the code within the same assembly.

6. **public int GradientColor;**

   - Another public integer field within the `AccentPolicy` struct. This field likely stores a color value in some format (e.g., ARGB).

7. **public int AnimationId;**
   - Yet another public integer field within the `AccentPolicy` struct. This might be used to store an identifier for a specific animation.

### Summary

This code defines an `internal` struct named `AccentPolicy` within the `Meta.Editor.Controls` namespace. The struct has four public fields:

- `AccentState AccentState`: Represents the state of the accent (type is defined elsewhere).
- `int AccentFlags`: Represents some flags related to the accent.
- `int GradientColor`: Represents the gradient color, likely in an integer format.
- `int AnimationId`: Represents an ID for an animation.

By disabling nullable reference type warnings, the code opts out of nullability checks, which can help avoid compiler warnings but may increase the risk of null reference exceptions if not handled carefully.

## /Meta/Editor/Controls/AccentState.cs

This C# code defines an `enum` named `AccentState` within the `Meta.Editor.Controls` namespace. Here’s a detailed explanation:

### Nullable Context

```csharp
#nullable disable
```

- `#nullable disable` is a preprocessor directive that disables nullable context warnings in the code that follows. This means that the compiler will not warn you about potential issues related to nullability, such as dereferencing a null reference.

### Namespace

```csharp
namespace Meta.Editor.Controls
```

- `namespace Meta.Editor.Controls` specifies that the following code belongs to the `Meta.Editor.Controls` namespace. Namespaces are used to organize code into a hierarchical structure and prevent name conflicts.

### Enum Definition

```csharp
internal enum AccentState
{
  ACCENT_ENABLE_GRADIENT,
  ACCENT_DISABLED,
  ACCENT_ENABLE_TRANSPARENTGRADIENT,
  ACCENT_ENABLE_BLURBEHIND,
  ACCENT_INVALID_STATE,
}
```

- `internal` is an access modifier that restricts the visibility of the `AccentState` enum to the current assembly. This means that `AccentState` can only be accessed by code within the same assembly and not from other assemblies.
- `enum AccentState` defines an enumeration named `AccentState`. An enum is a distinct type that consists of a set of named constants called the enumerator list.

### Enum Members

The `AccentState` enum has the following members:

- `ACCENT_ENABLE_GRADIENT`: Likely represents a state where an accent with a gradient effect is enabled.
- `ACCENT_DISABLED`: Represents a state where accents are disabled.
- `ACCENT_ENABLE_TRANSPARENTGRADIENT`: Represents a state where an accent with a transparent gradient effect is enabled.
- `ACCENT_ENABLE_BLURBEHIND`: Represents a state where an accent with a blur-behind effect is enabled.
- `ACCENT_INVALID_STATE`: Represents an invalid or undefined state for accents.

### Usage

Enums are commonly used to define a set of named values for a variable, making the code more readable and maintainable. In this context, the `AccentState` enum likely represents various visual styles or effects that can be applied to a UI element within the `Meta.Editor.Controls` namespace.

### Example Usage

Here’s an example of how you might use the `AccentState` enum in your code:

```csharp
public class AccentControl
{
    private AccentState currentState;

    public void SetAccentState(AccentState newState)
    {
        if (newState != AccentState.ACCENT_INVALID_STATE)
        {
            currentState = newState;
            ApplyAccentState();
        }
        else
        {
            throw new ArgumentException("Invalid accent state");
        }
    }

    private void ApplyAccentState()
    {
        // Logic to apply the accent state
        switch (currentState)
        {
            case AccentState.ACCENT_ENABLE_GRADIENT:
                // Apply gradient effect
                break;
            case AccentState.ACCENT_DISABLED:
                // Disable accent
                break;
            case AccentState.ACCENT_ENABLE_TRANSPARENTGRADIENT:
                // Apply transparent gradient effect
                break;
            case AccentState.ACCENT_ENABLE_BLURBEHIND:
                // Apply blur-behind effect
                break;
        }
    }
}
```

In this example, the `SetAccentState` method sets the current accent state and applies the corresponding visual effect based on the value of `currentState`.

## /Meta/Editor/Controls/AutoFilteredComboBox.cs

The `AutoFilteredComboBox` class is a custom control that extends the standard `ComboBox` in WPF (Windows Presentation Foundation) to provide automatic filtering of items based on the text input. Here is a breakdown of its functionality:

### Class Overview

- **Namespace and Imports**: The class is defined within the `Meta.Editor.Controls` namespace and includes several necessary imports such as `System`, `System.Collections`, `System.ComponentModel`, and various `System.Windows` and `System.Windows.Controls` namespaces.
- **Nullable Context**: The `#nullable enable` directive at the top enables nullable reference types to help avoid null reference exceptions.

### Fields and Properties

- **Private Fields**: Several private fields manage state and behavior, including `_silenceEvents`, `_collView`, `_savedText`, `_textSaved`, `_start`, `_length`, `_keyboardSelectionGuard`, and `_editableTextBoxSite`.
- **Dependency Properties**:
  - `IsCaseSensitiveProperty` controls whether the filtering is case-sensitive.
  - `DropDownOnFocusProperty` controls whether the dropdown opens when the combo box gains focus.

### Constructor

- **AutoFilteredComboBox()**: The constructor registers event handlers for changes in the `Text` property and the `IsCaseSensitive` property.

### Public Properties

- **IsCaseSensitive**: Gets or sets whether the filtering is case-sensitive.
- **DropDownOnFocus**: Gets or sets whether the dropdown should open when the control receives focus.
- **EditableTextBox**: Exposes the editable text box part of the combo box template.

### Methods

- **OnApplyTemplate**: Called when the control's template is applied. This method finds and sets up the editable text box and the popup parts of the template.
- **EditableTextBox_SelectionChanged**: Handles selection changes in the editable text box, updating the filter based on the current selection.
- **OnIsCaseSensitiveChanged**: Refreshes the filter when the `IsCaseSensitive` property changes.
- **OnTextChanged**: Updates the filter whenever the text changes, selecting the first matching item if text is entered.
- **OnGotFocus**: Opens the dropdown when the control gains focus, if the `DropDownOnFocus` property is true.
- **OnPreviewLostKeyboardFocus**: Restores saved text or selects the currently selected item when the control loses keyboard focus.
- **OnItemsSourceChanged**: Refreshes the items source (this method is incomplete in the decompiled code).
- **OnInitialized**: Calls the base initialization method.
- **OnItemsChanged**: Calls the base method for handling changes in the items collection.
- **OnPreviewKeyDown**: Handles key down events, particularly for Enter and other specific keys to manage keyboard interactions.
- **OnKeyDown**: Clears the filter when Enter is pressed.

### Helper Methods

- **RegisterIsCaseSensitiveChangeNotification**: Registers a change notification for the `IsCaseSensitive` property.
- **SilenceEvents** and **UnSilenceEvents**: Methods to manage `_silenceEvents` to prevent event handlers from executing during certain operations.
- **RefreshFilter**: Applies the filter to the items based on the current text.
- **FilterPredicate**: Defines the filtering logic, checking if the item contains the text entered by the user.
- **RestoreSavedText**: Restores the previously saved text.
- **ClearFilter**: Clears the current filter.
- **ScrollItemsToTop**: Scrolls the items in the dropdown to the top.

### Summary

This class enhances the standard `ComboBox` by adding functionality to filter the items dynamically as the user types, with additional features such as case sensitivity and dropdown behavior on focus. It includes various event handlers and helper methods to manage the internal state and ensure smooth operation of the filtering and selection mechanisms.

## /Meta/Editor/Controls/BoolToVisibilityConverter.cs

This C# code defines a class `BoolToVisibilityConverter` that implements the `IValueConverter` interface. This class is used in WPF (Windows Presentation Foundation) applications to convert a boolean value to a `Visibility` enumeration value for binding purposes. Here’s a detailed explanation of the code:

### Namespaces and Nullable Context

```csharp
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

#nullable enable
```

- `using System;`, `using System.Globalization;`, `using System.Windows;`, `using System.Windows.Data;`: These lines include the necessary namespaces for the classes and interfaces used in this file.
- `#nullable enable`: This directive enables nullable reference types to avoid null reference exceptions.

### Namespace and Class Definition

```csharp
namespace Meta.Editor.Controls
{
  public class BoolToVisibilityConverter : IValueConverter
  {
```

- `namespace Meta.Editor.Controls`: Defines a namespace to organize the code and avoid naming conflicts.
- `public class BoolToVisibilityConverter : IValueConverter`: Declares a public class `BoolToVisibilityConverter` that implements the `IValueConverter` interface.

### Convert Method

```csharp
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return value is bool flag && flag ? (object) Visibility.Collapsed : (object) Visibility.Visible;
    }
```

- `public object Convert(object value, Type targetType, object parameter, CultureInfo culture)`: This method is called when the value is passed from the source to the target (e.g., from a ViewModel to a View in MVVM pattern).
- `value is bool flag && flag`: Checks if the `value` is a boolean and assigns it to `flag`.
- `return value is bool flag && flag ? (object) Visibility.Collapsed : (object) Visibility.Visible;`: If `flag` is `true`, the method returns `Visibility.Collapsed`, otherwise, it returns `Visibility.Visible`.

### ConvertBack Method

```csharp
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
```

- `public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)`: This method is intended to convert a value back from the target to the source.
- `throw new NotImplementedException();`: This method is not implemented because the conversion back from `Visibility` to `bool` is not needed in this scenario.

### Closing Braces

```csharp
  }
}
```

- These lines close the class and namespace definitions.

### Summary

The `BoolToVisibilityConverter` class converts a boolean value to a `Visibility` enumeration value. If the boolean is `true`, it returns `Visibility.Collapsed`, and if `false`, it returns `Visibility.Visible`. This is useful in WPF applications for binding UI elements' visibility to boolean properties in the ViewModel. The `ConvertBack` method is not implemented because this conversion is one-way.

## /Meta/Editor/Controls/ContextMenuItem.cs

Let's break down this C# code snippet:

### Code Explanation

1. **using Directives**

   ```csharp
   using MaterialDesignThemes.Wpf;
   using Meta.Editor.Commands;
   using System;
   using System.Windows;
   using System.Windows.Controls;
   using System.Windows.Input;
   ```

   - These `using` directives import namespaces that contain various classes and methods used in the code. They are:
     - `MaterialDesignThemes.Wpf`: Likely contains the `PackIcon` and `PackIconKind` classes used for displaying icons.
     - `Meta.Editor.Commands`: Presumably contains the `RelayCommand` class.
     - `System`: Provides basic types and base classes.
     - `System.Windows`: Contains types for Windows Presentation Foundation (WPF) applications.
     - `System.Windows.Controls`: Provides various WPF controls, including `MenuItem`.
     - `System.Windows.Input`: Contains classes for commanding and input.

2. **#nullable enable**

   ```csharp
   #nullable enable
   ```

   - This directive enables nullable reference type warnings for this file. It helps the compiler enforce nullability rules and warns if you might be dereferencing a null reference.

3. **namespace Meta.Editor.Controls**

   ```csharp
   namespace Meta.Editor.Controls
   ```

   - This namespace groups related classes and other types under `Meta.Editor.Controls`, helping organize the code and prevent naming conflicts.

4. **public class ContextMenuItem : MenuItem**

   ```csharp
   public class ContextMenuItem : MenuItem
   ```

   - This defines a public class named `ContextMenuItem` that inherits from `MenuItem`. This means `ContextMenuItem` extends the functionality of the `MenuItem` control.

5. **Constructor**

   ```csharp
   public ContextMenuItem(
     string text,
     string tooltip,
     string icon,
     RelayCommand inCommand,
     bool isAddedByPlugin = false)
   {
     this.Header = (object) text;
     this.ToolTip = (object) tooltip;
     PackIconKind result;
     if (Enum.TryParse<PackIconKind>(icon, out result))
     {
       PackIcon packIcon = new PackIcon();
       packIcon.Kind = result;
       ((FrameworkElement) packIcon).Width = 16.0;
       ((FrameworkElement) packIcon).Height = 16.0;
       this.Icon = (object) packIcon;
     }
     this.Command = (ICommand) inCommand;
   }
   ```

   - The constructor initializes a new instance of the `ContextMenuItem` class. It takes five parameters:

     - `string text`: The text displayed on the menu item.
     - `string tooltip`: The tooltip text displayed when hovering over the menu item.
     - `string icon`: The name of the icon to display.
     - `RelayCommand inCommand`: A command to be executed when the menu item is clicked.
     - `bool isAddedByPlugin` (optional, defaults to `false`): Indicates whether the item is added by a plugin.

   - **Header and ToolTip**

     ```csharp
     this.Header = (object) text;
     this.ToolTip = (object) tooltip;
     ```

     - Sets the `Header` property (text of the menu item) and `ToolTip` property (tooltip text) to the provided values.

   - **Icon Parsing and Setting**

     ```csharp
     PackIconKind result;
     if (Enum.TryParse<PackIconKind>(icon, out result))
     {
       PackIcon packIcon = new PackIcon();
       packIcon.Kind = result;
       ((FrameworkElement) packIcon).Width = 16.0;
       ((FrameworkElement) packIcon).Height = 16.0;
       this.Icon = (object) packIcon;
     }
     ```

     - Tries to parse the `icon` string to a `PackIconKind` enum value.
     - If successful, creates a `PackIcon` object, sets its `Kind` property, and adjusts its width and height.
     - Sets the `Icon` property of the menu item to the created `PackIcon`.

   - **Command Assignment**

     ```csharp
     this.Command = (ICommand) inCommand;
     ```

     - Sets the `Command` property of the menu item to the provided `RelayCommand`.

### Summary

This code defines a custom `ContextMenuItem` class that extends `MenuItem` to include additional functionality for setting text, tooltip, icon, and command. The constructor takes parameters for these properties, and it attempts to parse the icon string into a `PackIconKind` enum. If successful, it creates and sets a `PackIcon` as the icon for the menu item. The command to be executed on click is also assigned through the constructor. This class leverages Material Design icons for WPF and custom commands defined in the `Meta.Editor.Commands` namespace.

## /Meta/Editor/Controls/CreationWindow.cs

This C# code defines a `CreationWindow` class within the `Meta.Editor.Controls` namespace. This class inherits from `MetaWindow` and implements the `IComponentConnector` interface. The class is responsible for managing a window that provides various creation profiles, such as character and belt profiles, likely for a game editor.

### Breakdown of the Code

#### Using Directives

These are the namespaces that are being used in the code:

```csharp
using Meta.Core;
using Meta.Editor.Controls.CreationSuite;
using MetaEditor;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
```

These directives bring various classes and methods into scope, enabling their use without needing to fully qualify their names.

#### Nullable Context

```csharp
#nullable enable
```

This directive enables nullable reference types and associated warnings, helping to avoid null reference exceptions.

### Namespace and Class Definition

```csharp
namespace Meta.Editor.Controls
{
  public class CreationWindow : MetaWindow, IComponentConnector
```

Defines the `CreationWindow` class within the `Meta.Editor.Controls` namespace. This class inherits from `MetaWindow` and implements the `IComponentConnector` interface, which is used for connecting components in XAML-based applications.

#### DependencyProperty

```csharp
public static readonly DependencyProperty ObjectProperty = DependencyProperty.Register(
    nameof(Object),
    typeof(object),
    typeof(CreationWindow),
    new FrameworkPropertyMetadata(null, new PropertyChangedCallback(CreationWindow.OnObjectChanged))
);
```

- `ObjectProperty` is a `DependencyProperty` that allows for binding and property change notifications in WPF.
- `OnObjectChanged` is a callback method that gets invoked when the value of `ObjectProperty` changes.

### Internal Fields

```csharp
internal Grid mainGrid;
internal Menu menu;
internal MenuItem NewCreationProfile;
internal MenuItem CreateCharacterProfile;
internal MenuItem CreateBeltProfile;
internal MenuItem OpenModMenuItem;
internal MenuItem SaveAsModMenuItem;
internal MenuItem ExitMenuItem;
internal MetaTabControl tabControl;
internal MetaDetachedTabControl tabContent;
internal MetaTabControl miscTabControl;
internal TextBox log;
private bool _contentLoaded;
```

These fields represent various UI elements and internal state management for the `CreationWindow` class. They are marked as `internal`, meaning they are accessible within the same assembly.

### Property and Methods

#### Property: `Object`

```csharp
public object Object
{
  get => this.GetValue(CreationWindow.ObjectProperty);
  set => this.SetValue(CreationWindow.ObjectProperty, value);
}
```

Defines a property `Object` that wraps around the `ObjectProperty` dependency property.

#### OnObjectChanged Method

```csharp
private static void OnObjectChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
{
  CreationWindow creationWindow = sender as CreationWindow;
  if (args.NewValue == null)
    return;
  creationWindow.ProcessClassEditors(args.NewValue);
}
```

This method is called when the `Object` property changes. It processes the new value and updates the UI accordingly.

### Constructor: `CreationWindow`

```csharp
public CreationWindow()
{
  this.InitializeComponent();
  this.tabContent.HeaderControl = this.tabControl;
  RoutedCommand routedCommand1 = new RoutedCommand();
  RoutedCommand routedCommand2 = new RoutedCommand();
  routedCommand1.InputGestures.Add(new KeyGesture(Key.O, ModifierKeys.Control));
  routedCommand2.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control));
  this.CommandBindings.Add(new CommandBinding(routedCommand1, this.OpenCreationProfile_Click));
  this.CommandBindings.Add(new CommandBinding(routedCommand2, this.SaveAsModMenuItem_Click));
}
```

The constructor initializes the `CreationWindow` instance, sets up command bindings, and calls `InitializeComponent` to load the XAML-defined components.

### Event Handlers and Helper Methods

- **`tabControl_SelectionChanged`**: Handles changes in tab selection.
- **`LogTextBox_TextChanged`**: Handles text changes in the log text box.
- **`MetaWindow_Loaded`**: Handles the window loaded event and binds the logger.
- **`ProcessClassEditors`**: Processes class editors based on the provided object value.
- **`RemoveAllTabs`** and **`RemoveTab`**: Methods to manage tabs in the UI.
- **`CreateCharacterProfile_Click`** and **`CreateBeltProfile_Click`**: Handle click events for creating character and belt profiles.
- **`SaveAsModMenuItem_Click`** and **`OpenCreationProfile_Click`**: Handle click events for saving and opening creation profiles.
- **`CreationControlFromGame`**: Creates a `CreationControl` instance based on game and profile type.
- **`ExitMenuItem_Click`**: Closes the window.

### InitializeComponent Method

```csharp
[DebuggerNonUserCode]
[GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
public void InitializeComponent()
{
  if (this._contentLoaded)
    return;
  this._contentLoaded = true;
  Application.LoadComponent(this, new Uri("/Meta.Editor;V1.0.5.32;component/controls/creationsuite/creationwindow.xaml", UriKind.Relative));
}
```

This method loads the XAML-defined components and ensures they are initialized only once.

### IComponentConnector Implementation

```csharp
[DebuggerNonUserCode]
[GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
void IComponentConnector.Connect(int connectionId, object target)
{
  switch (connectionId)
  {
    case 1:
      this.mainGrid = (Grid) target;
      break;
    // other cases to initialize internal fields
    default:
      this._contentLoaded = true;
      break;
  }
}
```

This method connects the components defined in XAML with the internal fields of the `CreationWindow` class, enabling interaction between the code-behind and the UI elements.

This comprehensive structure of the `CreationWindow` class ensures a robust and interactive user interface for managing creation profiles in a WPF application.

## /Meta/Editor/Controls/Editor.cs

The `Editor` class within the `Meta.Editor.Controls` namespace is designed to manage and manipulate a `MetaAsset` in a graphical editor. It supports functionalities such as monitoring file changes, importing/exporting data, and handling user interface elements like toolbars and context menus. Here's a breakdown of its components and functionalities:

### Namespaces and Imports

The class uses a variety of namespaces to support its functionalities:

- `Meta.Core`, `Meta.Core.Interfaces`, `Meta.Core.IO`, etc., are presumably custom namespaces within the Meta project.
- `Microsoft.CSharp.RuntimeBinder`, `Microsoft.Win32`, `Newtonsoft.Json.Linq`, `Notification.Wpf`, etc., are external libraries and system namespaces for runtime binding, file dialogs, JSON handling, and notifications.

### Fields and Properties

- **Protected Fields**:

  - `logger`: For logging activities.
  - `FControl`: Instance of `FlatbufferControl`, likely a UI control for handling Flatbuffers.
  - `asset`: Represents the `MetaAsset` being edited.
  - `Resource`: Byte array for storing resource data.
  - `watcher`: Instance of `FileSystemSafeWatcher` for monitoring file changes.
  - `watching`: Boolean indicating if the watcher is active.
  - `schema`: Represents the schema for the Flatbuffer.
  - `parent`: Stores the parent object.

- **Public Properties**:
  - `Asset`: Gets or sets the `MetaAsset`.
  - `Icon`: String property for the editor's icon.
  - `Data`: Object to hold arbitrary data.
  - `Schema`: Gets or sets the `FlatbufferSchema`.
  - `IsWatching`: Boolean indicating if the editor is actively watching a file.
  - `Parent`: Gets or sets the parent object.

### Constructor

- **Editor(ILogger inLogger = null, FlatbufferSchema \_schema = null, string file = null)**: Initializes the editor with optional logger, schema, and file parameters.

### Methods

- **Initialize**: Sets up the editor with the given sender object, attaches event handlers, and starts watching the file if necessary.
- **BuildTreeNodes**: Constructs a tree of `MetaFlatbufferItem` objects from a JSON object, supporting both arrays and objects. This method uses dynamic binding to handle various JSON structures.
- **CreateRootNode**: Creates the root node of the tree by deserializing the asset and building the tree nodes.
- **OnChanged**: Handles file change events, logging the event and triggering serialization.
- **OnEngineChanged**: Handles changes in the engine version, updating the configuration accordingly.
- **Export**: Exports the asset data to a specified location and sets up file watching if needed.
- **OnEnterQueue**: Manages the asset's entry into a serialization queue, backing up the file and triggering notifications.
- **Import**: Imports data from a file, handling backups and updating the asset and its configuration.
- **RegisterToolbarItems**: Virtual method to register toolbar items, returning an empty list by default.
- **RegisterContextMenuItems**: Virtual method to register context menu items, returning an empty list by default.
- **Shutdown**: Stops watching the file and disposes of the watcher.
- **Dispose**: Implements the `IDisposable` interface to clean up resources, particularly the file watcher.

### Event Handling

- **File Watching**: Uses `FileSystemSafeWatcher` to monitor changes in the asset's file and triggers actions like serialization and logging when changes are detected.
- **Engine Change**: Updates configuration when the engine version changes, ensuring the correct version is used.

### Dynamic Binding

- The class uses `Microsoft.CSharp.RuntimeBinder` to dynamically bind and manipulate JSON data, allowing it to handle various structures without knowing their exact types at compile time.

### Summary

The `Editor` class is a sophisticated component for managing and editing `MetaAsset` objects within a graphical editor. It supports file watching, importing/exporting data, dynamic JSON manipulation, and integration with UI elements like toolbars and context menus. The class is designed to be extendable, with several virtual methods allowing for customization in derived classes.

## /Meta/Editor/Controls/EditorCharProfileTable.cs

This C# code is a class definition for `EditorCharProfileTable` within a WPF (Windows Presentation Foundation) application. The class inherits from `Meta.Editor.Controls.Editor` and is designed to handle character profile data for the game "WWE 2K23." Here's a breakdown of the key components and functionality:

### Namespaces and Nullable Context

```csharp
using Meta.Core;
using Meta.Core.Attributes;
using Meta.Core.Interfaces;
using Meta.Editor.Commands;
using Meta.Editor.Converters;
using Meta.Editor.IO.WWE2K23;
using Meta.Editor.Windows;
using Meta.Structures.Flatbuffers;
using Meta.Structures.Flatbuffers.WWE2K23;
using Meta.WWE2K23;
using MetaEditor;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Win32;
using Newtonsoft.Json;
using Ookii.Dialogs.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

#nullable enable
```

These lines include necessary namespaces for various functionalities such as logging, JSON handling, file dialogs, and WPF controls. The `#nullable enable` directive enables nullable reference types to prevent null reference exceptions.

### Class Definition and Attributes

```csharp
namespace Meta.Editor.Controls
{
  [EditorType("Prof")]
  [GameVersion("WWE 2K23")]
  public class EditorCharProfileTable : Meta.Editor.Controls.Editor
  {
```

- The class is defined within the `Meta.Editor.Controls` namespace.
- `EditorType` and `GameVersion` attributes specify metadata for the editor type and game version.

### Properties and Constructor

```csharp
    protected bool GameWasClosed;

    public override string Icon => "Table";

    protected ICollection<long> CharacterProfileOffsets { get; set; }

    protected ICollection<long> CharacterMotionOffsets { get; set; }

    public EditorCharProfileTable(ILogger inLogger, FlatbufferSchema _schema, string filename)
      : base(inLogger, _schema, filename)
    {
    }
```

- `GameWasClosed` is a flag indicating whether the game was closed.
- `Icon` is an overridden property returning the icon string.
- `CharacterProfileOffsets` and `CharacterMotionOffsets` are collections to store memory offsets for character profiles and motions.
- The constructor initializes the class with a logger, schema, and filename.

### Initialize Method

```csharp
    public override void Initialize(object sender)
    {
      base.Initialize(sender);
      if (App.ActiveGame == null)
        return;
      App.ActiveGame.Exited += new EventHandler(this.ActiveGame_Exited);
    }

    private void ActiveGame_Exited(object? sender, EventArgs e)
    {
      this.GameWasClosed = true;
      App.GameRunning = false;
    }
```

- `Initialize` sets up the event handler for when the game exits.
- `ActiveGame_Exited` sets `GameWasClosed` to `true` and updates `App.GameRunning` to `false`.

### Toolbar and Context Menu Registration

```csharp
    public override List<ToolbarItem> RegisterToolbarItems()
    {
      List<ToolbarItem> toolbarItemList = base.RegisterToolbarItems();
      toolbarItemList.Add(new ToolbarItem("Prime Memory", "Initialize game memory regions for injection", "Memory", new RelayCommand((Action<object>) (state => this.PrimeMemory_Click((object) this, new RoutedEventArgs())))));
      toolbarItemList.Add(new ToolbarItem("Bulk Import", "Bulk import character profile stats", "PackageUp", new RelayCommand((Action<object>) (state => this.BulkImport_Click((object) this, new RoutedEventArgs())))));
      return toolbarItemList;
    }

    public override List<ContextMenuItem> RegisterContextMenuItems()
    {
      List<ContextMenuItem> contextMenuItemList = base.RegisterContextMenuItems();
      contextMenuItemList.Add(new ContextMenuItem("Import Full Character Profile", "Import a Wrestler's data to the desired slot", "FileImport", new RelayCommand((Action<object>) (state => this.ImportProfile_Click((object) this, new RoutedEventArgs())))));
      contextMenuItemList.Add(new ContextMenuItem("Import Character Only", "Import a Wrestler's profile information only", "FaceManProfile", new RelayCommand((Action<object>) (state => this.ImportCharacter_Click((object) this, new RoutedEventArgs())))));
      contextMenuItemList.Add(new ContextMenuItem("Import Motion Only", "Import a Wrestler's profile motion data only", "ExitRun", new RelayCommand((Action<object>) (state => this.ImportMotion_Click((object) this, new RoutedEventArgs())))));
      contextMenuItemList.Add(new ContextMenuItem("Import Moveset Only", "Import a Wrestler's profile moveset data only", "RunFast", new RelayCommand((Action<object>) (state => this.ImportMoveset_Click((object) this, new RoutedEventArgs())))));
      contextMenuItemList.Add(new ContextMenuItem("Extract All", "Extract all character profiles", "DatabaseExport", new RelayCommand((Action<object>) (state => this.ExportAllMemory_Click((object) this, new RoutedEventArgs())))));
      contextMenuItemList.Add(new ContextMenuItem("Extract Full Character Profile", "Extract the character data from memory", "FileExport", new RelayCommand((Action<object>) (state => this.ExportMemory_Click((object) this, new RoutedEventArgs())))));
      return contextMenuItemList;
    }
```

- `RegisterToolbarItems` and `RegisterContextMenuItems` methods register items for the toolbar and context menu, respectively. Each item is associated with a specific action command.

### Memory Operations

The methods for exporting and importing memory handle the interaction with the game's memory regions, using various dialogs to select files and folders and performing read/write operations on the memory.

#### Export Memory

```csharp
    private void ExportAllMemory_Click(object sender, RoutedEventArgs e) { /* Implementation */ }

    private void ExportMemory_Click(object sender, RoutedEventArgs e) { /* Implementation */ }
```

These methods handle exporting all character profiles or a single profile from memory to JSON files.

#### Import Memory

```csharp
    protected virtual bool ImportMemory(EditorCharProfileTable.ImportMethod method) { /* Implementation */ }

    private void ImportMotion_Click(object sender, RoutedEventArgs e) { /* Implementation */ }

    private void ImportMoveset_Click(object sender, RoutedEventArgs e) { /* Implementation */ }

    private void ImportCharacter_Click(object sender, RoutedEventArgs e) { /* Implementation */ }

    private void ImportProfile_Click(object sender, RoutedEventArgs e) { /* Implementation */ }

    protected virtual void BulkImport_Click(object sender, RoutedEventArgs e) { /* Implementation */ }
```

These methods handle importing character profiles, motions, and movesets from JSON files into memory. The `ImportMemory` method is a generalized method called by specific import actions.

### Priming Memory

```csharp
    protected virtual void PrimeMemory_Click(object sender, RoutedEventArgs e)
    {
      if (App.GameRunning)
      {
        MetaTaskWindow.Show("Priming Memory", "This may take a minute - do not exit this window", (MetaTaskCallback) (async task =>
        {
          this.CharacterProfileOffsets = (ICollection<long>) null;
          IEnumerable<long> ProfileRegionSearchTable = App.MemoryManager.AoBScanAsync(App.CurrentGame.Memory.AOB["Profile"], App.CurrentGame.Exe, App.CurrentGame.Memory.MaximumReach);
          int TotalRegions = ProfileRegionSearchTable.Count<long>();
          if (TotalRegions > 0)
          {
            List<long> ProfileCleanTable = ProfileRegionSearchTable.ToList<long>();
            ProfileCleanTable.RemoveAt(ProfileCleanTable.Count - 1);
            for (int i = 0; i < ProfileCleanTable.Count; ++i)
            {
              ProfileCleanTable[i] -= (long) (App.CurrentGame.Memory.Regions["ProfileSize"] * 100);
              this.logger.Log("Found {0} [Character] location", new object[1]
              {
                (object) ProfileCleanTable[i]
              });
            }
            this.CharacterProfileOffsets = (ICollection<long>) ProfileCleanTable;
            this.logger.Log("Found {0} total [Character] memory locations", new object[1]
            {
              (object) TotalRegions
            });
            ProfileCleanTable = (List<long>) null;
          }
          long BaseAddress = 0;
          IEnumerable<long> MotionRegionSearchTable = App.MemoryManager.AoBScanAsync(App.CurrentGame.Memory.AOB["UniverseMotion"], App.CurrentGame.Exe, App.CurrentGame.Memory.MaximumReach, ref BaseAddress);
          TotalRegions = MotionRegionSearchTable.Count<long>();
          this.CharacterMotionOffsets = (ICollection<long>) new List<long>();
          if (TotalRegions > 0)
          {
            List<long> MotionCleanTable = MotionRegionSearchTable.ToList<long>();
            for (int i = 0; i < MotionCleanTable.Count; ++i)
            {
              long MotionAddy = MotionCleanTable[i] + (long) App.CurrentGame.Memory.Regions["MotionUniverseSize"];
              if (!App.MemoryManager.ReadMByte(App.CurrentGame.Exe, 1L, MotionAddy, (byte) 1))
              {
                this.CharacterMotionOffsets.Add(MotionAddy - 1L - (long) (App.CurrentGame.Memory.Regions["MotionSize"] * 100));
                this.logger.Log("Found {0} [Motion] location", new object[1]
                {
                  (object) (MotionAddy - 1L - (long) (App.CurrentGame.Memory.Regions["MotionSize"] * 100))
                });
              }
            }
            MotionCleanTable =

 (List<long>) null;
          }
          this.CharacterMotionOffsets.Add(BaseAddress + (long) App.CurrentGame.Memory.Regions["MotionStatic"] - (long) (App.CurrentGame.Memory.Regions["MotionSize"] * 100));
          this.logger.Log("Found {0} total [Motion] memory locations (including static)", new object[1]
          {
            (object) this.CharacterMotionOffsets.Count
          });
          ProfileRegionSearchTable = (IEnumerable<long>) null;
          MotionRegionSearchTable = (IEnumerable<long>) null;
        }));
      }
      else
      {
        int num = (int) MetaMessageBox.Show("Game was not found, attempting resync (check log)", "Meta Memory Manager");
        if (App.InitiateWatchGame())
          this.GameWasClosed = false;
      }
    }
```

The `PrimeMemory_Click` method scans the game's memory to find offsets for character profiles and motions, initializing these memory regions for future operations.

### CreateRootNode Method

```csharp
    public override MetaFlatbufferItem CreateRootNode()
    {
      CharProfileTableArchive profileTableArchive = this.Asset.Deserialize<CharProfileTableArchive>();
      MetaFlatbufferItem rootNode = new MetaFlatbufferItem()
      {
        Name = "root"
      };
      rootNode.Children = new ObservableCollection<MetaFlatbufferItem>();
      MetaFlatbufferItem metaFlatbufferItem1 = new MetaFlatbufferItem()
      {
        Name = "characters"
      };
      metaFlatbufferItem1.Children = new ObservableCollection<MetaFlatbufferItem>();
      rootNode.Children.Add(metaFlatbufferItem1);
      int num = 0;
      foreach (RosterTable rosterTable in profileTableArchive.table)
      {
        MetaFlatbufferItem metaFlatbufferItem2 = new MetaFlatbufferItem()
        {
          Index = num,
          Name = string.Format("Wrestler ID: {0} | Slot ID: {1}", (object) rosterTable.wrestler_id, (object) rosterTable.slot_id),
          Pointer = (int) rosterTable.slot_id,
          Data = (object) rosterTable,
          Icon = "TextBoxOutline"
        };
        metaFlatbufferItem1.Children.Add(metaFlatbufferItem2);
        ++num;
      }
      IOrderedEnumerable<MetaFlatbufferItem> collection = metaFlatbufferItem1.Children.OrderBy<MetaFlatbufferItem, int>((Func<MetaFlatbufferItem, int>) (ite => ite.Pointer));
      metaFlatbufferItem1.Children = new ObservableCollection<MetaFlatbufferItem>((IEnumerable<MetaFlatbufferItem>) collection);
      metaFlatbufferItem1.IsExpanded = true;
      rootNode.IsExpanded = true;
      return rootNode;
    }
```

This method creates a root node for the tree view of character profiles, organizing them by wrestler ID and slot ID.

### ImportMethod Enum

```csharp
    public enum ImportMethod
    {
      Full,
      Motion,
      Moveset,
      Character,
    }
  }
}
```

Defines an enumeration for different import methods: Full, Motion, Moveset, and Character.

### Summary

The `EditorCharProfileTable` class is a specialized WPF editor for managing character profiles in the game "WWE 2K23." It handles memory operations for importing and exporting character data, registers toolbar and context menu items for these actions, and provides methods to initialize and manage these processes. The class also includes functionality for priming memory and creating a root node for the character profiles in the UI.

## /Meta/Editor/Controls/EditorCharProfileTable_WWE2K24.cs

The provided code defines a class `EditorCharProfileTable_WWE2K24` which is used to manage and edit character profile tables for the game WWE 2K24. The class is part of the `Meta.Editor.Controls` namespace and extends the `EditorCharProfileTable` class.

Here's a breakdown of its key components:

### Namespaces and Dependencies

The class imports several namespaces and dependencies, which are necessary for its functionality, including:

- `Meta.Core`, `Meta.Core.Attributes`, `Meta.Core.Interfaces`, `Meta.Editor.Converters`, `Meta.Editor.Windows`, `Meta.Structures.Flatbuffers`, `Meta.Structures.Flatbuffers.WWE2K24`, `Meta.WWE2K23`, `MetaEditor`, `Microsoft.CSharp.RuntimeBinder`, `Microsoft.Win32`, `Newtonsoft.Json`, `System`, `System.Collections.Generic`, `System.Collections.ObjectModel`, `System.IO`, `System.Linq`, `System.Runtime.CompilerServices`, `System.Windows`, `System.Windows.Controls`.

### Class Definition and Attributes

The class `EditorCharProfileTable_WWE2K24` is decorated with two custom attributes:

- `[EditorType("Prof")]`: Specifies the type of editor.
- `[GameVersion("WWE 2K24")]`: Indicates the game version this editor is designed for.

### Constructor

The constructor initializes the class with an `ILogger` instance, a `FlatbufferSchema` object, and a filename. It calls the base class constructor with these parameters.

```csharp
public EditorCharProfileTable_WWE2K24(
  ILogger inLogger,
  FlatbufferSchema _schema,
  string filename)
  : base(inLogger, _schema, filename)
{
}
```

### CreateRootNode Method

This method creates the root node of the character profile table. It deserializes the `CharProfileTableArchive` from the asset and populates a tree structure with character data.

```csharp
public override MetaFlatbufferItem CreateRootNode()
{
  CharProfileTableArchive profileTableArchive = this.Asset.Deserialize<CharProfileTableArchive>();
  MetaFlatbufferItem rootNode = new MetaFlatbufferItem() { Name = "root" };
  rootNode.Children = new ObservableCollection<MetaFlatbufferItem>();
  MetaFlatbufferItem metaFlatbufferItem1 = new MetaFlatbufferItem() { Name = "characters" };
  metaFlatbufferItem1.Children = new ObservableCollection<MetaFlatbufferItem>();
  rootNode.Children.Add(metaFlatbufferItem1);
  int num = 0;
  foreach (RosterTable rosterTable in profileTableArchive.table)
  {
    MetaFlatbufferItem metaFlatbufferItem2 = new MetaFlatbufferItem()
    {
      Index = num,
      Name = string.Format("Wrestler ID: {0} | Slot ID: {1}", rosterTable.wrestler_id, rosterTable.slot_id),
      Pointer = (int) rosterTable.slot_id,
      Data = rosterTable,
      Icon = "CircleSmall"
    };
    metaFlatbufferItem1.Children.Add(metaFlatbufferItem2);
    ++num;
  }
  IOrderedEnumerable<MetaFlatbufferItem> collection = metaFlatbufferItem1.Children.OrderBy(ite => ite.Pointer);
  metaFlatbufferItem1.Children = new ObservableCollection<MetaFlatbufferItem>(collection);
  metaFlatbufferItem1.IsExpanded = true;
  rootNode.IsExpanded = true;
  return rootNode;
}
```

### PrimeMemory_Click Method

This method handles the click event for priming memory. It scans and logs memory locations related to character profiles and motions in the game.

```csharp
protected override void PrimeMemory_Click(object sender, RoutedEventArgs e)
{
  if (App.GameRunning)
  {
    MetaTaskWindow.Show("Priming Memory", "This may take a minute - do not exit this window", async task =>
    {
      this.CharacterProfileOffsets = null;
      IEnumerable<long> ProfileRegionSearchTable = App.MemoryManager.AoBScanAsync(App.CurrentGame.Memory.AOB["Profile"], App.CurrentGame.Exe, App.CurrentGame.Memory.MaximumReach);
      int TotalRegions = ProfileRegionSearchTable.Count();
      if (TotalRegions > 0)
      {
        List<long> ProfileCleanTable = ProfileRegionSearchTable.ToList();
        for (int i = 0; i < ProfileCleanTable.Count; ++i)
        {
          ProfileCleanTable[i] -= (long) (App.CurrentGame.Memory.Regions["ProfileSize"] * 100);
          this.logger.Log("Found {0} [Character] location", ProfileCleanTable[i]);
        }
        this.CharacterProfileOffsets = ProfileCleanTable;
        this.logger.Log("Found {0} total [Character] memory locations", TotalRegions);
        ProfileCleanTable = null;
      }
      long BaseAddress = 0;
      IEnumerable<long> MotionRegionSearchTable = App.MemoryManager.AoBScanAsync(App.CurrentGame.Memory.AOB["UniverseMotion"], App.CurrentGame.Exe, App.CurrentGame.Memory.MaximumReach, ref BaseAddress);
      TotalRegions = MotionRegionSearchTable.Count();
      this.CharacterMotionOffsets = new List<long>();
      if (TotalRegions > 0)
      {
        List<long> MotionCleanTable = MotionRegionSearchTable.ToList();
        for (int i = 0; i < MotionCleanTable.Count; ++i)
        {
          long MotionAddy = MotionCleanTable[i] + (long) App.CurrentGame.Memory.Regions["MotionUniverseSize"];
          if (!App.MemoryManager.ReadMByte(App.CurrentGame.Exe, 1L, MotionAddy, (byte) 1))
          {
            this.CharacterMotionOffsets.Add(MotionAddy - 1L - (long) (App.CurrentGame.Memory.Regions["MotionSize"] * 100));
            this.logger.Log("Found {0} [Motion] location", MotionAddy - 1L - (long) (App.CurrentGame.Memory.Regions["MotionSize"] * 100));
          }
        }
        MotionCleanTable = null;
      }
      this.CharacterMotionOffsets.Add(BaseAddress + (long) App.CurrentGame.Memory.Regions["MotionStatic"] - (long) (App.CurrentGame.Memory.Regions["MotionSize"] * 100));
      this.logger.Log("Found {0} total [Motion] memory locations (including static)", this.CharacterMotionOffsets.Count);
      ProfileRegionSearchTable = null;
      MotionRegionSearchTable = null;
    });
  }
  else
  {
    int num = (int) MetaMessageBox.Show("Game was not found, attempting resync (check log)", "Meta Memory Manager");
    if (App.InitiateWatchGame())
      this.GameWasClosed = false;
  }
}
```

### ImportMemory Method

This method imports memory from a profile file. It handles different import methods and updates the game's memory regions with the imported data.

```csharp
protected override bool ImportMemory(EditorCharProfileTable.ImportMethod method)
{
  if (!this.GameWasClosed)
  {
    if (App.GameRunning)
    {
      if (this.CharacterProfileOffsets != null && this.CharacterProfileOffsets.Count > 0)
      {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        openFileDialog1.Filter = "(All supported formats)|*.json";
        openFileDialog1.Title = "Open Profile";
        openFileDialog1.Multiselect = false;
        OpenFileDialog openFileDialog2 = openFileDialog1;
        bool? nullable = openFileDialog2.ShowDialog();
        bool flag = true;
        if (nullable.GetValueOrDefault() == flag & nullable.HasValue)
        {
          Profile profile = JsonConvert.DeserializeObject<Profile>(File.ReadAllText(openFileDialog2.FileName));
          if (profile.Type.Equals((object) (ProfileType) 0))
          {
            TreeView tree = ((FlatbufferControl) this.Parent).Tree;
            // ISSUE: reference to a compiler-generated field
            if (EditorCharProfileTable_WWE2K24.\u003C\u003Eo__3.\u003C\u003Ep__2 == null)
            {
              // ISSUE: reference to a compiler-generated field
              EditorCharProfileTable_WWE2K24.\u003C\u003Eo__3.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, CharacterProfile_WWE2K23>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (CharacterProfile_WWE2K23), typeof (EditorCharProfileTable_WWE2K24)));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, CharacterProfile_WWE2K23> target1 = EditorCharProfileTable_WWE2K24.\u003C\u003Eo__3.\u003C\u003Ep__2.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, CharacterProfile_WWE2K23>> p2 = EditorCharProfileTable_WWE2K24.\u003C\u003Eo__3.\u003C\u003Ep__2;
            // ISSUE: reference to a compiler-generated field
            if (EditorCharProfileTable_WWE2K24.\u003C\u003Eo__3.\u003C\u003Ep__1 == null)
            {
              // ISSUE: reference to a compiler-generated field
              EditorCharProfileTable_WWE2K24.\u003C\u003Eo__3.\u003C\u003Ep__1 = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "DeserializeObject", (IEnumerable<Type>) new Type[1]
              {
                typeof (CharacterProfile_WWE2K23)
              }, typeof (EditorCharProfileTable_WWE2K24), (

IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, Type, object, object> target2 = EditorCharProfileTable_WWE2K24.\u003C\u003Eo__3.\u003C\u003Ep__1.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, Type, object, object>> p1 = EditorCharProfileTable_WWE2K24.\u003C\u003Eo__3.\u003C\u003Ep__1;
            Type type = typeof (JsonConvert);
            // ISSUE: reference to a compiler-generated field
            if (EditorCharProfileTable_WWE2K24.\u003C\u003Eo__3.\u003C\u003Ep__0 == null)
            {
              // ISSUE: reference to a compiler-generated field
              EditorCharProfileTable_WWE2K24.\u003C\u003Eo__3.\u003C\u003Ep__0 = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "SerializeObject", (IEnumerable<Type>) null, typeof (EditorCharProfileTable_WWE2K24), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj1 = EditorCharProfileTable_WWE2K24.\u003C\u003Eo__3.\u003C\u003Ep__0.Target((CallSite) EditorCharProfileTable_WWE2K24.\u003C\u003Eo__3.\u003C\u003Ep__0, typeof (JsonConvert), profile.Data);
            object obj2 = target2((CallSite) p1, type, obj1);
            CharacterProfile_WWE2K23 MetaData = target1((CallSite) p2, obj2);
            if (MetaData != null)
            {
              if (MetaData.Info != null && (method == EditorCharProfileTable.ImportMethod.Full || method == EditorCharProfileTable.ImportMethod.Character))
              {
                foreach (long characterProfileOffset in (IEnumerable<long>) this.CharacterProfileOffsets)
                {
                  long ActualAddress = characterProfileOffset + (long) (App.CurrentGame.Memory.Regions["ProfileSize"] * ((MetaFlatbufferItem) tree.SelectedItem).Pointer);
                  DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(41, 1);
                  interpolatedStringHandler.AppendLiteral("Importing [Character] to memory region (");
                  interpolatedStringHandler.AppendFormatted<long>(ActualAddress);
                  interpolatedStringHandler.AppendLiteral(")");
                  MetaTaskWindow.Show(interpolatedStringHandler.ToStringAndClear(), "Hold tight.", task =>
                  {
                    string str;
                    App.MemoryManager.Queue(App.CurrentGame.Exe, ActualAddress, ref str);
                    App.MemoryManager.CWrite<ushort>(App.CurrentGame.Memory.ProfileOffsets, "Category", (object) (ushort) 0);
                    App.MemoryManager.CWrite<ushort>(App.CurrentGame.Memory.ProfileOffsets, "Wrestler_ID", (object) MetaData.Info.wrestler_id);
                    App.MemoryManager.CWrite<ushort>(App.CurrentGame.Memory.ProfileOffsets, "Slot_ID", (object) MetaData.Info.slot_id);
                    App.MemoryManager.CWrite<ushort>(App.CurrentGame.Memory.ProfileOffsets, "Wrestler_ID_2", (object) MetaData.Info.wrestler_id_2);
                    App.MemoryManager.CWrite<uint>(App.CurrentGame.Memory.ProfileOffsets, "Full_Name", (object) MetaData.Info.fullname_sdb_id);
                    App.MemoryManager.CWrite<uint>(App.CurrentGame.Memory.ProfileOffsets, "Full_Name_2", (object) MetaData.Info.fullname_sdb_id);
                    App.MemoryManager.CWrite<uint>(App.CurrentGame.Memory.ProfileOffsets, "Full_Name_3", (object) MetaData.Info.fullname_sdb_id);
                    App.MemoryManager.CWrite<uint>(App.CurrentGame.Memory.ProfileOffsets, "Nickname", (object) MetaData.Info.nickname_sdb_id);
                    App.MemoryManager.CWrite<uint>(App.CurrentGame.Memory.ProfileOffsets, "Full_Name_4", (object) MetaData.Info.fullname_sdb_id);
                    App.MemoryManager.CWrite<uint>(App.CurrentGame.Memory.ProfileOffsets, "Social_media", (object) MetaData.Info.socialmedia_sdb_id);
                    App.MemoryManager.CWrite<ushort>(App.CurrentGame.Memory.ProfileOffsets, "Gender", (object) MetaData.Info.gender);
                    App.MemoryManager.CWrite<ushort>(App.CurrentGame.Memory.ProfileOffsets, "Weight", (object) MetaData.Info.weight);
                    App.MemoryManager.CWrite<byte>(App.CurrentGame.Memory.ProfileOffsets, "Weight_Class", (object) MetaData.Info.weight_class);
                    App.MemoryManager.CWrite<byte>(App.CurrentGame.Memory.ProfileOffsets, "Wrestler_Type", (object) MetaData.Info.wrestler_type);
                    App.MemoryManager.CWrite<byte>(App.CurrentGame.Memory.ProfileOffsets, "Crowd_Balance", (object) MetaData.Info.crowd_balance);
                    App.MemoryManager.CWrite<byte>(App.CurrentGame.Memory.ProfileOffsets, "Crowd_Reaction", (object) MetaData.Info.crowd_reaction);
                    App.MemoryManager.CWrite<uint>(App.CurrentGame.Memory.ProfileOffsets, "Victory_Name", (object) MetaData.Info.fullname_sdb_id);
                    App.MemoryManager.CWrite<uint>(App.CurrentGame.Memory.ProfileOffsets, "Commentary_ID", (object) MetaData.Info.commentary_id);
                    App.MemoryManager.CWrite<uint>(App.CurrentGame.Memory.ProfileOffsets, "Ring_Announcer_ID", (object) MetaData.Info.announcer_id);
                    App.MemoryManager.CWrite<uint>(App.CurrentGame.Memory.ProfileOffsets, "Hometown", (object) MetaData.Info.location_callname);
                    App.MemoryManager.CWrite<byte>(App.CurrentGame.Memory.ProfileOffsets, "Payback_1_Flag", (object) MetaData.Info.payback_01);
                    App.MemoryManager.CWrite<byte>(App.CurrentGame.Memory.ProfileOffsets, "Payback_2_Flag", (object) MetaData.Info.payback_02);
                    App.MemoryManager.CWrite<byte>(App.CurrentGame.Memory.ProfileOffsets, "Unlock_Flag", (object) MetaData.Info.playability);
                    App.MemoryManager.CWrite<byte>(App.CurrentGame.Memory.ProfileOffsets, "Menu_Flag", (object) MetaData.Info.menu_location);
                    App.MemoryManager.CWrite<uint[]>(App.CurrentGame.Memory.ProfileOffsets, "Crowd_Signs", (object) MetaData.Info.crowd_signs.ToByteArray());
                    App.MemoryManager.CWrite<byte[]>(App.CurrentGame.Memory.ProfileOffsets, "Ai_Attributes", (object) MetaData.Info.ai_attributes.ToArray());
                    App.MemoryManager.CWrite<byte[]>(App.CurrentGame.Memory.ProfileOffsets, "Attributes", (object) MetaData.Info.attributes.ToArray());
                    App.MemoryManager.CWrite<byte[]>(App.CurrentGame.Memory.ProfileOffsets, "Hit_Point_Ratio", (object) MetaData.Info.hit_point.ToArray());
                    App.MemoryManager.CWrite<byte[]>(App.CurrentGame.Memory.ProfileOffsets, "Personality_Traits", (object) MetaData.Info.personality_traits.ToArray());
                    ushort minValue = (ushort) HeightConverter.CalculateValueRange(MetaData.Info.height).minValue;
                    App.MemoryManager.CWrite<ushort>(App.CurrentGame.Memory.ProfileOffsets, "Height", (object) minValue);
                    App.MemoryManager.Write(new byte[2]
                    {
                      MetaData.Info.payback_01,
                      MetaData.Info.payback_02
                    }, App.CurrentGame.Memory.MoveOffsets["Moves_Payback"]);
                    App.MemoryManager.Release();
                  });
                  this.logger.Log("Imported [Character Data] to region: {0}", ActualAddress);
                }
              }
              if (MetaData.Motion != null && (method == EditorCharProfileTable.ImportMethod.Full || method == EditorCharProfileTable.ImportMethod.Motion))
              {
                foreach (long characterMotionOffset in (IEnumerable<long>) this.CharacterMotionOffsets)
                {
                  long ActualAddress = characterMotionOffset + (long) (App.CurrentGame.Memory.Regions["MotionSize"] * ((MetaFlatbufferItem) tree.SelectedItem).Pointer);
                  DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(38, 1);
                  interpolatedStringHandler.AppendLiteral("Importing [Motion] to memory region (");
                  interpolatedStringHandler.AppendFormatted<long>(ActualAddress);
                  interpolatedStringHandler.AppendLiteral(")");
                  MetaTaskWindow.Show(interpolatedStringHandler.ToStringAndClear(), "Hold tight.", task =>
                  {
                    string str;
                    App.MemoryManager.Queue(App.CurrentGame.Exe, ActualAddress, ref str);
                    App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Info.wrestler_id), App.CurrentGame.Memory.MotionOffsets["Wrestler_ID"]);
                    App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.entrance_music), App.CurrentGame.Memory.MotionOffsets["Entrance_Music"]);
                    App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.entrance_music), App.CurrentGame.Memory.MotionOffsets["Victory_

Entrance_Music"]);
                    App.MemoryManager.Write(new byte[4], App.CurrentGame.Memory.MotionOffsets["Template_Flag"]);
                    App.MemoryManager.Write(new byte[4], App.CurrentGame.Memory.MotionOffsets["Template_ID"]);
                    App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.victory_motion_face), App.CurrentGame.Memory.MotionOffsets["Victory_Motion_Face"]);
                    App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.victory_motion_heel), App.CurrentGame.Memory.MotionOffsets["Victory_Motion_Heel"]);
                    App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.victory_title_motion_face), App.CurrentGame.Memory.MotionOffsets["Victory_Title_Motion_Face"]);
                    App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.victory_title_motion_heel), App.CurrentGame.Memory.MotionOffsets["Victory_Title_Motion_Heel"]);
                    App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.entrance_title_motion), App.CurrentGame.Memory.MotionOffsets["Title_Motion"]);
                    App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.entrance_MITB_motion), App.CurrentGame.Memory.MotionOffsets["MITB_Motion"]);
                    App.MemoryManager.Write(new byte[4], App.CurrentGame.Memory.MotionOffsets["Victory_Template_Flag"]);
                    App.MemoryManager.Write(new byte[4], App.CurrentGame.Memory.MotionOffsets["Victory_Template_ID"]);
                    App.MemoryManager.Write(new byte[4]
                    {
                      byte.MaxValue,
                      byte.MaxValue,
                      byte.MaxValue,
                      byte.MaxValue
                    }, App.CurrentGame.Memory.MotionOffsets["Template"]);
                    App.MemoryManager.Write(BitConverter.GetBytes((short) MetaData.Motion.screen_effect), App.CurrentGame.Memory.MotionOffsets["Arena_Effect"]);
                    App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.light_show), App.CurrentGame.Memory.MotionOffsets["Light_Show"]);
                    App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.entrance_motion_intro), App.CurrentGame.Memory.MotionOffsets["Motion_Intro"]);
                    App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.entrance_motion_stage), App.CurrentGame.Memory.MotionOffsets["Motion_Stage"]);
                    App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.entrance_motion_ramp), App.CurrentGame.Memory.MotionOffsets["Motion_Ramp"]);
                    App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.entrance_motion_ring_in), App.CurrentGame.Memory.MotionOffsets["Motion_Ring_In"]);
                    App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.entrance_motion_ring), App.CurrentGame.Memory.MotionOffsets["Motion_Ring"]);
                    App.MemoryManager.Write(BitConverter.GetBytes((short) MetaData.Motion.movies_enabled), App.CurrentGame.Memory.MotionOffsets["Movie_Display"]);
                    App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.movie_titantron), App.CurrentGame.Memory.MotionOffsets["Titantron_Movie"]);
                    App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.movie_stage_ramp), App.CurrentGame.Memory.MotionOffsets["Stage_Ramp_Movie"]);
                    App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.movie_barricade), App.CurrentGame.Memory.MotionOffsets["Barricade_Movie"]);
                    App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.movie_apron_ringpost), App.CurrentGame.Memory.MotionOffsets["Apron_Ring_Post_Movie"]);
                    App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.movie_unknown), App.CurrentGame.Memory.MotionOffsets["Unknown_Movie"]);
                    App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.movie_banner), App.CurrentGame.Memory.MotionOffsets["Banner_Movie"]);
                    App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.movie_titantron), App.CurrentGame.Memory.MotionOffsets["Victory_Titantron_Movie"]);
                    App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.movie_stage_ramp), App.CurrentGame.Memory.MotionOffsets["Victory_Stage_Ramp_Movie"]);
                    App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.movie_apron_ringpost), App.CurrentGame.Memory.MotionOffsets["Victory_Apron_Ring_Post_Movie"]);
                    App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.movie_unknown), App.CurrentGame.Memory.MotionOffsets["Victory_Unknown_Movie"]);
                    App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.movie_banner), App.CurrentGame.Memory.MotionOffsets["Victory_Banner_Movie"]);
                    App.MemoryManager.Write(new byte[2]
                    {
                      MetaData.Info.payback_01,
                      MetaData.Info.payback_02
                    }, App.CurrentGame.Memory.MoveOffsets["Moves_Payback"]);
                    App.MemoryManager.Release();
                  });
                  this.logger.Log("Imported [Motion Data] to region: {0}", ActualAddress);
                }
              }
              if (MetaData.Moveset == null || method != EditorCharProfileTable.ImportMethod.Full && method != EditorCharProfileTable.ImportMethod.Moveset)
                ;
              return true;
            }
          }
          else
          {
            int num = (int) MetaMessageBox.Show("Invalid profile.", "Meta Memory Manager");
          }
        }
      }
      else
      {
        int num1 = (int) MetaMessageBox.Show("Memory is not primed", "Meta Memory Manager");
      }
    }
    else
    {
      int num2 = (int) MetaMessageBox.Show("Game was not found, attempting resync", "Meta Memory Manager");
      if (App.InitiateWatchGame())
        this.GameWasClosed = false;
    }
  }
  else
  {
    int num3 = (int) MetaMessageBox.Show("Game was recently closed, you must prime memory again.", "Meta Memory Manager");
    if (!App.GameRunning && App.InitiateWatchGame())
      this.GameWasClosed = false;
  }
  return false;
}
```

### Summary

The `EditorCharProfileTable_WWE2K24` class is an editor control used to manage and edit character profile tables for the WWE 2K24 game. It extends the `EditorCharProfileTable` class and includes methods for creating the root node of the profile table, priming memory by scanning for character and motion data locations, and importing memory from a profile file. The class makes extensive use of the `Meta` framework for flatbuffers and memory management, and interacts with the game's memory to update character profiles and motions.

## /Meta/Editor/Controls/FlatbufferControl.cs

This C# code defines a custom WPF control named `FlatbufferControl` in the `Meta.Editor.Controls` namespace. Here's a breakdown of its components and functionality:

### Namespaces and References

The code uses various namespaces and references, indicating that it deals with WPF (Windows Presentation Foundation) controls, Flatbuffers (a serialization library), and some custom Meta framework:

```csharp
using Meta.Core;
using Meta.Core.Attributes;
using Meta.Core.Interfaces;
using Meta.Editor.Commands;
using Meta.Editor.Windows;
using Meta.Structures.Flatbuffers;
using MetaEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Threading;
```

### Class Definition and Attributes

The `FlatbufferControl` class inherits from `MetaBaseControl` and includes some WPF-specific attributes for template parts:

```csharp
[TemplatePart(Name = "PART_FilterTextBox", Type = typeof(MetaWatermarkTextbox))]
[TemplatePart(Name = "PART_JsonTreeView", Type = typeof(TreeView))]
public class FlatbufferControl : MetaBaseControl
```

### Fields and Properties

Various fields and properties are defined to manage the control's state and functionality:

- **Template parts**: Fields for `PART_FilterTextBox` and `PART_JsonTreeView`.
- **Control state**: Fields like `firstTimeLoad`, `controlTab`, `expanded`, and `activeFile`.
- **ObservableCollection**: `Items` to hold the data items for the control.
- **Properties**: Getters and setters for `Tab`, `IsExpanded`, `Tree`, `Icon`, `OpenFile`, and `Schema`.

### Static Constructor

A static constructor sets the default style for the control:

```csharp
static FlatbufferControl()
{
  FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(FlatbufferControl), new FrameworkPropertyMetadata(typeof(FlatbufferControl)));
}
```

### Constructor

The constructor initializes the control with a logger, a Flatbuffer schema, and a filename:

```csharp
public FlatbufferControl(ILogger inLogger, FlatbufferSchema _schema, string _filename) : base(inLogger)
{
  this.OpenFile = _filename;
  this.Schema = _schema;
  this._onEngineChange += new MetaEngineChangeCallback(this.OnEngineChanged);
  this.LoadAsset(_filename);
}
```

### Methods

#### Initialize

This method initializes the control by loading the appropriate editor type based on attributes and schema identifier:

```csharp
public bool Initialize()
{
  if (this.Schema.identifier == null)
    return false;
  var data = ((IEnumerable<Type>)Assembly.GetExecutingAssembly().GetTypes())
    .Where(t => t.GetCustomAttributes(typeof(EditorTypeAttribute), true).Length != 0)
    .Where(t => t.GetCustomAttributes(typeof(GameVersionAttribute), true).Cast<GameVersionAttribute>()
    .Any(attr => attr.Value.Equals(App.Game)))
    .Select(t => new { Type = t, Attributes = t.GetCustomAttributes(typeof(EditorTypeAttribute), true).Cast<EditorTypeAttribute>().FirstOrDefault() })
    .FirstOrDefault(x => x.Attributes.Value.Contains(this.Schema.identifier));
  Meta.Editor.Controls.Editor instance;
  if (data == null)
    instance = (Meta.Editor.Controls.Editor)Activator.CreateInstance(typeof(Meta.Editor.Controls.Editor), App.Logger, this.Schema, this.OpenFile);
  else
    instance = (Meta.Editor.Controls.Editor)Activator.CreateInstance(data.Type, App.Logger, this.Schema, this.OpenFile);
  this.assetEditor = instance;
  if (this.assetEditor == null)
    return false;
  this.assetEditor.FControl = this;
  return true;
}
```

#### OnApplyTemplate

This method overrides the base class's method to apply the template parts and set up event handlers:

```csharp
public override void OnApplyTemplate()
{
  base.OnApplyTemplate();
  this.filterTb = this.GetTemplateChild("PART_FilterTextBox") as MetaWatermarkTextbox;
  this.dataTreeView = this.GetTemplateChild("PART_JsonTreeView") as TreeView;
  this.dataTreeView.SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>(this.JsonTreeView_SelectedItemChanged);
  this.Loaded += new RoutedEventHandler(this.FlatBufferControl_Loaded);
  this.filterTb.TextChanged += new TextChangedEventHandler(this.FilterTb_LostFocus);
}
```

#### RegisterToolbarItems

This method registers toolbar items specific to the control:

```csharp
public override List<ToolbarItem> RegisterToolbarItems()
{
  List<ToolbarItem> toolbarItemList = base.RegisterToolbarItems();
  toolbarItemList.Add(new ToolbarItem("Export JSON", "Export to JSON", "ArrowUpBold", new RelayCommand(state => this.ExportButton_Click(this, new RoutedEventArgs()))));
  toolbarItemList.InsertRange(toolbarItemList.Count, this.assetEditor.RegisterToolbarItems());
  return toolbarItemList;
}
```

#### Closed

This method overrides the base class's method to clean up resources:

```csharp
public override void Closed()
{
  base.Closed();
  if (this.assetEditor == null)
    return;
  this.assetEditor.Shutdown();
}
```

#### Event Handlers and Utility Methods

Various private methods handle events and utility functions, such as `FilterTb_LostFocus`, `ExportButton_Click`, `JsonTreeView_SelectedItemChanged`, `UpdateControlSource`, `FlatBufferControl_Loaded`, `OnEngineChanged`, `OnDeserializerSuccess`, `OnDeserializerFailed`, and `TreeViewItem_PreviewMouseRightButtonDown`.

### Summary

In summary, `FlatbufferControl` is a custom WPF control for handling and displaying Flatbuffer data within a tree view, with integrated filtering, exporting, and context menu functionality. It relies on a schema to deserialize data and dynamically loads the appropriate editor based on attributes and game version. The control interacts with other parts of the Meta framework, integrating deeply with its ecosystem.

## /Meta/Editor/Controls/ItemsSourceConverter.cs

The `ItemsSourceConverter` class in the provided C# code implements the `IValueConverter` interface from the `System.Windows.Data` namespace. This interface is used in WPF (Windows Presentation Foundation) to convert data between different types or formats. The class is designed to convert an `IEnumerable` collection to a `CollectionView`, which can be used as the data source for controls that support data binding, such as `ItemsControl`, `ListBox`, or `ComboBox`.

Here's a detailed explanation of the code:

### Namespace and Class Declaration

```csharp
namespace Meta.Editor.Controls
{
  public class ItemsSourceConverter : IValueConverter
  {
    // Methods will be defined here
  }
}
```

- The class `ItemsSourceConverter` is defined within the `Meta.Editor.Controls` namespace.
- It implements the `IValueConverter` interface, which requires the implementation of two methods: `Convert` and `ConvertBack`.

### Nullable Context

```csharp
#nullable enable
```

- This directive enables nullable reference types, allowing for better handling of `null` values and avoiding potential `null` reference exceptions.

### Convert Method

```csharp
public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
{
  return value is IEnumerable enumerable && enumerable != null ?
         (object)new CollectionViewSource() { Source = ((object)enumerable) }.View :
         throw new Exception("Value must be an IEnumerable");
}
```

- The `Convert` method is used to transform the source value to a target value. It takes four parameters:

  - `value`: The source value (expected to be an `IEnumerable`).
  - `targetType`: The type of the binding target property.
  - `parameter`: An optional parameter to use in the converter logic.
  - `culture`: The culture information to use in the converter.

- The method checks if `value` is an `IEnumerable`. If it is, a `CollectionViewSource` is created with the `Source` property set to the `IEnumerable`. The `View` property of the `CollectionViewSource` is then returned.
- If `value` is not an `IEnumerable`, an exception is thrown with the message "Value must be an IEnumerable".

### ConvertBack Method

```csharp
public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
{
  return DependencyProperty.UnsetValue;
}
```

- The `ConvertBack` method is used to convert the target value back to the source value. It takes the same parameters as the `Convert` method.
- In this implementation, `ConvertBack` simply returns `DependencyProperty.UnsetValue`, indicating that the conversion back is not supported or not needed.

### Summary

- This `ItemsSourceConverter` is a utility class for converting `IEnumerable` collections to a `CollectionView` for use in WPF data binding scenarios.
- It ensures that the data source provided to WPF controls is a `CollectionView`, which provides additional functionalities like sorting, filtering, and grouping.
- The `ConvertBack` method is not implemented, as converting a `CollectionView` back to an `IEnumerable` is not necessary in this context.

### Example Usage

To use this converter in a WPF application, you would typically define it as a resource and use it in a data binding expression in XAML:

```xml
<Window x:Class="Meta.Editor.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="clr-namespace:Meta.Editor.Controls"
        Title="MainWindow" Height="350" Width="525">
    <Window.Resources>
        <local:ItemsSourceConverter x:Key="ItemsSourceConverter"/>
    </Window.Resources>
    <Grid>
        <ListBox ItemsSource="{Binding MyCollection, Converter={StaticResource ItemsSourceConverter}}"/>
    </Grid>
</Window>
```

In this example, `MyCollection` would be an `IEnumerable` property in the data context of the `Window`, and the converter would ensure it is presented as a `CollectionView` in the `ListBox`.

## /Meta/Editor/Controls/JObject.cs

Certainly! Let's break down the code provided:

### Code Explanation

#### Namespace Declaration

```csharp
namespace Meta.Editor.Controls
```

- This declares a namespace named `Meta.Editor.Controls`, which is a way to organize classes and other types into a hierarchical structure. This helps in avoiding name conflicts and logically grouping related code.

#### Class Declaration

```csharp
public class JObject
```

- This defines a public class named `JObject`. The `public` keyword means that this class can be accessed from outside its namespace.

#### Properties

```csharp
public object Id { get; private set; }
public string Name { get; private set; }
```

- These are properties of the `JObject` class.
- `Id` is of type `object`, meaning it can hold any data type. It has a private setter, which means it can only be set within the class.
- `Name` is of type `string`, representing a sequence of characters. It also has a private setter.

#### Constructor

```csharp
public JObject(object Value, string name)
```

- This is the constructor of the `JObject` class. A constructor is a special method that is called when an instance of the class is created.
- It takes two parameters: `Value` of type `object` and `name` of type `string`.
- Inside the constructor, the `Id` property is set to `Value` and the `Name` property is set to `name`.

#### ToString Method

```csharp
public override string ToString() => string.Format("{0}", (object) this.Name);
```

- This method overrides the `ToString` method from the base `Object` class.
- It returns the `Name` property of the `JObject` instance as a string.
- `string.Format("{0}", (object) this.Name)` is a way to format the string, though in this simple case, it could just return `this.Name` directly.

### Nullable Enable Directive

```csharp
#nullable enable
```

- This directive enables nullable reference types for the file. This means the compiler will enforce nullable reference type annotations and warnings, helping to avoid null reference exceptions.

### Summary

The `JObject` class is a simple container for two properties: `Id` and `Name`. It provides a constructor for initializing these properties and overrides the `ToString` method to return the `Name` as a string. The `#nullable enable` directive ensures that the compiler checks for nullable reference types, enhancing the safety and robustness of the code.

## /Meta/Editor/Controls/JObjectCrowdSign.cs

This code defines a class named `JObjectCrowdSign` within the namespace `Meta.Editor.Controls`. Here's a detailed explanation:

1. **Nullable Context**:

   ```csharp
   #nullable enable
   ```

   This directive enables nullable reference types for this file or scope. It ensures the compiler enforces nullable reference type rules, helping to avoid null reference exceptions.

2. **Namespace**:

   ```csharp
   namespace Meta.Editor.Controls
   ```

   The class is contained within the `Meta.Editor.Controls` namespace, which helps organize code and prevents naming conflicts.

3. **Class Definition**:

   ```csharp
   public sealed class JObjectCrowdSign : JObject
   ```

   - `public sealed class JObjectCrowdSign` declares a class named `JObjectCrowdSign`.
   - `sealed` keyword indicates that this class cannot be inherited.
   - `: JObject` means `JObjectCrowdSign` inherits from a base class `JObject`.

4. **Constructor**:

   ```csharp
   public JObjectCrowdSign(object Value, string name)
      : base(Value, name)
   {
   }
   ```

   - This is a constructor for the `JObjectCrowdSign` class.
   - It takes two parameters: `object Value` and `string name`.
   - `: base(Value, name)` calls the constructor of the base class `JObject` with these parameters.

5. **Override `ToString` Method**:

   ```csharp
   public override string ToString() => string.Format("{0} {1}", this.Id, (object) this.Name);
   ```

   - This method overrides the `ToString` method from the base class.
   - `string.Format("{0} {1}", this.Id, (object) this.Name)` returns a formatted string combining the `Id` and `Name` properties of the instance. The `(object)` cast is used to ensure the proper formatting.

### Summary

The `JObjectCrowdSign` class is a specific type of `JObject` that includes additional functionality through its constructor and `ToString` method. The class ensures proper string representation by concatenating its `Id` and `Name` properties. The `sealed` keyword ensures that no other class can inherit from `JObjectCrowdSign`, indicating it is a final implementation.

## /Meta/Editor/Controls/JObjectExtensions.cs

This code defines a static class `JObjectExtensions` within the `Meta.Editor.Controls` namespace, providing extension methods for the `ObservableCollection<T>` class. These methods enable the retrieval of objects based on a specified type and input value. The `#nullable enable` directive at the top indicates that nullable reference types are enabled for this file, which helps with nullability checks and warnings.

Let's break it down:

1. **Namespaces and Directives**:

   - `using System;`: Imports basic system types.
   - `using System.Collections.ObjectModel;`: Imports the `ObservableCollection` class.
   - `using System.Linq;`: Imports LINQ methods for querying collections.

2. **Class and Methods**:

   - `public static class JObjectExtensions`: A static class that contains the extension methods.
   - `public static JObject Get<T>(this ObservableCollection<JObject> table, object inputType)`: An extension method for `ObservableCollection<JObject>`. This method retrieves a `JObject` from the collection based on the type `T` and the `inputType`.

     The method uses conditional checks for three types: `byte`, `ushort`, and `uint`. For each type, it uses LINQ to filter the collection where the `Id` property of `JObject` (cast to `long` and then to the specific type) matches the `inputType`. The `FirstOrDefault` method returns the first matching element or null if no match is found.

     - `if (typeof(T) == typeof(byte))`: Checks if `T` is `byte`.
     - `if (typeof(T) == typeof(ushort))`: Checks if `T` is `ushort`.
     - `if (typeof(T) == typeof(uint))`: Checks if `T` is `uint`.

     Each condition performs a LINQ query on the `table` collection and returns the first matching `JObject`.

   - `public static JObjectCrowdSign Get<T>(this ObservableCollection<JObjectCrowdSign> table, object inputType)`: Another extension method for `ObservableCollection<JObjectCrowdSign>`. This method is similar to the previous one but specifically handles `JObjectCrowdSign`.

     - `if (typeof(T) == typeof(uint))`: Checks if `T` is `uint`.

     It performs a LINQ query on the `table` collection and returns the first matching `JObjectCrowdSign`.

### Summary

The extension methods allow you to retrieve a `JObject` or `JObjectCrowdSign` from an `ObservableCollection` based on a specified type (`byte`, `ushort`, `uint`) and an input value. The methods use LINQ to filter the collection based on the `Id` property, cast to the appropriate type, and check for equality with the `inputType`.

## /Meta/Editor/Controls/JObjectMove.cs

This C# code defines a class `JObjectMove` that extends another class called `JObject` within the `Meta.Editor.Controls` namespace. Here's a detailed explanation:

### Nullable Context

- `#nullable enable`: This directive enables nullable reference types in the file, allowing for more precise handling of nullability.

### Namespace

- `namespace Meta.Editor.Controls`: The class is part of the `Meta.Editor.Controls` namespace, which helps organize and manage the code logically.

### Class Declaration

- `public class JObjectMove : JObject`: The `JObjectMove` class inherits from the `JObject` class. This means `JObjectMove` inherits all the properties and methods of `JObject`.

### Properties

- `public uint ID { get; private set; }`: This defines a property `ID` of type `uint` (unsigned integer). It has a private setter, meaning it can only be set within the class itself.

### Methods

- `public override string ToString() => string.Format("{0}", (object) this.Name);`: This overrides the `ToString` method from the base class (`JObject`). It returns the `Name` property (assumed to be inherited from `JObject`) of the object as a string.

### Constructor

- `public JObjectMove(object Value, string name, uint anim_id) : base(Value, name)`: This is a constructor for the `JObjectMove` class. It takes three parameters: `Value` (of type `object`), `name` (of type `string`), and `anim_id` (of type `uint`). It calls the base class constructor (`base(Value, name)`) to initialize the inherited properties and sets the `ID` property to `anim_id`.

### Summary

- The `JObjectMove` class is a specialized version of `JObject` with an additional `ID` property.
- It overrides the `ToString` method to return the name of the object.
- The constructor initializes the object with provided values and sets the `ID` property.

The `JObjectMove` class is likely used to represent some kind of object movement with an associated ID within the `Meta.Editor.Controls` context, where `JObject` serves as a base class providing common functionality.

## /Meta/Editor/Controls/MaxIdConverter.cs

Certainly! Here’s a detailed explanation of the provided C# code:

### Namespaces and Usings

- `using System;`: Imports fundamental classes and base classes that define commonly-used value and reference data types, events, and event handlers, interfaces, attributes, and processing exceptions.
- `using System.Globalization;`: Provides classes that define culture-related information, including language, country/region, calendars in use, format patterns for dates, currency, and numbers, and sort order for strings.
- `using System.Windows.Data;`: Provides classes to support data binding in WPF (Windows Presentation Foundation) applications.

### Nullable Enable

- `#nullable enable`: This directive enables nullable reference types, which help you write safer code by indicating whether a reference type variable may be null.

### Namespace Declaration

- `namespace Meta.Editor.Controls`: Defines a namespace named `Meta.Editor.Controls` to logically group related classes. Namespaces help organize code and prevent naming conflicts.

### Class Definition: MaxIdConverter

- `public class MaxIdConverter : IValueConverter`: This class implements the `IValueConverter` interface, which is used in WPF data binding to convert values between the source and target.

### Fields and Constructor

- `private bool hasOverride = false;`: Declares a private boolean field `hasOverride` initialized to `false`. This field likely serves as a flag to determine some behavior in the converter, though it’s not utilized within the provided methods.
- `public MaxIdConverter(bool _hasOverride) => this.hasOverride = _hasOverride;`: This is a constructor that initializes the `hasOverride` field with a value passed as a parameter `_hasOverride`.

### Convert Method

- `public object Convert(object value, Type targetType, object parameter, CultureInfo culture)`: This method is used to convert a value from the source type to the target type. It’s commonly used in data binding scenarios.
  - `return value is uint num ? (object) (uint) ((int) num + 1) : value;`: This line checks if the `value` is of type `uint`. If so, it casts `value` to `uint`, adds `1` to it, and returns the result. If `value` is not `uint`, it returns the original `value`.

### ConvertBack Method

- `public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)`: This method is used to convert a value from the target type back to the source type. However, in this implementation, it simply returns the `value` unchanged.
  - `return value;`: Returns the input `value` as-is, indicating that the back conversion logic is not implemented or needed.

### Summary

The `MaxIdConverter` class is designed to be used in WPF data binding scenarios where it converts an unsigned integer (`uint`) to `uint + 1`. The class implements the `IValueConverter` interface, which requires the `Convert` and `ConvertBack` methods. The `Convert` method increments the value if it is of type `uint`, while the `ConvertBack` method returns the value unchanged. The `hasOverride` field is set via the constructor but isn't used within the provided methods.

## /Meta/Editor/Controls/MessageBoxClickCommand.cs

This C# code defines a custom command, `MessageBoxClickCommand`, for handling button clicks in a WPF (Windows Presentation Foundation) application. The command interprets the content of a button and triggers the corresponding action on a custom `MetaMessageBox` window. Here’s a breakdown of the key components:

### Namespaces and Directives

```csharp
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

#nullable enable
```

- `using System;`: Includes the base class library.
- `using System.Windows;`, `using System.Windows.Controls;`, `using System.Windows.Input;`: These are WPF-specific namespaces for UI elements and command handling.
- `#nullable enable`: Enables nullable reference types to ensure better handling of null values.

### Namespace Declaration

```csharp
namespace Meta.Editor.Controls
{
```

Defines a namespace `Meta.Editor.Controls` to organize the code and avoid naming conflicts.

### Class Definition

```csharp
public class MessageBoxClickCommand : ICommand
{
```

- `MessageBoxClickCommand`: A class implementing the `ICommand` interface, which is used to create commands in WPF.

### Event: CanExecuteChanged

```csharp
public event EventHandler CanExecuteChanged
{
  add => CommandManager.RequerySuggested += value;
  remove => CommandManager.RequerySuggested -= value;
}
```

- `CanExecuteChanged`: An event that gets fired when the state of the command changes.
- `CommandManager.RequerySuggested`: A built-in event in WPF that gets triggered periodically to re-evaluate the `CanExecute` method.

### Method: CanExecute

```csharp
public bool CanExecute(object parameter) => true;
```

- `CanExecute`: Determines if the command can execute. Always returns `true` in this implementation, meaning the command can always execute.

### Method: Execute

```csharp
public void Execute(object parameter)
{
  Button button = parameter as Button;
  MetaMessageBox window = Window.GetWindow((DependencyObject) button) as MetaMessageBox;
  MessageBoxResult result;
  switch ((string) button.Content)
  {
    case "OK":
      result = MessageBoxResult.OK;
      break;
    case "No":
      result = MessageBoxResult.No;
      break;
    case "Yes":
      result = MessageBoxResult.Yes;
      break;
    default:
      result = MessageBoxResult.Cancel;
      break;
  }
  window.RequestClose(result);
}
```

- `Execute`: Executes the command logic.
  - Casts `parameter` to a `Button`.
  - Retrieves the parent `MetaMessageBox` window using `Window.GetWindow`.
  - Determines the `MessageBoxResult` based on the button's content (`"OK"`, `"No"`, `"Yes"`, or other).
  - Calls `RequestClose(result)` on the `MetaMessageBox` window to close it and return the result.

### Summary

This class enables a button click to execute a command that interacts with a `MetaMessageBox` window. When a button with specific content is clicked, the corresponding `MessageBoxResult` is set, and the window is closed with that result. This approach separates command logic from UI elements, promoting better code organization and maintainability in a WPF application.

## /Meta/Editor/Controls/MetaAutoSizedGridView.cs

This code defines a custom control named `MetaAutoSizedGridView` in the C# programming language, which extends the `GridView` class. The key functionality of this custom control is to automatically adjust the widths of the columns in a `GridView`. Here's a breakdown of the code:

1. **Namespaces and Directives**:

   ```csharp
   using System.Collections.ObjectModel;
   using System.Windows.Controls;
   #nullable enable
   ```

   - `using System.Collections.ObjectModel;` imports the `Collection<T>` class, which is used to work with collections of objects.
   - `using System.Windows.Controls;` imports the `GridView` and `ListViewItem` classes, which are part of the Windows Presentation Foundation (WPF) framework.
   - `#nullable enable` enables nullable reference types, which is a feature to help avoid null reference exceptions.

2. **Namespace Declaration**:

   ```csharp
   namespace Meta.Editor.Controls
   ```

   - This declares the namespace `Meta.Editor.Controls`, which is a way to organize code and avoid naming conflicts.

3. **Class Definition**:

   ```csharp
   public class MetaAutoSizedGridView : GridView
   ```

   - The `MetaAutoSizedGridView` class inherits from `GridView`, which means it extends the functionality of the `GridView` control.

4. **Override of `PrepareItem` Method**:

   ```csharp
   protected override void PrepareItem(ListViewItem item)
   {
     foreach (GridViewColumn column in (Collection<GridViewColumn>) this.Columns)
     {
       if (double.IsNaN(column.Width))
         column.Width = column.ActualWidth;
       column.Width = double.NaN;
     }
     base.PrepareItem(item);
   }
   ```

   - `protected override void PrepareItem(ListViewItem item)`: This method is an override of the `GridView.PrepareItem` method. It is called whenever an item is being prepared for display in the `GridView`.

   - `foreach (GridViewColumn column in (Collection<GridViewColumn>) this.Columns)`: This loop iterates over all the columns in the `GridView`.

   - `if (double.IsNaN(column.Width))`: Checks if the width of the column is not a number (NaN). This typically means that the width has not been explicitly set and is being automatically sized.

   - `column.Width = column.ActualWidth;`: If the column's width is NaN, it sets the column's width to its actual width. This effectively locks the column width to its current size.

   - `column.Width = double.NaN;`: Immediately after setting the column width to its actual width, it sets the width to NaN again. This triggers the column to auto-size itself based on its content.

   - `base.PrepareItem(item);`: Calls the base class's `PrepareItem` method to ensure that any additional behavior defined in the base class is executed.

**Summary**:
The `MetaAutoSizedGridView` class is a custom `GridView` control designed to automatically adjust its column widths based on the content. It overrides the `PrepareItem` method to temporarily fix each column's width to its current size and then reset it to auto-size, ensuring that the columns always fit their content optimally.

## /Meta/Editor/Controls/MetaBaseControl.cs

This C# code defines a class named `MetaBaseControl`, which is a custom control inheriting from the `Control` class and implementing the `INotifyPropertyChanged` interface. It is part of the `Meta.Editor.Controls` namespace and is intended to be used within a user interface context, likely in a WPF (Windows Presentation Foundation) application. Here is a breakdown of the code:

### Using Directives

```csharp
using Meta.Core;
using Meta.Core.Interfaces;
using Meta.Core.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;
```

These directives import necessary namespaces:

- `Meta.Core`, `Meta.Core.Interfaces`, and `Meta.Core.IO` for custom classes and interfaces used in this application.
- `System`, `System.Collections.Generic` for general .NET classes.
- `System.ComponentModel` for property change notification.
- `System.Windows.Controls` for UI controls in WPF.

### Namespace Declaration

```csharp
namespace Meta.Editor.Controls
{
```

Defines the namespace `Meta.Editor.Controls`.

### Class Definition

```csharp
public class MetaBaseControl : Control, INotifyPropertyChanged
{
```

`MetaBaseControl` inherits from `Control` (a WPF base class for UI elements) and implements the `INotifyPropertyChanged` interface, which allows the class to notify clients, typically binding clients, that a property value has changed.

### Fields and Properties

```csharp
    private EngineVersion engineVersion = (EngineVersion) 0;
    protected ILogger logger;
    protected MetaAsset asset;
    public MetaEngineChangeCallback _onEngineChange;

    public event PropertyChangedEventHandler PropertyChanged;

    public MetaAsset Asset => this.asset;

    public virtual string Icon => "Folder";

    public EngineVersion Engine
    {
      get => this.engineVersion;
      set
      {
        if (value == this.engineVersion)
          return;
        this.engineVersion = value;
        this.OnPropertyChanged(nameof (Engine));
      }
    }
```

- `engineVersion`: A private field of type `EngineVersion` (probably an enum or class) initialized to zero.
- `logger`: A protected field of type `ILogger` for logging.
- `asset`: A protected field of type `MetaAsset` for managing assets.
- `_onEngineChange`: A public delegate for handling engine change events.
- `PropertyChanged`: An event of type `PropertyChangedEventHandler` for notifying property changes.
- `Asset`: A public property exposing the `asset` field.
- `Icon`: A virtual property returning a string ("Folder").
- `Engine`: A public property with getter and setter. The setter triggers `OnPropertyChanged` if the value changes.

### Constructor

```csharp
    public MetaBaseControl(ILogger inLogger) => this.logger = inLogger;
```

The constructor initializes the `logger` field with the provided `ILogger` instance.

### Methods

```csharp
    public virtual void Closed()
    {
    }

    public virtual void OnEngineSet(EngineVersion version) => this._onEngineChange(version);

    public virtual void LoadAsset(string path) => this.asset = new MetaAsset(path, (Type) null);

    public virtual List<ToolbarItem> RegisterToolbarItems() => new List<ToolbarItem>();

    protected virtual void OnPropertyChanged(string propertyName)
    {
      PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
      if (propertyChanged == null)
        return;
      propertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
```

- `Closed`: A virtual method meant to be overridden in derived classes.
- `OnEngineSet`: A virtual method that triggers the `_onEngineChange` delegate.
- `LoadAsset`: A virtual method that initializes the `asset` field with a new `MetaAsset` object.
- `RegisterToolbarItems`: A virtual method that returns a new list of `ToolbarItem` objects, meant to be overridden.
- `OnPropertyChanged`: A protected method that raises the `PropertyChanged` event for the specified property.

### Summary

`MetaBaseControl` is a base class for creating custom controls in a WPF application. It provides functionality for handling property changes, loading assets, managing engine versions, and registering toolbar items. Derived classes are expected to override its virtual methods to provide specific functionality. The `INotifyPropertyChanged` implementation allows the control to participate in data binding scenarios, commonly used in WPF applications.

## /Meta/Editor/Controls/MetaBlurWindow.cs

This C# code defines a `MetaBlurWindow` class that extends the `Window` class in a WPF (Windows Presentation Foundation) application. The main purpose of this class is to enable a blur effect on the window using Windows' Composition API. Let's break down the code step by step.

### Namespaces and Directives

```csharp
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
```

- `System`: Provides fundamental classes and base classes.
- `System.Runtime.InteropServices`: Provides a wide variety of members that support COM interop and platform invoke services.
- `System.Windows`: Provides classes for creating Windows-based applications.
- `System.Windows.Interop`: Provides helper classes for interoperation between WPF and other technologies like Win32.

### Enabling Nullable Reference Types

```csharp
#nullable enable
```

- Enables nullable reference types, a feature that helps to prevent `null` reference exceptions.

### Namespace and Class Definition

```csharp
namespace Meta.Editor.Controls
{
  public class MetaBlurWindow : Window
  {
```

- Defines the namespace `Meta.Editor.Controls`.
- Defines the `MetaBlurWindow` class which inherits from the `Window` class.

### P/Invoke to Set Window Composition Attribute

```csharp
    [DllImport("user32.dll")]
    internal static extern int SetWindowCompositionAttribute(
      IntPtr hwnd,
      ref WindowCompositionAttributeData data);
```

- Declares a method `SetWindowCompositionAttribute` from the `user32.dll` which allows setting attributes on a window, such as enabling blur.

### Static Constructor

```csharp
    static MetaBlurWindow()
    {
      FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (MetaBlurWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (MetaBlurWindow)));
    }
```

- Static constructor to override the default style key property of the `MetaBlurWindow` class.

### Event Handler for Window Loaded

```csharp
    private void Window_Loaded(object sender, RoutedEventArgs e) => this.EnableBlur();
```

- Event handler that calls `EnableBlur` method when the window is loaded.

### EnableBlur Method

```csharp
    internal void EnableBlur()
    {
      WindowInteropHelper windowInteropHelper = new WindowInteropHelper((Window) this);
      AccentPolicy structure = new AccentPolicy();
      int cb = Marshal.SizeOf<AccentPolicy>(structure);
      structure.AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND;
      IntPtr num = Marshal.AllocHGlobal(cb);
      Marshal.StructureToPtr<AccentPolicy>(structure, num, false);
      MetaBlurWindow.SetWindowCompositionAttribute(windowInteropHelper.Handle, ref new WindowCompositionAttributeData()
      {
        Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY,
        SizeOfData = cb,
        Data = num
      });
      Marshal.FreeHGlobal(num);
    }
  }
}
```

- **`EnableBlur` Method:**
  - Creates a `WindowInteropHelper` to get the window handle (`HWND`).
  - Defines an `AccentPolicy` structure to specify the accent state (blur behind).
  - Allocates unmanaged memory to store the `AccentPolicy` structure.
  - Marshals the `AccentPolicy` structure to unmanaged memory.
  - Calls `SetWindowCompositionAttribute` with the window handle and composition attribute data to apply the blur effect.
  - Frees the allocated unmanaged memory.

### Supporting Structures and Enums (Not included in the provided code)

For the `EnableBlur` method to work correctly, the following supporting structures and enums would be necessary. These are typically defined outside the `MetaBlurWindow` class:

```csharp
internal enum WindowCompositionAttribute
{
    WCA_ACCENT_POLICY = 19
}

internal enum AccentState
{
    ACCENT_DISABLED = 0,
    ACCENT_ENABLE_GRADIENT = 1,
    ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
    ACCENT_ENABLE_BLURBEHIND = 3,
    ACCENT_ENABLE_ACRYLICBLURBEHIND = 4,
    ACCENT_ENABLE_HOSTBACKDROP = 5,
    ACCENT_ENABLE_ACRYLICBLURBEHIND1 = 6
}

[StructLayout(LayoutKind.Sequential)]
internal struct AccentPolicy
{
    public AccentState AccentState;
    public int AccentFlags;
    public int GradientColor;
    public int AnimationId;
}

[StructLayout(LayoutKind.Sequential)]
internal struct WindowCompositionAttributeData
{
    public WindowCompositionAttribute Attribute;
    public IntPtr Data;
    public int SizeOfData;
}
```

### Summary

The `MetaBlurWindow` class customizes a WPF window to enable a blur effect behind the window by using the Windows Composition API. It uses Platform Invocation Services (P/Invoke) to call native methods from `user32.dll` and marshals data between managed and unmanaged memory to apply the blur effect.

## /Meta/Editor/Controls/MetaDetachedTabControl.cs

The given code defines a custom control in C# using the Windows Presentation Foundation (WPF) framework. Let's break it down step by step.

### Namespaces and Directives

```csharp
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

#nullable enable
```

- `using System.Windows;`, `System.Windows.Controls;`, and `System.Windows.Data;`: These directives import necessary namespaces for WPF controls and data binding.
- `#nullable enable`: Enables nullable reference types to help with nullability checks and warnings.

### Namespace and Class Declaration

```csharp
namespace Meta.Editor.Controls
{
  public class MetaDetachedTabControl : ContentControl
  {
```

- The `Meta.Editor.Controls` namespace contains the custom controls.
- The `MetaDetachedTabControl` class inherits from `ContentControl`, which means it can hold a single piece of content.

### Dependency Property

```csharp
    public static readonly DependencyProperty HeaderControlProperty = DependencyProperty.Register(
        nameof(HeaderControl),
        typeof(Control),
        typeof(MetaDetachedTabControl),
        new FrameworkPropertyMetadata(null)
    );
```

- `HeaderControlProperty` is a `DependencyProperty`, which is a special type of property used in WPF to enable styles, data binding, animations, and more.
- `DependencyProperty.Register` registers a new dependency property named `HeaderControl`.
  - The name of the property is `HeaderControl`.
  - The property type is `Control`.
  - The owner type is `MetaDetachedTabControl`.
  - The metadata includes a default value of `null`.

### Property Definition

```csharp
    public Control HeaderControl
    {
      get => (Control) this.GetValue(MetaDetachedTabControl.HeaderControlProperty);
      set
      {
        this.SetValue(MetaDetachedTabControl.HeaderControlProperty, value);
        Binding binding = new Binding("SelectedContent")
        {
          Source = value,
          Mode = BindingMode.OneWay
        };
        BindingOperations.SetBinding(this, ContentControl.ContentProperty, binding);
      }
    }
  }
}
```

- The `HeaderControl` property is a wrapper around the `HeaderControlProperty` dependency property.
- The `get` accessor retrieves the value of the `HeaderControlProperty`.
- The `set` accessor sets the value of the `HeaderControlProperty` and also sets up a data binding:
  - It creates a new `Binding` to the `SelectedContent` property of the `HeaderControl`.
  - The binding mode is `OneWay`, meaning changes to `SelectedContent` will update the `ContentControl.ContentProperty`.
  - `BindingOperations.SetBinding` applies this binding to the current control (`this`), making the content of `MetaDetachedTabControl` reflect the `SelectedContent` of the `HeaderControl`.

### Summary

- The `MetaDetachedTabControl` class is a custom WPF control inheriting from `ContentControl`.
- It defines a `HeaderControl` property, which is a `DependencyProperty`.
- When the `HeaderControl` property is set, it binds the `ContentControl.ContentProperty` of `MetaDetachedTabControl` to the `SelectedContent` property of the `HeaderControl`.
- This setup allows the `MetaDetachedTabControl` to dynamically display the content selected in its header control.

## /Meta/Editor/Controls/MetaDirectorySelect.cs

This code defines a custom directory picker control named `MetaDirectorySelect` that extends the `DirectoryPicker` class from the `PropertyTools.Wpf` library. The `MetaDirectorySelect` control uses the `Ookii.Dialogs.Wpf` library to provide a more advanced folder browser dialog. Here's a detailed explanation of the code:

1. **Namespaces:**

   - `using Ookii.Dialogs.Wpf;`: This imports the `Ookii.Dialogs.Wpf` namespace, which contains the `VistaFolderBrowserDialog` class used to present a folder selection dialog.
   - `using PropertyTools.Wpf;`: This imports the `PropertyTools.Wpf` namespace, which likely contains the `DirectoryPicker` class that `MetaDirectorySelect` inherits from.
   - `using System;`: This imports the base class library for core functionalities.
   - `using System.Windows.Input;`: This imports classes related to commands, such as `ICommand` and `DelegateCommand`.

2. **Nullable Annotations:**

   - `#nullable disable`: This directive disables nullable reference type annotations for the file.

3. **Namespace and Class Definition:**

   - The `MetaDirectorySelect` class is defined within the `Meta.Editor.Controls` namespace.
   - `public class MetaDirectorySelect : DirectoryPicker`: This declares the `MetaDirectorySelect` class, which inherits from `DirectoryPicker`.

4. **Constructor:**

   - `public MetaDirectorySelect()`: This is the constructor for the `MetaDirectorySelect` class.
   - `this.BrowseCommand = (ICommand) new DelegateCommand(new Action(this.Browse));`: This line assigns a new `DelegateCommand` to the `BrowseCommand` property. The `DelegateCommand` is initialized with an `Action` delegate that calls the `Browse` method when executed.

5. **Browse Method:**
   - `private void Browse()`: This method is called when the `BrowseCommand` is executed.
   - `VistaFolderBrowserDialog folderBrowserDialog = new VistaFolderBrowserDialog();`: This creates a new instance of the `VistaFolderBrowserDialog` class.
   - `folderBrowserDialog.Description = "Please select a folder.";`: This sets the description text that appears in the folder browser dialog.
   - `folderBrowserDialog.UseDescriptionForTitle = true;`: This sets a flag to use the description as the title of the dialog.
   - `bool? nullable = folderBrowserDialog.ShowDialog();`: This shows the folder browser dialog and stores the result (a nullable boolean) in the `nullable` variable.
   - `if (!(1 == (nullable.GetValueOrDefault() ? 1 : 0) & nullable.HasValue)) return;`: This checks if the dialog result is `true` (meaning the user clicked "OK" and selected a folder). If the result is not `true`, the method returns without doing anything.
   - `this.Directory = folderBrowserDialog.SelectedPath;`: If the dialog result is `true`, this line sets the `Directory` property (inherited from `DirectoryPicker`) to the selected folder path.

In summary, the `MetaDirectorySelect` class provides a custom directory picker control that uses the `VistaFolderBrowserDialog` to allow users to select a folder. The `Browse` method handles the folder selection process, and the selected folder path is assigned to the `Directory` property.

## /Meta/Editor/Controls/MetaDockableWindow.cs

Certainly! Here's a breakdown of the provided C# code snippet:

### Namespaces and Directives

```csharp
using System.Windows;
#nullable enable
namespace Meta.Editor.Controls
```

- `using System.Windows;`: This statement includes the `System.Windows` namespace, which is part of the Windows Presentation Foundation (WPF) library and contains classes for creating Windows-based applications.
- `#nullable enable`: This directive enables nullable reference types in the code, allowing for better handling of null values and reducing the likelihood of null reference exceptions.

### Class Definition

```csharp
public class MetaDockableWindow : MetaWindow
```

- `public class MetaDockableWindow`: This defines a public class named `MetaDockableWindow`.
- `: MetaWindow`: This indicates that `MetaDockableWindow` inherits from another class called `MetaWindow`. Inheritance allows `MetaDockableWindow` to reuse and extend the functionality provided by `MetaWindow`.

### Properties

```csharp
public DependencyObject WindowParent { get; set; }
```

- `public DependencyObject WindowParent { get; set; }`: This defines a public property named `WindowParent` of type `DependencyObject`. The `{ get; set; }` part indicates that this property has both a getter and a setter, allowing for both reading and writing of its value. `DependencyObject` is a base class that enables WPF property system services on its many derived classes.

### Static Constructor

```csharp
static MetaDockableWindow()
{
  FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (MetaDockableWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (MetaDockableWindow)));
}
```

- `static MetaDockableWindow()`: This is a static constructor for the `MetaDockableWindow` class. Static constructors are called once, and only once, when the class is first accessed.
- `FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (MetaDockableWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (MetaDockableWindow)))`: This line overrides the default style key property metadata for the `MetaDockableWindow` class.
  - `FrameworkElement.DefaultStyleKeyProperty` is a dependency property that WPF uses to determine the style to apply to an element.
  - `OverrideMetadata` is a method that allows changing the metadata for a dependency property.
  - `typeof(MetaDockableWindow)` specifies that this override is for the `MetaDockableWindow` type.
  - `new FrameworkPropertyMetadata((object) typeof (MetaDockableWindow))` creates new metadata, setting the default style key to the `MetaDockableWindow` type itself. This means that WPF will look for a style specifically defined for `MetaDockableWindow`.

### Summary

This code defines a WPF window class named `MetaDockableWindow` that extends `MetaWindow`. It includes a property `WindowParent` of type `DependencyObject` and a static constructor that sets the default style key to ensure the correct style is applied to instances of `MetaDockableWindow`. The `#nullable enable` directive ensures better handling of nullable reference types, enhancing code safety and reliability.

## /Meta/Editor/Controls/MetaEngineChangeCallback.cs

This C# code snippet defines a delegate within the `Meta.Editor.Controls` namespace. Here's a detailed breakdown:

1. **Using Directive:**

   ```csharp
   using Meta.Core;
   ```

   This line indicates that the code will use types defined in the `Meta.Core` namespace. This helps to avoid fully qualifying the types from that namespace within the current file.

2. **Namespace Declaration:**

   ```csharp
   namespace Meta.Editor.Controls
   ```

   This line defines a namespace called `Meta.Editor.Controls`. Namespaces are used to organize code into a hierarchical structure, which helps to manage the scope of class and method names and to avoid naming conflicts.

3. **Nullable Disable Directive:**

   ```csharp
   #nullable disable
   ```

   This directive disables nullable reference types for the file. It means that the compiler will not issue warnings about potential null reference issues in this code.

4. **Delegate Declaration:**

   ```csharp
   public delegate void MetaEngineChangeCallback(EngineVersion version);
   ```

   This line defines a delegate named `MetaEngineChangeCallback`. Delegates are type-safe function pointers or references to methods. This particular delegate can reference any method that returns `void` and takes a single parameter of type `EngineVersion`.

   - **`public`:** The delegate is accessible from other classes and assemblies.
   - **`delegate`:** Indicates that this is a delegate type.
   - **`void`:** Specifies the return type of the methods that can be referenced by this delegate (no return value).
   - **`MetaEngineChangeCallback`:** The name of the delegate.
   - **`(EngineVersion version)`:** The parameter list for the methods that can be referenced by this delegate. It accepts a single parameter of type `EngineVersion`.

**Contextual Explanation:**

- **EngineVersion:** The `EngineVersion` type is likely defined in the `Meta.Core` namespace (as indicated by the using directive). This type is used as a parameter in the delegate, suggesting it represents some version information related to an engine (possibly a software engine, such as a game or rendering engine).

- **MetaEngineChangeCallback:** This delegate is intended to be used as a callback mechanism. Whenever the engine version changes, a method conforming to this delegate's signature can be called to handle the change. For example, you might have a method that logs the new version or updates the UI to reflect the version change.

Here’s an example usage of this delegate:

```csharp
namespace Meta.Editor.Controls
{
    public class EngineController
    {
        public event MetaEngineChangeCallback OnEngineVersionChanged;

        public void ChangeEngineVersion(EngineVersion newVersion)
        {
            // Logic to change the engine version
            // ...

            // Notify subscribers about the change
            OnEngineVersionChanged?.Invoke(newVersion);
        }
    }
}
```

In this example, `OnEngineVersionChanged` is an event that uses the `MetaEngineChangeCallback` delegate. The `ChangeEngineVersion` method changes the engine version and then invokes the delegate to notify any subscribers about the change.

## /Meta/Editor/Controls/MetaFlatbufferItem.cs

This C# code defines a class `MetaFlatbufferItem` within the `Meta.Editor.Controls` namespace. This class represents an item that can be used in a hierarchical structure, like a tree view. Here’s a detailed explanation of its components:

1. **Namespace Declaration**:

   - `namespace Meta.Editor.Controls`: Declares the namespace for the class, helping organize code and avoid naming conflicts.

2. **Nullable Enable Directive**:

   - `#nullable enable`: Enables nullable reference types, which helps catch potential null reference errors at compile-time.

3. **Class Definition**:

   - `public class MetaFlatbufferItem`: Defines a public class named `MetaFlatbufferItem`.

4. **Properties**:

   - `public bool IsVisible { get; set; }`: Indicates whether the item is visible.
   - `public int Index { get; set; }`: Represents the index of the item, possibly in a collection.
   - `public int Pointer { get; set; }`: Likely represents a memory address or a reference to another item.
   - `public bool IsExpanded { get; set; }`: Indicates whether the item (if a folder) is expanded to show its children.
   - `public string Name { get; set; }`: The name of the item.
   - `public object Data { get; set; }`: Holds any data associated with the item.
   - `public string Icon { get; set; } = "Folder"`: The icon representing the item, defaulting to "Folder".
   - `public string IconExpand { get; set; } = "FolderOpen"`: The icon used when the item is expanded, defaulting to "FolderOpen".
   - `public MetaFlatbufferItem.ItemType IType { get; set; }`: The type of the item, defined by the `ItemType` enum.
   - `public ObservableCollection<MetaFlatbufferItem> Children { get; set; }`: A collection of child items, allowing the representation of a hierarchy.

5. **Enum Definition**:
   - `public enum ItemType`: Defines an enumeration `ItemType` with three possible values:
     - `Folder`: Represents a folder item.
     - `Root`: Represents the root item of the hierarchy.
     - `Data`: Represents a data item.

The `MetaFlatbufferItem` class can be used to build hierarchical structures, such as a file explorer, where each item can be a folder, root, or data item. The `ObservableCollection` ensures that changes to the collection (like adding or removing children) are automatically reflected in any UI components bound to it.

## /Meta/Editor/Controls/MetaMessageBox.cs

The provided C# code defines a custom message box class `MetaMessageBox` within the `Meta.Editor.Controls` namespace. This class extends a hypothetical `MetaDockableWindow` and implements custom properties and behaviors to display a message box in a WPF application. Let's break it down:

### Namespace and Class Definition

```csharp
using System;
using System.Threading;
using System.Windows;

#nullable enable
namespace Meta.Editor.Controls
{
  public class MetaMessageBox : MetaDockableWindow
  {
    // Class body
  }
}
```

- The code starts by enabling nullable reference types with `#nullable enable`.
- It defines the `MetaMessageBox` class within the `Meta.Editor.Controls` namespace, inheriting from `MetaDockableWindow`.

### Dependency Properties

```csharp
public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(MetaMessageBox), new PropertyMetadata(""));
public static readonly DependencyProperty AlignmentProperty = DependencyProperty.Register(nameof(Alignment), typeof(TextAlignment), typeof(MetaMessageBox), new PropertyMetadata(TextAlignment.Left));
public static readonly DependencyProperty ButtonsProperty = DependencyProperty.Register(nameof(Buttons), typeof(MessageBoxButton), typeof(MetaMessageBox), new PropertyMetadata(MessageBoxButton.OK));
```

- These lines define three dependency properties: `TextProperty`, `AlignmentProperty`, and `ButtonsProperty`. Dependency properties are used in WPF for property binding, styling, and other purposes.

### CLR Properties

```csharp
public string Text
{
  get => (string)this.GetValue(MetaMessageBox.TextProperty);
  set => this.SetValue(MetaMessageBox.TextProperty, value);
}

public TextAlignment Alignment
{
  get => (TextAlignment)this.GetValue(MetaMessageBox.AlignmentProperty);
  set => this.SetValue(MetaMessageBox.AlignmentProperty, value);
}

public MessageBoxButton Buttons
{
  get => (MessageBoxButton)this.GetValue(MetaMessageBox.ButtonsProperty);
  set => this.SetValue(MetaMessageBox.ButtonsProperty, value);
}
```

- These are the CLR properties that wrap the dependency properties, providing a more convenient way to get and set their values.

### Other Properties and Constructor

```csharp
public MessageBoxResult MessageBoxResult { get; set; }

public MetaMessageBox()
{
  this.Topmost = true;
  this.ShowInTaskbar = false;
  this.ResizeMode = ResizeMode.NoResize;
  this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
  this.MessageBoxResult = MessageBoxResult.Cancel;
  this.SizeToContent = SizeToContent.Height;
  this.Width = 500.0;
  this.Height = 150.0;
  this.Icon = Application.Current.MainWindow.Icon;
}
```

- `MessageBoxResult` is a property that stores the result of the message box (e.g., OK, Cancel).
- The constructor initializes various properties to configure the appearance and behavior of the message box, such as setting it to be topmost, not showing in the taskbar, disabling resizing, centering on the screen, etc.

### Overriding `OnApplyTemplate`

```csharp
public override void OnApplyTemplate()
{
  base.OnApplyTemplate();
  this.Width = 100.0;
}
```

- This method overrides `OnApplyTemplate` from the base class to adjust the width of the message box template.

### Method to Close the Message Box

```csharp
public void RequestClose(MessageBoxResult result)
{
  this.MessageBoxResult = result;
  this.Close();
}
```

- This method sets the `MessageBoxResult` and then closes the message box.

### Static Show Methods

```csharp
public static MessageBoxResult Show(string text)
{
  bool rememberAction = false;
  return MetaMessageBox.ShowInternal(text, "", MessageBoxButton.OK, false, ref rememberAction);
}

public static MessageBoxResult Show(string text, string title)
{
  bool rememberAction = false;
  return MetaMessageBox.ShowInternal(text, title, MessageBoxButton.OK, false, ref rememberAction);
}

public static MessageBoxResult Show(string text, string title, MessageBoxButton button)
{
  bool rememberAction = false;
  return MetaMessageBox.ShowInternal(text, title, button, false, ref rememberAction);
}

public static MessageBoxResult Show(string text, string title, MessageBoxButton button, ref bool rememberAction)
{
  return MetaMessageBox.ShowInternal(text, title, button, true, ref rememberAction);
}
```

- These static methods are overloaded versions of the `Show` method, allowing the message box to be displayed with varying levels of detail (just text, text with title, text with title and buttons, etc.).

### Internal Show Method

```csharp
private static MessageBoxResult ShowInternal(
  string text,
  string title,
  MessageBoxButton button,
  bool rememberActionPrompt,
  ref bool rememberAction)
{
  MessageBoxResult msgBoxResult = MessageBoxResult.None;
  TextAlignment alignment = TextAlignment.Center;
  if (text.Contains("\r\n"))
    alignment = TextAlignment.Left;
  if (Thread.CurrentThread.GetApartmentState() != 0)
  {
    bool result = false;
    bool flag = false;
    Application.Current.Dispatcher.Invoke((Action)(() =>
    {
      MetaMessageBox metaMessageBox = new MetaMessageBox()
      {
        Text = text,
        Title = title,
        Buttons = button,
        Alignment = alignment
      };
      metaMessageBox.ShowDialog();
      result = true;
      msgBoxResult = metaMessageBox.MessageBoxResult;
    }));
    while (!result)
      Thread.Sleep(10);
    rememberAction = flag;
  }
  else
  {
    MetaMessageBox metaMessageBox1 = new MetaMessageBox();
    metaMessageBox1.Text = text;
    metaMessageBox1.Title = title;
    metaMessageBox1.Buttons = button;
    metaMessageBox1.Alignment = alignment;
    MetaMessageBox metaMessageBox2 = metaMessageBox1;
    metaMessageBox2.ShowDialog();
    msgBoxResult = metaMessageBox2.MessageBoxResult;
  }
  return msgBoxResult;
}
```

- This method handles the actual display of the message box. It checks if the current thread's apartment state is not STA (Single Threaded Apartment), and if so, it uses the dispatcher to invoke the message box on the UI thread. It sets the properties and shows the message box as a dialog, then returns the result.

### Summary

- **Purpose**: The `MetaMessageBox` class is a custom WPF message box with additional properties for text, alignment, and buttons, providing flexibility in how message boxes are displayed.
- **Key Features**:
  - Dependency properties for text, alignment, and buttons.
  - CLR properties for easy access to dependency properties.
  - Configurable constructor settings.
  - Methods to display the message box in different ways and handle the result.

This class provides a customizable message box solution for WPF applications, allowing for tailored user prompts and interactions.

## /Meta/Editor/Controls/MetaPropertyGridFactory.cs

The provided code defines a custom property grid control factory named `MetaPropertyGridFactory` within the `Meta.Editor.Controls` namespace. This factory is responsible for creating specific types of controls based on the attributes of the property items passed to it. Here's a breakdown of the code:

### Namespaces and Usings

- The code imports various namespaces for WPF (Windows Presentation Foundation) controls and data binding:

  ```csharp
  using Meta.Editor.Controls.CreationSuite;
  using PropertyTools.Wpf;
  using System;
  using System.Linq;
  using System.Windows;
  using System.Windows.Controls;
  using System.Windows.Controls.Primitives;
  using System.Windows.Data;
  ```

### Nullable Context

- `#nullable enable`: Enables nullable reference types, allowing the code to express whether a variable can be null.

### Namespace and Class Definition

- The `MetaPropertyGridFactory` class inherits from `PropertyGridControlFactory` and overrides the method for creating controls:

  ```csharp
  namespace Meta.Editor.Controls
  {
    public class MetaPropertyGridFactory : PropertyGridControlFactory
    {
  ```

### CreateControl Method

- This method determines which control to create based on the attributes of the `PropertyItem`:

  ```csharp
  public virtual FrameworkElement CreateControl(PropertyItem pi, PropertyControlFactoryOptions options)
  {
    if (pi.GetAttribute<ImportantAttribute>() != null)
      return this.CreateAutoCompleteControl(pi, options);
    if (pi.GetAttribute<CrowdSignAttribute>() != null)
      return this.CreateAutoCompleteCrowdControl(pi, options);
    if (pi.GetAttribute<CountryAttribute>() != null)
      return this.CreateCountryScrollControl(pi, options);
    return pi.GetAttribute<MetaDirectorySelectAttribute>() != null ? this.CreateMetaDirectorySelectControl(pi) : base.CreateControl(pi, options);
  }
  ```

### CreateMetaDirectorySelectControl Method

- Creates a `MetaDirectorySelect` control for selecting directories:

  ```csharp
  protected virtual FrameworkElement CreateMetaDirectorySelectControl(PropertyItem property)
  {
    MetaDirectorySelect metaDirectorySelect = new MetaDirectorySelect();
    metaDirectorySelect.FolderBrowserDialogService = this.FolderBrowserDialogService;
    MetaDirectorySelect directorySelectControl = metaDirectorySelect;
    UpdateSourceTrigger updateSourceTrigger = property.AutoUpdateText ? UpdateSourceTrigger.PropertyChanged : UpdateSourceTrigger.Default;
    ((FrameworkElement)directorySelectControl).SetBinding(DirectoryPicker.DirectoryProperty, (BindingBase)property.CreateBinding(updateSourceTrigger, true));
    return (FrameworkElement)directorySelectControl;
  }
  ```

### CreateCountryScrollControl Method

- Creates a combo box for selecting countries:

  ```csharp
  protected virtual FrameworkElement CreateCountryScrollControl(PropertyItem pi, PropertyControlFactoryOptions options)
  {
    AutoFilteredComboBox filteredComboBox1 = new AutoFilteredComboBox();
    filteredComboBox1.Name = "WrestlerCountries";
    filteredComboBox1.SelectedValuePath = "index";
    filteredComboBox1.IsEditable = true;
    filteredComboBox1.IsDropDownOpen = false;
    filteredComboBox1.StaysOpenOnEdit = true;
    AutoFilteredComboBox filteredComboBox2 = filteredComboBox1;
    DataTemplate dataTemplate1 = new DataTemplate();
    dataTemplate1.VisualTree = new FrameworkElementFactory(typeof(StackPanel));
    DataTemplate dataTemplate2 = dataTemplate1;
    filteredComboBox2.ItemTemplate = dataTemplate2;
    filteredComboBox1.ItemsPanel = new ItemsPanelTemplate(new FrameworkElementFactory(typeof(VirtualizingStackPanel)));
    AutoFilteredComboBox element = filteredComboBox1;
    if (pi.ItemsSourceDescriptor != null)
      element.SetBinding(ItemsControl.ItemsSourceProperty, (BindingBase)new Binding(pi.ItemsSourceDescriptor.Name));
    element.SetBinding(Selector.SelectedItemProperty, (BindingBase)pi.CreateBinding(UpdateSourceTrigger.Default, true));
    MultiBinding binding1 = new MultiBinding();
    binding1.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
    binding1.StringFormat = "{0} {1} {2}";
    Binding binding2 = new Binding("country");
    Binding binding3 = new Binding("state");
    Binding binding4 = new Binding("city");
    binding1.Bindings.Add((BindingBase)binding2);
    binding1.Bindings.Add((BindingBase)binding3);
    binding1.Bindings.Add((BindingBase)binding4);
    FrameworkElementFactory child = new FrameworkElementFactory(typeof(TextBlock));
    child.SetBinding(TextBlock.TextProperty, (BindingBase)binding1);
    child.SetValue(TextBlock.FontWeightProperty, (object)FontWeights.Bold);
    element.ItemTemplate.VisualTree.AppendChild(child);
    Grid countryScrollControl = new Grid();
    countryScrollControl.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1.0, GridUnitType.Star) });
    countryScrollControl.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1.0, GridUnitType.Auto) });
    countryScrollControl.Children.Add((UIElement)element);
    return (FrameworkElement)countryScrollControl;
  }
  ```

### CreateAutoCompleteCrowdControl Method

- Creates a combo box with auto-complete functionality for crowd control:

  ```csharp
  protected virtual FrameworkElement CreateAutoCompleteCrowdControl(PropertyItem pi, PropertyControlFactoryOptions options)
  {
    AutoFilteredComboBox filteredComboBox1 = new AutoFilteredComboBox();
    filteredComboBox1.IsEditable = true;
    filteredComboBox1.IsDropDownOpen = false;
    filteredComboBox1.StaysOpenOnEdit = true;
    AutoFilteredComboBox filteredComboBox2 = filteredComboBox1;
    DataTemplate dataTemplate1 = new DataTemplate();
    dataTemplate1.VisualTree = new FrameworkElementFactory(typeof(VirtualizingStackPanel));
    DataTemplate dataTemplate2 = dataTemplate1;
    filteredComboBox2.ItemTemplate = dataTemplate2;
    filteredComboBox1.ItemsPanel = new ItemsPanelTemplate(new FrameworkElementFactory(typeof(VirtualizingStackPanel)));
    AutoFilteredComboBox element = filteredComboBox1;
    if (pi.ItemsSourceDescriptor != null)
      element.SetBinding(ItemsControl.ItemsSourceProperty, (BindingBase)new Binding(pi.ItemsSourceDescriptor.Name) { Converter = (IValueConverter)new ItemsSourceConverter() });
    element.SetBinding(Selector.SelectedItemProperty, (BindingBase)pi.CreateBinding(UpdateSourceTrigger.Default, true));
    MultiBinding binding1 = new MultiBinding();
    binding1.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
    binding1.StringFormat = "{0} {1}";
    Binding binding2 = new Binding("Id");
    Binding binding3 = new Binding("Name");
    binding1.Bindings.Add((BindingBase)binding2);
    binding1.Bindings.Add((BindingBase)binding3);
    FrameworkElementFactory child = new FrameworkElementFactory(typeof(TextBlock));
    child.SetBinding(TextBlock.TextProperty, (BindingBase)binding1);
    child.SetValue(TextBlock.FontWeightProperty, (object)FontWeights.Bold);
    element.ItemTemplate.VisualTree.AppendChild(child);
    Grid completeCrowdControl = new Grid();
    completeCrowdControl.Children.Add((UIElement)element);
    return (FrameworkElement)completeCrowdControl;
  }
  ```

### CreateAutoCompleteControl Method

- Creates a combo box with auto-complete functionality:

  ```csharp
  protected virtual FrameworkElement CreateAutoCompleteControl(PropertyItem pi, PropertyControlFactoryOptions options)
  {
    AutoFilteredComboBox filteredComboBox1 = new AutoFilteredComboBox();
    filteredComboBox1.IsEditable = true;
    filteredComboBox1.IsDropDownOpen = false;
    filteredComboBox1.StaysOpenOnEdit = true;
    filteredComboBox1.IsSynchronizedWithCurrentItem = new bool?(false);
    AutoFilteredComboBox filteredComboBox2 = filteredComboBox1;
    DataTemplate dataTemplate1 = new DataTemplate();
    dataTemplate1.VisualTree = new FrameworkElementFactory(typeof(VirtualizingStackPanel));
    DataTemplate dataTemplate2 = dataTemplate1;
    filteredComboBox2.ItemTemplate = dataTemplate2;
    filteredComboBox1.ItemsPanel = new ItemsPanelTemplate(new FrameworkElementFactory(typeof(VirtualizingStackPanel)));
    AutoFilteredComboBox s1 = filteredComboBox1;
    if (pi.ItemsSourceDescriptor != null)
      s1.SetBinding(ItemsControl.ItemsSourceProperty, (BindingBase)new Binding(pi.ItemsSourceDescriptor.Name) { Converter = (IValueConverter)new ItemsSourceConverter() });
    s1.SetBinding(Selector.SelectedItemProperty, (BindingBase)pi.CreateBinding(UpdateSourceTrigger.PropertyChanged, true));
    s1.Loaded += (RoutedEventHandler)((sender, e) =>
    {
      DefaultIndexAttribute defaultSelectedItemIndexAttribute = pi.GetAttribute<DefaultIndexAttribute>();
      if (defaultSelectedItemIndexAttribute == null)
        return;
      s1.SelectedValue = (object)s1.ItemsSource.Cast<JObject>().FirstOrDefault<JObject>((Func<JObject, bool>)(s => s.Name.Equals(defaultSelectedItemIndexAttribute.DefaultSelectedIndex)));
    });
    FrameworkElementFactory child = new FrameworkElementFactory(typeof(TextBlock));
    child.SetBinding(TextBlock.TextProperty, (BindingBase)new Binding("Name"));
    child.SetValue(TextBlock.FontWeightProperty, (object)FontWeights.Bold);
    s1.ItemTemplate.VisualTree.AppendChild(child);
    Grid autoCompleteControl = new Grid();
    autoCompleteControl.Children.Add((UIElement)s1);
    return (FrameworkElement)autoCompleteControl;
  }
  }
  ```

### Summary

- The `MetaPropertyGridFactory` class customizes the creation of property grid controls based on specific attributes (`ImportantAttribute`, `CrowdSignAttribute`, `CountryAttribute`, `MetaDirectorySelectAttribute`).
- It uses WPF controls such as `AutoFilteredComboBox`, `Grid`, and `TextBlock`, and employs data binding techniques to link properties to UI elements.

- The methods override the base functionality to create specific types of controls (auto-complete combo boxes, country selectors, directory selectors) based on the presence of particular attributes on the property items.

## /Meta/Editor/Controls/MetaPropertyGridOperator.cs

This C# code defines a custom class `MetaPropertyGridOperator` that extends the functionality of the `PropertyGridOperator` class from the `PropertyTools.Wpf` library. Here’s a breakdown of what each part of the code does:

1. **Using Directives**:

   ```csharp
   using PropertyTools.Wpf;
   using System.ComponentModel;
   ```

   These directives include namespaces that provide access to the `PropertyTools.Wpf` library and the `System.ComponentModel` namespace. The `PropertyTools.Wpf` library is likely used for creating property grids in WPF applications, while `System.ComponentModel` provides classes for working with properties and attributes.

2. **Nullable Context**:

   ```csharp
   #nullable enable
   ```

   This directive enables nullable reference types for the code that follows, allowing the code to provide better null safety by distinguishing between nullable and non-nullable reference types.

3. **Namespace Declaration**:

   ```csharp
   namespace Meta.Editor.Controls
   ```

   This line declares a namespace called `Meta.Editor.Controls`. Namespaces are used to organize code into a hierarchical structure and avoid name conflicts.

4. **Class Declaration**:

   ```csharp
   public class MetaPropertyGridOperator : PropertyGridOperator
   ```

   This line declares a public class named `MetaPropertyGridOperator` that inherits from the `PropertyGridOperator` class. By inheriting from `PropertyGridOperator`, `MetaPropertyGridOperator` can extend or modify its functionality.

5. **Protected Virtual Method**:

   ```csharp
   protected virtual PropertyItem CreateCore(
     PropertyDescriptor pd,
     PropertyDescriptorCollection properties)
   {
     return base.CreateCore(pd, properties);
   }
   ```

   This method overrides a method from the base class. The `CreateCore` method takes two parameters:

   - `pd`: A `PropertyDescriptor` object that provides information about a property, such as its name, type, and attributes.
   - `properties`: A `PropertyDescriptorCollection` object that represents a collection of `PropertyDescriptor` objects.

   The method is marked as `protected` (accessible within its own class and by derived class instances) and `virtual` (can be overridden by derived classes).

   Inside the method, it simply calls the base class's `CreateCore` method with the same parameters and returns the result. This allows any derived class to override `CreateCore` and provide its own implementation while still having the option to call the base class’s implementation.

**Summary**:
This code defines a custom class `MetaPropertyGridOperator` that extends the `PropertyGridOperator` class from the `PropertyTools.Wpf` library. The primary purpose of this class is to override the `CreateCore` method, which creates property items for a property grid, but in this case, it simply calls the base implementation. The use of `#nullable enable` ensures better null safety by enabling nullable reference types.

## /Meta/Editor/Controls/MetaSaveFileDialog.cs

This code defines a class `MetaSaveFileDialog` within the `Meta.Editor.Controls` namespace in C#. This class is a custom wrapper around the `SaveFileDialog` class from the `Microsoft.Win32` namespace, adding some additional functionality. Here’s a breakdown of the code:

### Namespaces

- `Meta.Core` and `Microsoft.Win32`: These namespaces are imported, allowing the code to use classes and methods defined within them.

### Class Definition

- `MetaSaveFileDialog`: This is the main class being defined.

### Class Members

1. **Private Members**:

   - `string key`: A private string variable to store the configuration key.
   - `SaveFileDialog sfd`: An instance of the `SaveFileDialog` class.
   - `bool config`: A flag to indicate whether to save the configuration or not.

2. **Public Properties**:
   - `FileName`: Gets the file name selected in the `SaveFileDialog`.
   - `InitialDirectory`: Gets or sets the initial directory shown in the `SaveFileDialog`.
   - `FilterIndex`: Gets the index of the filter selected in the `SaveFileDialog`.

### Constructor

- The constructor initializes the `MetaSaveFileDialog` with the following parameters:
  - `title`: The title of the `SaveFileDialog`.
  - `filter`: The filter string to determine which file types to display.
  - `inKey`: A string key used for configuration purposes.
  - `filename`: The default file name to display (optional, defaults to an empty string).
  - `overwritePrompt`: A boolean indicating whether to prompt the user if the selected file already exists (optional, defaults to true).
  - `config`: A boolean indicating whether to save the configuration (optional, defaults to true).

### Methods

- `ShowDialog()`: Shows the `SaveFileDialog` and returns `true` if the user selects a file and clicks OK, and `false` otherwise. If the `config` flag is true, it saves the selected file path to a configuration.

### Detailed Explanation

```csharp
public class MetaSaveFileDialog
{
  // Private fields
  private string key;
  private SaveFileDialog sfd;
  private bool config;

  // Public properties to access SaveFileDialog properties
  public string FileName => this.sfd.FileName;

  public string InitialDirectory
  {
    get => this.sfd.InitialDirectory;
    set => this.sfd.InitialDirectory = value;
  }

  public int FilterIndex => this.sfd.FilterIndex;

  // Constructor initializing the SaveFileDialog with given parameters
  public MetaSaveFileDialog(
    string title,
    string filter,
    string inKey,
    string filename = "",
    bool overwritePrompt = true,
    bool config = true)
  {
    this.key = inKey + "_ExportPath";
    SaveFileDialog saveFileDialog = new SaveFileDialog();
    saveFileDialog.Title = title;
    saveFileDialog.Filter = filter;
    saveFileDialog.FileName = filename;
    saveFileDialog.OverwritePrompt = overwritePrompt;
    this.sfd = saveFileDialog;
    this.config = config;
  }

  // Method to show the dialog and handle configuration saving
  public bool ShowDialog()
  {
    bool? nullable = this.sfd.ShowDialog();
    bool flag = true;
    if (!(nullable.GetValueOrDefault() == flag & nullable.HasValue))
      return false;
    if (this.config)
    {
      Config.Add(this.key, (object) this.sfd.FileName);
      Config.Save();
    }
    return true;
  }
}
```

### Summary

- **Purpose**: The `MetaSaveFileDialog` class provides a customized save file dialog with added functionality to save the chosen file path to a configuration file.
- **Constructor**: Initializes a `SaveFileDialog` with specific parameters and an optional configuration save feature.
- **ShowDialog Method**: Displays the dialog, and if a file is selected and the `config` flag is true, saves the file path to a configuration.

This class is useful in applications where you need to display a save file dialog and optionally save the file path to a configuration for later use.

## /Meta/Editor/Controls/MetaSDBControl.cs

The provided code is a C# implementation of a custom WPF control named `MetaSDBControl`. This control is designed to manage and interact with a string database (SDB). Let's break down its components and functionalities:

### Namespaces and Dependencies

The code imports several namespaces, which provide the necessary classes and methods for various functionalities:

- **Meta.Core, Meta.Core.Interfaces, Meta.Core.IO, Meta.Editor.Commands, Meta.Editor.Extensions, Meta.Editor.Windows**: These are custom namespaces likely related to the Meta framework or library, providing core functionalities, interfaces, IO operations, commands, extensions, and window management.
- **System, System.Collections, System.Collections.Generic, System.Collections.ObjectModel, System.ComponentModel, System.IO, System.Linq, System.Text, System.Text.RegularExpressions, System.Windows, System.Windows.Controls, System.Windows.Data, System.Windows.Input, System.Windows.Threading**: These are standard .NET namespaces used for collections, IO operations, LINQ queries, text manipulation, regular expressions, WPF controls, data binding, input handling, and thread dispatching.

### MetaSDBControl Class

The `MetaSDBControl` class inherits from `MetaBaseControl` and implements the `INotifyPropertyChanged` interface. It is a custom WPF control for managing an SDB. Here's an overview of its key components and functionalities:

#### Fields and Properties

- **dataGrid, filterTb, newStringID, newStringText, newSDBBtn**: These are private fields representing various UI elements like a `DataGrid`, `MetaWatermarkTextbox`, and `TextBox` for string ID and text, and a `Button` for adding new SDB entries.
- **sdbCache**: A cache for storing `ObservableCollection<SDBAsset>`.
- **StringsDatabase**: An observable collection of `SDBAsset` objects, representing the SDB.
- **firstTimeLoad**: A boolean flag indicating if the control is loaded for the first time.
- **Type**: Enum representing header tags for the SDB.
- **\_isGUIDOverride**: A private boolean field with a public property `GUIDOverride` for GUID override functionality.

#### Static Constructor and Constructor

- **Static Constructor**: Sets the default style key for the control.
- **Constructor**: Initializes the control with a logger.

#### Methods

- **RegisterToolbarItems()**: Registers toolbar items with save and patch functionalities.
- **OnApplyTemplate()**: Applies the control's template and sets up event handlers.
- **DataGrid_CellEditEnding()**: Handles cell edit ending events in the `DataGrid`.
- **NewSDBBtn_Click()**: Handles the click event for adding new entries to the SDB.
- **FilterTb_KeyUp(), FilterTb_LostFocus()**: Handle key up and lost focus events for the filter textbox.
- **SaveStringDatabase()**: Saves the current state of the string database.
- **PatchStringDatabase()**: Patches the SDB with cached data.
- **LoadCache()**: Loads the SDB cache.
- **UnpackDatabase()**: Unpacks the SDB from a file into an observable collection.
- **DemangleString()**: Demangles a string using a specific algorithm.
- **SDBControl_Loaded()**: Handles the control's loaded event and initializes the SDB.

#### Enum

- **HeaderTags**: Represents header tags for the SDB with values `SDB_NO_MANGLING` and `SDB_MANGLED`.

### Summary

The `MetaSDBControl` class is a comprehensive custom control for managing a string database within a WPF application. It includes functionalities for loading, displaying, filtering, adding, editing, saving, and patching string entries in the SDB. The control interacts with various UI elements, handles events, and leverages a caching mechanism for efficient data management.

## /Meta/Editor/Controls/MetaSpinner.cs

The given code defines a custom control in WPF (Windows Presentation Foundation) in C#. Here’s a detailed explanation:

### Namespaces

```csharp
using System.Windows;
using System.Windows.Controls;
```

- **System.Windows**: This namespace includes classes for creating and managing Windows-based applications.
- **System.Windows.Controls**: This namespace includes the base classes for user interface controls like buttons, text boxes, and other UI elements.

### Nullable Directive

```csharp
#nullable disable
```

- This directive disables nullable reference types for the file, meaning the compiler will not warn about possible null reference exceptions in this code.

### Namespace and Class Definition

```csharp
namespace Meta.Editor.Controls
{
  public class MetaSpinner : Control
  {
    static MetaSpinner()
    {
      FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (MetaSpinner), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (MetaSpinner)));
    }
  }
}
```

1. **Namespace**: `Meta.Editor.Controls`

   - This is the logical grouping of related classes. Namespaces help organize code and prevent naming conflicts.

2. **Class**: `MetaSpinner`

   - This class inherits from `Control`, which is a base class for WPF controls.

3. **Static Constructor**: `static MetaSpinner()`

   - A static constructor is called once per type, not per instance, and is used to initialize static members or to perform actions that need to be done only once.

4. **OverrideMetadata**:

   ```csharp
   FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(MetaSpinner), new FrameworkPropertyMetadata(typeof(MetaSpinner)));
   ```

   - `DefaultStyleKeyProperty` is a dependency property used by WPF to apply a style to a control.
   - `OverrideMetadata` method changes the metadata for the `DefaultStyleKeyProperty` for the `MetaSpinner` class.
   - This line ensures that WPF looks for a default style for `MetaSpinner` in the resource dictionaries, typically defined in `Generic.xaml` in the themes folder.

### Explanation Summary

This code defines a custom control named `MetaSpinner` in WPF. The static constructor for `MetaSpinner` ensures that when WPF applies styles, it will use the default style defined for `MetaSpinner`. This is done by overriding the metadata of the `DefaultStyleKeyProperty` to associate the `MetaSpinner` class with its style. This setup allows the custom control to be styled correctly using WPF’s theming and styling system.

## /Meta/Editor/Controls/MetaTabControl.cs

The code provided is a custom implementation of a `TabControl` in WPF (Windows Presentation Foundation) named `MetaTabControl`. This control extends the default `TabControl` and adds custom functionality for scrolling through the tabs using buttons. Let's break down the key parts:

### Namespaces and Directives

```csharp
using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

#nullable enable
```

- `using` directives import necessary namespaces.
- `#nullable enable` enables nullable reference types.

### Namespace and Class Declaration

```csharp
namespace Meta.Editor.Controls
{
  [TemplatePart(Name = "PART_ScrollLeft", Type = typeof (RepeatButton))]
  [TemplatePart(Name = "PART_ScrollRight", Type = typeof (RepeatButton))]
  [TemplatePart(Name = "PART_ScrollViewer", Type = typeof (ScrollViewer))]
  public class MetaTabControl : TabControl
  {
    private const string PART_ScrollLeft = "PART_ScrollLeft";
    private const string PART_ScrollRight = "PART_ScrollRight";
    private const string PART_ScrollViewer = "PART_ScrollViewer";
    private RepeatButton? scrollLeftButton;
    private RepeatButton? scrollRightButton;
    private ScrollViewer? scrollViewer;
```

- Declares the `Meta.Editor.Controls` namespace and the `MetaTabControl` class.
- `MetaTabControl` extends `TabControl`.
- Uses `TemplatePart` attributes to define parts of the control's template, linking template part names to their types.
- Declares constants for template part names and nullable fields for the template parts.

### OnApplyTemplate Method

```csharp
    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      this.scrollLeftButton = this.GetTemplateChild("PART_ScrollLeft") as RepeatButton;
      this.scrollLeftButton.Click += new RoutedEventHandler(this.ScrollLeftButton_Click);
      this.scrollRightButton = this.GetTemplateChild("PART_ScrollRight") as RepeatButton;
      this.scrollRightButton.Click += new RoutedEventHandler(this.ScrollRightButton_Click);
      this.scrollViewer = this.GetTemplateChild("PART_ScrollViewer") as ScrollViewer;
      this.scrollViewer.Loaded += (RoutedEventHandler) ((s, e) => this.UpdateControls());
      this.scrollViewer.ScrollChanged += (ScrollChangedEventHandler) ((s, e) => this.UpdateControls());
      this.SelectionChanged += (SelectionChangedEventHandler) ((s, e) => this.ScrollToSelectedItem());
    }
```

- `OnApplyTemplate` is called when the control's template is applied.
- Retrieves template parts (`PART_ScrollLeft`, `PART_ScrollRight`, `PART_ScrollViewer`) and assigns them to fields.
- Hooks up event handlers for button clicks, `ScrollViewer` load, scroll changes, and selection changes.

### Scroll Button Click Handlers

```csharp
    private void ScrollLeftButton_Click(object sender, RoutedEventArgs e)
    {
      this.ScrollToItem(this.GetItemByOffset(Math.Max(this.scrollViewer.HorizontalOffset, 0.0)));
    }

    private void ScrollRightButton_Click(object sender, RoutedEventArgs e)
    {
      this.ScrollToItem(this.GetItemByOffset(Math.Min(this.scrollViewer.HorizontalOffset + this.scrollViewer.ViewportWidth + 1.0, this.scrollViewer.ExtentWidth)));
    }
```

- `ScrollLeftButton_Click` and `ScrollRightButton_Click` handle scrolling left and right, respectively, by calculating the offset and calling `ScrollToItem`.

### UpdateControls Method

```csharp
    private void UpdateControls()
    {
      double num1 = Math.Max(this.scrollViewer.HorizontalOffset, 0.0);
      double num2 = Math.Max(this.scrollViewer.ScrollableWidth, 0.0);
      this.scrollLeftButton.Visibility = num2 == 0.0 ? Visibility.Collapsed : Visibility.Visible;
      this.scrollRightButton.Visibility = num2 == 0.0 ? Visibility.Collapsed : Visibility.Visible;
      this.scrollLeftButton.IsEnabled = num1 > 0.0;
      this.scrollRightButton.IsEnabled = num1 < num2;
    }
```

- `UpdateControls` updates the visibility and enabled state of the scroll buttons based on the scroll position and scrollable width.

### ScrollToSelectedItem Method

```csharp
    private void ScrollToSelectedItem()
    {
      if (!(this.SelectedItem is TabItem selectedItem))
        return;
      if (selectedItem.ActualWidth == 0.0 && !selectedItem.IsLoaded)
        selectedItem.Loaded += (RoutedEventHandler) ((s, e) => this.ScrollToSelectedItem());
      else
        this.ScrollToItem(selectedItem);
    }
```

- `ScrollToSelectedItem` ensures the selected tab item is scrolled into view. If the item is not fully loaded, it waits until it is loaded to scroll.

### ScrollToItem Method

```csharp
    private void ScrollToItem(TabItem ti)
    {
      double offset = 0.0;
      foreach (TabItem tabItem in (IEnumerable) this.Items)
      {
        if (tabItem != ti)
          offset += tabItem.ActualWidth;
        else
          break;
      }
      if (offset + ti.ActualWidth > this.scrollViewer.HorizontalOffset + this.scrollViewer.ViewportWidth)
      {
        this.scrollViewer.ScrollToHorizontalOffset(offset + ti.ActualWidth - this.scrollViewer.ViewportWidth);
      }
      else
      {
        if (offset >= this.scrollViewer.HorizontalOffset)
          return;
        this.scrollViewer.ScrollToHorizontalOffset(offset);
      }
    }
```

- `ScrollToItem` calculates the offset required to scroll a specific `TabItem` into view.

### GetItemByOffset Method

```csharp
    private TabItem GetItemByOffset(double offset)
    {
      double num = 0.0;
      foreach (TabItem itemByOffset in (IEnumerable) this.Items)
      {
        if (num + itemByOffset.ActualWidth >= offset)
          return itemByOffset;
        num += itemByOffset.ActualWidth;
      }
      return this.Items[this.Items.Count - 1] as TabItem;
    }
  }
}
```

- `GetItemByOffset` returns the `TabItem` at a specific offset.

### Summary

`MetaTabControl` enhances a `TabControl` with scroll buttons to navigate through tabs. It customizes the control's behavior using template parts and handles various events to manage scrolling, ensuring the selected tab is always visible and updating the state of the scroll buttons as needed.

## /Meta/Editor/Controls/MetaTabItem.cs

This code defines a custom control named `MetaTabItem` that inherits from `TabItem` in the `System.Windows.Controls` namespace. It is part of the `Meta.Editor.Controls` namespace. The control includes various properties, events, and methods to enhance its functionality. Below is an explanation of each section of the code:

### Using Directives

```csharp
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
```

These are the namespaces that are being used in this file for WPF (Windows Presentation Foundation) functionalities, including basic controls, input handling, and media.

### Nullable Enable

```csharp
#nullable enable
```

This directive enables nullable reference types for the file, which helps in better handling of null values.

### Namespace Declaration

```csharp
namespace Meta.Editor.Controls
{
```

This declares the namespace `Meta.Editor.Controls`, encapsulating the `MetaTabItem` class within it.

### Class Declaration

```csharp
[TemplatePart(Name = "PART_CloseButton", Type = typeof (ButtonBase))]
[TemplatePart(Name = "PART_DragLabel", Type = typeof (Label))]
public class MetaTabItem : TabItem
{
```

- The `MetaTabItem` class inherits from `TabItem`.
- `TemplatePart` attributes indicate that the control template is expected to contain elements named `PART_CloseButton` and `PART_DragLabel`.

### Constants and Dependency Properties

```csharp
private const string PART_CloseButton = "PART_CloseButton";
private const string PART_DragLabel = "PART_DragLabel";

public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
    nameof(Icon), typeof(string), typeof(MetaTabItem), new FrameworkPropertyMetadata("Home"));

public static readonly DependencyProperty SvgIconProperty = DependencyProperty.Register(
    nameof(SvgIcon), typeof(Geometry), typeof(MetaTabItem), new FrameworkPropertyMetadata(null));

public static readonly DependencyProperty CloseButtonVisibleProperty = DependencyProperty.Register(
    nameof(CloseButtonVisible), typeof(bool), typeof(MetaTabItem), new FrameworkPropertyMetadata(false));

public static readonly DependencyProperty ObjectProperty = DependencyProperty.Register(
    nameof(Object), typeof(object), typeof(MetaTabItem), new FrameworkPropertyMetadata(null));
```

These are dependency properties that can be set through XAML or code:

- `IconProperty`: Stores a string representing the icon.
- `SvgIconProperty`: Stores a Geometry object representing an SVG icon.
- `CloseButtonVisibleProperty`: Indicates whether the close button is visible.
- `ObjectProperty`: Stores any object associated with the tab item.

### Private Fields

```csharp
private ButtonBase closeButton;
private Label dragLabel;
```

These fields hold references to the parts of the template (`closeButton` and `dragLabel`).

### Properties

```csharp
public string Icon
{
    get => (string)this.GetValue(IconProperty);
    set => this.SetValue(IconProperty, value);
}

public Geometry SvgIcon
{
    get => (Geometry)this.GetValue(SvgIconProperty);
    set => this.SetValue(SvgIconProperty, value);
}

public bool CloseButtonVisible
{
    get => (bool)this.GetValue(CloseButtonVisibleProperty);
    set => this.SetValue(CloseButtonVisibleProperty, value);
}

public object Object
{
    get => this.GetValue(ObjectProperty);
    set => this.SetValue(ObjectProperty, value);
}

public object SelectedClass => this.Object;

public string TabId { get; set; }
```

These are the properties that expose the dependency properties and a few other properties:

- `Icon`, `SvgIcon`, `CloseButtonVisible`, and `Object` are dependency properties.
- `SelectedClass` is a read-only property that returns the value of `Object`.
- `TabId` is a simple string property to store an identifier for the tab.

### Events

```csharp
private event RoutedEventHandler closeButtonClick;
public event RoutedEventHandler CloseButtonClick
{
    add => this.closeButtonClick += value;
    remove => this.closeButtonClick -= value;
}

private event MouseEventHandler middleMouseButtonClick;
public event MouseEventHandler MiddleMouseButtonClick
{
    add => this.middleMouseButtonClick += value;
    remove => this.middleMouseButtonClick -= value;
}

private event MouseEventHandler rightMouseButtonClick;
public event MouseEventHandler RightMouseButtonClick
{
    add => this.rightMouseButtonClick += value;
    remove => this.rightMouseButtonClick -= value;
}
```

These events handle user interactions with the control:

- `CloseButtonClick` is triggered when the close button is clicked.
- `MiddleMouseButtonClick` and `RightMouseButtonClick` handle middle and right mouse button clicks on the drag label.

### Static Constructor

```csharp
static MetaTabItem()
{
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(
        typeof(MetaTabItem), new FrameworkPropertyMetadata(typeof(MetaTabItem)));
}
```

This static constructor sets the default style for the `MetaTabItem` control to itself.

### Methods

```csharp
public void Terminate()
{
    RoutedEventArgs e = new RoutedEventArgs();
    this.closeButtonClick?.Invoke(this, e);
}

public override void OnApplyTemplate()
{
    base.OnApplyTemplate();
    this.closeButton = this.GetTemplateChild(PART_CloseButton) as ButtonBase;
    this.dragLabel = this.GetTemplateChild(PART_DragLabel) as Label;

    if (this.closeButton != null && this.closeButtonClick != null)
        this.closeButton.Click += this.closeButtonClick;

    if (this.dragLabel != null)
    {
        this.dragLabel.MouseUp += (s, o) =>
        {
            if (o.ChangedButton == MouseButton.Right)
                this.rightMouseButtonClick?.Invoke(s, o);
            else if (o.ChangedButton == MouseButton.Middle)
                this.middleMouseButtonClick?.Invoke(s, o);
        };
    }
}
```

- `Terminate()`: Raises the `CloseButtonClick` event programmatically.
- `OnApplyTemplate()`: Called when the control's template is applied. It sets up event handlers for the `closeButton` and `dragLabel`.

Overall, this class customizes the `TabItem` control by adding additional properties and events, and it manages the behavior of the close button and drag label within the tab.

## /Meta/Editor/Controls/MetaWatermarkTextbox.cs

This C# code defines a custom WPF (Windows Presentation Foundation) control named `MetaWatermarkTextbox`, which extends the standard `TextBox` control to include watermark functionality. Here's a detailed explanation of the code:

### Namespaces

```csharp
using System.Windows;
using System.Windows.Controls;
```

These `using` directives include the necessary namespaces for working with WPF controls and elements.

### Nullable Context

```csharp
#nullable enable
```

This directive enables nullable reference types, allowing for better null handling and warnings during compile time.

### Namespace and Class Definition

```csharp
namespace Meta.Editor.Controls
{
    [TemplatePart(Name = "PART_Watermark", Type = typeof (TextBlock))]
    public class MetaWatermarkTextbox : TextBox
    {
        // Class contents...
    }
}
```

- The class `MetaWatermarkTextbox` is defined within the `Meta.Editor.Controls` namespace.
- The `[TemplatePart]` attribute specifies that the control template should include a part named `PART_Watermark` of type `TextBlock`.

### DependencyProperty for WatermarkText

```csharp
public static readonly DependencyProperty WatermarkTextProperty = DependencyProperty.Register(nameof (WatermarkText), typeof (string), typeof (MetaWatermarkTextbox), (PropertyMetadata) new FrameworkPropertyMetadata((object) ""));
```

This line defines a dependency property named `WatermarkTextProperty`. Dependency properties are a special type of property in WPF that supports data binding, styling, animation, and other WPF features.

### Private Field for the Watermark TextBlock

```csharp
private TextBlock watermarkTextBlock;
```

This private field will hold a reference to the `TextBlock` that displays the watermark text.

### WatermarkText Property

```csharp
public string WatermarkText
{
    get => (string) this.GetValue(MetaWatermarkTextbox.WatermarkTextProperty);
    set => this.SetValue(MetaWatermarkTextbox.WatermarkTextProperty, (object) value);
}
```

- The `WatermarkText` property wraps the `WatermarkTextProperty` dependency property, allowing access to its value using standard property syntax.

### Static Constructor

```csharp
static MetaWatermarkTextbox()
{
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (MetaWatermarkTextbox), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (MetaWatermarkTextbox)));
}
```

The static constructor overrides the default style key for the `MetaWatermarkTextbox` control, ensuring that it uses the correct control template.

### OnApplyTemplate Method

```csharp
public override void OnApplyTemplate()
{
    base.OnApplyTemplate();
    this.watermarkTextBlock = this.GetTemplateChild("PART_Watermark") as TextBlock;
    this.GotFocus += new RoutedEventHandler(this.MetaWatermarkTextBox_GotFocus);
    this.LostFocus += new RoutedEventHandler(this.MetaWatermarkTextBox_LostFocus);
}
```

- `OnApplyTemplate` is called when the control's template is applied. It retrieves the `TextBlock` named `PART_Watermark` from the template.
- Event handlers for `GotFocus` and `LostFocus` are added to handle the display and hiding of the watermark.

### Focus Event Handlers

```csharp
private void MetaWatermarkTextBox_LostFocus(object sender, RoutedEventArgs e)
{
    if (!(this.Text == ""))
        return;
    this.watermarkTextBlock.Visibility = Visibility.Visible;
}

private void MetaWatermarkTextBox_GotFocus(object sender, RoutedEventArgs e)
{
    this.watermarkTextBlock.Visibility = Visibility.Collapsed;
}
```

- `MetaWatermarkTextBox_LostFocus` is called when the `TextBox` loses focus. If the `TextBox` is empty, the watermark `TextBlock` is made visible.
- `MetaWatermarkTextBox_GotFocus` is called when the `TextBox` gains focus. It hides the watermark `TextBlock`.

### Summary

This custom control extends the standard `TextBox` to include watermark functionality. The watermark is displayed when the `TextBox` is empty and loses focus, and it is hidden when the `TextBox` gains focus. This is achieved using a `TextBlock` defined in the control template and event handlers for focus events.

## /Meta/Editor/Controls/MetaWindow.cs

This code defines a custom WPF (Windows Presentation Foundation) window named `MetaWindow` within the `Meta.Editor.Controls` namespace. Here's a detailed explanation of its components and functionality:

### Key Components and Features

1. **Template Parts**: The `MetaWindow` class uses the `[TemplatePart]` attribute to declare the parts of its visual tree that are essential for its functionality. These parts include borders, buttons, and other controls.

2. **Dependency Properties**:

   - `ResizeBorderWidth`: Width of the resize border.
   - `EnableDropShadow`: Determines whether a drop shadow effect is enabled.
   - `DropShadowBlurRadius`: Blur radius of the drop shadow.
   - `DropShadowOpacity`: Opacity of the drop shadow.
   - `DropShadowColor`: Color of the drop shadow.
   - `IsDragging`: Indicates if the window is being dragged.

3. **Events**:

   - `MetaLoaded`: Event triggered when the window is fully loaded and rendered.

4. **Static Constructor**: Sets the default style key for `MetaWindow`.

5. **Properties**:

   - Standard properties with getters and setters for the dependency properties listed above.

6. **Template Handling**:

   - `OnApplyTemplate()`: Attaches or detaches event handlers for the visual elements defined in the template.

7. **Event Handlers**:

   - Handles actions like clicking the minimize, maximize, and close buttons.
   - Manages dragging and dropping of the window.
   - Implements double-click behavior for the drag control.

8. **Visual Tree Management**:

   - `DetachFromVisualTree()`: Detaches event handlers from the visual elements.
   - `AttachToVisualTree()`: Attaches event handlers to the visual elements.

9. **Window Chrome and Customization**:

   - Uses `WindowChrome` to customize the window's appearance (e.g., border thickness, corner radius).
   - Implements custom behaviors for resizing, maximizing, and restoring the window.

10. **Win32 Interop**:

    - Uses DllImport to call native Win32 functions for monitor information and window manipulation.
    - Handles window messages to implement custom behaviors like resizing and snapping.

11. **Drop Shadow Management**:

    - `ShowDropShadow()`: Displays the drop shadow effect.
    - `HideDropShadow()`: Hides the drop shadow effect.
    - `CreateDropShadowEffect()`: Creates a drop shadow effect with specified properties.

12. **Native Structures and Interop Helpers**:
    - Defines native structures like `RECT`, `POINT`, `MINMAXINFO`, and `WINDOWPOS`.
    - Provides methods to retrieve and manipulate monitor information and window positioning.

### How It Works

- The `MetaWindow` class is a highly customizable WPF window with extended functionality for window management, including custom resize borders, drop shadow effects, and advanced drag and drop capabilities.
- The dependency properties allow the customization of visual aspects like the resize border and drop shadow.
- The class overrides WPF methods and hooks into Win32 messages to manage the window's behavior, ensuring it handles resizing, dragging, and snapping efficiently.
- The `OnApplyTemplate` method ensures the correct elements are hooked up when the control's template is applied.

### Example Usage

To use `MetaWindow`, you would define it in your XAML as follows:

```xml
<local:MetaWindow x:Class="YourNamespace.YourWindow"
                  xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                  xmlns:local="clr-namespace:Meta.Editor.Controls"
                  ResizeBorderWidth="10"
                  EnableDropShadow="True"
                  DropShadowBlurRadius="15"
                  DropShadowOpacity="0.8"
                  DropShadowColor="Gray"
                  Title="Custom Meta Window">
  <!-- Define the content and template parts here -->
</local:MetaWindow>
```

This setup provides a customizable and visually appealing window with enhanced functionality for user interactions.

## /Meta/Editor/Controls/NullToZeroConverter.cs

The code provided is a C# class `NullToZeroConverter` implementing the `IValueConverter` interface, typically used in WPF (Windows Presentation Foundation) applications to convert values between types in data binding scenarios. This converter specifically handles converting a collection to an integer, returning 0 if the collection is null or empty. Here's a breakdown of the code:

1. **Namespaces and Nullable Enable Directive:**

   - `using System;`
   - `using System.Collections;`
   - `using System.Globalization;`
   - `using System.Windows.Data;`
   - `#nullable enable`

   These lines import the necessary namespaces for the class and enable nullable reference types to provide better null safety.

2. **Namespace Declaration:**

   - `namespace Meta.Editor.Controls`

   The `NullToZeroConverter` class is part of the `Meta.Editor.Controls` namespace.

3. **Class Declaration:**

   - `public class NullToZeroConverter : IValueConverter`

   The class `NullToZeroConverter` implements the `IValueConverter` interface, which requires the implementation of two methods: `Convert` and `ConvertBack`.

4. **Convert Method:**

   - `public object Convert(object value, Type targetType, object parameter, CultureInfo culture)`

   This method converts the input value to the desired output type. Here's how it works:

   - **Parameters:**

     - `value`: The value to be converted.
     - `targetType`: The type of the target property.
     - `parameter`: An optional parameter to use in the converter logic.
     - `culture`: The culture to use in the converter.

   - **Logic:**

     ```csharp
     ICollection collection;
     int num;
     if (value != null)
     {
       collection = value as ICollection;
       num = collection == null ? 1 : 0;
     }
     else
       num = 1;
     return num != 0 ? (object) 0 : (object) collection.Count;
     ```

     - If `value` is not null, it attempts to cast `value` to `ICollection`.
     - If the cast is successful, `num` is set to 0; otherwise, it is set to 1.
     - If `value` is null, `num` is set to 1.
     - Finally, if `num` is 1 (meaning `value` was null or not a collection), the method returns 0. If `num` is 0 (meaning `value` was a valid collection), it returns the count of the collection.

5. **ConvertBack Method:**

   - `public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)`

   This method is used to convert the value back to its original type. In this case, the method is not implemented and will throw a `NotImplementedException` if called.

   ```csharp
   throw new NotImplementedException();
   ```

In summary, the `NullToZeroConverter` class is a WPF value converter that converts a collection to its count if it's not null and returns 0 if the collection is null or not a collection. The `ConvertBack` method is not implemented, as the conversion is likely one-way for this use case.

## /Meta/Editor/Controls/SDBAsset.cs

This C# code defines a class `SDBAsset` within the `Meta.Editor.Controls` namespace. The class implements the `INotifyPropertyChanged` interface, which is used to notify clients, typically binding clients, that a property value has changed. Here's a detailed breakdown:

### Breakdown of the Code

1. **Namespaces and Directives**

   ```csharp
   using System.ComponentModel;

   #nullable enable
   ```

   - `using System.ComponentModel;`: This directive includes the `System.ComponentModel` namespace, which contains the `INotifyPropertyChanged` interface and related classes.
   - `#nullable enable`: This directive enables nullable reference types, allowing for better nullability handling and warnings in the code.

2. **Namespace Declaration**

   ```csharp
   namespace Meta.Editor.Controls
   {
   ```

   - Defines a namespace `Meta.Editor.Controls` to organize the code and avoid naming conflicts.

3. **Class Declaration**

   ```csharp
   public class SDBAsset : INotifyPropertyChanged
   {
   ```

   - Declares a public class `SDBAsset` that implements the `INotifyPropertyChanged` interface.

4. **Private Fields**

   ```csharp
   private uint id;
   ```

   - Defines a private field `id` of type `uint` to store the value of the `Id` property.

5. **Public Properties**

   ```csharp
   public uint Index { get; set; }

   public uint Id
   {
     get => this.id;
     set
     {
       if ((int) this.id == (int) value)
         return;
       this.id = value;
       this.OnPropertyChanged(nameof (Id));
     }
   }

   public string String { get; set; }

   public uint Address { get; set; }

   public uint Size { get; set; }
   ```

   - `Index`, `String`, `Address`, and `Size` are auto-implemented properties with `get` and `set` accessors.
   - `Id` is a property with custom `get` and `set` accessors:
     - `get => this.id;` returns the value of the private field `id`.
     - `set` checks if the new value is different from the current value. If they are different, it updates `id` and calls `OnPropertyChanged` to notify listeners that the `Id` property has changed.

6. **INotifyPropertyChanged Implementation**

   ```csharp
   public event PropertyChangedEventHandler PropertyChanged;

   protected virtual void OnPropertyChanged(string propertyName)
   {
     PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
     if (propertyChanged == null)
       return;
     propertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
   }
   ```

   - `PropertyChanged` event is declared as part of the `INotifyPropertyChanged` interface.
   - `OnPropertyChanged` method:
     - Takes the name of the property that changed as a parameter (`propertyName`).
     - Checks if there are any subscribers to the `PropertyChanged` event.
     - If there are subscribers, it raises the event, passing `this` as the sender and a new `PropertyChangedEventArgs` object containing the property name.

### Summary

The `SDBAsset` class is a data model that implements `INotifyPropertyChanged` to support property change notifications, which are crucial for data binding in applications, especially in UI frameworks like WPF or Xamarin. When the `Id` property is set to a new value, it triggers the `PropertyChanged` event, allowing any subscribed components to react to the change (e.g., update the UI). The class also includes other properties (`Index`, `String`, `Address`, `Size`) with auto-implemented `get` and `set` accessors.

## /Meta/Editor/Controls/SDBCache.cs

This C# code defines a simple class named `SDBCache` within the namespace `Meta.Editor.Controls`. Here's a detailed explanation of each part of the code:

1. **Using Directive**:

   ```csharp
   using System.Collections.ObjectModel;
   ```

   This line includes the `System.Collections.ObjectModel` namespace, which provides classes such as `ObservableCollection<T>`. `ObservableCollection<T>` is a dynamic data collection that provides notifications when items get added, removed, or when the entire list is refreshed.

2. **Nullable Enable**:

   ```csharp
   #nullable enable
   ```

   This directive enables nullable reference types for this file. This means that the compiler will enforce nullability rules, helping to prevent null reference exceptions by distinguishing between nullable and non-nullable reference types.

3. **Namespace Declaration**:

   ```csharp
   namespace Meta.Editor.Controls
   ```

   This defines a namespace called `Meta.Editor.Controls`, which helps organize the code and prevent naming conflicts.

4. **Class Definition**:

   ```csharp
   public class SDBCache
   ```

   This defines a public class named `SDBCache`. The `public` keyword means that this class can be accessed from other classes.

5. **Properties**:

   ```csharp
   public string File { get; set; }

   public ObservableCollection<SDBAsset> Database { get; set; }
   ```

   The `SDBCache` class has two public properties:

   - `File`: This is a property of type `string`. It has a getter and a setter, meaning that the value can be read and modified.
   - `Database`: This is a property of type `ObservableCollection<SDBAsset>`. Like `File`, it has both a getter and a setter. `ObservableCollection<SDBAsset>` is a collection that can hold multiple `SDBAsset` objects and provides notifications when the collection is changed.

6. **Nullable Context**:
   The `#nullable enable` directive at the top means that the properties can enforce non-nullability if not explicitly set to accept null values. However, by default, without any further nullable annotations, they are considered non-nullable.

In summary, the `SDBCache` class is designed to hold a file path (`File`) and a collection of `SDBAsset` objects (`Database`). The use of `ObservableCollection` indicates that this collection can notify any observers when changes occur, making it useful in data-binding scenarios often found in GUI applications.

## /Meta/Editor/Controls/ToolbarItem.cs

This C# code defines a class named `ToolbarItem` within the `Meta.Editor.Controls` namespace. Let's break down the key components:

### Namespace Declaration

```csharp
namespace Meta.Editor.Controls
{
```

The `namespace` keyword is used to declare a scope that contains a set of related objects. In this case, the `ToolbarItem` class is part of the `Meta.Editor.Controls` namespace, which is likely a part of a larger project related to a Meta Editor.

### Class Definition

```csharp
public class ToolbarItem
{
```

The `public` keyword means this class is accessible from other classes and assemblies. The `ToolbarItem` class is designed to represent an item in a toolbar.

### Properties

```csharp
public string Text { get; private set; }

public string ToolTip { get; private set; }

public string Icon { get; private set; }

public RelayCommand Command { get; private set; }
```

These are properties of the `ToolbarItem` class:

- `Text`: Represents the text displayed on the toolbar item.
- `ToolTip`: Represents the tooltip text displayed when the user hovers over the toolbar item.
- `Icon`: Represents the icon image displayed on the toolbar item.
- `Command`: Represents the action (or command) that is executed when the toolbar item is clicked.

All these properties have `private` setters, meaning they can only be set within the class itself, not from outside the class. They have `public` getters, so they can be read from outside the class.

### Constructor

```csharp
public ToolbarItem(
  string text,
  string tooltip,
  string icon,
  RelayCommand inCommand,
  bool isAddedByPlugin = false)
{
  this.Text = text;
  this.ToolTip = tooltip;
  this.Icon = icon;
  this.Command = inCommand;
}
```

This is the constructor of the `ToolbarItem` class. A constructor is a special method that is called when an instance of the class is created.

#### Parameters

- `string text`: The text to be displayed on the toolbar item.
- `string tooltip`: The tooltip text for the toolbar item.
- `string icon`: The icon for the toolbar item.
- `RelayCommand inCommand`: The command to be executed when the toolbar item is clicked.
- `bool isAddedByPlugin = false`: This is an optional parameter with a default value of `false`. It indicates whether the toolbar item was added by a plugin. However, in the current implementation, this parameter is not used within the constructor body.

#### Body

Inside the constructor, the parameters are assigned to the properties of the class using the `this` keyword, which refers to the current instance of the class:

```csharp
this.Text = text;
this.ToolTip = tooltip;
this.Icon = icon;
this.Command = inCommand;
```

### #nullable enable

```csharp
#nullable enable
```

This directive enables nullable reference types in the code file. It allows you to explicitly specify whether a reference type can be `null`, enhancing code safety and reducing null reference exceptions.

### Summary

The `ToolbarItem` class encapsulates the properties and behavior of an item in a toolbar within the Meta Editor. It holds text, tooltip, icon, and a command to execute. The class is designed to be used within the context of a toolbar control in an editor application.

## /Meta/Editor/Controls/ToUpperConverter.cs

This C# code defines a `ToUpperConverter` class that implements the `IValueConverter` interface. This converter is typically used in WPF (Windows Presentation Foundation) data binding to convert string values to uppercase. Here's a detailed explanation:

### Namespace and Class Declaration

```csharp
namespace Meta.Editor.Controls
{
  public class ToUpperConverter : IValueConverter
  {
    // Class implementation
  }
}
```

- **Namespace**: `Meta.Editor.Controls` - This groups related classes together.
- **Class**: `ToUpperConverter` - This class implements the `IValueConverter` interface, which defines methods used for converting data from one type to another.

### Nullable Enable Directive

```csharp
#nullable enable
```

- This enables nullable reference types, allowing the code to explicitly specify when a reference type is nullable. This helps to avoid null reference exceptions.

### Implementing IValueConverter

The `IValueConverter` interface requires two methods: `Convert` and `ConvertBack`.

#### Convert Method

```csharp
public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
{
  return value == null ? (object) null : (object) value.ToString().ToUpper(culture);
}
```

- **Parameters**:

  - `value`: The value produced by the binding source. Expected to be a string.
  - `targetType`: The type of the binding target property.
  - `parameter`: An optional parameter to be used in the converter logic.
  - `culture`: The culture to be used in the converter.

- **Logic**:

  - Checks if `value` is null. If it is, it returns null.
  - If `value` is not null, it converts `value` to a string and then to uppercase using the provided `culture`.

- **Return**:
  - Returns the uppercase version of the string or null if the input value is null.

#### ConvertBack Method

```csharp
public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
{
  throw new NotSupportedException("ConvertBack is not supported in ToUpperConverter");
}
```

- **Purpose**:
  - This method is intended to convert a value back to its original type. However, in this implementation, it throws a `NotSupportedException` because converting back from uppercase to the original string is not supported or required for this converter.

### Summary

- The `ToUpperConverter` class is a WPF value converter that converts strings to uppercase.
- The `Convert` method takes a string input and returns its uppercase version, handling null values gracefully.
- The `ConvertBack` method is not implemented and throws an exception if called, indicating that reverse conversion is not supported.

This class can be used in WPF data bindings to ensure that bound string values are displayed in uppercase in the user interface.

## /Meta/Editor/Controls/WindowCloseCommand.cs

Certainly! Here's an explanation of the code:

### Namespace and Class Definition

```csharp
using System;
using System.Windows;
using System.Windows.Input;

#nullable enable
namespace Meta.Editor.Controls
{
    public class WindowCloseCommand : ICommand
    {
        ...
    }
}
```

1. **Namespace and Usings**:

   - `using System;` includes basic system functions.
   - `using System.Windows;` includes Windows-related functions, specifically those related to GUI elements.
   - `using System.Windows.Input;` includes input-related functions, particularly the ICommand interface which is used for commanding in WPF.

2. **Nullable Context**:

   - `#nullable enable` enables nullable reference types. This helps to catch potential `null` reference issues at compile time.

3. **Namespace**:
   - The code is within the `Meta.Editor.Controls` namespace, organizing this class logically within the project.

### ICommand Interface Implementation

```csharp
public class WindowCloseCommand : ICommand
{
    public bool CanExecute(object parameter) => true;

    public event EventHandler CanExecuteChanged;

    public void Execute(object parameter)
    {
        if (!(parameter is Window window))
            return;
        window.Close();
    }
}
```

4. **Class Definition**:

   - `public class WindowCloseCommand : ICommand`: This defines a class `WindowCloseCommand` that implements the `ICommand` interface. The `ICommand` interface is used in WPF to handle command logic (such as button clicks).

5. **CanExecute Method**:

   - `public bool CanExecute(object parameter) => true;`: This method determines whether the command can execute. Returning `true` means the command can always execute.

6. **CanExecuteChanged Event**:

   - `public event EventHandler CanExecuteChanged;`: This event is part of the `ICommand` interface. It should be triggered when the result of `CanExecute` changes. However, it's not being used in this implementation.

7. **Execute Method**:
   - `public void Execute(object parameter)`: This method contains the logic to execute when the command is invoked.
   - `if (!(parameter is Window window)) return;`: This checks if the `parameter` is a `Window`. If not, it returns and does nothing.
   - `window.Close();`: If the parameter is a `Window`, it closes the window.

### Summary

This class defines a simple command for closing a window in a WPF application. It always allows execution (as `CanExecute` always returns true) and closes a window when executed. The parameter passed to the `Execute` method must be of type `Window` for the close operation to occur.

## /Meta/Editor/Controls/WindowCompositionAttribute.cs

This piece of code defines an enumeration (`enum`) called `WindowCompositionAttribute` within a namespace `Meta.Editor.Controls`. Here's a breakdown of the components:

### Breakdown of the Code

1. **`#nullable disable`**

   - This directive disables nullable reference types in the code, meaning that the compiler will not enforce nullable reference type annotations. It allows for more flexible handling of null values but can potentially lead to null reference exceptions if not carefully managed.

2. **`namespace Meta.Editor.Controls`**

   - Namespaces are used to organize code and prevent naming conflicts. The `Meta.Editor.Controls` namespace indicates that this code is part of the `Meta` project, specifically within the `Editor.Controls` module.

3. **`internal enum WindowCompositionAttribute`**

   - `internal`: This access modifier means that the enumeration is accessible only within the same assembly (project).
   - `enum`: Enumerations are a distinct type consisting of a set of named constants called the enumerator list.
   - `WindowCompositionAttribute`: The name of the enumeration, which likely pertains to attributes related to window composition, possibly for a graphical user interface.

4. **Enumeration Members**
   - `WCA_ACCENT_POLICY = 19, // 0x00000013`
     - `WCA_ACCENT_POLICY`: The name of the enumeration member, which is given the value `19`.
     - `// 0x00000013`: A comment indicating the hexadecimal equivalent of the value `19`.

### Purpose of the Code

This enumeration likely defines constants that are used in setting or querying attributes of window composition, potentially for modifying the appearance or behavior of windows in a user interface. The specific member `WCA_ACCENT_POLICY` with the value `19` might correspond to a particular attribute or setting related to window accent policies, such as transparency, color, or other visual effects.

### Example Usage

In practice, this enumeration might be used in methods that interface with the Windows API to modify window properties. For example:

```csharp
public void SetWindowAccent(IntPtr windowHandle, int accentState)
{
    var data = new WindowCompositionAttributeData
    {
        Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY,
        SizeOfData = Marshal.SizeOf(accentState),
        Data = IntPtr.Zero
    };
    data.Data = Marshal.AllocHGlobal(data.SizeOfData);
    Marshal.StructureToPtr(accentState, data.Data, false);

    // Call to a hypothetical method that sets the window composition attribute
    SetWindowCompositionAttribute(windowHandle, ref data);

    Marshal.FreeHGlobal(data.Data);
}
```

In this example, `WindowCompositionAttribute.WCA_ACCENT_POLICY` is used to specify which attribute to set on a window.

## /Meta/Editor/Controls/WindowCompositionAttributeData.cs

Sure, let me break down the provided C# code for you.

### Explanation

This code defines a struct named `WindowCompositionAttributeData` within the `Meta.Editor.Controls` namespace. Let's go through it step by step.

1. **Namespace Declaration:**

   ```csharp
   namespace Meta.Editor.Controls
   {
   ```

   This declares a namespace called `Meta.Editor.Controls`. Namespaces are used to organize code and prevent name collisions.

2. **Struct Declaration:**

   ```csharp
   internal struct WindowCompositionAttributeData
   {
   ```

   This declares a struct named `WindowCompositionAttributeData`. The `internal` keyword means that this struct is accessible only within the same assembly.

3. **Struct Members:**

   ```csharp
   public WindowCompositionAttribute Attribute;
   public IntPtr Data;
   public int SizeOfData;
   ```

   These lines define three public members of the `WindowCompositionAttributeData` struct:

   - `Attribute`: This is of type `WindowCompositionAttribute`. Without additional context, we can assume `WindowCompositionAttribute` is either an enum or a struct/class defined elsewhere in your code.
   - `Data`: This is of type `IntPtr`, which is used to represent a pointer or a handle. It is often used in interoperability with unmanaged code or low-level operations.
   - `SizeOfData`: This is of type `int`, representing the size of the data pointed to by `Data`.

4. **End of Struct and Namespace:**

   ```csharp
   }
   }
   ```

### Nullable Context

The `#nullable disable` directive at the top:

```csharp
#nullable disable
```

This disables nullable reference types for this file, meaning the compiler will not enforce nullability rules on reference types in this file. This is relevant for ensuring backward compatibility or for working with legacy code where nullability annotations might not be used.

### Summary

In summary, this struct `WindowCompositionAttributeData` is likely used to encapsulate data related to window composition attributes, possibly for use in setting or getting window properties in a Windows environment. The `Attribute` member specifies what attribute is being referred to, `Data` points to the actual data, and `SizeOfData` indicates the size of that data. This struct could be used in P/Invoke calls to interact with native Windows APIs.

## /Meta/Editor/Controls/CreationSuite/AttireAttribute.cs

This C# code defines a custom attribute called `AttireAttribute` within the `Meta.Editor.Controls.CreationSuite` namespace. Here’s a breakdown of each part of the code:

### 1. `using System;`

This line imports the `System` namespace, which contains fundamental classes and base classes that define commonly used values and reference data types, events and event handlers, interfaces, attributes, and processing exceptions.

### 2. `#nullable disable`

This directive disables nullable reference types for this file. Nullable reference types are a feature in C# 8.0 that allows you to annotate reference types to indicate whether they can be null. Disabling it means the code will not generate warnings for potential null reference exceptions.

### 3. `namespace Meta.Editor.Controls.CreationSuite`

This defines a namespace called `Meta.Editor.Controls.CreationSuite`. Namespaces are used to organize code into a hierarchical structure, preventing name collisions and making the code easier to manage.

### 4. `[AttributeUsage(AttributeTargets.Property)]`

This is an attribute applied to the `AttireAttribute` class. The `AttributeUsage` attribute specifies the types of items this attribute can be applied to. In this case, it indicates that the `AttireAttribute` can only be applied to properties (`AttributeTargets.Property`).

### 5. `public class AttireAttribute : Attribute`

This declares a public class named `AttireAttribute` that inherits from the `Attribute` class. Custom attributes in C# are classes derived from `System.Attribute`.

### 6. `public AttireAttribute(int id) => this.id = id;`

This is a constructor for the `AttireAttribute` class that takes an integer parameter `id` and assigns it to the private field `id`. This allows the attribute to be initialized with a specific ID value when applied.

### 7. `public virtual int id { get; private set; }`

This declares a public virtual property named `id` with a private setter. The `virtual` keyword indicates that this property can be overridden in a derived class. The `id` property can be accessed publicly but can only be set privately within the class or its constructor.

### Summary

The `AttireAttribute` class is a custom attribute designed to be applied to properties. It includes a constructor that initializes an integer ID and a public property `id` to retrieve this ID. This attribute can be used to mark properties with specific IDs, possibly for identification, metadata, or processing purposes within the `Meta.Editor.Controls.CreationSuite` namespace.

## /Meta/Editor/Controls/CreationSuite/BaseEditor.cs

Sure, let's break down the provided code snippet:

### Code Snippet Explanation

```csharp
#nullable disable
namespace Meta.Editor.Controls.CreationSuite
{
  public class BaseEditor
  {
  }
}
```

1. **`#nullable disable`**:

   - This directive is used to control nullable reference types in C#. When `#nullable disable` is used, it disables nullable reference types' warnings and features. This means that the compiler will not issue warnings about potential null reference issues for reference types within this file.

2. **`namespace Meta.Editor.Controls.CreationSuite`**:

   - A namespace is a way to organize code and group related classes, interfaces, enums, and other types. In this case, the namespace is `Meta.Editor.Controls.CreationSuite`. This indicates that the `BaseEditor` class belongs to this specific namespace, helping to avoid naming conflicts and organize the code logically.

3. **`public class BaseEditor`**:

   - This line declares a public class named `BaseEditor`. A class is a blueprint for creating objects and encapsulates data for the object. The `public` keyword means that this class is accessible from other code outside its namespace.

4. **Empty Class Body**:
   - The `{}` following the class declaration represents the class body. In this case, the body is empty, meaning that the `BaseEditor` class currently does not contain any properties, methods, or other members.

### Summary

This code snippet defines a namespace `Meta.Editor.Controls.CreationSuite` and within that namespace, it declares a public class named `BaseEditor`. The class itself does not contain any implementation yet. The `#nullable disable` directive ensures that the compiler does not generate warnings for nullable reference types within this file. This setup might be a placeholder or a base class intended to be extended with additional functionality later.

## /Meta/Editor/Controls/CreationSuite/BaseEditorExtesions.cs

This code defines a static class `BaseEditorExtensions` within the `Meta.Editor.Controls.CreationSuite` namespace. This class includes an extension method `Get<T, TValue>` for instances of types derived from `BaseEditor`. The method is designed to retrieve the value of a property specified by a lambda expression. Below is a detailed explanation of the code:

```csharp
using System;
using System.Linq.Expressions;
using System.Reflection;

#nullable enable
namespace Meta.Editor.Controls.CreationSuite
{
  public static class BaseEditorExtensions
  {
    public static TValue Get<T, TValue>(
      this T editor,
      Expression<Func<T, TValue>> propertyExpression)
      where T : BaseEditor
    {
      PropertyInfo member;
      int num;
      if (propertyExpression.Body is MemberExpression body)
      {
        member = body.Member as PropertyInfo;
        num = member != null ? 1 : 0;
      }
      else
        num = 0;
      if (num != 0)
      {
        object obj1 = member.GetValue((object) editor);
        if (obj1 == null)
          return (TValue) new JObject((object) 0L, "null");
        if (obj1 is TValue obj2)
          return obj2;
      }
      throw new ArgumentException("Invalid property expression", nameof (propertyExpression));
    }
  }
}
```

### Explanation

1. **Namespace and Class Declaration**:

   - `namespace Meta.Editor.Controls.CreationSuite`: This defines a namespace to encapsulate related classes.
   - `public static class BaseEditorExtensions`: This declares a static class that contains extension methods for `BaseEditor`.

2. **Nullable Context**:

   - `#nullable enable`: Enables nullable reference types, allowing more explicit handling of `null` values.

3. **Extension Method `Get<T, TValue>`**:

   - `public static TValue Get<T, TValue>(this T editor, Expression<Func<T, TValue>> propertyExpression) where T : BaseEditor`: Defines an extension method that can be called on any instance of `T` where `T` is derived from `BaseEditor`. The method accepts a lambda expression specifying a property of the editor to retrieve.

4. **Property Extraction**:

   - `if (propertyExpression.Body is MemberExpression body)`: Checks if the body of the lambda expression is a member expression, which represents accessing a field or property.
   - `member = body.Member as PropertyInfo`: Attempts to cast the member to a `PropertyInfo` to ensure it's a property, not a field or method.
   - `num = member != null ? 1 : 0`: Sets `num` to 1 if `member` is not null (i.e., it is a property), otherwise sets it to 0.

5. **Property Value Retrieval**:

   - `if (num != 0)`: Proceeds only if the member is a valid property.
   - `object obj1 = member.GetValue((object) editor)`: Uses reflection to get the value of the property from the `editor` instance.
   - `if (obj1 == null) return (TValue) new JObject((object) 0L, "null")`: If the property value is `null`, returns a new `JObject` representing a null value.
   - `if (obj1 is TValue obj2) return obj2`: If the property value can be cast to `TValue`, returns the cast value.

6. **Exception Handling**:
   - `throw new ArgumentException("Invalid property expression", nameof (propertyExpression))`: Throws an exception if the provided expression does not represent a valid property access.

### Key Points

- **Extension Method**: The method is an extension method for `BaseEditor`, allowing it to be called as if it were an instance method of `BaseEditor` or its derived types.
- **Reflection**: Utilizes reflection to get property information and values at runtime.
- **Lambda Expressions**: Uses lambda expressions to specify the property to retrieve, providing a strongly-typed way to access properties.
- **Null Handling**: The method includes handling for `null` values, returning a `JObject` if the property value is `null`.
- **Error Handling**: Throws an exception for invalid property expressions, ensuring that the method fails gracefully for incorrect inputs.

## /Meta/Editor/Controls/CreationSuite/BeltCreationControl.cs

This code defines a class `BeltCreationControl` that extends `CreationControl` for managing and editing belt creation in a software related to WWE2K23. Here's a detailed explanation of the key components and functionality:

### Namespaces and Usings

```csharp
using Meta.Core;
using Meta.Core.Interfaces;
using Meta.Structures.Flatbuffers.WWE2K23;
using MetaEditor;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows;
```

These are the namespaces and libraries used. They include custom libraries (`Meta.Core`, `MetaEditor`), Flatbuffers for WWE2K23 structures, JSON serialization (`Newtonsoft.Json`), file dialogs (`Microsoft.Win32`), and core .NET namespaces (`System`, `System.IO`, `System.Windows`).

### Namespace and Class Declaration

```csharp
namespace Meta.Editor.Controls.CreationSuite
{
  [CreationControl]
  public class BeltCreationControl : CreationControl
  {
    public EditorBelt editorBelt;
```

- `Meta.Editor.Controls.CreationSuite`: Defines the namespace for organizing the code.
- `[CreationControl]`: Attribute to mark this class as a creation control.
- `BeltCreationControl`: The main class, inheriting from `CreationControl`.
- `editorBelt`: An instance of `EditorBelt`, which handles specific belt editing functionalities.

### Constructor

```csharp
public BeltCreationControl(ILogger inLogger, MetaTabControl tab)
  : base(inLogger, tab)
{
  this.logger.Log("[Editor][Belt Creation] Loading...", Array.Empty<object>());
  this.editorBelt = new EditorBelt(inLogger);
  this.Editors.Add((CreationEditor) this.editorBelt);
}
```

- `BeltCreationControl(ILogger inLogger, MetaTabControl tab)`: Constructor initializing the control with a logger and tab control.
- `this.logger.Log(...)`: Logs the loading message.
- `this.editorBelt = new EditorBelt(inLogger)`: Instantiates `EditorBelt`.
- `this.Editors.Add(...)`: Adds `editorBelt` to the list of editors.

### Method: OpenAs

```csharp
public override void OpenAs(Profile profile)
{
  if (!profile.Type.Equals((object) (ProfileType) 1))
    return;
  WWE2K23_Generated_Belt Profile = JsonConvert.DeserializeObject<WWE2K23_Generated_Belt>(JsonConvert.SerializeObject(profile.Generated), new JsonSerializerSettings()
  {
    MissingMemberHandling = MissingMemberHandling.Ignore
  });
  if (Profile != null)
  {
    if (Profile.BeltDataTable != null)
    {
      this.editorBelt.Load(Profile);
    }
    else
    {
      int num = (int) MetaMessageBox.Show("Info or Motion data missing", "Meta Data Manager");
    }
  }
}
```

- `OpenAs(Profile profile)`: Opens the profile if it's of type 1.
- Deserializes `profile.Generated` into `WWE2K23_Generated_Belt`.
- If `Profile` and its `BeltDataTable` are not null, it loads the profile into `editorBelt`.
- If `BeltDataTable` is null, shows a message box indicating missing data.

### Method: SaveAs

```csharp
public override void SaveAs()
{
  base.SaveAs();
  ((UIElement) this.editorBelt.PrimaryInfoPropertyGrid).UpdateLayout();
  ((FrameworkElement) this.editorBelt.PrimaryInfoPropertyGrid).ApplyTemplate();
  SaveFileDialog saveFileDialog1 = new SaveFileDialog();
  saveFileDialog1.Filter = "(All supported formats)|*.json";
  saveFileDialog1.Title = "Save Profile";
  SaveFileDialog saveFileDialog2 = saveFileDialog1;
  bool? nullable = saveFileDialog2.ShowDialog();
  bool flag = true;
  if (!(nullable.GetValueOrDefault() == flag & nullable.HasValue))
    return;
  Profile profile = new Profile()
  {
    Type = (ProfileType) 1
  };
  WWE2K23_Generated_Belt k23GeneratedBelt = new WWE2K23_Generated_Belt()
  {
    BeltData_AssetMap = new BeltsMapTable(),
    BeltDataTable = new BeltInfo()
  };
  k23GeneratedBelt.BeltDataTable.id = this.editorBelt.beltPrimaryInfo.BeltSlotID;
  k23GeneratedBelt.BeltDataTable.meta = new BeltMetaTable();
  k23GeneratedBelt.BeltDataTable.meta.type = (byte) (long) this.editorBelt.beltPrimaryInfo.BeltType.Id;
  k23GeneratedBelt.BeltDataTable.meta.belt_name_id = this.editorBelt.beltPrimaryInfo.BeltBrandFullName;
  k23GeneratedBelt.BeltDataTable.meta.belt_name_2_id = this.editorBelt.beltPrimaryInfo.BeltFullName;
  k23GeneratedBelt.BeltDataTable.meta.belt_champion_id = this.editorBelt.beltPrimaryInfo.BeltChampionName;
  k23GeneratedBelt.BeltDataTable.meta.belt_name_3_id = 712412311U;
  k23GeneratedBelt.BeltDataTable.meta.call_id = this.editorBelt.beltPrimaryInfo.BeltCallID;
  k23GeneratedBelt.BeltDataTable.meta.is_female = this.editorBelt.beltPrimaryInfo.BeltIsFemale;
  k23GeneratedBelt.BeltDataTable.meta.no_heavyweights = this.editorBelt.beltPrimaryInfo.BeltNoHeavyweights;
  k23GeneratedBelt.BeltDataTable.meta.is_tag_team = this.editorBelt.beltPrimaryInfo.BeltIsTagTeam;
  k23GeneratedBelt.BeltDataTable.meta.default_champion_0 = new ushort[0];
  k23GeneratedBelt.BeltDataTable.meta.default_champion_1 = new ushort[2]
  {
    this.editorBelt.beltPrimaryInfo.BeltDefaultChampion1,
    this.editorBelt.beltPrimaryInfo.BeltDefaultChampion2
  };
  k23GeneratedBelt.BeltDataTable.meta.default_champion_2 = new ushort[2]
  {
    this.editorBelt.beltPrimaryInfo.BeltDefaultChampion1,
    this.editorBelt.beltPrimaryInfo.BeltDefaultChampion2
  };
  k23GeneratedBelt.BeltDataTable.meta.visual = new Visual()
  {
    belt_all = this.editorBelt.beltSecondaryInfo.BeltRenderPath.HashTexture(App.CurrentGame.Folders),
    belt_all_ct = this.editorBelt.beltSecondaryInfo.BeltRenderPath.HashTexture(App.CurrentGame.Folders),
    belt_front = this.editorBelt.beltSecondaryInfo.BeltRenderPath.HashTexture(App.CurrentGame.Folders),
    belt_side = this.editorBelt.beltSecondaryInfo.BeltRenderPath.HashTexture(App.CurrentGame.Folders),
    belt_strap = this.editorBelt.beltSecondaryInfo.BeltRenderPath.HashTexture(App.CurrentGame.Folders)
  };
  k23GeneratedBelt.BeltDataTable.meta.movie_data_1 = new MovieData1()
  {
    string_id_1 = this.editorBelt.beltPrimaryInfo.BeltFullName,
    string_id_2 = this.editorBelt.beltPrimaryInfo.BeltFullName
  };
  if (((byte) (long) this.editorBelt.beltPrimaryInfo.BeltType.Id).Equals((byte) 7))
  {
    k23GeneratedBelt.BeltDataTable.meta.movie_data_1.bk2 = uint.Parse("5" + this.editorBelt.beltPrimaryInfo.BeltMovieBK2ID.ToString().PadLeft(3, '0') + "00");
    k23GeneratedBelt.BeltDataTable.meta.movie_data_1.unk_1 = 489U;
  }
  k23GeneratedBelt.BeltDataTable.meta.movie_data_2 = new MovieData2();
  k23GeneratedBelt.BeltData_AssetMap.id = this.editorBelt.beltPrimaryInfo.BeltSlotID;
  k23GeneratedBelt.BeltData_AssetMap.data = new BeltsDataMap[3];
  for (int index = 0; index < k23GeneratedBelt.BeltData_AssetMap.data.Length; ++index)
  {
    k23GeneratedBelt.BeltData_AssetMap.data[index] = new BeltsDataMap();
    if (index.Equals(0))
    {
      k23GeneratedBelt.BeltData_AssetMap.data[index].mdl_path = this.editorBelt.beltSecondaryInfo.CutsceneMDLPath.Hash(App.CurrentGame.Folders);
      k23GeneratedBelt.BeltData_AssetMap.data[index].belt_textures_path = this.editorBelt.beltSecondaryInfo.CutsceneTexturesPath.Hash(App.CurrentGame.Folders);
    }
    else if (index.Equals(1))
    {
      k23GeneratedBelt.BeltData_AssetMap.data[index].mdl_path = this.editorBelt.beltSecondaryInfo.DefaultBeltMDLPath.Hash(App.CurrentGame.Folders);
      k23GeneratedBelt.BeltData_AssetMap.data[index].belt_textures_path = this.editorBelt.beltSecondaryInfo.DefaultTexturesPath.Hash(App.CurrentGame.Folders);
      k23GeneratedBelt.BeltData_AssetMap.data[index].havok_path = this.editorBelt.beltSecondaryInfo.DefaultHavokFolderPath.Hash(App.CurrentGame.Folders);
      k23GeneratedBelt.BeltData_AssetMap.data[index].propconfig_global_jsfb = this.editorBelt.beltSecondaryInfo.DefaultPropConfigPath.Hash(App.CurrentGame.Folders);
    }
    else if (index.Equals(2

))
    {
      k23GeneratedBelt.BeltData_AssetMap.data[index].mdl_path = this.editorBelt.beltSecondaryInfo.LadderMDLPath.Hash(App.CurrentGame.Folders);
      k23GeneratedBelt.BeltData_AssetMap.data[index].belt_textures_path = this.editorBelt.beltSecondaryInfo.LadderTexturesPath.Hash(App.CurrentGame.Folders);
    }
  }
  profile.Generated = (object) k23GeneratedBelt;
  JsonSerializerSettings settings = new JsonSerializerSettings()
  {
    DefaultValueHandling = DefaultValueHandling.Ignore,
    MissingMemberHandling = MissingMemberHandling.Ignore,
    Formatting = Formatting.Indented,
    NullValueHandling = NullValueHandling.Ignore
  };
  File.WriteAllText(saveFileDialog2.FileName, JsonConvert.SerializeObject((object) profile, settings));
}
```

- `SaveAs()`: Saves the current profile.
- Updates layout and applies template for `PrimaryInfoPropertyGrid`.
- Uses `SaveFileDialog` to get the file name and path from the user.
- Constructs a `Profile` object with a `WWE2K23_Generated_Belt`.
- Populates `k23GeneratedBelt` with various belt-related information, including metadata and asset paths.
- Serializes the profile to JSON and writes it to the specified file.

### Summary

This class `BeltCreationControl` is designed to manage belt creation for WWE2K23. It loads and saves belt profiles, interacts with UI elements for editing belt information, and uses JSON for serialization and deserialization. The class ensures that all necessary belt data is handled correctly during loading and saving operations.

## /Meta/Editor/Controls/CreationSuite/BeltCreationControl_WWE2K24.cs

This code is a C# class `BeltCreationControl_WWE2K24` within a namespace `Meta.Editor.Controls.CreationSuite`. The class inherits from `CreationControl` and is used for creating and managing belt profiles for a WWE 2K24 editor.

Here's a breakdown of the code:

### Namespaces

- **Meta.Core**: Likely contains core functionalities for the application.
- **Meta.Core.Interfaces**: Contains interfaces used in the application.
- **Meta.Structures.Flatbuffers.WWE2K23** and **Meta.Structures.Flatbuffers.WWE2K24**: Contains structures related to WWE 2K23 and 2K24.
- **MetaEditor**: Likely includes editor-specific functionalities.
- **Microsoft.Win32**: Provides classes to interact with the Windows registry and file dialogs.
- **Newtonsoft.Json**: Used for JSON serialization and deserialization.
- **System**, **System.IO**, **System.Windows**: Standard C# libraries for core functions, IO operations, and Windows UI elements.

### Class Definition

- **BeltCreationControl_WWE2K24**: A class marked with the `[CreationControl]` attribute, indicating it is a part of the creation suite.

### Constructor

- **BeltCreationControl_WWE2K24(ILogger inLogger, MetaTabControl tab)**: Initializes the control with a logger and a tab control. Logs a loading message and creates an instance of `EditorBelt_WWE2K24`.

### Methods

1. **OpenAs(Profile profile)**:

   - Checks if the profile type is 1 (possibly indicating a specific type of profile).
   - Deserializes the profile to a `WWE2K24_Generated_Belt` object.
   - If the deserialized object is valid and contains belt data, it loads the data into `editorBelt`.

2. **SaveAs()**:
   - Calls the base class's `SaveAs` method.
   - Updates and applies the template to the primary info property grid of `editorBelt`.
   - Opens a `SaveFileDialog` to save the profile as a JSON file.
   - Creates a new `Profile` object and initializes a `WWE2K24_Generated_Belt` with various belt data.
   - Fills in details from `editorBelt` into the `WWE2K24_Generated_Belt` object.
   - Serializes the `Profile` object to JSON and writes it to the selected file.
   - Logs success or error messages based on the outcome.

### Detailed Explanation of Serialization and Deserialization

- **JsonConvert.DeserializeObject**: Used to convert JSON data into a `WWE2K24_Generated_Belt` object, ignoring missing members.
- **JsonConvert.SerializeObject**: Used to convert a `Profile` object into JSON format with specific settings (e.g., ignoring default values and missing members).

### Specific Properties and Data

- **BeltDataTable**: Holds various properties related to the belt, including metadata, champion information, and visual data.
- **AssetMap**: Contains paths to assets like models and textures.
- **Meta**: Holds metadata like belt names, champion IDs, and other attributes.

### Error Handling

- **try-catch block**: Used during file writing to catch and log any exceptions.

This class essentially manages the creation and saving of belt profiles for WWE 2K24, including handling user interactions through the UI and ensuring data is correctly serialized and deserialized.

## /Meta/Editor/Controls/CreationSuite/CharacterCreationControl.cs

This code snippet is part of a larger application that likely deals with character creation and editing for a game, specifically WWE2K23. Here’s a breakdown of its functionality:

### Namespaces and Usings

The code begins with a set of using directives which import various namespaces that are needed for the code to function. These include namespaces for:

- Core functionalities (`Meta.Core`, `Meta.Core.Interfaces`, `Meta.Editor.Converters`, etc.).
- WWE2K23 specific structures (`Meta.Structures.Flatbuffers.WWE2K23`, `Meta.WWE2K23`).
- General utilities (`Newtonsoft.Json`, `Microsoft.Win32`, etc.).

### Namespace and Class Declaration

The `CharacterCreationControl` class is declared within the `Meta.Editor.Controls.CreationSuite` namespace. This class inherits from `CreationControl`.

### Fields and Constructor

The class has three public fields:

- `editorCharacter`
- `editorMapping`
- `editorMotion`

These are initialized in the constructor, which also logs a message indicating that the character creation editor is loading. The constructor also creates and populates an `ObservableCollection` with these editors.

### Methods

#### `Input`

The `Input` method accepts two parameters (`primaryInfo` and `name`). It iterates over the properties of `primaryInfo` and retrieves values that have a specific `CategoryAttribute`, converting them to `ushort` and adding them to a list.

#### `OpenAs`

The `OpenAs` method overrides the base class method to open a profile. It checks the profile type and then deserializes the profile data into a `CharacterProfile_WWE2K23` object using `JsonConvert`. If the deserialization is successful and both `Info` and `Motion` properties are not null, it loads the profile into the respective editors and logs a success message. If not, it shows an error message.

#### `SaveAs`

The `SaveAs` method overrides the base class method to save the current state of the editor as a profile. It gathers data from various properties and populates an `Info` and `Motion` object with the character's attributes, stats, and moves. These objects are then serialized and written to a file using a `SaveFileDialog`.

### Detailed Breakdown of `SaveAs`

1. **Update UI Elements**: The method ensures that the UI elements are updated and templates applied.
2. **File Dialog**: A `SaveFileDialog` is presented to the user to specify the file path for saving the profile.
3. **Profile Object**: A `Profile` object is created, and `Info` and `Motion` objects are populated with data from the editor fields.
4. **Populating Data**:
   - **Attributes**: The character's attributes, AI attributes, personality traits, and hit points are collected into lists.
   - **Motion Data**: Various motion data like entrance music, victory motions, etc., are gathered.
   - **Moveset**: The moveset data, including standing moves, signatures, finishers, ground moves, etc., are populated.
5. **Serialize and Save**: The profile object is serialized to JSON and saved to the specified file path.

### Summary

This class is part of a character editor tool for WWE2K23, allowing users to load, edit, and save character profiles. It integrates with a logging system to provide feedback during these operations and uses JSON serialization for saving the profile data. The detailed handling of properties and attributes suggests a robust system for managing complex character data.

## /Meta/Editor/Controls/CreationSuite/CharacterCreationControl_WWE2K24.cs

The provided code is part of a custom character creation control for a WWE2K24 game editor. Here's a breakdown of the key components and functionality:

### Imports and Namespace Declaration

- **Imports**: The code uses various namespaces for functionality like logging, serialization, UI controls, etc.
- **Namespace**: `Meta.Editor.Controls.CreationSuite` encapsulates the `CharacterCreationControl_WWE2K24` class.

### Class Definition

- **`CharacterCreationControl_WWE2K24`**: This class extends `CharacterCreationControl` and adds functionality specific to the WWE2K24 character creation.

### Fields

- **Fields**: The class contains fields for handling different aspects of character editing:
  - `editorCharacter`: Manages character-specific data.
  - `editorMapping`: Handles character mappings.
  - `editorMotion`: Manages character motions.

### Constructor

- **Constructor**: The constructor initializes the logger and the editor components, and sets up an `ObservableCollection` for the editors.

### Methods

1. **`OpenAs(Profile profile)`**:

   - **Purpose**: Opens and loads a character profile.
   - **Steps**:
     - Checks the profile type.
     - Sets up JSON serialization settings.
     - Deserializes the character profile data from the profile.
     - Loads the character profile into the editor components (`editorCharacter`, `editorMapping`, `editorMotion`).
     - Logs the loading process.

2. **`SaveAs()`**:
   - **Purpose**: Saves the current character profile to a file.
   - **Steps**:
     - Updates and applies the layout and template for the character information property grid.
     - Opens a save file dialog to get the save location and format.
     - Collects various data about the character including attributes, moves, motion data, etc.
     - Constructs a `CharacterProfile_WWE2K24` object and populates it with the collected data.
     - Serializes the profile and writes it to a file in JSON format.

### Detailed Breakdown

- **Initialization**: Editors for character, mapping, and motion are initialized and added to an observable collection.
- **OpenAs Method**:
  - Uses dynamic binding (via `Microsoft.CSharp.RuntimeBinder`) to deserialize profile data.
  - Loads various components of the character profile (e.g., info, motion) into the editor components.
- **SaveAs Method**:
  - Gathers character info (e.g., wrestler ID, attributes, motion data).
  - Iterates over properties to collect attributes, AI attributes, personality traits, and hit point ratios.
  - Configures motions for different scenarios (e.g., standing, ground, diving, springboard).
  - Maps attire data and creates character mappings.
  - Serializes the complete profile and writes it to a file.

### Use of Attributes and Serialization

- **Attributes**: `CategoryAttribute` is used to categorize properties for serialization.
- **Serialization**: `JsonConvert.SerializeObject` and `File.WriteAllText` are used to save the character profile in JSON format.

### Summary

This class is a specialized control for creating and managing WWE2K24 character profiles within an editor. It provides methods to load existing profiles and save new or updated profiles, handling various aspects of character data including attributes, motions, and mappings.

## /Meta/Editor/Controls/CreationSuite/CountryAttribute.cs

The given C# code defines a custom attribute class named `CountryAttribute` within the `Meta.Editor.Controls.CreationSuite` namespace. Here’s a breakdown of what each part of the code does:

### Code Breakdown

1. **Namespace Declaration:**

   ```csharp
   namespace Meta.Editor.Controls.CreationSuite
   ```

   - This line declares the namespace `Meta.Editor.Controls.CreationSuite`, which helps in organizing code and preventing naming conflicts.

2. **Using Directive:**

   ```csharp
   using System;
   ```

   - This line imports the `System` namespace, which includes the base class `Attribute` used for defining custom attributes.

3. **Nullable Directive:**

   ```csharp
   #nullable disable
   ```

   - This directive disables nullable reference types within this file, meaning the compiler will not enforce nullable reference type checks.

4. **AttributeUsage Attribute:**

   ```csharp
   [AttributeUsage(AttributeTargets.Property)]
   ```

   - This attribute specifies that the `CountryAttribute` can only be applied to properties. The `AttributeTargets.Property` enum value restricts its usage.

5. **CountryAttribute Class Definition:**

   ```csharp
   public class CountryAttribute : Attribute
   {
   }
   ```

   - This defines the `CountryAttribute` class as a subclass of `System.Attribute`, making it a custom attribute that can be used to decorate properties.

### Explanation

- **Custom Attribute (`CountryAttribute`):** This class inherits from `System.Attribute`, which allows it to be used as a custom attribute. It doesn’t have any methods or properties defined within it, so it serves as a marker attribute.
- **Usage Restriction:** The `AttributeUsage` attribute restricts the `CountryAttribute` to be applied only to properties. This means that you cannot use this attribute on classes, methods, fields, etc.

### Example Usage

Here’s an example of how you might use the `CountryAttribute` in another part of the code:

```csharp
public class User
{
  [Country]
  public string Country { get; set; }
}
```

In this example, the `CountryAttribute` is applied to the `Country` property of the `User` class. This could be used, for instance, to provide metadata or validation rules for the `Country` property at runtime or by a tool that processes these attributes.

### Summary

This code defines a simple custom attribute named `CountryAttribute` that can be applied only to properties. The attribute doesn't have any behavior or data associated with it by itself and serves as a marker that can be used for various purposes, such as metadata or validation.

## /Meta/Editor/Controls/CreationSuite/CreationControl.cs

This code defines a class `CreationControl` in the `Meta.Editor.Controls.CreationSuite` namespace. Let's break down the components and functionality of this code:

### Namespaces and Usings

```csharp
using Meta.Core;
using Meta.Core.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
```

These `using` directives import various namespaces that provide necessary classes and interfaces:

- `Meta.Core` and `Meta.Core.Interfaces`: Custom namespaces likely containing core functionality and interfaces for the Meta project.
- `System`: The base namespace containing fundamental classes.
- `System.Collections.ObjectModel`: Contains `ObservableCollection`, a dynamic data collection that provides notifications when items get added, removed, or when the entire list is refreshed.
- `System.Windows.Controls`: Contains classes related to UI controls for WPF applications.

### Nullable Context

```csharp
#nullable enable
```

Enables nullable reference types to help avoid null reference exceptions.

### Namespace Declaration

```csharp
namespace Meta.Editor.Controls.CreationSuite
```

Declares the namespace in which the `CreationControl` class resides.

### Class Definition

```csharp
public class CreationControl : Control
```

`CreationControl` is a public class that inherits from `Control`, a base class for WPF user interface elements.

### Fields and Properties

```csharp
public ObservableCollection<CreationEditor> Editors = new ObservableCollection<CreationEditor>();
protected ILogger logger;
protected MetaTabControl Tab;
```

- `Editors`: A public collection of `CreationEditor` objects, using `ObservableCollection` to automatically notify when changes occur.
- `logger`: A protected field of type `ILogger` for logging purposes.
- `Tab`: A protected field of type `MetaTabControl`, representing a tab control in the UI.

### Constructor

```csharp
public CreationControl(ILogger inLogger, MetaTabControl tab)
{
  this.logger = inLogger;
  this.Tab = tab;
}
```

The constructor initializes the `CreationControl` object with an `ILogger` instance and a `MetaTabControl` instance, assigning them to the respective fields.

### Methods

```csharp
public virtual void OpenAs(Profile profile)
{
}
```

A virtual method `OpenAs` that takes a `Profile` object as a parameter. This method is currently empty and intended to be overridden in derived classes.

```csharp
public virtual void SaveAs()
{
}
```

A virtual method `SaveAs` that currently does nothing but is intended to be overridden in derived classes.

```csharp
public virtual void Closed()
{
  foreach (CreationEditor editor in (Collection<CreationEditor>) this.Editors)
    editor.Shutdown();
  GC.Collect();
}
```

A virtual method `Closed` that performs cleanup:

- Iterates through each `CreationEditor` in the `Editors` collection and calls the `Shutdown` method on each.
- Calls `GC.Collect()` to trigger garbage collection, which helps in reclaiming memory.

### Summary

The `CreationControl` class is a custom control for a WPF application within the `Meta.Editor.Controls.CreationSuite` namespace. It manages a collection of `CreationEditor` objects and provides methods for opening, saving, and closing these editors. The class is designed to be extended, with virtual methods that can be overridden to provide specific functionality in derived classes. The use of an `ILogger` for logging and a `MetaTabControl` for UI tab management indicates this control is part of a larger, potentially complex user interface.

## /Meta/Editor/Controls/CreationSuite/CreationControlAttribute.cs

This code snippet defines a custom attribute called `CreationControlAttribute` in the `Meta.Editor.Controls.CreationSuite` namespace. Let's break down its functionality:

### Namespaces and Usings

The code starts with `using` directives that import necessary namespaces:

- `Meta.Core`: This suggests that there might be some core functionalities or types defined in the `Meta.Core` namespace that are used within this attribute class.
- `System`: This includes basic system functionalities provided by the .NET framework.

### Nullable Context

`#nullable enable` enables nullable reference types feature introduced in C# 8.0, which helps in nullability annotations and static analysis for potential `null` references.

### Namespace

The code is defined within the `Meta.Editor.Controls.CreationSuite` namespace, indicating that it is part of the editor controls for a creation suite, likely used for game or content creation.

### `CreationControlAttribute` Class

The `CreationControlAttribute` class is derived from `System.Attribute`, making it a custom attribute that can be applied to other program elements.

### Attribute Usage

```csharp
[AttributeUsage(AttributeTargets.All)]
```

The `AttributeUsage` attribute specifies that the `CreationControlAttribute` can be applied to all program elements (`AttributeTargets.All`).

### Constructor

```csharp
public CreationControlAttribute(string id, ProfileType profileType)
```

This constructor accepts two parameters:

- `id`: A `string` that represents an identifier for the attribute.
- `profileType`: An enumeration value of type `ProfileType` that indicates the profile type associated with this attribute.

The constructor initializes the `id` and `profile` properties with the provided values.

### Properties

The attribute class has two properties:

- `id`: A `string` property that stores the identifier. It is declared with a `private set`, meaning it can only be set within the class.
- `profile`: A `ProfileType` property that stores the profile type. Similarly, it is declared with a `private set`.

### Example Usage

An attribute class like this could be used to decorate other classes, methods, or properties to provide additional metadata about them. For example:

```csharp
[CreationControl("character", ProfileType.Character)]
public class CharacterCreationControl : CreationControl
{
    // Class implementation
}
```

In this example, the `CharacterCreationControl` class is decorated with the `CreationControlAttribute`, providing metadata that identifies it as a "character" creation control and associates it with a specific profile type (`ProfileType.Character`).

### Summary

- **Purpose**: The `CreationControlAttribute` class provides a way to attach metadata (`id` and `profileType`) to other elements in the program.
- **Constructor**: Initializes the `id` and `profile` properties.
- **Properties**: `id` and `profile` store the values passed during the attribute initialization.
- **Usage**: It can be applied to any program element to provide additional information, which can be useful for reflection or custom handling within the application.

## /Meta/Editor/Controls/CreationSuite/CreationEditor.cs

The provided code defines a class named `CreationEditor` within the `Meta.Editor.Controls.CreationSuite` namespace. This class is intended to be a base class for creation editor controls in a WPF application. Here's a detailed explanation of its components:

### Imports and Namespace Declaration

- **Imports**: The code uses namespaces for logging (`Meta.Core.Interfaces`), standard .NET functionalities (`System`), property change notifications (`System.ComponentModel`), and WPF controls (`System.Windows.Controls`).
- **Namespace**: `Meta.Editor.Controls.CreationSuite` encapsulates the `CreationEditor` class.

### Class Definition

- **`CreationEditor`**: This class derives from `Control` and implements the `INotifyPropertyChanged` interface. It serves as a base class for editor controls in the creation suite.

### Fields

- **`logger`**: A protected field of type `ILogger` used for logging purposes.

### Events

- **`PropertyChanged`**: An event from the `INotifyPropertyChanged` interface that is used to notify clients, typically binding clients, that a property value has changed.

### Properties

- **`Title`**: A virtual property that returns a string `"Empty Control"`. Derived classes can override this to provide a specific title.
- **`Icon`**: A virtual property that returns a string `"Folder"`. Derived classes can override this to provide a specific icon.

### Constructor

- **`CreationEditor(ILogger inLogger)`**:
  - Initializes the `logger` field with the provided `ILogger` instance.
  - Subscribes to the `Initialized` event with the `CreationEditor_Initialized` event handler.

### Methods

1. **`CreationEditor_Initialized(object? sender, EventArgs e)`**:

   - A protected virtual method that serves as an event handler for the `Initialized` event.
   - This method is intended to be overridden by derived classes to perform initialization tasks.

2. **`Shutdown()`**:
   - A public virtual method intended to be overridden by derived classes to perform cleanup or shutdown tasks.

### Summary

- **Purpose**: The `CreationEditor` class provides a base structure for editor controls in a WPF application. It includes basic functionalities such as logging, property change notifications, and initialization/shutdown mechanisms.
- **Extensibility**: The class is designed to be extended by other classes that will provide specific functionalities for different types of creation editors. The properties `Title` and `Icon` are virtual, allowing derived classes to specify their own titles and icons. Similarly, the methods `CreationEditor_Initialized` and `Shutdown` are virtual, enabling derived classes to customize their initialization and shutdown processes.

## /Meta/Editor/Controls/CreationSuite/CrowdSignAttribute.cs

The given C# code defines a custom attribute class named `CrowdSignAttribute` within the `Meta.Editor.Controls.CreationSuite` namespace. Let’s break down and explain each part of the code:

### Code Breakdown

1. **Using Directive:**

   ```csharp
   using System;
   ```

   - This line imports the `System` namespace, which includes the base class `Attribute` used for defining custom attributes.

2. **Nullable Directive:**

   ```csharp
   #nullable disable
   ```

   - This directive disables nullable reference type annotations and warnings in this file, meaning the compiler will not enforce nullable reference type checks.

3. **Namespace Declaration:**

   ```csharp
   namespace Meta.Editor.Controls.CreationSuite
   ```

   - This line declares the namespace `Meta.Editor.Controls.CreationSuite`. Namespaces are used to organize code and prevent naming conflicts.

4. **AttributeUsage Attribute:**

   ```csharp
   [AttributeUsage(AttributeTargets.Property)]
   ```

   - This attribute specifies that the `CrowdSignAttribute` can only be applied to properties. The `AttributeTargets.Property` enum value restricts its usage.

5. **CrowdSignAttribute Class Definition:**

   ```csharp
   public class CrowdSignAttribute : Attribute
   {
   }
   ```

   - This defines the `CrowdSignAttribute` class as a subclass of `System.Attribute`, making it a custom attribute that can be used to decorate properties.

### Explanation

- **Custom Attribute (`CrowdSignAttribute`):** This class inherits from `System.Attribute`, allowing it to be used as a custom attribute. It doesn't contain any methods or properties, so it serves as a marker attribute.

- **Usage Restriction:** The `AttributeUsage` attribute restricts the `CrowdSignAttribute` to be applied only to properties. This means that you cannot use this attribute on classes, methods, fields, etc.

### Example Usage

Here’s an example of how you might use the `CrowdSignAttribute` in another part of the code:

```csharp
public class Event
{
  [CrowdSign]
  public string Sign { get; set; }
}
```

In this example, the `CrowdSignAttribute` is applied to the `Sign` property of the `Event` class. This could be used, for instance, to provide metadata or validation rules for the `Sign` property at runtime or by a tool that processes these attributes.

### Summary

This code defines a simple custom attribute named `CrowdSignAttribute` that can be applied only to properties. The attribute doesn’t have any behavior or data associated with it by itself and serves as a marker that can be used for various purposes, such as metadata or validation.

## /Meta/Editor/Controls/CreationSuite/DefaultIndexAttribute.cs

Sure, here's an explanation of the given C# code:

### Overview

This code defines a custom attribute named `DefaultIndexAttribute` within the `Meta.Editor.Controls.CreationSuite` namespace. Attributes in C# are a way to add metadata to your code, and they can be used to decorate classes, methods, properties, etc. This particular attribute is designed to be applied to properties, and it allows a default selected index to be specified.

### Breakdown

1. **Namespace Declaration**

   ```csharp
   namespace Meta.Editor.Controls.CreationSuite
   ```

   The `namespace` keyword is used to declare a scope that contains a set of related objects. Here, `Meta.Editor.Controls.CreationSuite` is the namespace containing the `DefaultIndexAttribute` class.

2. **Nullable Context**

   ```csharp
   #nullable enable
   ```

   This directive enables nullable reference types, which is a feature that helps to prevent null reference exceptions. It indicates that the code that follows should use the nullable annotations and warnings.

3. **Attribute Declaration**

   ```csharp
   [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
   internal sealed class DefaultIndexAttribute : Attribute
   ```

   - `[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]`: This specifies how the attribute can be used:
     - `AttributeTargets.Property`: The attribute can only be applied to properties.
     - `Inherited = false`: The attribute will not be inherited by derived classes.
     - `AllowMultiple = false`: The attribute cannot be applied more than once to a single property.
   - `internal sealed class DefaultIndexAttribute`: Defines an internal (accessible only within the same assembly) and sealed (cannot be inherited) class named `DefaultIndexAttribute` that extends `Attribute`.

4. **Property and Constructor**

   ```csharp
   public string DefaultSelectedIndex { get; }

   public DefaultIndexAttribute(string defaultSelectedIndex)
   {
     this.DefaultSelectedIndex = defaultSelectedIndex;
   }
   ```

   - `public string DefaultSelectedIndex { get; }`: This is an auto-implemented property that gets the default selected index.
   - `public DefaultIndexAttribute(string defaultSelectedIndex)`: This is the constructor for the `DefaultIndexAttribute` class. It takes a single parameter, `defaultSelectedIndex`, and assigns it to the `DefaultSelectedIndex` property.

### Usage

You can use the `DefaultIndexAttribute` to decorate properties in your classes. For example:

```csharp
public class ExampleClass
{
  [DefaultIndex("0")]
  public string ExampleProperty { get; set; }
}
```

In this example, the `ExampleProperty` has a `DefaultIndexAttribute` applied with a default selected index of "0".

### Summary

- **Namespace:** Groups related classes and interfaces.
- **Nullable Context:** Enables nullable reference types.
- **Attribute:** A custom attribute to specify a default selected index for properties.
- **Constructor:** Initializes the attribute with a specific default index value.

This attribute can be useful in scenarios where you need to specify a default index for properties, such as in a UI framework where you might want to pre-select an item in a list or dropdown.

## /Meta/Editor/Controls/CreationSuite/EditorBelt.cs

The provided code defines a class named `EditorBelt` within the `Meta.Editor.Controls.CreationSuite` namespace. This class extends from `CreationEditor` and is part of a GUI framework that deals with creating and editing objects, specifically belts, for what appears to be a game or an application. Here’s a breakdown of the key components and functionalities:

### Namespaces and Dependencies

- **Namespaces:**

  - `Meta.Core.Interfaces`
  - `MetaEditor`
  - `Newtonsoft.Json`
  - `PropertyTools.DataAnnotations`
  - `PropertyTools.Wpf`
  - `System.Collections.ObjectModel`
  - `System.Windows`

- **Dependencies:**
  - `MetaPropertyGridFactory`: A factory for creating property grids.
  - `ILogger`: An interface for logging.
  - `PropertyGrid`: A control for displaying and editing properties.
  - `JsonConvert`: For JSON serialization and deserialization.

### Classes and Members

#### `EditorBelt` Class

- **Fields and Properties:**

  - `PART_PrimaryInfoPropertyGrid`, `PART_SecondaryInfoPropertyGrid`: Constants for template parts.
  - `PrimaryInfoPropertyGrid`, `SecondaryInfoPropertyGrid`: Instances of `PropertyGrid` for displaying primary and secondary belt information.
  - `beltPrimaryInfo`, `beltSecondaryInfo`: Instances of `BeltBasicInfo` and `BeltMappingInfo` for storing belt information.

- **Properties:**

  - `Title`: Overrides the title property with "Info".
  - `Icon`: Overrides the icon property with "Trophy".
  - `MetaPropertyGridFactory`: A factory for creating property grid controls.
  - `BeltInfo`: Gets the selected object from `PrimaryInfoPropertyGrid`.
  - `BeltMapping`: Gets the selected object from `SecondaryInfoPropertyGrid`.

- **Constructor:**

  - Initializes `MetaPropertyGridFactory`, `beltPrimaryInfo`, and `beltSecondaryInfo`.
  - Loads default values for belt information.

- **Static Constructor:**

  - Overrides the default style key for `EditorBelt`.

- **Methods:**
  - `OnApplyTemplate`: Applies the template and initializes the property grids.
  - `Load`: Loads belt information from a `WWE2K23_Generated_Belt` profile.
  - `Shutdown`: Cleans up the property grids on shutdown.

#### `BeltBasicInfo` Class

- **Fields and Properties:**
  - `BeltTypes`: Collection of belt types.
  - Various properties annotated with `Category`, `DisplayName`, `Description`, etc., for displaying in the property grid.
  - `LoadDefaults`: Sets default values for the properties.

#### `BeltMappingInfo` Class

- **Fields and Properties:**
  - Various properties annotated with `Category`, `DisplayName`, `InputFilePath`, `MetaDirectorySelect`, etc., for displaying in the property grid.
  - `LoadDefaults`: Sets default values for the properties.
  - Filter properties for file dialogs.

### Summary

The `EditorBelt` class is designed to be a part of a GUI that allows users to create and edit belt objects within an application. It leverages property grids to display and edit properties of these belts, with support for loading belt data from an external profile and saving user inputs back to the profile.

The `BeltBasicInfo` and `BeltMappingInfo` classes encapsulate the properties related to the belt's basic information and mapping information, respectively. These classes use JSON for serialization and deserialization and are designed to be used within property grids for user-friendly data manipulation.

## /Meta/Editor/Controls/CreationSuite/EditorBelt_WWE2K24.cs

The code provided is a C# class named `EditorBelt_WWE2K24` within the `Meta.Editor.Controls.CreationSuite` namespace. This class extends `CreationEditor` and is part of a graphical editor suite for the WWE2K24 game, focusing on the creation and editing of championship belts.

Here's a breakdown of the key components and functionality:

1. **Namespace and Using Directives**:

   - The code starts with several `using` directives that import necessary namespaces and libraries such as `Meta.Core.Interfaces`, `MetaEditor`, `Newtonsoft.Json`, and others for various functionalities like JSON handling and property annotations.

2. **Class Definition and Fields**:

   - `EditorBelt_WWE2K24` class inherits from `CreationEditor`.
   - It defines several fields and constants, including:
     - `PrimaryInfoPropertyGrid` and `SecondaryInfoPropertyGrid`, which are `PropertyGrid` controls used to display and edit belt properties.
     - `beltPrimaryInfo` and `beltSecondaryInfo`, which are instances of nested classes `BeltBasicInfo` and `BeltMappingInfo`, respectively, holding the primary and secondary information about a belt.

3. **Properties**:

   - `Title` and `Icon` properties override base class properties to return specific values ("Info" and "Trophy").
   - `MetaPropertyGridFactory` is a property used to generate property grid controls.
   - `BeltInfo` and `BeltMapping` properties return the selected objects from the property grids.

4. **Constructor**:

   - The constructor initializes the `MetaPropertyGridFactory` and loads default values into `beltPrimaryInfo` and `beltSecondaryInfo`.

5. **Static Constructor**:

   - This static constructor sets the default style key property for the `EditorBelt_WWE2K24` control, integrating it into the WPF styling system.

6. **OnApplyTemplate Method**:

   - This method is called when the control's template is applied. It retrieves the `PrimaryInfoPropertyGrid` and `SecondaryInfoPropertyGrid` from the template, sets their `ControlFactory`, and assigns the selected objects to the corresponding belt info instances.

7. **Load Method**:

   - The `Load` method populates the belt info instances (`beltPrimaryInfo` and `beltSecondaryInfo`) with data from a `WWE2K24_Generated_Belt` object. This includes setting various properties like `BeltType`, `BeltSlotID`, `BeltFullName`, and paths for models and textures.

8. **Shutdown Method**:

   - This method cleans up resources by setting the data context and selected objects of the property grids to `null`.

9. **Nested Classes (`BeltBasicInfo` and `BeltMappingInfo`)**:
   - `BeltBasicInfo` contains properties for basic belt information such as `BeltType`, `BeltSlotID`, `BeltFullName`, and various other attributes. These properties are decorated with attributes for display and data binding in the property grid.
   - `BeltMappingInfo` contains properties for belt rendering paths and configurations, such as `BeltRenderPath`, `CutsceneMDLPath`, and `DefaultTexturesPath`.

These classes and methods together form a comprehensive editor for creating and modifying belt information in the WWE2K24 game, utilizing WPF for the user interface and JSON for data serialization and deserialization.

## /Meta/Editor/Controls/CreationSuite/EditorCharacter.cs

This C# code defines a class `EditorCharacter` within the `Meta.Editor.Controls.CreationSuite` namespace. This class is part of a larger application, likely a game editor, possibly for WWE 2K23, given the references. The class and its nested classes handle the properties and behavior for character creation within this editor. Here's a breakdown of the code:

### Namespaces and Imports

```csharp
using Meta.Core.Interfaces;
using Meta.WWE2K23;
using MetaEditor;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using PropertyTools.DataAnnotations;
using PropertyTools.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
```

- Various namespaces are imported to handle different functionalities, including JSON serialization, WPF controls, runtime binding, and reflection.

### Nullable Context and Namespace Declaration

```csharp
#nullable enable
namespace Meta.Editor.Controls.CreationSuite
{
```

- `#nullable enable` enables nullable reference types.
- The `Meta.Editor.Controls.CreationSuite` namespace indicates the scope of the class.

### Class Attributes and Template Parts

```csharp
[TemplatePart(Name = "PART_GeneralInfoPropertyGrid", Type = typeof(PropertyGrid))]
[TemplatePart(Name = "PART_SecondaryInfoPropertyGrid", Type = typeof(PropertyGrid))]
public class EditorCharacter : CreationEditor
{
```

- The `TemplatePart` attributes specify the names and types of template parts used within the WPF control.

### Class Members and Properties

```csharp
protected const string PART_GeneralInfoPropertyGrid = "PART_GeneralInfoPropertyGrid";
protected const string PART_SecondaryInfoPropertyGrid = "PART_SecondaryInfoPropertyGrid";
public PropertyGrid BasicInfoPropertyGrid;
protected PropertyGrid SecondaryInfoPropertyGrid;
public EditorCharacter.CharacterBasicInfo characterPrimaryInfo;
protected EditorCharacter.CharacterSecondaryInfo characterSecondaryInfo;

public override string Title => "Info";

public override string Icon => "FaceAgent";

public MetaPropertyGridFactory MetaPropertyGridFactory { get; set; }
```

- Various fields and properties are declared to hold references to the property grids and character info.
- `Title` and `Icon` are overridden properties from the base class `CreationEditor`.

### Constructor and Static Constructor

```csharp
public EditorCharacter(ILogger inLogger)
    : base(inLogger)
{
    this.MetaPropertyGridFactory = new MetaPropertyGridFactory();
    this.characterPrimaryInfo = new EditorCharacter.CharacterBasicInfo();
    this.characterPrimaryInfo.LoadDefaults();
    this.characterSecondaryInfo = new EditorCharacter.CharacterSecondaryInfo();
    this.characterSecondaryInfo.LoadDefaults();
}

static EditorCharacter()
{
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(EditorCharacter), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(EditorCharacter)));
}
```

- The constructor initializes the `MetaPropertyGridFactory` and character info objects.
- The static constructor sets the default style key for the `EditorCharacter` control.

### OnApplyTemplate Method

```csharp
public override void OnApplyTemplate()
{
    base.OnApplyTemplate();
    this.BasicInfoPropertyGrid = this.GetTemplateChild("PART_GeneralInfoPropertyGrid") as PropertyGrid;
    this.BasicInfoPropertyGrid.ControlFactory = (IPropertyGridControlFactory)this.MetaPropertyGridFactory;
    this.BasicInfoPropertyGrid.SelectedObject = (object)this.characterPrimaryInfo;
    this.SecondaryInfoPropertyGrid = this.GetTemplateChild("PART_SecondaryInfoPropertyGrid") as PropertyGrid;
    this.SecondaryInfoPropertyGrid.ControlFactory = (IPropertyGridControlFactory)this.MetaPropertyGridFactory;
    this.SecondaryInfoPropertyGrid.SelectedObject = (object)this.characterSecondaryInfo;
}
```

- This method is called when the control's template is applied. It retrieves the template parts and sets their properties.

### Load Method

```csharp
public virtual void Load(object characterProfile)
{
    if (EditorCharacter.< >o__23.< >p__0 == null)
    {
        EditorCharacter.< >o__23.< >p__0 = CallSite<Func<CallSite, object, CharacterProfile_WWE2K23>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(CharacterProfile_WWE2K23), typeof(EditorCharacter)));
    }
    CharacterProfile_WWE2K23 Profile = EditorCharacter.< >o__23.< >p__0.Target((CallSite)EditorCharacter.< >o__23.< >p__0, characterProfile);
    this.characterPrimaryInfo = new EditorCharacter.CharacterBasicInfo();
    this.characterPrimaryInfo.LoadDefaults();
    this.characterSecondaryInfo = new EditorCharacter.CharacterSecondaryInfo();
    this.characterSecondaryInfo.LoadDefaults();
    // Various property assignments from Profile to characterPrimaryInfo and characterSecondaryInfo
}
```

- This method loads character data from a given profile object and sets various properties on the character info objects.

### Shutdown Method

```csharp
public override void Shutdown()
{
    base.Shutdown();
    ((FrameworkElement)this.BasicInfoPropertyGrid).DataContext = (object)null;
    this.BasicInfoPropertyGrid.SelectedObject = (object)null;
    ((FrameworkElement)this.SecondaryInfoPropertyGrid).DataContext = (object)null;
    this.SecondaryInfoPropertyGrid.SelectedObject = (object)null;
}
```

- This method cleans up by setting the data context and selected objects to null when shutting down.

### Nested CharacterBasicInfo and CharacterSecondaryInfo Classes

```csharp
public class CharacterBasicInfo : BaseEditor
{
    public CharacterBasicInfo()
    {
        // Initialize ObservableCollections from JSON data
    }

    public void LoadDefaults()
    {
        // Set default values for various properties
    }

    // Various properties with attributes for WPF property grid
}
```

- `CharacterBasicInfo` and `CharacterSecondaryInfo` classes represent the primary and secondary information for a character, respectively.
- Each class includes properties with attributes for display in a property grid, including categories, display names, and data sources.

### Summary

This code defines a WPF control for editing characters in a WWE game editor. It uses property grids to display and edit character properties, loads data from a character profile, and supports customization through various attributes and JSON data.

## /Meta/Editor/Controls/CreationSuite/EditorCharacter_WWE2K24.cs

The provided code snippet is a part of a larger application, possibly for editing or creating character profiles for a wrestling video game, WWE 2K24. Here's a breakdown of the main components and functionality of the code:

### Namespaces and Usings

The code uses several namespaces and libraries, including:

- `Meta.Core.Interfaces`: Likely contains core interfaces used in the application.
- `Meta.WWE2K24`: Specific to the WWE 2K24 game, possibly containing game-specific classes and methods.
- `MetaEditor`: Contains editing functionalities.
- `Microsoft.CSharp.RuntimeBinder`: Provides runtime binding for dynamic operations.
- `Newtonsoft.Json`: Used for JSON serialization and deserialization.
- `PropertyTools.DataAnnotations` and `PropertyTools.Wpf`: For creating property grids in WPF applications.
- `System`, `System.Collections.Generic`, `System.Collections.ObjectModel`, `System.Linq`, `System.Reflection`, `System.Runtime.CompilerServices`, and `System.Windows`: Standard .NET libraries for collections, reflection, and WPF.

### Class Definition

The `EditorCharacter_WWE2K24` class is a WPF control used for editing character profiles in WWE 2K24. It inherits from `CreationEditor`.

#### Attributes and Fields

- `[TemplatePart(Name = "PART_GeneralInfoPropertyGrid", Type = typeof(PropertyGrid))]`: Specifies a named part of the template for the control.
- `BasicInfoPropertyGrid`, `SecondaryInfoPropertyGrid`: Instances of `PropertyGrid` for displaying and editing character information.
- `characterPrimaryInfo`, `characterSecondaryInfo`: Instances of `CharacterBasicInfo` and `CharacterSecondaryInfo`, respectively, holding the character's primary and secondary information.

#### Properties

- `Title`: Overrides the title of the editor to "Info".
- `Icon`: Overrides the icon to "FaceAgent".
- `MetaPropertyGridFactory`: A factory for creating property grid controls.
- `CharacterInfo`: Retrieves the selected object from `BasicInfoPropertyGrid`.
- `CharacterStats`: Retrieves the selected object from `SecondaryInfoPropertyGrid`.

#### Constructor

The constructor initializes the property grid factory and loads default values for character primary and secondary information.

#### Static Constructor

Sets the default style key property for the control.

#### Methods

- `OnApplyTemplate()`: Applies the template and initializes the property grids with control factories and selected objects.
- `Load(object characterProfile)`: Loads a character profile into the editor. It maps various properties from the `characterProfile` object to the corresponding properties in `characterPrimaryInfo` and `characterSecondaryInfo`.
- `Shutdown()`: Cleans up the data context and selected objects of the property grids when shutting down the editor.

### Nested Classes

#### `CharacterBasicInfo`

- A class that holds basic information about a character, with properties decorated with attributes like `[Category]`, `[DisplayName]`, `[ItemsSourceProperty]`, and `[Slidable]` to control their appearance in the property grid.
- Properties include `WrestlerSlotID`, `WrestlerID`, `WrestlerPlayability`, `WrestlerMenuLocation`, `WrestlerGender`, `WrestlerClass`, `WrestlerCountry`, `WrestlerHeight`, `WrestlerWeight`, `WrestlerCommentaryID`, `WrestlerAnnounceID`, `WrestlerMusic`, `WrestlerFullName`, `WrestlerNickName`, `WrestlerSocialMedia`, `WrestlerPayBack1`, `WrestlerPayBack2`, `WrestlerEntranceMotionIntro`, `WrestlerEntranceMotionRing`, `WrestlerEntranceMotionRingIn`, `WrestlerEntranceMotionRamp`, `WrestlerEntranceMotionStage`, `WrestlerEntranceTitleMotion`, `WrestlerEntranceMITBMotion`, `WrestlerEntranceFilter`, `WrestlerEntranceLightShow`, `WrestlerVictoryMotionFace`, `WrestlerVictoryMotionHeel`, `WrestlerVictoryTitleMotionFace`, `WrestlerVictoryTitleMotionHeel`, `WrestlerEntranceMovieTitantron`, `WrestlerEntranceMovieBanner`, `WrestlerEntranceMovieStageRamp`, `WrestlerEntranceMovieApronRingPost`, `WrestlerEntranceMovieBarricade`, and several others.

#### `CharacterSecondaryInfo`

- A class that holds secondary information about a character, with properties decorated similarly to `CharacterBasicInfo`.
- Properties include `WrestlerHitPointHead`, `WrestlerHitPointBody`, `WrestlerHitPointArms`, `WrestlerHitPointLegs`, `WrestlerEgotisticalPrideful`, `WrestlerDisrespectfulRespectful`, `WrestlerDesperatePreservant`, `WrestlerTreacherousLoyal`, `WrestlerCowardlyBold`, `WrestlerAggressiveDisciplined`, `WrestlerAttributeArmPower`, `WrestlerAttributeLegPower`, `WrestlerAttributeGrappleOffense`, `WrestlerAttributeRunningOffense`, `WrestlerAttributeAerialOffense`, `WrestlerAttributeAeriaRange`, `WrestlerAttributePowerSubmissionOffense`, `WrestlerAttributeTechnicalSubmissionOffense`, `WrestlerAttributeStrikeReversal`, `WrestlerAttributeGrappleReversal`, `WrestlerAttributeAerialReversal`, `WrestlerAttributeBodyDurability`, `WrestlerAttributeArmDurability`, `WrestlerAttributeLegDurability`, `WrestlerAttributePowerSubmissionDefense`, `WrestlerAttributeTechnicalSubmissionDefense`, `WrestlerAttributePinEscape`, `WrestlerAttributeStrength`, `WrestlerAttributeStamina`, `WrestlerAttributeAgility`, `WrestlerAttributeMovementSpeed`, `WrestlerAttributeRecovery`, `WrestlerAttributeSpecial`, `WrestlerAttributeFinisher`, `WrestlerAIComboTendency`, `WrestlerAIComboSelectionTowards`, `WrestlerAIComboSelectionNeutral`, `WrestlerAIComboSelectionAway`, `WrestlerAISubmissionsTendency`, `WrestlerAILightStrikeTendency`, `WrestlerAIHeavyStrikeTendency`, `WrestlerAILightGrappleTendency`, `WrestlerAIHeavyGrappleTendency`, `WrestlerAIGroundStrikeTendency`, `WrestlerAIGroundGrappleTendency`, `WrestlerAIEnvironmentalStrikeTendency`, `WrestlerAIEnvironmentalGrappleTendency`, `WrestlerAIDiveTendency`, `WrestlerAIDaredevilDiveTendency`, `WrestlerAIInRingSpringboardTendency`, `WrestlerAIRingsideSpringboardTendency`, `WrestlerAILimbTargetingTendency`, `WrestlerAIRunningAttackTendency`, `WrestlerAIBlockingTendency`, `WrestlerAIDodgingTendency`, `WrestlerAIWeaponUsageTendency`, `WrestlerAITableUsageTendency`, `WrestlerAIPossumAttackandPinTendency`, `WrestlerAIInstantRecoveryTendency`, `WrestlerAIRingEscapeTendency`, and `WrestlerAIPinComboTendency`.

### Summary

The `EditorCharacter_WWE2K24` class is designed to provide a UI for editing the details of a character in the WWE 2K24 game. It utilizes property grids to display and edit properties, which are categorized and decorated for better UX. The class also includes methods for loading character profiles and setting default values, ensuring that the character information is properly initialized and displayed.

## /Meta/Editor/Controls/CreationSuite/EditorMapping.cs

The provided code defines a class named `EditorMapping` which inherits from a class called `CreationEditor`. This class is a part of the `Meta.Editor.Controls.CreationSuite` namespace and appears to be part of a larger application, likely a modding or editing tool for the WWE2K23 game.

Here's a breakdown of what the code does:

### Namespaces and Dependencies

The code starts by importing several namespaces and libraries, including `Meta.Core`, `MetaEditor`, `Newtonsoft.Json`, and `PropertyTools`. These provide various functionalities such as core application logic, JSON serialization, and property grid controls for WPF (Windows Presentation Foundation).

### Class Definition

The `EditorMapping` class is decorated with `TemplatePart` attributes that define parts of the WPF control template it uses:

- `PART_GeneralInfoPropertyGrid` and `PART_SecondaryInfoPropertyGrid`, which are expected to be `PropertyGrid` controls.

### Fields and Properties

- `BasicInfoPropertyGrid` and `SecondaryMappingPropertyGrid` are fields for the two `PropertyGrid` controls.
- `mappingPrimaryInfo` and `mappingSecondaryInfo` are fields that hold instances of nested classes `MappingPrimaryInfo` and `MappingSecondaryInfo` respectively.
- `Primaryinfo` and `SecondaryInfo` are public properties that expose `mappingPrimaryInfo` and `mappingSecondaryInfo`.
- `Title` and `Icon` are overridden properties from the base class, providing a title and icon for the editor.
- `MetaPropertyGridFactory` is a property for a factory object that creates controls for the property grids.

### Constructor

The constructor initializes the `DataContext`, creates instances of the `MetaPropertyGridFactory`, and the nested classes `MappingPrimaryInfo` and `MappingSecondaryInfo`. It also calls their `LoadDefaults` methods to initialize default values.

### Static Constructor

The static constructor overrides the default style key property for the `EditorMapping` class, which is necessary for WPF control templating.

### OnApplyTemplate Method

This method is called when the control template is applied. It initializes the `PropertyGrid` controls, sets their control factories, and assigns selected objects to the property grids for display and editing.

### Methods

- `GetRenders` returns an observable collection of property info objects related to renders by filtering properties with a specific category attribute.
- `GetAttireData` returns an observable collection of grouped property info objects related to attire data by filtering properties with a specific attribute and grouping them by an ID.
- `Load` method loads character profile data and maps it to the primary and secondary mapping info objects. It also updates the property grids' selected objects.
- `Shutdown` method clears the data context and selected objects of the property grids.

### Nested Classes

- `MappingPrimaryInfo` contains properties related to primary mapping info, with attributes for categorization and display purposes.
- `MappingSecondaryInfo` contains properties related to secondary mapping info and attire, with attributes for categorization and display purposes, as well as methods to load default values.

### Enums

The `Attires` enum defines possible values for the number of attires a character can have.

### Attributes

The code uses various attributes to control how properties are displayed and interacted with in the property grids, such as `Category`, `DisplayName`, `InputFilePath`, and custom attributes like `Attire` and `CrowdSign`.

In summary, the `EditorMapping` class is a WPF control designed for editing character mapping data in WWE2K23. It uses property grids to allow users to modify various properties of the character profiles and loads/saves data using JSON serialization. The control integrates with WPF templating and data binding to provide a user-friendly interface for these operations.

## /Meta/Editor/Controls/CreationSuite/EditorMapping_WWE2K24.cs

This code defines a custom WPF control for the WWE 2K24 game editor, specifically for mapping character data in the Creation Suite. Here's a breakdown of the code:

### Namespaces and Dependencies

The code starts by importing several namespaces and libraries required for the functionality, including Meta.Core, Newtonsoft.Json for JSON handling, PropertyTools for WPF property grids, and System.Collections.Generic for collections.

### Class Definition: `EditorMapping_WWE2K24`

This class extends `CreationEditor` and is decorated with `TemplatePart` attributes to define parts of the control template, specifically for property grids (`PropertyGrid`).

### Fields

The class contains several fields:

- `BasicInfoPropertyGrid` and `SecondaryMappingPropertyGrid`: These are property grids for displaying primary and secondary information.
- `mappingPrimaryInfo` and `mappingSecondaryInfo`: Instances of inner classes to hold primary and secondary mapping information.

### Properties

- `Primaryinfo` and `SecondaryInfo`: Read-only properties to access the primary and secondary mapping information.
- `Title` and `Icon`: Override properties to provide the title and icon for the editor.
- `MetaPropertyGridFactory`: A factory to create custom property grid controls.

### Constructor

The constructor initializes the `MetaPropertyGridFactory`, sets the data context, and loads default values for `mappingPrimaryInfo` and `mappingSecondaryInfo`.

### Static Constructor

This overrides the default style key property for the control.

### Methods

- `OnApplyTemplate`: Applies the control template, initializing the property grids with the appropriate data and factory.
- `GetRenders`: Returns a collection of properties related to renders, filtered by a custom attribute.
- `GetAttireData`: Returns a collection of attire properties, grouped by an ID.
- `Load`: Loads a `CharacterProfile_WWE2K24` and generated profile into the mapping classes, setting various properties based on the deserialized data.
- `Shutdown`: Clears data contexts and selected objects for the property grids.

### Inner Classes

- `MappingPrimaryInfo` and `MappingSecondaryInfo`: These classes contain properties decorated with attributes to define their appearance in the property grid and to hold various paths and IDs for character mapping.

### Enum: `Attires`

An enumeration to represent the number of available attires.

### Detailed Breakdown of `Load` Method

- Initializes `mappingPrimaryInfo` and `mappingSecondaryInfo` with default values.
- Uses `JsonConvert` to deserialize a generated character object.
- Iterates through character mappings and sets corresponding properties in `mappingSecondaryInfo`.
- Processes render paths and movie information, setting them in `mappingPrimaryInfo`.
- Updates the property grids with the loaded data.

This custom control is designed to integrate deeply with the WWE 2K24 game editor, providing a UI for mapping character data, including attires and render paths, and handling complex property configurations through WPF property grids.

## /Meta/Editor/Controls/CreationSuite/EditorMotion.cs

This C# code defines a WPF (Windows Presentation Foundation) control named `EditorMotion` within the `Meta.Editor.Controls.CreationSuite` namespace. The purpose of this control is to handle and manage the creation and editing of wrestling movesets in a game, likely WWE 2K23. Here's an explanation of the key components and functionality:

### Namespaces and Dependencies

- **Meta.Core.Interfaces**, **Meta.WWE2K23**, **MetaEditor**, **Newtonsoft.Json**, **PropertyTools.DataAnnotations**, **PropertyTools.Wpf**: These namespaces are imported to use various classes and interfaces necessary for the functionality, including JSON handling and property grid control.

### Class Definition

- **EditorMotion** inherits from **CreationEditor**:
  - **TemplatePart** attributes: These attributes define parts of the control template that will be used to find elements within the control's XAML template.
  - **PropertyGrid**: Instances of PropertyGrid are used to display and edit properties of objects within the control.
  - **MotionPrimary** and **MotionSecondary**: Nested classes used to hold primary and secondary motion data for editing.

### Properties and Fields

- **BasicInfoPropertyGrid** and **SecondaryMappingPropertyGrid**: Instances of PropertyGrid for primary and secondary properties.
- **motionPrimaryInfo** and **motionSecondaryInfo**: Instances of MotionPrimary and MotionSecondary to hold moveset data.
- **MetaPropertyGridFactory**: A factory for creating property grid controls.

### Methods

- **Constructor**: Initializes the control, sets up the data context, and instantiates primary and secondary motion data.
- **Static Constructor**: Overrides the default style key for the control.
- **OnApplyTemplate**: Called when the control's template is applied. It sets up the property grids and assigns the respective objects for editing.
- **Shutdown**: Cleans up data contexts and selected objects in property grids.
- **Load**: Loads a character profile's moveset into the primary and secondary motion data objects, mapping each move from the profile to the appropriate properties.

### Nested Classes (MotionPrimary and MotionSecondary)

- **MotionPrimary** and **MotionSecondary**: These classes define properties for different wrestling moves, categorized and annotated for display in a property grid. They use JSON data to initialize moves and combos from the game data.

### Key Functionalities

1. **Loading Movesets**: The `Load` method maps the moves from a character profile to the respective properties in the `MotionPrimary` and `MotionSecondary` classes. It uses reflection to get properties and set values based on the category.
2. **Property Grid Setup**: The `OnApplyTemplate` method sets up the property grids, assigning control factories and selected objects for editing.
3. **Data Binding and Cleanup**: Data contexts and selected objects are managed properly to ensure that the property grids display the correct information and are cleaned up when no longer needed.

### Example of Property Definitions

The nested `MotionPrimary` and `MotionSecondary` classes define properties for various moves. Each property is annotated with categories and display names, and sources its values from the respective collection of moves:

```csharp
[Category("Standing|Front Light Attack")]
[DisplayName("1")]
[ItemsSourceProperty("WrestlerMoves")]
[Important]
public JObject MovesetStandingLightAttack1 { get; set; }
```

These properties allow the property grid to categorize and display moves, enabling the user to edit the moveset easily.

In summary, this code is part of a larger WPF application for editing wrestling movesets, using property grids to provide a user-friendly interface for managing complex data structures.

## /Meta/Editor/Controls/CreationSuite/EditorMotion_WWE2K24.cs

This code is a part of a custom editor for the WWE 2K24 game, specifically designed to manage and customize wrestler movesets. Here’s a breakdown of the key components and functionality:

### Namespaces and Imports

- **Using Statements:** These include necessary libraries and namespaces like `Meta.Core.Interfaces`, `Meta.WWE2K24`, `MetaEditor`, `Newtonsoft.Json`, and others related to WPF (Windows Presentation Foundation) and property grid control for user interface elements.

### Namespace and Class Definition

- **Namespace:** `Meta.Editor.Controls.CreationSuite`
- **Class:** `EditorMotion_WWE2K24` inherits from `CreationEditor` and is decorated with `TemplatePart` attributes to define parts of the control template.

### Properties and Fields

- **Template Parts:**
  - `PART_PrimaryPropertyGrid` and `PART_SecondaryInfoPropertyGrid` represent the primary and secondary property grids in the UI.
- **Property Grids:**
  - `BasicInfoPropertyGrid` and `SecondaryMappingPropertyGrid` for displaying and editing primary and secondary motion information.
- **Motion Info Objects:**
  - `motionPrimaryInfo` and `motionSecondaryInfo` hold primary and secondary motion data.

### MetaPropertyGridFactory

- A factory class for creating property grid controls.

### Class Constructor

- Initializes the `EditorMotion_WWE2K24` object, sets the `DataContext`, and initializes `MetaPropertyGridFactory` and motion information objects.

### Static Constructor

- Sets the default style key for the control, overriding the metadata for `FrameworkElement.DefaultStyleKeyProperty`.

### OnApplyTemplate Method

- Called when the control template is applied. It initializes the property grids and sets their selected objects to the motion information objects.

### Shutdown Method

- Cleans up by setting the `DataContext` and `SelectedObject` properties of the property grids to null.

### Load Method

- Loads a `CharacterProfile_WWE2K24` profile and populates the motion information objects with moveset data from the profile.

### Nested Classes for Motion Information

- **MotionPrimary:** Inherits from `BaseEditor` and holds primary moveset information, categorized by move types and attributes.

  - **SetValue Method:** Sets the values of properties in the `MotionPrimary` class based on a category and a list of values.
  - **Properties:** Decorated with `Category`, `DisplayName`, `ItemsSourceProperty`, and `Important` attributes to specify UI behavior.

- **MotionSecondary:** Similar to `MotionPrimary` but holds secondary moveset information.
  - **Properties:** Similar decoration for UI behavior.

### Summary

The `EditorMotion_WWE2K24` class is a WPF control designed for editing wrestler movesets in WWE 2K24. It uses property grids to display and edit moveset information, loaded from a character profile. The class structure ensures that all moves are categorized and presented in a user-friendly manner, with support for dynamically setting values and updating the UI accordingly. The use of attributes and custom property grid controls facilitates a streamlined and organized editing experience.

## /Meta/Editor/Controls/CreationSuite/ImportantAttribute.cs

The code you provided defines a custom attribute class in C#. Here's an explanation of each part of the code:

1. **Namespace Declaration:**

   ```csharp
   namespace Meta.Editor.Controls.CreationSuite
   {
   ```

   This declares a namespace `Meta.Editor.Controls.CreationSuite`. Namespaces are used to organize code and prevent naming conflicts.

2. **AttributeUsage Attribute:**

   ```csharp
   [AttributeUsage(AttributeTargets.Property)]
   ```

   This line specifies that the `ImportantAttribute` can only be applied to properties. The `AttributeUsage` attribute controls how the custom attribute can be used. `AttributeTargets.Property` means this attribute can be applied to properties only.

3. **Class Definition:**

   ```csharp
   public class ImportantAttribute : Attribute
   {
   }
   ```

   This defines a public class named `ImportantAttribute` that inherits from the `System.Attribute` class. By inheriting from `Attribute`, it becomes a custom attribute that can be applied to other code elements, in this case, properties.

4. **Nullable Directive:**

   ```csharp
   #nullable disable
   ```

   This directive disables nullable reference type annotations and warnings. In C#, nullable reference types provide a way to explicitly express nullability in the type system, helping to avoid null reference exceptions. The `#nullable disable` directive turns off these features.

### Summary

- **Namespace:** Organizes the class within `Meta.Editor.Controls.CreationSuite`.
- **AttributeUsage:** Limits the application of `ImportantAttribute` to properties.
- **Class:** Defines `ImportantAttribute` as a custom attribute by inheriting from `System.Attribute`.
- **Nullable Directive:** Disables nullable reference type features for this file or section of code.

This custom attribute can now be used to annotate properties in your code, providing metadata that you can use for various purposes, such as marking important properties for serialization, validation, or other processing.

## /Meta/Editor/Controls/CreationSuite/Location.cs

The provided code defines a class `Location` in the C# programming language within the `Meta.Editor.Controls.CreationSuite` namespace. Here's a breakdown of its components and functionality:

### Code Explanation

```csharp
using System;

#nullable enable
namespace Meta.Editor.Controls.CreationSuite
{
  public class Location
  {
    public string country { get; set; }

    public string state { get; set; }

    public string city { get; set; }

    public int? city_group { get; set; }

    public int? country_group { get; set; }

    public Decimal callname { get; set; }

    public int index { get; set; }

    public override string ToString()
    {
      return string.Format("{0} {1} {2}", (object) this.country, (object) this.state, (object) this.city);
    }
  }
}
```

### Detailed Breakdown

1. **Namespace and Nullable Context**:

   ```csharp
   using System;
   #nullable enable
   namespace Meta.Editor.Controls.CreationSuite
   ```

   - `using System;` allows the use of the System namespace, which provides fundamental classes and base classes that define commonly used value and reference data types.
   - `#nullable enable` directive enables nullable reference types to help prevent null reference errors by specifying whether a variable can be null.

2. **Class Definition**:

   ```csharp
   public class Location
   ```

   - Defines a public class `Location` within the `Meta.Editor.Controls.CreationSuite` namespace. Public classes are accessible from other classes and assemblies.

3. **Properties**:

   ```csharp
   public string country { get; set; }
   public string state { get; set; }
   public string city { get; set; }
   public int? city_group { get; set; }
   public int? country_group { get; set; }
   public Decimal callname { get; set; }
   public int index { get; set; }
   ```

   - `country`, `state`, and `city` are string properties with getter and setter methods.
   - `city_group` and `country_group` are nullable integer properties, indicated by the `int?` type, meaning they can hold an integer value or null.
   - `callname` is a Decimal property.
   - `index` is an integer property.

4. **Override ToString Method**:

   ```csharp
   public override string ToString()
   {
     return string.Format("{0} {1} {2}", (object) this.country, (object) this.state, (object) this.city);
   }
   ```

   - Overrides the `ToString` method to provide a custom string representation of the `Location` object.
   - Uses `string.Format` to format the output string, which includes the `country`, `state`, and `city` properties.
   - The `(object)` cast ensures the values are treated as objects, but in this context, it is not strictly necessary as `string.Format` can handle string arguments directly.

### Usage

This class is designed to represent a geographical location with several properties to hold information such as country, state, city, and related group identifiers. The `ToString` method provides a formatted string representation of a `Location` object, which is useful for debugging or displaying the location in a user interface. The use of nullable types for `city_group` and `country_group` allows these properties to be optional.

## /Meta/Editor/Controls/CreationSuite/MetaDirectorySelectAttribute.cs

This C# code defines a custom attribute called `MetaDirectorySelectAttribute` within the `Meta.Editor.Controls.CreationSuite` namespace. Here's a detailed explanation of each component:

### 1. `using System;`

This line includes the `System` namespace, which contains fundamental classes and base classes that define commonly-used data types, events and event handlers, interfaces, attributes, and processing exceptions.

### 2. `#nullable disable`

The `#nullable disable` directive is used to disable nullable reference type annotations and warnings in the file. This means that the compiler will not issue warnings related to nullability, and reference types are treated as non-nullable by default.

### 3. `namespace Meta.Editor.Controls.CreationSuite`

This line declares a namespace called `Meta.Editor.Controls.CreationSuite`. Namespaces are used to organize code into a hierarchical structure, preventing naming conflicts and making the code easier to manage.

### 4. `[AttributeUsage(AttributeTargets.Property)]`

This is an attribute applied to the `MetaDirectorySelectAttribute` class. The `AttributeUsage` attribute specifies how the `MetaDirectorySelectAttribute` can be used. Here, `AttributeTargets.Property` indicates that this attribute can only be applied to properties.

### 5. `public class MetaDirectorySelectAttribute : Attribute`

This line defines a public class named `MetaDirectorySelectAttribute` that inherits from the `Attribute` class. By inheriting from `Attribute`, `MetaDirectorySelectAttribute` becomes a custom attribute that can be used to annotate properties in other classes.

### Summary

The `MetaDirectorySelectAttribute` is a custom attribute that can be applied to properties within classes to provide additional metadata or functionality. Since there are no additional members (fields, properties, methods) within the `MetaDirectorySelectAttribute` class, it serves as a marker attribute. Marker attributes are often used to tag properties with specific characteristics or to indicate that they should be processed in a particular way by some other part of the system, such as a framework or a custom tool.

### Example Usage

Here's an example of how you might use this attribute in another class:

```csharp
using Meta.Editor.Controls.CreationSuite;

public class ExampleClass
{
    [MetaDirectorySelect]
    public string DirectoryPath { get; set; }
}
```

In this example, the `MetaDirectorySelectAttribute` is applied to the `DirectoryPath` property of the `ExampleClass`. This could be used by a framework or tool to recognize that `DirectoryPath` should be treated in a specific way, such as opening a directory selection dialog in a user interface.

## /Meta/Editor/Controls/CreationSuite/Movie_WWE2K24.cs

This code defines a class named `Movie_WWE2K24` within the `Meta.Editor.Controls.CreationSuite` namespace. The class includes properties for various attributes of a movie and an enumeration (`enum`) for different types of movie display regions, specifically for WWE2K24.

### Breakdown of the Code

### Nullable Reference Types

- **#nullable enable**
  This directive enables nullable reference types, allowing the compiler to enforce nullability rules. It helps in avoiding null reference exceptions by making the developer explicitly handle cases where a reference type can be null.

### Namespace

- **namespace Meta.Editor.Controls.CreationSuite**
  This defines the namespace `Meta.Editor.Controls.CreationSuite`, which helps organize the code and avoid naming conflicts.

### Class Definition

- **public class Movie_WWE2K24**
  This defines a public class named `Movie_WWE2K24`.

### Properties

- **public uint id { get; set; }**
  This property holds an unsigned 32-bit integer (`uint`) representing the unique identifier of the movie.

- **public string type { get; set; }**
  This property holds a string representing the type of the movie. Since the `#nullable enable` directive is used, the string type will be non-nullable by default, meaning it cannot be null unless explicitly specified.

- **public uint sdb_id { get; set; }**
  This property holds an unsigned 32-bit integer (`uint`) representing the SDB (presumably some kind of database) identifier for the movie.

- **public ulong bk2_path { get; set; }**
  This property holds an unsigned 64-bit integer (`ulong`) representing the path to the BK2 (Bink Video) file associated with the movie. It is assumed to be a unique identifier for the file path.

- **public ulong thumbnail_dds_path { get; set; }**
  This property holds an unsigned 64-bit integer (`ulong`) representing the path to the thumbnail image file in DDS (DirectDraw Surface) format associated with the movie.

### Enum Definition

- **public enum Tron_Type**
  This defines an enumeration named `Tron_Type` within the `Movie_WWE2K24` class. An enum is a distinct value type that consists of a set of named constants called the enumerator list.

### Enum Values

- **Unknown**
  This value represents an unknown type of Tron display.

- **Titantron**
  This value represents a Titantron display, which is typically a large screen used in WWE events.

- **Banner**
  This value represents a banner display.

- **Stage**
  This value represents a stage display.

- **Apron**
  This value represents an apron display, referring to the edge of the wrestling ring.

- **Barricade**
  This value represents a barricade display, which is likely used around the ring or audience area.

- **Transition**
  This value represents a transition display, likely used for scene or event transitions.

### Summary

The `Movie_WWE2K24` class represents a movie entity for the WWE2K24 game with properties for its ID, type, SDB ID, BK2 file path, and thumbnail DDS file path. It also includes an enumeration, `Tron_Type`, which lists various types of display regions where the movie might be shown, such as Titantron, banner, stage, and others. The use of `#nullable enable` ensures that reference types are explicitly handled for nullability, enhancing the safety and robustness of the code.

## /Meta/Editor/Controls/CreationSuite/MovieConfig.cs

This C# code defines a class `MovieConfig` in the `Meta.Editor.Controls.CreationSuite` namespace. This class is likely part of an editor or creation suite, possibly for a game or media application, and it holds configuration settings for different components or features in a "movie" context.

Here's a detailed explanation:

1. **Nullable Context**:

   - `#nullable disable`: This directive disables nullable reference types for this file, meaning the compiler will not perform any nullability analysis. This can lead to potential `null` reference issues, but it might be used here to simplify the code or maintain compatibility with existing codebases that do not use nullable reference types.

2. **Namespace Declaration**:

   - `namespace Meta.Editor.Controls.CreationSuite`: Specifies that the `MovieConfig` class is part of the `Meta.Editor.Controls.CreationSuite` namespace. This indicates that the class is part of an editor or creation suite, which might be used for customizing or configuring elements in a game or media application.

3. **Class Definition**:

   - `public class MovieConfig`: Declares a public class named `MovieConfig`.

4. **Properties**:
   - `public byte Value { get; set; }`: A public property of type `byte` with a getter and setter. This property might represent a specific configuration value or identifier for the movie configuration.
   - `public bool Titantron { get; set; }`: A public boolean property indicating whether the Titantron feature is enabled. In the context of wrestling games, a Titantron is the large screen used to display videos and graphics.
   - `public bool Banner { get; set; }`: A public boolean property indicating whether the banner feature is enabled. This might refer to banners displayed during an event or scene.
   - `public bool Stage { get; set; }`: A public boolean property indicating whether the stage feature is enabled. This could refer to the configuration of the stage area in a scene or event.
   - `public bool Apron { get; set; }`: A public boolean property indicating whether the apron feature is enabled. In wrestling, the apron is the area around the ring, and this property might configure its appearance or behavior.
   - `public bool Post { get; set; }`: A public boolean property indicating whether the post feature is enabled. This could refer to the ring posts in a wrestling ring or other vertical structures in a stage setup.
   - `public bool Barricade { get; set; }`: A public boolean property indicating whether the barricade feature is enabled. This might refer to barriers used to separate the audience from the stage or ring area.

### Explanation Summary

- **Purpose**: The `MovieConfig` class is designed to hold configuration settings for various components or features in a movie or event setup, likely within an editor or creation suite for a game or media application.

- **Properties**:
  - `Value`: A byte property that likely holds a specific configuration value or identifier.
  - `Titantron`, `Banner`, `Stage`, `Apron`, `Post`, `Barricade`: Boolean properties indicating whether each respective feature is enabled. These features are common in wrestling or event setups, suggesting that this configuration class might be used in a wrestling game editor or a similar context.

### Contextual Details

- **Editor or Creation Suite**: The namespace `Meta.Editor.Controls.CreationSuite` suggests that this class is part of a toolset for customizing or configuring elements within a larger application, such as a game or media editor.
- **Wrestling Game Context**: Given the property names like `Titantron`, `Stage`, `Apron`, and `Post`, it is likely that this configuration class is used in the context of a wrestling game, where users can customize various aspects of the event setup.

This class provides a simple and structured way to manage configuration settings for different components in a movie or event context, allowing for easy customization and enabling or disabling of specific features.

## /Meta/Editor/Controls/CreationSuite/WWE2K23_Generated_Belt.cs

This code defines a class `WWE2K23_Generated_Belt` within the `Meta.Editor.Controls.CreationSuite` namespace. This class appears to manage data related to a belt (likely a championship belt or similar) in the WWE2K23 game or application context. Here’s a detailed breakdown of its components:

### Namespaces and Libraries

- **Meta.Structures.Flatbuffers.WWE2K23**: This namespace suggests the use of Flatbuffers, a serialization library for efficient data interchange, specifically for structures related to WWE2K23.
- **#nullable enable**: Enables nullable reference types to enhance null safety.

### Class Definition: `WWE2K23_Generated_Belt`

This class represents a generated belt within the WWE2K23 context, with properties to manage the belt’s data and its asset map.

#### Properties

1. **BeltDataTable**
   - **Type**: `BeltInfo`
   - **Description**: This property holds information about the belt. The type `BeltInfo` is likely a custom class or struct that contains various details or metadata about the belt, such as its design, specifications, and attributes.

```csharp
public BeltInfo BeltDataTable { get; set; }
```

2. **BeltData_AssetMap**
   - **Type**: `BeltsMapTable`
   - **Description**: This property holds the asset map data for the belt. The type `BeltsMapTable` is likely a custom class or struct that maps the belt data to specific assets, such as textures, models, and other resources required for rendering the belt in the game or application.

```csharp
public BeltsMapTable BeltData_AssetMap { get; set; }
```

### Usage Scenario

The `WWE2K23_Generated_Belt` class is part of a system managing generated belts within the WWE2K23 game or application. It provides properties to store and manage detailed information about a belt (`BeltDataTable`) and the corresponding asset mapping (`BeltData_AssetMap`). This setup is crucial for representing the belt both in terms of its metadata and its visual or physical assets.

### Key Points

- **Properties for Belt Data**: The class encapsulates the belt’s data and its asset map, making it a comprehensive representation of a generated belt.
- **Flatbuffers**: Indicates efficient serialization and deserialization, which is particularly useful for game data that needs to be quickly loaded and accessed.
- **`#nullable enable`**: Ensures that the code handles null values safely, providing more robust and error-free code.

This class serves as a foundational component in a larger system managing the dynamic aspects of generated belts in WWE2K23, providing a structure that can be easily integrated with other components for managing belts within the game or application.

## /Meta/Editor/Controls/CreationSuite/WWE2K23_Generated_Character.cs

This code defines a class named `WWE2K23_Generated_Character` within the `Meta.Editor.Controls.CreationSuite` namespace. The class uses the `Meta.Structures.Flatbuffers.WWE2K23` namespace and `System.Collections.ObjectModel`. The `#nullable enable` directive at the top indicates that nullable reference types are enabled, allowing the code to distinguish between nullable and non-nullable reference types.

Here's a breakdown of the code:

### Namespaces

- **using Meta.Structures.Flatbuffers.WWE2K23;**
  This imports the `WWE2K23` namespace from the `Meta.Structures.Flatbuffers` library, which likely contains definitions and structures related to the WWE2K23 game.
- **using System.Collections.ObjectModel;**
  This imports the `ObservableCollection` class from the `System.Collections.ObjectModel` namespace, which is a dynamic data collection providing notifications when items get added, removed, or when the entire list is refreshed.

### Class Definition

- **namespace Meta.Editor.Controls.CreationSuite**
  This defines the namespace `Meta.Editor.Controls.CreationSuite`, which helps organize the code and avoid naming conflicts.

- **public class WWE2K23_Generated_Character**
  This defines a public class named `WWE2K23_Generated_Character`.

### Properties

- **public ObservableCollection<Meta.Structures.Flatbuffers.WWE2K23.CharacterMapping> CharacterMapping { get; set; }**
  This property is an `ObservableCollection` of `CharacterMapping` objects from the `Meta.Structures.Flatbuffers.WWE2K23` namespace. `ObservableCollection` is useful for data binding in UI frameworks because it provides notifications when the collection changes.
- **public FaceTextures Renders { get; set; }**
  This property is of type `FaceTextures`, which presumably holds texture data related to a character's face. The exact definition of `FaceTextures` is not provided, but it is likely a class or structure defined elsewhere in the codebase.

- **public MoviesTable Movie { get; set; }**
  This property is of type `MoviesTable`, which likely holds movie or animation data for the character. Similar to `FaceTextures`, the definition of `MoviesTable` is not provided here but is assumed to be defined elsewhere.

### Nullable Reference Types

- **#nullable enable**
  This directive enables nullable reference types, allowing the compiler to enforce nullability rules. It helps in avoiding null reference exceptions by making the developer explicitly handle cases where a reference type can be null.

### Summary

The `WWE2K23_Generated_Character` class represents a character generated for the WWE2K23 game. It contains properties for character mappings (`CharacterMapping`), face textures (`Renders`), and movies or animations (`Movie`). The class uses `ObservableCollection` for `CharacterMapping` to provide change notifications, which is useful for UI data binding scenarios. The `#nullable enable` directive helps in managing nullability in the code.

## /Meta/Editor/Controls/CreationSuite/WWE2K24_Generated_Belt.cs

This code defines a class `WWE2K24_Generated_Character` within the `Meta.Editor.Controls.CreationSuite` namespace. This class is part of a structure for handling generated characters, likely within a game or application related to WWE2K24. Here's a detailed breakdown of its components:

### Namespaces and Libraries

- **Meta.Structures.Flatbuffers.WWE2K24**: This namespace suggests the use of Flatbuffers, a serialization library for efficient data interchange, specifically for structures related to WWE2K24.
- **System.Collections.ObjectModel**: This namespace provides classes that can be used to create collections that have built-in notification capabilities when items get added or removed, such as `ObservableCollection<T>`.

### Nullable Context

- **#nullable enable**: Enables nullable reference types to enhance null safety.

### Class Definition: `WWE2K24_Generated_Character`

This class is designed to represent a generated character within the WWE2K24 context, with properties to manage character mappings, face textures, and associated movies.

#### Properties

1. **CharacterMapping**
   - **Type**: `ObservableCollection<Meta.Structures.Flatbuffers.WWE2K24.CharacterMapping>`
   - **Description**: This property holds a collection of `CharacterMapping` objects. An `ObservableCollection` is used here, which is a dynamic data collection that provides notifications when items get added, removed, or when the whole list is refreshed. This is particularly useful for data binding in WPF or similar UI frameworks.

```csharp
public ObservableCollection<Meta.Structures.Flatbuffers.WWE2K24.CharacterMapping> CharacterMapping { get; set; }
```

2. **Renders**
   - **Type**: `FaceTextures`
   - **Description**: This property holds the face textures associated with the generated character. The type `FaceTextures` is likely a custom class or struct that contains information or methods related to facial texture data.

```csharp
public FaceTextures Renders { get; set; }
```

3. **Movies**
   - **Type**: `ObservableCollection<Movie_WWE2K24>`
   - **Description**: This property holds a collection of `Movie_WWE2K24` objects. Similar to `CharacterMapping`, an `ObservableCollection` is used to manage a list of movies that can dynamically notify changes.

```csharp
public ObservableCollection<Movie_WWE2K24> Movies { get; set; }
```

### Usage Scenario

This class is part of a system managing generated characters within the WWE2K24 game or application. It provides properties to store and manage character mappings, face textures, and movies associated with the character. The use of `ObservableCollection` for `CharacterMapping` and `Movies` suggests that these collections are intended to be bound to a UI, allowing for real-time updates and dynamic interaction.

### Key Points

- **`ObservableCollection<T>`**: A collection class that supports data binding and provides notifications when items change, which is useful for UI elements that need to update in real-time.
- **Properties for Character Data**: The class encapsulates the character's data, including mappings, textures, and associated movies, making it a comprehensive representation of a generated character.
- **Flatbuffers**: Indicates efficient serialization and deserialization, which is particularly useful for game data that needs to be quickly loaded and accessed.

This class serves as a foundational component in a larger system managing the dynamic aspects of generated characters in WWE2K24, providing a structure that can be easily integrated with UI elements for interactive applications.

## /Meta/Editor/Controls/CreationSuite/WWE2K24_Generated_Character.cs

This C# code defines a class `WWE2K24_Generated_Belt` in the `Meta.Editor.Controls.CreationSuite` namespace. This class appears to be part of an editor or creation suite for the WWE 2K video game series, specifically versions 23 and 24. It uses structures from Flatbuffers, a serialization library for performance-critical applications.

Here's a detailed explanation:

1. **Namespace and Usings**:

   - `Meta.Structures.Flatbuffers.WWE2K23`: This namespace likely contains structures and classes related to WWE 2K23, defined using Flatbuffers.
   - `Meta.Structures.Flatbuffers.WWE2K24`: This namespace likely contains similar structures for WWE 2K24.
   - `#nullable enable`: Enables nullable reference types to help catch potential `null` reference issues at compile time.

2. **Namespace Declaration**:

   - `namespace Meta.Editor.Controls.CreationSuite`: This specifies that the `WWE2K24_Generated_Belt` class is part of the `Meta.Editor.Controls.CreationSuite` namespace, likely indicating its role in the editor/creation suite functionalities for WWE 2K games.

3. **Class Definition**:

   - `public class WWE2K24_Generated_Belt`: Declares a public class named `WWE2K24_Generated_Belt`.

4. **Properties**:
   - `public BeltInfo BeltDataTable { get; set; }`: A public property of type `BeltInfo` with a getter and setter. This property likely holds detailed information about a belt in WWE 2K24.
   - `public BeltsMapTable BeltData_AssetMap { get; set; }`: Another public property, this time of type `BeltsMapTable`, with a getter and setter. This property probably maps belt data to assets (like textures or models) in the game.

### Explanation Summary

- **Purpose**: The `WWE2K24_Generated_Belt` class represents a belt in the WWE 2K24 game within a creation suite or editor. It holds data about the belt and its associated assets.

- **Properties**:
  - `BeltDataTable`: Contains detailed information about the belt, like its attributes, appearance, or metadata.
  - `BeltData_AssetMap`: Maps the belt's data to the actual assets used in the game, such as textures, models, or other resources.

### Contextual Details

- **Flatbuffers**: This is a serialization library designed for high-performance applications. Using Flatbuffers suggests that the `BeltInfo` and `BeltsMapTable` structures are optimized for quick access and minimal overhead, suitable for real-time applications like games.

- **WWE 2K Games**: These are professional wrestling video games, where users can create and customize various elements, including wrestlers, arenas, and belts. The `Meta.Editor.Controls.CreationSuite` namespace likely provides tools for creating and customizing these elements.

- **Nullable Reference Types**: By enabling nullable reference types, the code aims to catch potential null reference issues at compile time, improving code safety and robustness.

This class is part of a larger system that facilitates the creation and customization of belts within the WWE 2K24 game, providing a structured and efficient way to handle belt data and its corresponding assets.

## /Meta/Editor/MenuExtension.cs

The provided C# code defines an abstract class `MenuExtension` within the `Meta.Editor` namespace. Here's an explanation of each component:

### Using Directive

```csharp
using Meta.Editor.Commands;
```

- This imports the `Meta.Editor.Commands` namespace, making the `RelayCommand` class available for use in this file.

### Nullable Context

```csharp
#nullable enable
```

- The `#nullable enable` directive enables nullable reference type warnings and features, helping to identify potential null reference issues at compile time.

### Namespace Declaration

```csharp
namespace Meta.Editor
{
    // ... class definition ...
}
```

- The `namespace Meta.Editor` declaration organizes the code within the `Meta.Editor` namespace, helping to logically group related types and avoid naming conflicts.

### `MenuExtension` Class Definition

```csharp
public abstract class MenuExtension
{
    public virtual string TopLevelMenuName { get; }

    public virtual string SubLevelMenuName { get; }

    public virtual string MenuItemName { get; }

    public virtual string Icon { get; }

    public virtual RelayCommand MenuItemClicked { get; }
}
```

- **`public abstract class MenuExtension`**: Declares an abstract class named `MenuExtension`. An abstract class cannot be instantiated directly and is intended to be subclassed by other classes.
- **Properties**: The class defines five `virtual` properties. In C#, a `virtual` property can be overridden in a derived class, allowing for customization of its behavior.

#### Properties Explained

1. **`TopLevelMenuName`**:

   ```csharp
   public virtual string TopLevelMenuName { get; }
   ```

   - Represents the name of the top-level menu to which this extension belongs. Since it's `virtual`, derived classes can override it.

2. **`SubLevelMenuName`**:

   ```csharp
   public virtual string SubLevelMenuName { get; }
   ```

   - Represents the name of the sub-level menu under the top-level menu. Derived classes can override this property.

3. **`MenuItemName`**:

   ```csharp
   public virtual string MenuItemName { get; }
   ```

   - Represents the name of the specific menu item. This property can also be overridden in derived classes.

4. **`Icon`**:

   ```csharp
   public virtual string Icon { get; }
   ```

   - Represents the icon associated with the menu item. Derived classes can override this property.

5. **`MenuItemClicked`**:

   ```csharp
   public virtual RelayCommand MenuItemClicked { get; }
   ```

   - Represents the command to be executed when the menu item is clicked. The `RelayCommand` type indicates that this command follows the `ICommand` pattern for handling user actions in WPF applications. Derived classes can override this property to define custom behavior for the menu item click event.

### Summary

- **`Meta.Editor.Commands` namespace**: The `RelayCommand` class is imported for use in the `MenuExtension` class.
- **`#nullable enable`**: Enables nullable reference type features for better null safety.
- **`MenuExtension` abstract class**: Defines a template for creating menu extensions with customizable properties for top-level menu names, sub-level menu names, menu item names, icons, and click commands.
- **`virtual` properties**: Allow derived classes to override and provide specific implementations for these properties.

This class serves as a base class for defining extensions to a menu system, where specific details of the menu items (names, icons, and commands) can be provided by subclasses. This allows for flexible and extensible menu configurations in an application.

## /Meta/Editor/MetaTaskManager.cs

Certainly! Let's break down the provided C# code step by step:

### Namespaces and Nullable Context

```csharp
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

#nullable enable
```

- `using System;`: Imports the `System` namespace, which contains fundamental classes and base classes that define commonly-used data types, events, and event handlers.
- `using System.Collections.Concurrent;`: Imports the `System.Collections.Concurrent` namespace, which provides thread-safe collection classes.
- `using System.Threading;`: Imports the `System.Threading` namespace, which provides classes and interfaces to handle multi-threading.
- `using System.Threading.Tasks;`: Imports the `System.Threading.Tasks` namespace, which provides types for parallel programming, including the `Task` class.
- `#nullable enable`: Enables nullable reference types. This allows the compiler to provide warnings about potential null reference errors.

### Namespace Declaration

```csharp
namespace Meta.Editor
{
```

- `namespace Meta.Editor`: Defines a namespace called `Meta.Editor`. Namespaces are used to organize code and prevent naming conflicts.

### Class Definition

```csharp
public class MetaTaskManager : IDisposable
{
```

- `public class MetaTaskManager`: Declares a public class named `MetaTaskManager`.
- `: IDisposable`: Indicates that `MetaTaskManager` implements the `IDisposable` interface. This interface provides a mechanism for releasing unmanaged resources.

### Private Field

```csharp
private readonly BlockingCollection<Task> _taskQ = new BlockingCollection<Task>();
```

- `private readonly BlockingCollection<Task> _taskQ`: Declares a private readonly field named `_taskQ` of type `BlockingCollection<Task>`. This collection is a thread-safe, bounded, and blocking queue that can store tasks.

### Constructor

```csharp
public MetaTaskManager(int workerCount)
{
  for (int index = 0; index < workerCount; ++index)
    Task.Factory.StartNew(new Action(this.Consume), TaskCreationOptions.LongRunning);
}
```

- `public MetaTaskManager(int workerCount)`: Constructor that takes an integer parameter `workerCount`, representing the number of worker threads to start.
- `for (int index = 0; index < workerCount; ++index)`: A loop that runs `workerCount` times.
- `Task.Factory.StartNew(new Action(this.Consume), TaskCreationOptions.LongRunning)`: Starts a new long-running task for each worker thread. The task runs the `Consume` method.

### Enqueue Method (Action)

```csharp
public Task Enqueue(Action action, CancellationToken cancelToken = default (CancellationToken))
{
  Task task = new Task(action, cancelToken);
  this._taskQ.Add(task);
  return task;
}
```

- `public Task Enqueue(Action action, CancellationToken cancelToken = default (CancellationToken))`: Method that takes an `Action` and an optional `CancellationToken` as parameters. It creates a new task, adds it to the queue, and returns the task.
- `Task task = new Task(action, cancelToken)`: Creates a new task with the specified action and cancellation token.
- `this._taskQ.Add(task)`: Adds the task to the blocking collection `_taskQ`.
- `return task`: Returns the created task.

### Enqueue Method (Func<TResult>)

```csharp
public Task<TResult> Enqueue<TResult>(Func<TResult> func, CancellationToken cancelToken = default (CancellationToken))
{
  Task<TResult> task = new Task<TResult>(func, cancelToken);
  this._taskQ.Add((Task) task);
  return task;
}
```

- `public Task<TResult> Enqueue<TResult>(Func<TResult> func, CancellationToken cancelToken = default (CancellationToken))`: Method that takes a `Func<TResult>` and an optional `CancellationToken` as parameters. It creates a new task that returns a result, adds it to the queue, and returns the task.
- `Task<TResult> task = new Task<TResult>(func, cancelToken)`: Creates a new task with the specified function and cancellation token.
- `this._taskQ.Add((Task) task)`: Adds the task to the blocking collection `_taskQ`.
- `return task`: Returns the created task.

### Consume Method

```csharp
private void Consume()
{
  foreach (Task consuming in this._taskQ.GetConsumingEnumerable())
  {
    try
    {
      if (!consuming.IsCanceled)
        consuming.RunSynchronously();
    }
    catch (InvalidOperationException ex)
    {
    }
  }
}
```

- `private void Consume()`: Private method that continuously consumes tasks from the blocking collection.
- `foreach (Task consuming in this._taskQ.GetConsumingEnumerable())`: Iterates over the tasks in the blocking collection using a consuming enumerable.
- `if (!consuming.IsCanceled)`: Checks if the task is not canceled.
- `consuming.RunSynchronously()`: Runs the task synchronously.
- `catch (InvalidOperationException ex)`: Catches any `InvalidOperationException` that might be thrown if the task cannot be run synchronously.

### Dispose Method

```csharp
public void Dispose() => this._taskQ.CompleteAdding();
```

- `public void Dispose()`: Implementation of the `Dispose` method from the `IDisposable` interface.
- `this._taskQ.CompleteAdding()`: Marks the blocking collection as not accepting any more additions.

### Summary

The `MetaTaskManager` class manages a collection of tasks using a blocking collection. It starts a specified number of worker threads, each consuming tasks from the collection. Tasks can be enqueued with actions or functions that return results. The `Consume` method runs each task synchronously, and the `Dispose` method stops the collection from accepting new tasks. This setup allows for efficient, multi-threaded task execution and management.

## /Meta/Editor/PluginLoadStatus.cs

The provided C# code defines an enumeration (`enum`) named `PluginLoadStatus` within the `Meta.Editor` namespace. Here's an explanation of each component:

### Nullable Context

```csharp
#nullable disable
```

- The `#nullable disable` directive disables nullable reference type warnings and features for the code that follows. This means the compiler will not enforce nullability annotations.

### Namespace Declaration

```csharp
namespace Meta.Editor
{
    // ... enum definition ...
}
```

- The `namespace Meta.Editor` declaration organizes the code within the `Meta.Editor` namespace, helping to logically group related types and avoid naming conflicts.

### Enumeration Definition

```csharp
public enum PluginLoadStatus
{
    Failed,
    Loaded,
    LoadedInvalid,
}
```

- `public enum PluginLoadStatus`: This line declares a public enumeration named `PluginLoadStatus`. Enumerations are a distinct value type that consists of a set of named constants called the enumerator list.
- The enumerator list includes three named constants:
  - **Failed**: Indicates that the plugin failed to load.
  - **Loaded**: Indicates that the plugin loaded successfully.
  - **LoadedInvalid**: Indicates that the plugin loaded but is in an invalid state (e.g., it might be corrupted or not functional as expected).

### Usage

The `PluginLoadStatus` enumeration can be used to represent the status of plugin loading operations in the application. For example:

```csharp
public PluginLoadStatus CheckPluginStatus()
{
    // Example logic to check plugin status
    bool isPluginLoaded = LoadPlugin();
    if (!isPluginLoaded)
    {
        return PluginLoadStatus.Failed;
    }

    bool isPluginValid = ValidatePlugin();
    if (!isPluginValid)
    {
        return PluginLoadStatus.LoadedInvalid;
    }

    return PluginLoadStatus.Loaded;
}
```

### Summary

- **`#nullable disable`**: Disables nullable reference type features.
- **`Meta.Editor` namespace**: Groups related code within the `Meta.Editor` namespace.
- **`PluginLoadStatus` enumeration**: Defines three named constants (`Failed`, `Loaded`, `LoadedInvalid`) to represent the different states of plugin loading.

This enumeration is useful for managing and communicating the status of plugin operations within the application, providing a clear and type-safe way to handle different loading outcomes.

## /Meta/Editor/Commands/ItemDoubleClickCommand.cs

Certainly! Let's break down the provided C# code step by step:

### Namespaces and Nullable Context

```csharp
using System;
using System.Windows.Input;

#nullable enable
```

- `using System;`: Imports the System namespace, which contains fundamental classes and base classes that define commonly-used data types, events, and event handlers.
- `using System.Windows.Input;`: Imports the System.Windows.Input namespace, which defines input-related types like `ICommand`.
- `#nullable enable`: Enables nullable reference types. This allows the compiler to provide warnings about potential null reference errors.

### Namespace Declaration

```csharp
namespace Meta.Editor.Commands
{
```

- `namespace Meta.Editor.Commands`: Defines a namespace called `Meta.Editor.Commands`. Namespaces are used to organize code and prevent naming conflicts.

### Class Definition

```csharp
public class ItemDoubleClickCommand : ICommand
{
```

- `public class ItemDoubleClickCommand`: Declares a public class named `ItemDoubleClickCommand`.
- `: ICommand`: Indicates that `ItemDoubleClickCommand` implements the `ICommand` interface. The `ICommand` interface is used to create command objects in the MVVM (Model-View-ViewModel) pattern, commonly used in WPF applications.

### Private Field

```csharp
private readonly ItemDoubleClickCommand.DoubleClickCommandDelegate commandToRun;
```

- `private readonly ItemDoubleClickCommand.DoubleClickCommandDelegate commandToRun`: Declares a private readonly field of type `DoubleClickCommandDelegate` named `commandToRun`. This field stores the delegate (method) that will be executed when the command is invoked.

### Event

```csharp
public event EventHandler CanExecuteChanged;
```

- `public event EventHandler CanExecuteChanged`: Declares an event named `CanExecuteChanged`. This event is part of the `ICommand` interface and should be raised whenever the result of `CanExecute` changes. It allows the UI to react to changes in command availability.

### Constructor

```csharp
public ItemDoubleClickCommand(ItemDoubleClickCommand.DoubleClickCommandDelegate inCommand)
{
  this.commandToRun = inCommand;
}
```

- `public ItemDoubleClickCommand(DoubleClickCommandDelegate inCommand)`: Constructor that takes a `DoubleClickCommandDelegate` as a parameter and assigns it to the `commandToRun` field. This allows the command to be configured with the specific action to perform when executed.

### CanExecute Method

```csharp
public bool CanExecute(object parameter) => true;
```

- `public bool CanExecute(object parameter) => true`: Implementation of the `CanExecute` method from the `ICommand` interface. This method returns a boolean indicating whether the command can be executed. Here, it always returns `true`, meaning the command can always be executed.

### Execute Method

```csharp
public void Execute(object parameter)
{
  ItemDoubleClickCommand.DoubleClickCommandDelegate commandToRun = this.commandToRun;
  if (commandToRun == null)
    return;
  commandToRun();
}
```

- `public void Execute(object parameter)`: Implementation of the `Execute` method from the `ICommand` interface. This method is called when the command is invoked.
- `ItemDoubleClickCommand.DoubleClickCommandDelegate commandToRun = this.commandToRun;`: Retrieves the delegate stored in `commandToRun`.
- `if (commandToRun == null) return;`: Checks if the delegate is null, and if so, returns immediately to avoid executing a null delegate.
- `commandToRun();`: Executes the delegate.

### Delegate Definition

```csharp
public delegate void DoubleClickCommandDelegate();
```

- `public delegate void DoubleClickCommandDelegate();`: Defines a delegate type named `DoubleClickCommandDelegate` that represents a method with no parameters and no return value. This delegate type is used to specify the method to be executed when the command is invoked.

### Summary

The `ItemDoubleClickCommand` class implements the `ICommand` interface, allowing it to be used as a command in WPF applications. It stores a delegate of type `DoubleClickCommandDelegate`, which represents the method to be executed when the command is invoked. The `CanExecute` method always returns `true`, indicating that the command can always be executed. The `Execute` method invokes the stored delegate if it is not null.

## /Meta/Editor/Commands/RelayCommand.cs

The provided C# code defines a `RelayCommand` class within the `Meta.Editor.Commands` namespace. This class implements the `ICommand` interface from the `System.Windows.Input` namespace, commonly used in MVVM (Model-View-ViewModel) design patterns in WPF (Windows Presentation Foundation) applications. Here's a breakdown of what each part of the code does:

### Namespaces and Nullable Context

```csharp
using System;
using System.Diagnostics;
using System.Windows.Input;

#nullable enable
namespace Meta.Editor.Commands
{
    // ... class definition ...
}
```

- `using` directives import necessary namespaces.
- `#nullable enable` directive enables nullable reference types to help identify potential null reference issues at compile time.

### `RelayCommand` Class

The `RelayCommand` class implements the `ICommand` interface, which requires the implementation of three members: `CanExecute`, `Execute`, and `CanExecuteChanged`.

### Fields

```csharp
private readonly Action<object> _execute;
private readonly Predicate<object> _canExecute;
```

- `_execute`: A delegate of type `Action<object>` that represents the method to be executed.
- `_canExecute`: A delegate of type `Predicate<object>` that determines whether the command can execute.

### Constructors

```csharp
public RelayCommand(Action<object> execute)
    : this(execute, (Predicate<object>) null)
{
}

public RelayCommand(Action<object> execute, Predicate<object> canExecute)
{
    this._execute = execute ?? throw new ArgumentNullException(nameof(execute));
    this._canExecute = canExecute;
}
```

- The first constructor initializes the `_execute` delegate and sets `_canExecute` to `null`.
- The second constructor initializes both `_execute` and `_canExecute` delegates. If `execute` is `null`, it throws an `ArgumentNullException`.

### `CanExecute` Method

```csharp
[DebuggerStepThrough]
public bool CanExecute(object parameters)
{
    return this._canExecute == null || this._canExecute(parameters);
}
```

- Determines whether the command can execute by invoking `_canExecute`. If `_canExecute` is `null`, it returns `true`, indicating the command can always execute.
- The `DebuggerStepThrough` attribute tells the debugger to step through this method without stopping.

### `CanExecuteChanged` Event

```csharp
public event EventHandler CanExecuteChanged
{
    add => CommandManager.RequerySuggested += value;
    remove => CommandManager.RequerySuggested -= value;
}
```

- This event is raised when changes occur that affect whether the command should execute. It uses the `CommandManager.RequerySuggested` event, which is raised by WPF to request a re-evaluation of the `CanExecute` method.

### `Execute` Method

```csharp
public void Execute(object parameters) => this._execute(parameters);
```

- Invokes the `_execute` delegate with the provided `parameters`.

### Summary

- **`RelayCommand`**: A class implementing `ICommand` for handling commands in WPF.
- **`_execute`**: Stores the method to be executed.
- **`_canExecute`**: Stores the method that determines if the command can execute.
- **Constructors**: Initialize `_execute` and optionally `_canExecute`.
- **`CanExecute`**: Checks if the command can execute.
- **`CanExecuteChanged`**: Notifies the UI to re-evaluate command execution.
- **`Execute`**: Executes the command logic.

This class is useful in MVVM applications to bind UI actions (like button clicks) to methods in the ViewModel, ensuring a clean separation between UI and business logic.

## /Meta/Editor/Converters/DelegatebasedValueConverter.cs

This C# code defines a custom value converter named `DelegateBasedValueConverter` within the `Meta.Editor.Converters` namespace. The converter implements the `IValueConverter` interface, allowing it to be used in data binding scenarios in WPF (Windows Presentation Foundation) applications. Let's break down the key parts of the code:

### 1. Namespaces and Using Directives

```csharp
using System;
using System.Globalization;
using System.Windows.Data;

#nullable enable
namespace Meta.Editor.Converters
{
```

These directives import necessary namespaces:

- `System` for basic .NET functionality.
- `System.Globalization` for handling culture-specific operations.
- `System.Windows.Data` for data binding in WPF.

The `#nullable enable` directive enables nullable reference types, helping to avoid null reference exceptions.

### 2. DelegateBasedValueConverter Class

```csharp
public class DelegateBasedValueConverter : IValueConverter
{
```

This class implements the `IValueConverter` interface, which requires two methods: `Convert` and `ConvertBack`.

### 3. Convert Method

```csharp
public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
{
    if (parameter == null || !(parameter is Func<object, object>))
        throw new ArgumentException("\"parameter\" is null or not of the type \"Func<object, object>\".");
    return ((Func<object, object>) parameter)(value);
}
```

The `Convert` method converts a value from the source type to the target type:

1. It checks if the `parameter` is `null` or not of type `Func<object, object>`. If either condition is true, it throws an `ArgumentException`.
2. If the `parameter` is valid, it casts the `parameter` to `Func<object, object>` and invokes it with the `value` as an argument, returning the result.

### 4. ConvertBack Method

```csharp
public object ConvertBack(
    object value,
    Type targetType,
    object parameter,
    CultureInfo culture)
{
    throw new NotImplementedException();
}
```

The `ConvertBack` method is intended to convert a value from the target type back to the source type. In this implementation, it simply throws a `NotImplementedException`, indicating that the reverse conversion is not supported.

### Summary

The `DelegateBasedValueConverter` class is a custom value converter that uses a delegate (a function) provided as a parameter to perform the conversion. It implements the `Convert` method to apply the delegate function to the input value, allowing dynamic and flexible conversions in WPF data bindings. The `ConvertBack` method is not implemented, signaling that reverse conversions are not supported by this converter.

## /Meta/Editor/Converters/HeightConverter.cs

This code defines a static class `HeightConverter` within the `Meta.Editor.Converters` namespace. The class provides methods to convert between height values in meters and a custom integer value range based on a scaling factor. Let's break down each part of the code:

### Using Directive

```csharp
using System;
```

- The `using System;` directive imports the `System` namespace, which includes fundamental classes like `Math`.

### Namespace

```csharp
namespace Meta.Editor.Converters
```

- The `namespace` keyword declares a scope that contains a set of related objects. In this case, the namespace is `Meta.Editor.Converters`.

### Static Class Declaration

```csharp
public static class HeightConverter
```

- The `public static class HeightConverter` line declares a static class named `HeightConverter`. This class cannot be instantiated and only contains static members.

### Private Static Fields

```csharp
private static readonly double baseHeight = 1.5;
private static readonly double scalingFactor = 2100.0;
private static readonly int baseValue = 3135;
```

- These fields define constants used in the conversion calculations.
  - `baseHeight`: A base height value in meters.
  - `scalingFactor`: A factor used to scale the height value.
  - `baseValue`: A base integer value used in the calculations.

### CalculateValueRange Method

```csharp
public static (int minValue, int maxValue) CalculateValueRange(double heightInMeters)
```

- This method takes a height in meters as a parameter and returns a tuple containing the minimum and maximum integer values corresponding to that height.

#### Method Logic

```csharp
double num = (heightInMeters - HeightConverter.baseHeight) * HeightConverter.scalingFactor + (double) HeightConverter.baseValue;
return ((int) Math.Floor(num), (int) Math.Ceiling(num));
```

- The method calculates an intermediate value `num` by:
  - Subtracting `baseHeight` from `heightInMeters`.
  - Multiplying the result by `scalingFactor`.
  - Adding `baseValue`.
- It then returns a tuple with the floor and ceiling of `num` converted to integers.

### ConvertValueToHeight Method

```csharp
public static double ConvertValueToHeight(int value)
```

- This method takes an integer value as a parameter and returns the corresponding height in meters.

#### Method Logic

```csharp
return Math.Floor(((double) (value - HeightConverter.baseValue) / HeightConverter.scalingFactor + HeightConverter.baseHeight) * 100.0) / 100.0;
```

- The method calculates the height in meters by:
  - Subtracting `baseValue` from the input `value`.
  - Dividing the result by `scalingFactor`.
  - Adding `baseHeight`.
  - Multiplying the result by 100 and flooring it to round down to two decimal places.
  - Dividing by 100 to convert back to the original scale with two decimal precision.

### Full Code Summary

- The `HeightConverter` class provides methods to convert heights in meters to a custom value range and vice versa.
- It uses predefined constants (`baseHeight`, `scalingFactor`, `baseValue`) to perform the conversions.
- `CalculateValueRange` returns the floor and ceiling integer values for a given height in meters.
- `ConvertValueToHeight` converts an integer value back to a height in meters, rounded down to two decimal places.

### Example Usage

Here is an example of how you might use these methods:

```csharp
double height = 1.75;
var valueRange = Meta.Editor.Converters.HeightConverter.CalculateValueRange(height);
Console.WriteLine($"Value range for height {height} meters: Min={valueRange.minValue}, Max={valueRange.maxValue}");

int value = 4000;
double convertedHeight = Meta.Editor.Converters.HeightConverter.ConvertValueToHeight(value);
Console.WriteLine($"Height for value {value}: {convertedHeight} meters");
```

In this example:

- The `CalculateValueRange` method is used to find the integer range for a height of 1.75 meters.
- The `ConvertValueToHeight` method is used to convert the integer value 4000 back to a height in meters.

## /Meta/Editor/Converters/InfoConverter.cs

This C# code defines a custom JSON converter named `InfoConverter` within the `Meta.Editor.Converters` namespace. The converter is used to serialize and deserialize objects of type `Info` using the `Newtonsoft.Json` library. Let's break down the key parts of the code:

### 1. Namespaces and Using Directives

```csharp
using Meta.WWE2K23;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;

#nullable enable
namespace Meta.Editor.Converters
{
```

These directives import necessary namespaces:

- `Meta.WWE2K23` for accessing the `Info` class.
- `Newtonsoft.Json` and `Newtonsoft.Json.Linq` for JSON serialization/deserialization.
- `System` and `System.Reflection` for basic .NET functionality and reflection.

The `#nullable enable` directive enables nullable reference types, helping to avoid null reference exceptions.

### 2. InfoConverter Class

```csharp
public class InfoConverter : JsonConverter
{
    public override bool CanConvert(Type objectType) => objectType == typeof(Info);
```

This method checks if the `InfoConverter` can convert objects of the specified type, which is `Info` in this case.

### 3. ReadJson Method

```csharp
public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
{
    JObject jobject = JObject.Load(reader);
    Info target = new Info();
    serializer.Populate(jobject.CreateReader(), (object) target);
    if (jobject["billed_from"] != null)
        target.location_callname = jobject["billed_from"].Value<uint>();
    if (jobject["payback_1"] != null)
        target.payback_01 = jobject["payback_1"].Value<byte>();
    if (jobject["payback_2"] != null)
        target.payback_02 = jobject["payback_2"].Value<byte>();
    return (object) target;
}
```

The `ReadJson` method deserializes a JSON object into an `Info` instance:

1. Loads the JSON object into a `JObject`.
2. Creates a new `Info` object.
3. Populates the `Info` object with values from the JSON object.
4. Maps specific JSON properties (`billed_from`, `payback_1`, `payback_2`) to corresponding properties in the `Info` object.

### 4. WriteJson Method

```csharp
public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
{
    Info info = (Info) value;
    JObject jobject = new JObject();
    serializer.Converters.Remove((JsonConverter) this);
    jobject.Add("location_callname", JToken.FromObject((object) info.location_callname, serializer));
    jobject.Add("payback_01", JToken.FromObject((object) info.payback_01, serializer));
    jobject.Add("payback_02", JToken.FromObject((object) info.payback_02, serializer));
    foreach (PropertyInfo property in typeof (Info).GetProperties())
    {
        if (property.Name != "billed_from")
            jobject.Add(property.Name, JToken.FromObject(property.GetValue((object) info), serializer));
        else if (property.Name != "payback_1")
            jobject.Add(property.Name, JToken.FromObject(property.GetValue((object) info), serializer));
        else if (property.Name != "payback_2")
            jobject.Add(property.Name, JToken.FromObject(property.GetValue((object) info), serializer));
    }
    jobject.WriteTo(writer);
}
```

The `WriteJson` method serializes an `Info` object into JSON:

1. Casts the `value` parameter to an `Info` object.
2. Creates a new `JObject`.
3. Temporarily removes the current converter from the serializer's converters list to avoid recursive calls.
4. Adds specific properties (`location_callname`, `payback_01`, `payback_02`) to the JSON object.
5. Uses reflection to add all other properties of the `Info` object to the JSON object, excluding `billed_from`, `payback_1`, and `payback_2`.
6. Writes the JSON object to the writer.

### Summary

The `InfoConverter` class is a custom JSON converter for the `Info` type, handling the conversion between JSON and `Info` objects. It customizes the serialization and deserialization processes to ensure specific properties are correctly mapped between JSON and the `Info` class.

## /Meta/Editor/Extensions/Cache`1.cs

This code defines a generic `Cache<T>` class in C# that handles caching of objects of type `T`. Here's a breakdown of the functionality and components:

### Namespaces and Dependencies

- **Namespaces**:
  - `Meta.Core`, `Meta.Core.Interfaces`, `Microsoft.CSharp.RuntimeBinder`, `Microsoft.Win32`, `Newtonsoft.Json`, `System`, `System.Collections.Generic`, `System.IO`, `System.Linq.Expressions`, `System.Runtime.CompilerServices`, `System.Security.Cryptography`, `System.Text`
- **Libraries**:
  - `Meta.Core`: Custom core functionalities.
  - `Newtonsoft.Json`: JSON serialization/deserialization.
  - `Microsoft.CSharp.RuntimeBinder`: Dynamic operations.
  - `Microsoft.Win32`: Common dialogs like OpenFileDialog.
  - `System.Security.Cryptography`: Cryptographic services.

### Class Definition

- **Class**: `Cache<T>`
- **Namespace**: `Meta.Editor.Extensions`
- **Nullable Context**: Enabled with `#nullable enable`

### Properties

- **logger**: An `ILogger` instance for logging operations.
- **specificObjectName**: A string representing the specific name of the cached object.
- **UniqueCacheID**: A unique identifier for the cache instance.
- **ActiveCache**: The current active cache file of type `MetaCacheFile`.
- **CachedObject**: The actual object of type `T` being cached.

### Constructor

- **Cache(ILogger inLogger, string specificObjectName)**: Initializes the cache with a logger and a specific object name, generates a unique cache ID, and calls `SerializeObjects`.

### Methods

- **SerializeObjects()**: Serializes and saves objects to cache files.

  - Reads all `.cache` files in the cache directory.
  - Deserializes them into `MetaCacheFile` objects.
  - Checks if the specific object name matches the cache file.
  - If a match is found, it deserializes the cached object using dynamic binding and assigns it to `CachedObject`.
  - If no match is found, it creates a new cache file with default values.

- **Load()**: Loads the cached object from a file.

  - Uses an `OpenFileDialog` to select a cache file.
  - Deserializes the selected cache file and returns the cached object.

- **Save()**: Saves the current cached object to the cache file.

  - Updates the `ActiveCache` object and serializes it to JSON.
  - Writes the serialized JSON to a file in the cache directory.

- **GenerateUniqueHash()**: Generates a unique hash using the current time ticks.
  - Uses MD5 hashing to create a unique string.

### Dynamic Binding

- Utilizes `Microsoft.CSharp.RuntimeBinder` for dynamic operations and expression trees for compiling dynamic code at runtime.
- `CallSite` and `CSharpArgumentInfo` are used for dynamic member invocations and operations.

### Serialization Settings

- Uses `JsonSerializerSettings` to ignore default values, handle missing members, format JSON, and ignore null values during serialization.

### Summary

This class is designed to handle caching operations generically, allowing you to cache any type of object. It includes methods for loading, saving, and serializing objects to cache files, with dynamic binding to handle JSON deserialization. The unique cache identifier ensures each cache instance is uniquely identifiable, and the logger provides logging functionality for tracking operations.

## /Meta/Editor/Extensions/GameUnlocker.cs

This code defines a static class `GameUnlocker` within the `Meta.Editor.Extensions` namespace. It contains a method `UnlockWWE2K23` that attempts to unlock all content in the game WWE 2K23 if the game is currently active. Here is a detailed breakdown of the code:

### Using Directives

```csharp
using Meta.Core.IO;
using Meta.Editor.Controls;
using Meta.Editor.Windows;
using MetaEditor;
using System;
```

- These `using` directives import various namespaces that provide functionality used in the code. This includes I/O operations, UI controls, window management, and core functionalities related to the MetaEditor framework.

### Namespace

```csharp
namespace Meta.Editor.Extensions
```

- The namespace declaration groups related classes together. In this case, `GameUnlocker` is part of the `Meta.Editor.Extensions` namespace.

### Static Class Declaration

```csharp
public static class GameUnlocker
```

- The `public static class GameUnlocker` declares a static class named `GameUnlocker`. This class cannot be instantiated and only contains static members.

### UnlockWWE2K23 Method

```csharp
public static bool UnlockWWE2K23()
```

- This is a static method that returns a boolean value (`true` if the unlock process was initiated, `false` if the game is not running).

#### Method Logic

```csharp
if (App.GameActive)
```

- Checks if the game is currently active using the `App.GameActive` property.

```csharp
MetaTaskWindow.Show("Unlocking everything", "This may take a minute, remember to save after", (MetaTaskCallback) (task =>
{
```

- If the game is active, it shows a task window with a message, using `MetaTaskWindow.Show`. The third parameter is a callback function of type `MetaTaskCallback` that performs the unlocking process.

#### Unlocking Process

```csharp
Mem mem = new Mem();
if (!mem.OpenProcess(App.CurrentGame.Exe))
  return;
UIntPtr num1 = (UIntPtr) (ulong) (long) mem.mProc.MainModule.BaseAddress + App.CurrentGame.Memory.Regions["Unlock"];
int num2 = App.CurrentGame.Memory.Regions["UnlockTotal"] / 8;
for (int index = 0; index < num2; ++index)
  mem.WriteBytes(num1 + 6 + 8 * index, new byte[1]
  {
    (byte) 3
  });
mem.CloseProcess();
App.Logger.Log("WWE 2K23 has been unlocked", Array.Empty<object>());
```

- Creates an instance of the `Mem` class.
- Opens the process associated with the current game executable using `mem.OpenProcess`.
- Calculates the base address plus an offset for the memory region to unlock using `UIntPtr`.
- Determines the number of iterations needed based on the size of the memory region divided by 8.
- Writes the byte `0x03` to each calculated address to unlock content.
- Closes the process.
- Logs the action using `App.Logger.Log`.

#### Error Handling

```csharp
int num = (int) MetaMessageBox.Show("Error: The game is not running");
return false;
```

- If the game is not active, it shows an error message using `MetaMessageBox.Show` and returns `false`.

### Full Code Summary

- The `GameUnlocker` class contains a single method `UnlockWWE2K23` designed to unlock all content in WWE 2K23.
- It checks if the game is running, then shows a task window and performs memory manipulation to unlock content.
- If the game is not running, it displays an error message.

### Example Usage

To use this method, simply call:

```csharp
bool success = Meta.Editor.Extensions.GameUnlocker.UnlockWWE2K23();
if (success)
{
  Console.WriteLine("Unlock process initiated.");
}
else
{
  Console.WriteLine("Failed to unlock. Game not running.");
}
```

This will attempt to unlock WWE 2K23 and print a message indicating whether the process was initiated or if it failed due to the game not running.

## /Meta/Editor/Extensions/MetaCacheFile.cs

This C# code defines a simple class `MetaCacheFile` within the `Meta.Editor.Extensions` namespace, intended for use in applications that might involve caching metadata or similar objects. Here is a detailed explanation of the code:

### Nullable Reference Types

- `#nullable enable`: Enables nullable reference type annotations and warnings in the code, helping to avoid null reference exceptions. This directive indicates that the code in this file will follow the rules of nullable reference types, enhancing the robustness by providing compile-time checks for nullability.

### Namespace Declaration

- `namespace Meta.Editor.Extensions`: Declares the namespace `Meta.Editor.Extensions`. This groups related classes and other types into a scope, organizing code and avoiding name collisions.

### Class Definition

- `public class MetaCacheFile`: Defines a public class named `MetaCacheFile`. This class is accessible from other classes and assemblies.

### Properties

The class contains three properties, each with a public getter and setter:

1. **Name**

   - `public string Name { get; set; }`: A public property of type `string` to hold the name of the cache file. The `{ get; set; }` syntax defines automatic properties, allowing the compiler to generate the backing field and the getter and setter methods automatically.

2. **UID**

   - `public string UID { get; set; }`: Another public property of type `string` to hold a unique identifier (UID) for the cache file. This could be used to uniquely identify cache entries.

3. **Object**
   - `public object Object { get; set; }`: A public property of type `object` to hold any type of data. Since `object` is the base type of all types in C#, this property can store any type of value or reference.

### Usage

The `MetaCacheFile` class is a simple data container, often referred to as a "plain old CLR object" (POCO) or a model class. It is designed to hold and manage metadata information, with the following properties:

- `Name`: Stores the name of the cache file.
- `UID`: Stores a unique identifier for the cache file.
- `Object`: Stores the actual data object, which can be of any type.

### Example Usage

Here is an example of how you might use the `MetaCacheFile` class in a C# application:

```csharp
using Meta.Editor.Extensions;

class Program
{
    static void Main()
    {
        MetaCacheFile cacheFile = new MetaCacheFile
        {
            Name = "example.txt",
            UID = "123-abc",
            Object = "This is some cached data."
        };

        Console.WriteLine($"Name: {cacheFile.Name}");
        Console.WriteLine($"UID: {cacheFile.UID}");
        Console.WriteLine($"Object: {cacheFile.Object}");
    }
}
```

In this example:

- An instance of `MetaCacheFile` is created.
- The properties `Name`, `UID`, and `Object` are set with respective values.
- The values of these properties are printed to the console.

This class can be useful in scenarios where you need to cache data along with its name and a unique identifier, making it easier to manage and retrieve cached information.

## /Meta/Editor/Extensions/OptionsExtension.cs

This code defines an abstract class `OptionsExtension` within the namespace `Meta.Editor.Extensions`. The class provides a basic structure for extensions that deal with loading, validating, and saving options. Let's break down each part:

### Namespace

```csharp
namespace Meta.Editor.Extensions
```

- The `namespace` keyword declares a scope that contains a set of related objects. In this case, the namespace is `Meta.Editor.Extensions`.

### Abstract Class Declaration

```csharp
public abstract class OptionsExtension
```

- The `public abstract class OptionsExtension` line declares an abstract class named `OptionsExtension`.
- An abstract class cannot be instantiated directly and is intended to be a base class for other classes.

### Methods

#### Load Method

```csharp
public virtual void Load()
{
}
```

- This method is a public virtual method named `Load`.
- The `virtual` keyword indicates that this method can be overridden in a derived class.
- Currently, the method has no implementation (empty body). Derived classes can provide specific functionality by overriding this method.

#### Validate Method

```csharp
public virtual bool Validate() => true;
```

- This method is a public virtual method named `Validate` that returns a boolean value.
- The method returns `true` by default.
- Like the `Load` method, it is marked as `virtual`, meaning it can be overridden in derived classes to provide specific validation logic.

#### Save Method

```csharp
public virtual void Save()
{
}
```

- This method is a public virtual method named `Save`.
- Similar to the `Load` method, it has an empty implementation and is marked as `virtual`, allowing derived classes to override it with specific save functionality.

### Full Code Summary

- `OptionsExtension` is an abstract base class designed to be inherited by other classes that need to implement loading, validating, and saving functionality.
- The class provides three virtual methods: `Load`, `Validate`, and `Save`, all of which have default (empty or minimal) implementations.
- Derived classes can override these methods to provide specific behavior for loading options, validating them, and saving them.

### Example Usage

Here is an example of how you might create a derived class that overrides these methods:

```csharp
namespace Meta.Editor.Extensions
{
  public class CustomOptionsExtension : OptionsExtension
  {
    public override void Load()
    {
      // Custom load logic
      Console.WriteLine("Loading options...");
    }

    public override bool Validate()
    {
      // Custom validation logic
      Console.WriteLine("Validating options...");
      return base.Validate(); // or custom logic returning true/false
    }

    public override void Save()
    {
      // Custom save logic
      Console.WriteLine("Saving options...");
    }
  }
}
```

In this example:

- `CustomOptionsExtension` inherits from `OptionsExtension`.
- It overrides the `Load`, `Validate`, and `Save` methods to provide specific behavior for loading, validating, and saving options.
- The `Validate` method can call the base class method if needed or provide its own logic.

### Summary of Key Points

- `OptionsExtension` is an abstract class with virtual methods meant to be overridden by derived classes.
- The class provides a basic framework for handling options, which derived classes can extend and customize.
- The `Load`, `Validate`, and `Save` methods are placeholders with minimal default behavior, allowing for flexibility in derived implementations.

## /Meta/Editor/Extensions/TextExtension.cs

This C# code defines a class `TextExtension` that extends `MarkupExtension`, allowing you to load text from a file and use it within XAML (Extensible Application Markup Language) in a WPF (Windows Presentation Foundation) application. Here is a breakdown of the code:

### Namespaces

- `System`: Provides basic functionalities like base data types, events, exceptions, etc.
- `System.IO`: Provides types for reading and writing to files and data streams.
- `System.Windows`: Contains classes for creating Windows-based applications.
- `System.Windows.Markup`: Provides classes for XAML markup processing.

### Nullable Reference Types

- `#nullable enable`: Enables nullable reference type annotations and warnings in the code, helping to avoid null reference exceptions.

### Namespace Declaration

- `namespace Meta.Editor.Extensions`: Declares a namespace `Meta.Editor.Extensions` that contains the `TextExtension` class.

### Class Definition

- `public class TextExtension : MarkupExtension`: Defines the `TextExtension` class that inherits from `MarkupExtension`. This class can be used in XAML to provide a value (specifically, text content from a file).

### Constructor

- `public TextExtension(string inTextFile)`: The constructor takes a string parameter `inTextFile`, representing the path to the text file. It initializes the `textFile` field with this value.

### Field

- `private readonly string textFile;`: A private readonly field that holds the path to the text file.

### Method

- `public override object ProvideValue(IServiceProvider serviceProvider)`: Overrides the `ProvideValue` method from `MarkupExtension`. This method is called to return the value to be used in the XAML.

#### ProvideValue Method Implementation

1. `Application.GetResourceStream(new Uri("pack://application:,,,/" + this.textFile))`: Gets a resource stream for the specified file using a pack URI.

   - `pack://application:,,,/`: The pack URI scheme for referencing application data files in WPF.
   - `this.textFile`: The path to the text file provided during the construction of the `TextExtension` object.

2. `using (Stream stream = ...`.Stream)`: Opens the resource stream.
3. `using (TextReader textReader = new StreamReader(stream))`: Creates a `TextReader` to read the text from the stream.
4. `return textReader.ReadToEnd();`: Reads the entire content of the text file and returns it.

### Usage in XAML

This extension can be used in XAML to load and display the content of a text file. Here’s an example of how you might use it:

```xaml
<Window x:Class="MyApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:ext="clr-namespace:Meta.Editor.Extensions"
        Title="MainWindow" Height="350" Width="525">
    <Grid>
        <TextBlock Text="{ext:TextExtension 'Resources/MyTextFile.txt'}"/>
    </Grid>
</Window>
```

In this example:

- `xmlns:ext="clr-namespace:Meta.Editor.Extensions"`: Declares the namespace to use the `TextExtension`.
- `<TextBlock Text="{ext:TextExtension 'Resources/MyTextFile.txt'}"/>`: Uses the `TextExtension` to load and display the content of `Resources/MyTextFile.txt` in a `TextBlock`.

## /Meta/Editor/Extensions/Tuple.cs

This code defines a static class `Tuple` within the namespace `Meta.Editor.Extensions`. The purpose of this class is to provide static methods for creating instances of the `Tuple<T>` and `Tuple<T, T2>` classes. Let's break it down:

### Namespace

```csharp
namespace Meta.Editor.Extensions
```

- The `namespace` keyword declares a scope that contains a set of related objects. In this case, the namespace is `Meta.Editor.Extensions`.

### Static Class Declaration

```csharp
public static class Tuple
```

- The `public static class Tuple` line declares a static class named `Tuple`. A static class cannot be instantiated and can only contain static members.

### Static Methods

#### New Method for Single Type Parameter

```csharp
public static Tuple<T1> New<T1>(T1 t1) => new Tuple<T1>(t1);
```

- This method is a static method named `New` that takes one type parameter `T1` and one parameter `t1` of type `T1`.
- The method returns an instance of `Tuple<T1>` by calling its constructor with the provided `t1` value.
- Essentially, this method acts as a factory method for creating instances of `Tuple<T1>`.

#### New Method for Two Type Parameters

```csharp
public static Tuple<T1, T2> New<T1, T2>(T1 t1, T2 t2) => new Tuple<T1, T2>(t1, t2);
```

- This method is a static method named `New` that takes two type parameters `T1` and `T2`, and two parameters `t1` and `t2` of types `T1` and `T2`, respectively.
- The method returns an instance of `Tuple<T1, T2>` by calling its constructor with the provided `t1` and `t2` values.
- This method acts as a factory method for creating instances of `Tuple<T1, T2>`.

### Full Code Summary

- The static class `Tuple` contains two overloaded static methods named `New`.
- The first `New` method creates and returns an instance of `Tuple<T1>`.
- The second `New` method creates and returns an instance of `Tuple<T1, T2>`.

### Example Usage

Here's an example of how you might use these methods:

```csharp
var singleTuple = Meta.Editor.Extensions.Tuple.New(42);
Console.WriteLine(singleTuple.First); // Output: 42

var doubleTuple = Meta.Editor.Extensions.Tuple.New(42, "Hello");
Console.WriteLine(doubleTuple.First); // Output: 42
Console.WriteLine(doubleTuple.Second); // Output: Hello
```

In this example:

- `singleTuple` is an instance of `Tuple<int>`, created using the `New` method with one type parameter.
- `doubleTuple` is an instance of `Tuple<int, string>`, created using the `New` method with two type parameters.

This static class provides a convenient way to create tuples without needing to directly call their constructors, enhancing code readability and simplicity.

## /Meta/Editor/Extensions/Tuple`1.cs

This code defines a simple generic class `Tuple<T>` in the `Meta.Editor.Extensions` namespace. Let's break down the components and functionality of this class:

### Nullable Context

```csharp
#nullable enable
```

This directive enables nullable reference types for the file or region. It helps in identifying potential null reference errors during compile time by distinguishing between nullable and non-nullable reference types.

### Namespace Declaration

```csharp
namespace Meta.Editor.Extensions
```

Defines the namespace in which the `Tuple<T>` class is contained, which is `Meta.Editor.Extensions`.

### Class Definition

```csharp
public class Tuple<T>
```

Defines a public class named `Tuple` that is generic, meaning it can work with any data type specified by `T`.

### Constructor

```csharp
public Tuple(T first) => this.First = first;
```

The constructor for the `Tuple<T>` class takes a single parameter `first` of type `T` and assigns it to the `First` property. The `=>` syntax is an expression-bodied member, which is a concise way to define simple methods or constructors.

### Property

```csharp
public T First { get; set; }
```

This is an auto-implemented property named `First` of type `T`. It has both a getter and a setter, allowing the value to be read and modified. Since the class is generic, `T` can be any data type (e.g., `int`, `string`, `CustomClass`, etc.).

### Summary

This `Tuple<T>` class is a simple container for a single value of type `T`. It provides a way to encapsulate a single piece of data within an object. The primary purpose of this class is to hold a value of any specified type with a straightforward interface for accessing and modifying that value.

### Example Usage

Here is an example of how you might use the `Tuple<T>` class:

```csharp
var intTuple = new Meta.Editor.Extensions.Tuple<int>(42);
Console.WriteLine(intTuple.First); // Output: 42

var stringTuple = new Meta.Editor.Extensions.Tuple<string>("Hello, World!");
Console.WriteLine(stringTuple.First); // Output: Hello, World!
```

In these examples:

- `intTuple` is a `Tuple` holding an integer value.
- `stringTuple` is a `Tuple` holding a string value.

The generic nature of the class allows it to be used with any type, providing flexibility and reusability.

## /Meta/Editor/Extensions/Tuple`2.cs

This code defines a generic class `Tuple<T, T2>` within the namespace `Meta.Editor.Extensions`. Here's a detailed breakdown of how it works:

### Namespace

```csharp
namespace Meta.Editor.Extensions
```

- The `namespace` keyword is used to declare a scope that contains a set of related objects. In this case, the namespace is `Meta.Editor.Extensions`.

### Class Declaration

```csharp
public class Tuple<T, T2> : Tuple<T>
```

- This line declares a public generic class named `Tuple` that takes two type parameters: `T` and `T2`.
- The class `Tuple<T, T2>` inherits from another generic class `Tuple<T>`. This means that `Tuple<T, T2>` is an extension of `Tuple<T>`.

### Constructor

```csharp
public Tuple(T first, T2 second)
  : base(first)
```

- This is the constructor for the `Tuple<T, T2>` class. It takes two parameters: `first` of type `T` and `second` of type `T2`.
- The `: base(first)` part calls the constructor of the base class `Tuple<T>` with `first` as an argument. This means that `first` will be handled by the base class `Tuple<T>`.

### Second Property

```csharp
public T2 Second { get; set; }
```

- This line declares a public property `Second` of type `T2` with both a getter and a setter. This property is used to store the second value of the tuple.

### Full Code Summary

- The `Tuple<T, T2>` class is an extension of the `Tuple<T>` class. It adds a new property `Second` to store an additional value.
- When an instance of `Tuple<T, T2>` is created, it initializes the base class `Tuple<T>` with the first value and stores the second value in the `Second` property.

### Example Usage

Here's an example of how you might use this class:

```csharp
var myTuple = new Meta.Editor.Extensions.Tuple<int, string>(42, "Hello");
Console.WriteLine(myTuple.First); // Output: 42
Console.WriteLine(myTuple.Second); // Output: Hello
```

In this example, `myTuple` is an instance of `Tuple<int, string>`. It stores an integer `42` as the first value (handled by the base class `Tuple<T>`) and a string `"Hello"` as the second value (handled by the `Second` property of `Tuple<T, T2>`).

## /Meta/Editor/IO/WWE2K23/MotionRender.cs

This code defines a `MotionRender` class in the `Meta.Editor.IO.WWE2K23` namespace, which reads and parses motion data for a game, specifically WWE 2K23. Let's break down the components and functionality of this code:

### Namespaces and Using Directives

```csharp
using Meta.Core.IO;
using Meta.WWE2K23;
using MetaEditor;
using System.IO;
```

These `using` directives import necessary namespaces:

- `Meta.Core.IO`: Presumably contains core input/output functionality.
- `Meta.WWE2K23`: Contains specific classes and methods related to WWE 2K23.
- `MetaEditor`: General purpose or utility classes for the editor.
- `System.IO`: .NET's built-in I/O functionality.

### Namespace Declaration

```csharp
namespace Meta.Editor.IO.WWE2K23
```

Defines the namespace in which this class is contained, indicating it is part of the Meta Editor specifically for WWE 2K23.

### Class Definition

```csharp
public class MotionRender : NativeReader
```

`MotionRender` is a public class that inherits from `NativeReader`. `NativeReader` is likely a class that provides functionality for reading native data types from a stream.

### Private Field

```csharp
private Motion activeMotion;
```

A private field to hold the `Motion` object being parsed.

### Property

```csharp
public Motion Motion => this.activeMotion;
```

A public property that exposes the `activeMotion` object.

### Constructor

```csharp
public MotionRender(Stream inStream, MetaGame game)
  : base(inStream)
{
  this.Parse(game);
}
```

The constructor takes a `Stream` (`inStream`) and a `MetaGame` object (`game`). It calls the base class constructor with the stream and then calls the `Parse` method to read and process the data.

### Parse Method

```csharp
private void Parse(MetaGame game)
{
  this.activeMotion = new Motion();
  this.Position = (long) game.Memory.MotionOffsets["Movie_Display"];
  this.activeMotion.movies_enabled = this.ReadByte();
  this.Position = (long) game.Memory.MotionOffsets["Entrance_Music"];
  this.activeMotion.entrance_music = this.ReadUInt((Endian) 0);
  this.Position = (long) game.Memory.MotionOffsets["Titantron_Movie"];
  this.activeMotion.movie_titantron = this.ReadUInt((Endian) 0);
  this.Position = (long) game.Memory.MotionOffsets["Unknown_Movie"];
  this.activeMotion.movie_unknown = this.ReadUInt((Endian) 0);
  this.Position = (long) game.Memory.MotionOffsets["Banner_Movie"];
  this.activeMotion.movie_banner = this.ReadUInt((Endian) 0);
  this.Position = (long) game.Memory.MotionOffsets["Stage_Ramp_Movie"];
  this.activeMotion.movie_stage_ramp = this.ReadUInt((Endian) 0);
  this.Position = (long) game.Memory.MotionOffsets["Arena_Effect"];
  this.activeMotion.screen_effect = this.ReadByte();
  this.Position = (long) game.Memory.MotionOffsets["Light_Show"];
  this.activeMotion.light_show = this.ReadUInt((Endian) 0);
  this.Position = (long) game.Memory.MotionOffsets["Apron_Ring_Post_Movie"];
  this.activeMotion.movie_apron_ringpost = this.ReadUInt((Endian) 0);
  this.Position = (long) game.Memory.MotionOffsets["Barricade_Movie"];
  this.activeMotion.movie_barricade = this.ReadUInt((Endian) 0);
  this.Position = (long) game.Memory.MotionOffsets["Victory_Motion_Face"];
  this.activeMotion.victory_motion_face = this.ReadUInt((Endian) 0);
  this.Position = (long) game.Memory.MotionOffsets["Victory_Motion_Heel"];
  this.activeMotion.victory_motion_heel = this.ReadUInt((Endian) 0);
  this.Position = (long) game.Memory.MotionOffsets["Victory_Title_Motion_Face"];
  this.activeMotion.victory_title_motion_face = this.ReadUInt((Endian) 0);
  this.Position = (long) game.Memory.MotionOffsets["Victory_Title_Motion_Heel"];
  this.activeMotion.victory_title_motion_heel = this.ReadUInt((Endian) 0);
  this.Position = (long) game.Memory.MotionOffsets["Title_Motion"];
  this.activeMotion.entrance_title_motion = this.ReadUInt((Endian) 0);
  this.Position = (long) game.Memory.MotionOffsets["MITB_Motion"];
  this.activeMotion.entrance_MITB_motion = this.ReadUInt((Endian) 0);
  this.Position = (long) game.Memory.MotionOffsets["Motion_Intro"];
  this.activeMotion.entrance_motion_intro = this.ReadUInt((Endian) 0);
  this.Position = (long) game.Memory.MotionOffsets["Motion_Stage"];
  this.activeMotion.entrance_motion_stage = this.ReadUInt((Endian) 0);
  this.Position = (long) game.Memory.MotionOffsets["Motion_Ramp"];
  this.activeMotion.entrance_motion_ramp = this.ReadUInt((Endian) 0);
  this.Position = (long) game.Memory.MotionOffsets["Motion_Ring_In"];
  this.activeMotion.entrance_motion_ring_in = this.ReadUInt((Endian) 0);
  this.Position = (long) game.Memory.MotionOffsets["Motion_Ring"];
  this.activeMotion.entrance_motion_ring = this.ReadUInt((Endian) 0);
}
```

The `Parse` method does the heavy lifting of reading data from specific offsets in the game's memory and populating the `activeMotion` object. Here's a breakdown:

- Initializes a new `Motion` object.
- Sets the reader's position to various offsets provided by `game.Memory.MotionOffsets` and reads data into the `activeMotion` properties.

### Motion Class (Assumed)

While not defined in this code, the `Motion` class is assumed to have properties corresponding to various motion settings (e.g., `movies_enabled`, `entrance_music`, `movie_titantron`, etc.).

### Reading Methods

The code uses methods like `ReadByte` and `ReadUInt` (with an `Endian` parameter) to read data from the stream. These methods are likely defined in the `NativeReader` class.

### Summary

This class is designed to read specific motion data from a stream based on offsets stored in the `MetaGame` object, and then populate a `Motion` object with this data. The `MotionRender` class essentially serves as a bridge between raw memory data and a more structured `Motion` object.

## /Meta/Editor/IO/WWE2K23/MovesetReader.cs

The `MovesetReader` class in the provided code is part of a namespace called `Meta.Editor.IO.WWE2K23`. Its primary function is to read and parse data related to wrestling movesets from a stream. Let's break down the components and functionalities:

### Namespaces and Imports

```csharp
using Meta.Core.IO;
using Meta.WWE2K23;
using MetaEditor;
using System.Collections.Generic;
using System.IO;
using System.Linq;
```

These statements import necessary namespaces and libraries:

- `Meta.Core.IO`, `Meta.WWE2K23`, and `MetaEditor` are presumably part of the project's own libraries.
- `System.Collections.Generic`, `System.IO`, and `System.Linq` are standard .NET libraries for collections, input/output operations, and LINQ operations, respectively.

### Class Declaration

```csharp
namespace Meta.Editor.IO.WWE2K23
{
  public class MovesetReader : NativeReader
  {
    private Moveset activeMoveset;

    public Moveset Moveset => this.activeMoveset;

    public MovesetReader(Stream inStream, MetaGame game)
      : base(inStream)
    {
      this.Parse(game);
    }
```

- `MovesetReader` is a class that inherits from `NativeReader`.
- It has a private field `activeMoveset` of type `Moveset` and a public property `Moveset` that returns this field.
- The constructor takes a `Stream` and a `MetaGame` object, passing the stream to the base `NativeReader` constructor and calling the `Parse` method.

### Parse Method

```csharp
    private void Parse(MetaGame game)
    {
      this.activeMoveset = new Moveset();
      this.activeMoveset.moves_standing = new Motion_Standing();

      // Reading Moves_Standing_Front_Light_Attack
      this.Position = (long) game.Memory.MoveOffsets["Moves_Standing_Front_Light_Attack"];
      this.activeMoveset.moves_standing.front_light_attack = ((IEnumerable<ushort>) this.ReadUShortArray(3)).ToList<ushort>();

      // Reading other moves in a similar fashion
      this.Position = (long) game.Memory.MoveOffsets["Moves_Standing_Front_Heavy_Attack"];
      this.activeMoveset.moves_standing.front_heavy_attack = ((IEnumerable<ushort>) this.ReadUShortArray(3)).ToList<ushort>();

      // This pattern repeats for many other moves...
    }
```

- The `Parse` method initializes the `activeMoveset` and its nested objects.
- It reads various moveset data from the `game.Memory.MoveOffsets` dictionary, setting the reader's position and reading arrays of `ushort` or `uint` values.
- The data is then stored in the appropriate properties of the `activeMoveset`.

### Detailed Breakdown

- **`Moveset` Initialization:**

  ```csharp
  this.activeMoveset = new Moveset();
  this.activeMoveset.moves_standing = new Motion_Standing();
  ```

  - Initializes `activeMoveset` and its nested `moves_standing` property.

- **Reading Move Offsets:**

  ```csharp
  this.Position = (long) game.Memory.MoveOffsets["Moves_Standing_Front_Light_Attack"];
  this.activeMoveset.moves_standing.front_light_attack = ((IEnumerable<ushort>) this.ReadUShortArray(3)).ToList<ushort>();
  ```

  - Sets the reader's position to the offset specified in `game.Memory.MoveOffsets` for `"Moves_Standing_Front_Light_Attack"`.
  - Reads an array of `ushort` values from the current position and converts it to a list, assigning it to `front_light_attack`.

- **Repeating the Pattern:**
  - This pattern repeats for many other moves, such as `"Moves_Standing_Front_Heavy_Attack"`, `"Moves_Standing_Front_Running"`, etc.
  - Each move type has its offset read from `game.Memory.MoveOffsets`, and the corresponding data is read and assigned to the `activeMoveset`.

### Summary

The `MovesetReader` class is responsible for parsing a wrestling game's moveset data from a binary stream. It reads various moves using offsets defined in the `MetaGame` object, storing the results in the `Moveset` object. This class allows structured access to the moveset data, which can be used for further processing or analysis within the application.

## /Meta/Editor/IO/WWE2K23/ProfileExtensions.cs

This C# code defines a static class `ProfileExtensions` within the namespace `Meta.Editor.IO.WWE2K23`. It provides utility methods to read different types of data from a `NativeReader` object based on a key-value pair provided in a dictionary. The purpose of these methods is to read data from a memory buffer at positions specified by the dictionary.

Here is a detailed explanation of the code:

### Namespaces and Directives

```csharp
using Meta.Core.IO;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
```

- **Meta.Core.IO**: Presumably, this namespace includes the `NativeReader` class and other IO-related functionalities.
- **System**: Provides fundamental classes and base classes that define commonly used value and reference data types.
- **System.Collections.Generic**: Contains interfaces and classes that define generic collections.
- **System.Linq**: Provides classes and interfaces that support queries that use Language-Integrated Query (LINQ).
- **#nullable enable**: Enables nullable reference types, which helps in nullability checks during compilation.

### Namespace and Static Class

```csharp
namespace Meta.Editor.IO.WWE2K23
{
  public static class ProfileExtensions
  {
    // Method implementations
  }
}
```

The `ProfileExtensions` class is declared as `public static`, meaning it contains only static members and cannot be instantiated.

### Method: ReadMemory

```csharp
public static object ReadMemory<T>(
  NativeReader reader,
  Dictionary<string, int> dictionary,
  string key)
{
  int num;
  if (dictionary.TryGetValue(key, out num))
  {
    if (typeof(T) == typeof(ushort))
    {
      reader.Position = (long)Convert.ToUInt32(num);
      return (object)reader.ReadUShort((Endian)0);
    }
    if (typeof(T) == typeof(uint))
    {
      reader.Position = (long)Convert.ToUInt32(num);
      return (object)reader.ReadUInt((Endian)0);
    }
    if (typeof(T) == typeof(byte))
    {
      reader.Position = (long)Convert.ToUInt32(num);
      return (object)reader.ReadByte();
    }
  }
  return (object)default(T);
}
```

- **Parameters**:

  - `NativeReader reader`: The reader object used to read from the memory buffer.
  - `Dictionary<string, int> dictionary`: A dictionary mapping string keys to integer memory positions.
  - `string key`: The key used to look up the memory position in the dictionary.

- **Functionality**:
  - Tries to get the memory position (`num`) from the dictionary using the provided key.
  - Depending on the type `T`, it sets the `reader` position and reads the corresponding data type:
    - `ushort` (16-bit unsigned integer)
    - `uint` (32-bit unsigned integer)
    - `byte` (8-bit unsigned integer)
  - If the type `T` does not match any of the specified types, it returns the default value for type `T`.

### Method: ReadMemoryArray

```csharp
public static object ReadMemoryArray<T>(
  NativeReader reader,
  Dictionary<string, int> dictionary,
  string key,
  int count)
{
  int num;
  if (dictionary.TryGetValue(key, out num))
  {
    if (typeof(T) == typeof(List<byte>))
    {
      reader.Position = (long)Convert.ToUInt32(num);
      return (object)((IEnumerable<byte>)reader.ReadByteArray(count)).ToList<byte>();
    }
    if (typeof(T) == typeof(List<uint>))
    {
      reader.Position = (long)Convert.ToUInt32(num);
      return (object)((IEnumerable<uint>)reader.ReadUIntArray(count)).ToList<uint>();
    }
  }
  return (object)default(T);
}
```

- **Parameters**:

  - `NativeReader reader`: The reader object used to read from the memory buffer.
  - `Dictionary<string, int> dictionary`: A dictionary mapping string keys to integer memory positions.
  - `string key`: The key used to look up the memory position in the dictionary.
  - `int count`: The number of elements to read from the memory buffer.

- **Functionality**:
  - Tries to get the memory position (`num`) from the dictionary using the provided key.
  - Depending on the type `T`, it sets the `reader` position and reads an array of the corresponding data type:
    - `List<byte>` (List of 8-bit unsigned integers)
    - `List<uint>` (List of 32-bit unsigned integers)
  - If the type `T` does not match any of the specified types, it returns the default value for type `T`.

### Summary

The `ProfileExtensions` class provides methods to read single values or arrays of values from a memory buffer at positions specified by a dictionary. These methods are generic and use type-checking to determine the correct type of data to read and return. The `NativeReader` class is assumed to have methods like `ReadUShort`, `ReadUInt`, `ReadByte`, `ReadByteArray`, and `ReadUIntArray`, which handle the actual reading of data from the memory buffer.

## /Meta/Editor/IO/WWE2K23/ProfileRender.cs

This C# code defines a class `ProfileRender` within the namespace `Meta.Editor.IO.WWE2K23`. The `ProfileRender` class inherits from the `NativeReader` class and is designed to read and parse profile information for the game WWE 2K23. Here's a detailed explanation of each part of the code:

### Using Directives

```csharp
using Meta.Core.IO;
using Meta.Editor.Converters;
using Meta.WWE2K23;
using MetaEditor;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
```

These directives include various namespaces that provide necessary classes and methods used in the `ProfileRender` class.

### Nullable Enable

```csharp
#nullable enable
```

This directive enables nullable reference types, which means the compiler will enforce nullability rules to help prevent `null` reference errors.

### Namespace Definition

```csharp
namespace Meta.Editor.IO.WWE2K23
```

This defines the `Meta.Editor.IO.WWE2K23` namespace, which helps in organizing the code and preventing name conflicts.

### Class Definition

```csharp
public class ProfileRender : NativeReader
```

This declares the `ProfileRender` class, which inherits from the `NativeReader` class. This class is responsible for reading and parsing profile data from a stream.

### Private Fields and Properties

```csharp
private Info activeProfile;

public Info Profile => this.activeProfile;
```

The `activeProfile` field stores the profile information, and the `Profile` property provides read-only access to this data.

### Constructor

```csharp
public ProfileRender(Stream inStream, MetaGame game)
    : base(inStream)
{
    this.Parse(game);
}
```

The constructor initializes a new instance of the `ProfileRender` class. It takes a `Stream` and a `MetaGame` object as parameters. The constructor calls the base class constructor with the stream and then calls the `Parse` method to parse the profile data.

### Parse Method

```csharp
private void Parse(MetaGame game)
{
    this.activeProfile = new Info();
    Info activeProfile1 = this.activeProfile;
    // ISSUE: reference to a compiler-generated field
    if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__0 == null)
    {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, ushort>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(ushort), typeof(ProfileRender)));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    int num1 = (int)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__0.Target((CallSite)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__0, ProfileExtensions.ReadMemory<ushort>((NativeReader)this, game.Memory.ProfileOffsets, "Wrestler_ID"));
    activeProfile1.wrestler_id = (ushort)num1;
    Info activeProfile2 = this.activeProfile;
    // ISSUE: reference to a compiler-generated field
    if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__1 == null)
    {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, ushort>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(ushort), typeof(ProfileRender)));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    int num2 = (int)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__1.Target((CallSite)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__1, ProfileExtensions.ReadMemory<ushort>((NativeReader)this, game.Memory.ProfileOffsets, "Slot_ID"));
    activeProfile2.slot_id = (ushort)num2;
    Info activeProfile3 = this.activeProfile;
    // ISSUE: reference to a compiler-generated field
    if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__2 == null)
    {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, ushort>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(ushort), typeof(ProfileRender)));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    int num3 = (int)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__2.Target((CallSite)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__2, ProfileExtensions.ReadMemory<ushort>((NativeReader)this, game.Memory.ProfileOffsets, "Wrestler_ID_2"));
    activeProfile3.wrestler_id_2 = (ushort)num3;
    Info activeProfile4 = this.activeProfile;
    // ISSUE: reference to a compiler-generated field
    if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__3 == null)
    {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, uint>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(uint), typeof(ProfileRender)));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    int num4 = (int)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__3.Target((CallSite)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__3, ProfileExtensions.ReadMemory<uint>((NativeReader)this, game.Memory.ProfileOffsets, "Full_Name"));
    activeProfile4.fullname_sdb_id = (uint)num4;
    Info activeProfile5 = this.activeProfile;
    // ISSUE: reference to a compiler-generated field
    if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__4 == null)
    {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, uint>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(uint), typeof(ProfileRender)));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    int num5 = (int)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__4.Target((CallSite)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__4, ProfileExtensions.ReadMemory<uint>((NativeReader)this, game.Memory.ProfileOffsets, "Nickname"));
    activeProfile5.nickname_sdb_id = (uint)num5;
    Info activeProfile6 = this.activeProfile;
    // ISSUE: reference to a compiler-generated field
    if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__5 == null)
    {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, uint>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(uint), typeof(ProfileRender)));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    int num6 = (int)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__5.Target((CallSite)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__5, ProfileExtensions.ReadMemory<uint>((NativeReader)this, game.Memory.ProfileOffsets, "Social_media"));
    activeProfile6.socialmedia_sdb_id = (uint)num6;
    Info activeProfile7 = this.activeProfile;
    // ISSUE: reference to a compiler-generated field
    if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__6 == null)
    {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, byte>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(byte), typeof(ProfileRender)));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    int num7 = (int)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__6.Target((CallSite)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__6, ProfileExtensions.ReadMemory<byte>((NativeReader)this, game.Memory.ProfileOffsets, "Unlock_Flag"));
    activeProfile7.playability = (byte)num7;
    Info

 activeProfile8 = this.activeProfile;
    // ISSUE: reference to a compiler-generated field
    if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__7 == null)
    {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__7 = CallSite<Func<CallSite, object, byte>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(byte), typeof(ProfileRender)));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    int num8 = (int)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__7.Target((CallSite)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__7, ProfileExtensions.ReadMemory<byte>((NativeReader)this, game.Memory.ProfileOffsets, "Menu_Flag"));
    activeProfile8.menu_location = (byte)num8;
    this.activeProfile.additional_attire_names = new List<uint>();
    Info activeProfile9 = this.activeProfile;
    // ISSUE: reference to a compiler-generated field
    if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__8 == null)
    {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__8 = CallSite<Func<CallSite, object, byte>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(byte), typeof(ProfileRender)));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    int num9 = (int)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__8.Target((CallSite)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__8, ProfileExtensions.ReadMemory<byte>((NativeReader)this, game.Memory.ProfileOffsets, "Gender"));
    activeProfile9.gender = (byte)num9;
    Info activeProfile10 = this.activeProfile;
    // ISSUE: reference to a compiler-generated field
    if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__9 == null)
    {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__9 = CallSite<Func<CallSite, object, ushort>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(ushort), typeof(ProfileRender)));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    int num10 = (int)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__9.Target((CallSite)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__9, ProfileExtensions.ReadMemory<ushort>((NativeReader)this, game.Memory.ProfileOffsets, "Weight"));
    activeProfile10.weight = (ushort)num10;
    Info activeProfile11 = this.activeProfile;
    // ISSUE: reference to a compiler-generated field
    if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__10 == null)
    {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__10 = CallSite<Func<CallSite, object, byte>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(byte), typeof(ProfileRender)));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    int num11 = (int)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__10.Target((CallSite)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__10, ProfileExtensions.ReadMemory<byte>((NativeReader)this, game.Memory.ProfileOffsets, "Weight_Class"));
    activeProfile11.weight_class = (byte)num11;
    Info activeProfile12 = this.activeProfile;
    // ISSUE: reference to a compiler-generated field
    if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__11 == null)
    {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__11 = CallSite<Func<CallSite, object, byte>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(byte), typeof(ProfileRender)));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    int num12 = (int)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__11.Target((CallSite)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__11, ProfileExtensions.ReadMemory<byte>((NativeReader)this, game.Memory.ProfileOffsets, "Crowd_Balance"));
    activeProfile12.crowd_balance = (byte)num12;
    Info activeProfile13 = this.activeProfile;
    // ISSUE: reference to a compiler-generated field
    if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__12 == null)
    {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__12 = CallSite<Func<CallSite, object, byte>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(byte), typeof(ProfileRender)));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    int num13 = (int)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__12.Target((CallSite)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__12, ProfileExtensions.ReadMemory<byte>((NativeReader)this, game.Memory.ProfileOffsets, "Crowd_Reaction"));
    activeProfile13.crowd_reaction = (byte)num13;
    Info activeProfile14 = this.activeProfile;
    // ISSUE: reference to a compiler-generated field
    if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__13 == null)
    {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__13 = CallSite<Func<CallSite, object, List<uint>>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(List<uint>), typeof(ProfileRender)));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    List<uint> uintList = ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__13.Target((CallSite)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__13, ProfileExtensions.ReadMemoryArray<List<uint>>((NativeReader)this, game.Memory.ProfileOffsets, "Crowd_Signs", 40));
    activeProfile14.crowd_signs = uintList;
    Info activeProfile15 = this.activeProfile;
    // ISSUE: reference to a compiler-generated field
    if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__14 == null)
    {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__14 = CallSite<Func<CallSite, object, List<byte>>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(List<byte>), typeof(ProfileRender)));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    List<byte> byteList1 = ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__14.Target((CallSite)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__14, ProfileExtensions.ReadMemoryArray<List<byte>>((NativeReader)this, game.Memory.ProfileOffsets, "Ai_Attributes", 27));
    activeProfile15.ai_attributes = byteList1;
    Info activeProfile16 = this.activeProfile;
    // ISSUE: reference to a compiler-generated field
    if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__15 == null)
    {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__15 = CallSite<Func<CallSite, object, List<byte>>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(List<byte>), typeof(ProfileRender)));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    List<byte> byteList2 = ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__15.Target((CallSite)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__15, ProfileExtensions.ReadMemoryArray<List<byte>>((NativeReader)this, game.Memory

.ProfileOffsets, "Attributes", 24));
    activeProfile16.attributes = byteList2;
    Info activeProfile17 = this.activeProfile;
    // ISSUE: reference to a compiler-generated field
    if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__16 == null)
    {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__16 = CallSite<Func<CallSite, object, List<byte>>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(List<byte>), typeof(ProfileRender)));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    List<byte> byteList3 = ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__16.Target((CallSite)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__16, ProfileExtensions.ReadMemoryArray<List<byte>>((NativeReader)this, game.Memory.ProfileOffsets, "Hit_Point_Ratio", 4));
    activeProfile17.hit_point = byteList3;
    Info activeProfile18 = this.activeProfile;
    // ISSUE: reference to a compiler-generated field
    if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__17 == null)
    {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__17 = CallSite<Func<CallSite, object, List<byte>>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(List<byte>), typeof(ProfileRender)));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    List<byte> byteList4 = ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__17.Target((CallSite)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__17, ProfileExtensions.ReadMemoryArray<List<byte>>((NativeReader)this, game.Memory.ProfileOffsets, "Hit_Point_Ratio", 6));
    activeProfile18.personality_traits = byteList4;
    Info activeProfile19 = this.activeProfile;
    // ISSUE: reference to a compiler-generated field
    if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__18 == null)
    {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__18 = CallSite<Func<CallSite, object, uint>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(uint), typeof(ProfileRender)));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    int num14 = (int)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__18.Target((CallSite)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__18, ProfileExtensions.ReadMemory<uint>((NativeReader)this, game.Memory.ProfileOffsets, "Commentary_ID"));
    activeProfile19.commentary_id = (uint)num14;
    Info activeProfile20 = this.activeProfile;
    // ISSUE: reference to a compiler-generated field
    if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__19 == null)
    {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__19 = CallSite<Func<CallSite, object, uint>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(uint), typeof(ProfileRender)));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    int num15 = (int)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__19.Target((CallSite)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__19, ProfileExtensions.ReadMemory<uint>((NativeReader)this, game.Memory.ProfileOffsets, "Ring_Announcer_ID"));
    activeProfile20.announcer_id = (uint)num15;
    Info activeProfile21 = this.activeProfile;
    // ISSUE: reference to a compiler-generated field
    if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__20 == null)
    {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__20 = CallSite<Func<CallSite, object, uint>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(uint), typeof(ProfileRender)));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    int num16 = (int)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__20.Target((CallSite)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__20, ProfileExtensions.ReadMemory<uint>((NativeReader)this, game.Memory.ProfileOffsets, "Hometown"));
    activeProfile21.location_callname = (uint)num16;
    Info activeProfile22 = this.activeProfile;
    // ISSUE: reference to a compiler-generated field
    if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__21 == null)
    {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__21 = CallSite<Func<CallSite, object, byte>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(byte), typeof(ProfileRender)));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    int num17 = (int)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__21.Target((CallSite)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__21, ProfileExtensions.ReadMemory<byte>((NativeReader)this, game.Memory.ProfileOffsets, "Payback_1_Flag"));
    activeProfile22.payback_01 = (byte)num17;
    Info activeProfile23 = this.activeProfile;
    // ISSUE: reference to a compiler-generated field
    if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__22 == null)
    {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__22 = CallSite<Func<CallSite, object, byte>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(byte), typeof(ProfileRender)));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    int num18 = (int)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__22.Target((CallSite)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__22, ProfileExtensions.ReadMemory<byte>((NativeReader)this, game.Memory.ProfileOffsets, "Payback_2_Flag"));
    activeProfile23.payback_02 = (byte)num18;
    Info activeProfile24 = this.activeProfile;
    // ISSUE: reference to a compiler-generated field
    if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__24 == null)
    {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__24 = CallSite<Func<CallSite, object, double>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(double), typeof(ProfileRender)));
    }
    // ISSUE: reference to a compiler-generated field
    Func<CallSite, object, double> target = ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__24.Target;
    // ISSUE: reference to a compiler-generated field
    CallSite<Func<CallSite, object, double>> p24 = ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__24;
    // ISSUE: reference to a compiler-generated field
    if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__23 == null)
    {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__23 = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ConvertValueToHeight", (IEnumerable<Type>)null, typeof(ProfileRender), (IEnumerable<CSharpArgumentInfo>)new CSharpArgumentInfo[2]
        {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string)null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string)null)
        }));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field


    object obj = ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__23.Target((CallSite)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__23, typeof(HeightConverter), ProfileExtensions.ReadMemory<ushort>((NativeReader)this, game.Memory.ProfileOffsets, "Height"));
    double num19 = target((CallSite)p24, obj);
    activeProfile24.height = num19;
}
```

This method reads various pieces of data from the input stream and assigns them to the fields of the `activeProfile` object. It uses dynamic binding and the `Microsoft.CSharp.RuntimeBinder` namespace to handle the conversion and assignment of values.

### Explanation of Specific Parts

1. **Initialization of `activeProfile`**:

   ```csharp
   this.activeProfile = new Info();
   ```

2. **Reading and Assigning Data**:

   ```csharp
   if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__0 == null)
   {
       ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, ushort>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(ushort), typeof(ProfileRender)));
   }
   int num1 = (int)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__0.Target((CallSite)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__0, ProfileExtensions.ReadMemory<ushort>((NativeReader)this, game.Memory.ProfileOffsets, "Wrestler_ID"));
   activeProfile1.wrestler_id = (ushort)num1;
   ```

   This block uses a `CallSite` to dynamically bind the conversion of a value read from the stream to a `ushort`, and then assigns it to the `wrestler_id` field of the `activeProfile`.

3. **Similar Blocks for Other Fields**:
   The method contains similar blocks of code for reading and assigning values to other fields of the `activeProfile` object, such as `slot_id`, `wrestler_id_2`, `fullname_sdb_id`, etc.

4. **Special Case for Height Conversion**:

   ```csharp
   Func<CallSite, object, double> target = ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__24.Target;
   CallSite<Func<CallSite, object, double>> p24 = ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__24;
   if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__23 == null)
   {
       ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__23 = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ConvertValueToHeight", (IEnumerable<Type>)null, typeof(ProfileRender), (IEnumerable<CSharpArgumentInfo>)new CSharpArgumentInfo[2]
       {
           CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string)null),
           CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string)null)
       }));
   }
   object obj = ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__23.Target((CallSite)ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__23, typeof(HeightConverter), ProfileExtensions.ReadMemory<ushort>((NativeReader)this, game.Memory.ProfileOffsets, "Height"));
   double num19 = target((CallSite)p24, obj);
   activeProfile24.height = num19;
   ```

   This block handles the conversion of the height value using a static method `ConvertValueToHeight` from the `HeightConverter` class, which demonstrates a more complex dynamic binding operation.

### Summary

The `ProfileRender` class is designed to read profile data from a stream for the WWE 2K23 game. It initializes an `activeProfile` object and populates its fields by reading data from the stream, using dynamic binding for data conversion and assignment. This approach allows for flexible and dynamic data handling, albeit with more complexity and potentially less performance than static binding.

## /Meta/Editor/Plugin/Attributes/Plugin.cs

This C# code defines a `Plugin` class within the `Meta.Editor.Plugin` namespace. The `Plugin` class represents a plugin with various properties, including its author, name, icon, status, and version, which are extracted from custom attributes of the associated assembly. Here’s a detailed breakdown of the code:

1. **Namespace Declarations**:

   ```csharp
   using Meta.Editor.Plugin.Attributes;
   using System;
   using System.IO;
   using System.Reflection;
   ```

   These `using` directives import necessary namespaces for working with attributes, general system functions, file I/O, and reflection.

2. **Nullable Context**:

   ```csharp
   #nullable enable
   ```

   This directive enables nullable reference types to improve null safety.

3. **Namespace Declaration**:

   ```csharp
   namespace Meta.Editor.Plugin
   ```

   This specifies that the `Plugin` class belongs to the `Meta.Editor.Plugin` namespace.

4. **Class Definition**:

   ```csharp
   public class Plugin
   ```

### Properties and Methods

1. **Author Property**:

   ```csharp
   public string Author
   {
     get
     {
       Assembly assembly = this.Assembly;
       string author = (object) assembly != null ? assembly.GetCustomAttribute<PluginAuthorAttribute>()?.Author : (string) null;
       return !string.IsNullOrEmpty(author) ? author : "Unknown";
     }
   }
   ```

   - **Purpose**: Retrieves the author's name from the `PluginAuthorAttribute` of the assembly. If not found, returns "Unknown".
   - **Mechanism**: Uses reflection to get the `PluginAuthorAttribute` from the assembly and reads the `Author` property.

2. **Assembly Property**:

   ```csharp
   public Assembly Assembly { get; set; }
   ```

   - **Purpose**: Holds the reference to the plugin’s assembly.
   - **Access**: Public getter and setter.

3. **LoadException Property**:

   ```csharp
   public Exception LoadException { get; set; }
   ```

   - **Purpose**: Stores any exception that occurred during the loading of the plugin.
   - **Access**: Public getter and setter.

4. **Name Property**:

   ```csharp
   public string Name
   {
     get
     {
       Assembly assembly = this.Assembly;
       string displayName = (object) assembly != null ? assembly.GetCustomAttribute<PluginDisplayNameAttribute>()?.DisplayName : (string) null;
       return !string.IsNullOrEmpty(displayName) ? displayName : Path.GetFileNameWithoutExtension(this.SourcePath);
     }
   }
   ```

   - **Purpose**: Retrieves the display name of the plugin from the `PluginDisplayNameAttribute`. If not found, uses the file name of the source path.
   - **Mechanism**: Uses reflection to get the `PluginDisplayNameAttribute` from the assembly and reads the `DisplayName` property.

5. **SourcePath Property**:

   ```csharp
   public string SourcePath { get; private set; }
   ```

   - **Purpose**: Stores the file path of the plugin source.
   - **Access**: Public getter and private setter.

6. **Icon Property**:

   ```csharp
   public string Icon
   {
     get
     {
       Assembly assembly = this.Assembly;
       string icon = (object) assembly != null ? assembly.GetCustomAttribute<PluginIconAttribute>()?.Icon : (string) null;
       return !string.IsNullOrEmpty(icon) ? icon : "Tools";
     }
   }
   ```

   - **Purpose**: Retrieves the icon name from the `PluginIconAttribute`. If not found, returns "Tools".
   - **Mechanism**: Uses reflection to get the `PluginIconAttribute` from the assembly and reads the `Icon` property.

7. **Status Property**:

   ```csharp
   public PluginLoadStatus Status { get; set; }
   ```

   - **Purpose**: Stores the status of the plugin.
   - **Access**: Public getter and setter.

8. **Version Property**:

   ```csharp
   public string Version
   {
     get
     {
       Assembly assembly = this.Assembly;
       string version = (object) assembly != null ? assembly.GetCustomAttribute<PluginVersionAttribute>()?.Version : (string) null;
       return !string.IsNullOrEmpty(version) ? version : "1.0.0.0";
     }
   }
   ```

   - **Purpose**: Retrieves the version of the plugin from the `PluginVersionAttribute`. If not found, returns "1.0.0.0".
   - **Mechanism**: Uses reflection to get the `PluginVersionAttribute` from the assembly and reads the `Version` property.

9. **Constructor**:

   ```csharp
   public Plugin(Assembly assembly, string sourcePath)
   {
     this.Assembly = assembly;
     this.SourcePath = sourcePath;
   }
   ```

   - **Purpose**: Initializes a new instance of the `Plugin` class with the provided assembly and source path.
   - **Parameters**:
     - `assembly`: The assembly associated with the plugin.
     - `sourcePath`: The file path of the plugin source.

### Summary

The `Plugin` class encapsulates various properties of a plugin, such as its author, name, icon, status, and version, by extracting this information from custom attributes applied to the assembly. This design allows for easy retrieval of metadata about the plugin, which can be useful in a modular application where plugins can be dynamically loaded and managed.

## /Meta/Editor/Plugin/Attributes/Plugin/PluginAuthorAttribute.cs

This C# code defines a custom attribute named `PluginAuthorAttribute` within the `Meta.Editor.Plugin.Attributes` namespace. Attributes in C# are used to add metadata to code elements such as classes, methods, assemblies, etc. Here’s a detailed explanation of each part of the code:

### `using System;`

This line imports the System namespace, which includes the definition for the `Attribute` class. This is necessary because the custom attribute will inherit from the `Attribute` class.

### `#nullable enable`

This directive enables nullable reference types, allowing the compiler to enforce nullability rules to help prevent `null` reference errors.

### `namespace Meta.Editor.Plugin.Attributes`

This defines a namespace `Meta.Editor.Plugin.Attributes`. Namespaces are used to organize code into a hierarchical structure and to prevent name conflicts.

### `[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]`

This line is an attribute usage constraint for the custom attribute. It specifies that `PluginAuthorAttribute` can only be applied to assemblies (`AttributeTargets.Assembly`) and not to other elements like classes or methods. It also specifies that this attribute can only be used once per assembly (`AllowMultiple = false`).

### `public class PluginAuthorAttribute : Attribute`

This line declares the `PluginAuthorAttribute` class, which inherits from the `Attribute` class. This makes it a custom attribute that can be applied to assemblies.

### `public string Author { get; private set; }`

This line declares a public property `Author` of type `string`. The `private set` modifier means that the property can only be set within the class itself, making it read-only from outside the class.

### `public PluginAuthorAttribute(string author) => this.Author = author;`

This is the constructor for the `PluginAuthorAttribute` class. It takes a single parameter `author` of type `string` and assigns it to the `Author` property. This means that when the attribute is applied, it must be given a string value representing the author.

### Summary

The `PluginAuthorAttribute` is a custom attribute designed to be applied to assemblies. It takes a single argument, a string representing the author, and stores it in a read-only property called `Author`. This attribute can be used to provide metadata about the author of an assembly, and it is designed to be used only once per assembly.

## /Meta/Editor/Plugin/Attributes/Plugin/PluginDisplayNameAttribute.cs

This C# code defines a custom attribute `PluginDisplayNameAttribute` within the `Meta.Editor.Plugin.Attributes` namespace. Here's a detailed breakdown of the code:

1. **Namespace Declaration**:

   ```csharp
   namespace Meta.Editor.Plugin.Attributes
   ```

   This specifies that the code belongs to the `Meta.Editor.Plugin.Attributes` namespace, organizing it within a logical structure.

2. **Nullable Context**:

   ```csharp
   #nullable enable
   ```

   This directive enables nullable reference types. It allows the code to differentiate between nullable and non-nullable reference types, improving the ability to avoid null reference exceptions.

3. **AttributeUsage Attribute**:

   ```csharp
   [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
   ```

   This attribute specifies that the `PluginDisplayNameAttribute` can only be applied to an assembly (`AttributeTargets.Assembly`) and cannot be applied multiple times to the same assembly (`AllowMultiple = false`).

4. **Class Definition**:

   ```csharp
   public class PluginDisplayNameAttribute : Attribute
   ```

   This defines the `PluginDisplayNameAttribute` class, which inherits from the base `Attribute` class. This inheritance makes `PluginDisplayNameAttribute` a custom attribute.

5. **Property**:

   ```csharp
   public string DisplayName { get; private set; }
   ```

   This defines a public, read-only property `DisplayName` of type `string`. The `private set` accessor means that this property can only be set within the class itself.

6. **Constructor**:

   ```csharp
   public PluginDisplayNameAttribute(string displayName) => this.DisplayName = displayName;
   ```

   This is the constructor for the `PluginDisplayNameAttribute` class. It takes a single parameter `displayName` of type `string` and assigns it to the `DisplayName` property.

### Summary

The `PluginDisplayNameAttribute` is a custom attribute designed to hold a display name for a plugin. It can be applied to assemblies and ensures that the display name is set when the attribute is used. This can be useful for providing metadata about plugins in a modular application.

## /Meta/Editor/Plugin/Attributes/Plugin/PluginIconAttribute.cs

This C# code defines a custom attribute called `PluginIconAttribute` within the `Meta.Editor.Plugin.Attributes` namespace. Attributes in C# are used to add metadata to your code elements such as classes, methods, assemblies, etc. Here’s a breakdown of what each part of the code does:

### `using System;`

This line imports the System namespace, which includes the definition for the `Attribute` class. This is necessary because the custom attribute will inherit from the `Attribute` class.

### `#nullable enable`

This directive enables nullable reference types, which means that the compiler will enforce nullability rules to help prevent `null` reference errors.

### `namespace Meta.Editor.Plugin.Attributes`

This defines a namespace `Meta.Editor.Plugin.Attributes`. Namespaces are used to organize code into a hierarchical structure, preventing name conflicts.

### `[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]`

This line is a usage constraint for the custom attribute. It specifies that `PluginIconAttribute` can only be applied to assemblies (`AttributeTargets.Assembly`) and not to other elements like classes or methods. It also specifies that this attribute can only be used once per assembly (`AllowMultiple = false`).

### `public class PluginIconAttribute : Attribute`

This line declares the `PluginIconAttribute` class, which inherits from the `Attribute` class. This makes it a custom attribute that can be applied to assemblies.

### `public string Icon { get; private set; }`

This line declares a public property `Icon` of type `string`. The `private set` modifier means that the property can only be set within the class itself, making it read-only from outside the class.

### `public PluginIconAttribute(string icon) => this.Icon = icon;`

This is the constructor for the `PluginIconAttribute` class. It takes a single parameter `icon` of type `string` and assigns it to the `Icon` property. This means that when the attribute is applied, it must be given a string value representing the icon.

### Summary

The `PluginIconAttribute` is a custom attribute designed to be applied to assemblies. It takes a single argument, a string representing the icon, and stores it in a read-only property called `Icon`. This attribute can be used to provide metadata about the icon associated with an assembly, and it is designed to be used only once per assembly.

## /Meta/Editor/Plugin/Attributes/Plugin/PluginVersionAttribute.cs

The provided code defines a custom attribute `PluginVersionAttribute` within a namespace `Meta.Editor.Plugin.Attributes` in C#. This attribute is used to specify a version number for a plugin assembly. Below is a detailed explanation of each part of the code:

### Using Directives

```csharp
using System;
```

- This statement includes the `System` namespace, which provides fundamental classes and base classes that define commonly used data types, events, and event handlers, interfaces, attributes, and processing exceptions.

### Nullable Context

```csharp
#nullable enable
```

- This directive enables nullable reference types. With this enabled, reference types (like `string`) can be explicitly marked as nullable or non-nullable, helping to avoid null reference errors.

### Namespace Declaration

```csharp
namespace Meta.Editor.Plugin.Attributes
{
```

- This declares a namespace `Meta.Editor.Plugin.Attributes`. Namespaces are used to organize code into a hierarchical structure and prevent naming conflicts.

### Attribute Declaration

```csharp
  [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
  public class PluginVersionAttribute : Attribute
  {
```

- `[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]` is an attribute that specifies how the `PluginVersionAttribute` can be used:
  - `AttributeTargets.Assembly` indicates that this attribute can only be applied to an assembly.
  - `AllowMultiple = false` indicates that only one instance of this attribute can be applied to a single assembly.
- `public class PluginVersionAttribute : Attribute` declares a public class `PluginVersionAttribute` that inherits from the base class `Attribute`.

### Property Declaration

```csharp
    public string Version { get; private set; }
```

- This declares a public property `Version` of type `string` with a private setter. This means the property can be read from outside the class but can only be set from within the class itself.

### Constructor

```csharp
    public PluginVersionAttribute(string version) => this.Version = version;
```

- This is a constructor for the `PluginVersionAttribute` class that takes a `string` parameter `version`.
- The `this.Version = version;` line assigns the value of the `version` parameter to the `Version` property.

### Closing Braces

```csharp
  }
}
```

- These close the `PluginVersionAttribute` class and the `Meta.Editor.Plugin.Attributes` namespace.

### Summary

- This custom attribute, `PluginVersionAttribute`, is designed to store version information for a plugin. It can be applied to an assembly, and the version string can be accessed via the `Version` property. This attribute helps in managing and identifying the version of a plugin within an assembly.

## /Meta/Editor/Plugin/Attributes/Plugin/RegisterMenuExtensionAttribute.cs

The provided C# code defines a custom attribute named `RegisterMenuExtensionAttribute` within the `Meta.Editor.Plugin.Attributes` namespace. Let's break down the key elements of this code:

### 1. Namespaces and Nullable Context

```csharp
using System;

#nullable enable
namespace Meta.Editor.Plugin.Attributes
```

- `using System;`: This statement includes the `System` namespace, which contains fundamental classes and base classes that define commonly-used value and reference data types, events, and event handlers, interfaces, attributes, and processing exceptions.
- `#nullable enable`: This directive enables nullable reference types context for the code that follows. This helps in identifying potential `null` reference exceptions at compile time, making the code safer and more robust.

### 2. Custom Attribute Definition

```csharp
[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
public class RegisterMenuExtensionAttribute : Attribute
```

- `[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]`: This is an `AttributeUsage` attribute applied to the `RegisterMenuExtensionAttribute` class. It specifies how the custom attribute can be used:

  - `AttributeTargets.Assembly`: The attribute can be applied at the assembly level.
  - `AllowMultiple = true`: Multiple instances of this attribute can be applied to a single target.
  - `Inherited = false`: The attribute is not inherited by derived classes.

- `public class RegisterMenuExtensionAttribute : Attribute`: This line defines a new attribute class named `RegisterMenuExtensionAttribute` that inherits from the `Attribute` base class. In C#, custom attributes are created by inheriting from the `System.Attribute` class.

### 3. Properties and Constructor

```csharp
{
  public Type MenuExtensionType { get; private set; }

  public RegisterMenuExtensionAttribute(Type type) => this.MenuExtensionType = type;
}
```

- `public Type MenuExtensionType { get; private set; }`: This property holds the `Type` of the menu extension. It is `public` for reading but `private` for setting, meaning it can only be set within the class itself.
- `public RegisterMenuExtensionAttribute(Type type) => this.MenuExtensionType = type;`: This is the constructor of the `RegisterMenuExtensionAttribute` class. It takes a `Type` as a parameter and assigns it to the `MenuExtensionType` property. This constructor allows the attribute to be initialized with a specific type representing a menu extension.

### Usage Example

Here's how you might use this custom attribute in an assembly:

```csharp
[assembly: Meta.Editor.Plugin.Attributes.RegisterMenuExtensionAttribute(typeof(MyMenuExtension))]
```

In this example, `MyMenuExtension` is a type that represents a menu extension being registered with the assembly.

### Summary

- The `RegisterMenuExtensionAttribute` is a custom attribute designed to be used at the assembly level.
- It holds a `Type` representing a menu extension.
- It allows multiple instances to be applied to the same assembly and is not inherited by derived classes.
- The `#nullable enable` directive ensures that nullability is properly handled, enhancing code safety.

This attribute can be useful in scenarios where you need to register multiple menu extensions within an application, particularly in a plugin or modular architecture.

## /Meta/Editor/Properties/Resources.cs

The provided code is a C# class that is part of a strongly-typed resource file for a .NET application. It is automatically generated to provide a convenient way to manage and access resources such as strings, images, and other types of files in the application. Here's a detailed explanation:

### Namespaces and Directives

1. **Namespaces**:

   - `System.CodeDom.Compiler`: Provides types for generating, compiling, and managing code.
   - `System.ComponentModel`: Contains classes that implement the run-time and design-time behavior of components and controls.
   - `System.Diagnostics`: Provides classes for interaction with system processes, event logs, and performance counters.
   - `System.Globalization`: Contains classes that define culture-related information, including language, country/region, calendars, and formats for dates and numbers.
   - `System.Resources`: Provides classes and interfaces for managing resources such as strings, images, and persisted objects.
   - `System.Runtime.CompilerServices`: Provides functionality for compiler writers using managed code.

2. **Attributes**:
   - `[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]`: Indicates that the class was generated by the StronglyTypedResourceBuilder tool.
   - `[DebuggerNonUserCode]`: Indicates that the method is not user code and should not be stepped into during debugging.
   - `[CompilerGenerated]`: Indicates that the class or member was generated by the compiler.

### Class Definition

The `Resources` class is an internal class within the `Meta.Editor.Properties` namespace.

#### Fields

- `private static ResourceManager resourceMan;`: A static field to hold the `ResourceManager` instance.
- `private static CultureInfo resourceCulture;`: A static field to hold the `CultureInfo` instance.

#### Constructor

- `internal Resources() { }`: An internal constructor to prevent instantiation of the class.

#### Properties

- `internal static ResourceManager ResourceManager`: A property to get the `ResourceManager` instance.

  - If `resourceMan` is `null`, it initializes it with a new `ResourceManager` instance for the specified resource file (`Meta.Editor.Properties.Resources`).
  - Returns the `resourceMan`.

- `internal static CultureInfo Culture`: A property to get or set the `CultureInfo` instance.
  - The getter returns `resourceCulture`.
  - The setter assigns a value to `resourceCulture`.

### Purpose

The purpose of this class is to provide a centralized and type-safe way to access resources (like strings, images, etc.) within the application. It encapsulates the resource management logic, making it easy to retrieve resources without directly dealing with the `ResourceManager` and culture settings.

This pattern is commonly used in .NET applications to manage localization and globalization, ensuring that resources can be easily accessed and modified as per the application's requirements.

## /Meta/Editor/Properties/Resources.resx

This XML document is a .resx (resource) file used in .NET applications to manage resources like strings, images, and other data used within the application. Here's a detailed breakdown of its components:

### Overview

- **Purpose**: This file format allows for a simple, human-readable way to store various types of data. It's primarily used for localization and managing resources in .NET applications.
- **Structure**: The file contains several XML elements that store resource data, headers with metadata, and a schema definition.

### Components

#### XML Declaration

```xml
<?xml version="1.0" encoding="utf-8"?>
```

This line declares the XML version and the character encoding used.

#### Root Element

```xml
<root>
```

The root element encapsulates all other elements within the file.

#### Comment Section

```xml
<!--
    Microsoft ResX Schema

    Version 2.0
    ...
-->
```

This comment provides metadata about the ResX schema, including its version, purpose, and an example of its usage.

#### Schema Definition

```xml
<xsd:schema id="root" xmlns="" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
    <xsd:import namespace="http://www.w3.org/XML/1998/namespace" />
    <xsd:element name="root" msdata:IsDataSet="true">
        ...
    </xsd:element>
</xsd:schema>
```

This section defines the XML Schema (XSD) for the .resx file, specifying the structure and data types for the elements contained within the `root` element.

#### Resource Headers

```xml
<resheader name="resmimetype">
    <value>text/microsoft-resx</value>
</resheader>
<resheader name="version">
    <value>2.0</value>
</resheader>
<resheader name="reader">
    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
</resheader>
<resheader name="writer">
    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
</resheader>
```

These `resheader` elements provide metadata about the .resx file, such as:

- `resmimetype`: Specifies the MIME type of the resource file.
- `version`: The version of the ResX schema.
- `reader`: The class used to read the resources.
- `writer`: The class used to write the resources.

### Key Elements in the Schema

#### `metadata` Element

Defines metadata elements with attributes like `name`, `type`, and `mimetype`.

```xml
<xsd:element name="metadata">
    ...
</xsd:element>
```

#### `assembly` Element

Defines assembly references within the resource file.

```xml
<xsd:element name="assembly">
    ...
</xsd:element>
```

#### `data` Element

Defines the actual data stored in the resource file, with attributes like `name`, `type`, and `mimetype`.

```xml
<xsd:element name="data">
    ...
</xsd:element>
```

#### `resheader` Element

Defines headers for the resource file.

```xml
<xsd:element name="resheader">
    ...
</xsd:element>
```

### Example Data

The example provided in the comment shows various types of data that can be stored in a .resx file:

- Simple strings
- Colors
- Binary serialized objects
- Icons

### Summary

This .resx file is designed to store various resources for a .NET application, using a structured XML format that supports different data types and metadata. The schema and headers provide information on how to read and write these resources, ensuring compatibility with .NET frameworks and tools.

## /Meta/Editor/Windows/HashGenWindow.cs

Let's break down this more extensive code snippet step by step.

### Using Directives

```csharp
using Meta.Editor.Controls;
using MetaEditor;
using Microsoft.Win32;
using Ookii.Dialogs.Wpf;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
```

These lines import various namespaces that are used within the code. These namespaces provide access to different classes and methods:

- `Meta.Editor.Controls` and `MetaEditor`: Custom namespaces likely containing controls and other functionality related to the "Meta" project.
- `Microsoft.Win32`: Provides classes to interact with Windows registry and file dialogs.
- `Ookii.Dialogs.Wpf`: Provides classes for dialog boxes, such as the folder browser dialog.
- `System`, `System.CodeDom.Compiler`, `System.ComponentModel`, `System.Diagnostics`, `System.Windows`, `System.Windows.Controls`, `System.Windows.Markup`: Standard .NET namespaces providing core functionality, code generation, component model support, debugging support, and WPF (Windows Presentation Foundation) controls and markup handling.

### `#nullable enable`

This directive enables nullable reference types in the entire file.

### Namespace Declaration

```csharp
namespace Meta.Editor.Windows
{
  ...
}
```

This defines the namespace `Meta.Editor.Windows`, grouping related classes and avoiding naming conflicts.

### Class Declaration

```csharp
public class HashGenWindow : MetaWindow, IComponentConnector
{
  ...
}
```

This defines the `HashGenWindow` class, which inherits from `MetaWindow` and implements the `IComponentConnector` interface. `MetaWindow` is likely a custom window class, and `IComponentConnector` is an interface used in WPF for component connection.

### Internal Fields

```csharp
internal
#nullable disable
TextBox PathInput;
internal Button OpenFileBtn;
internal Button OpenFolderBtn;
internal TextBlock FormattedPath;
internal TextBox modTitleTextBox;
private bool _contentLoaded;
```

These are internal fields used within the class. The `#nullable disable` directive temporarily disables nullable reference types for these fields, meaning they can be `null` without warnings.

### Constructor

```csharp
public HashGenWindow()
{
  this.InitializeComponent();
  this.OpenFileBtn.Click += new RoutedEventHandler(this.OpenFileBtn_Click);
  this.OpenFolderBtn.Click += new RoutedEventHandler(this.OpenFolderBtn_Click);
}
```

The constructor initializes the component and attaches event handlers to the `Click` events of the `OpenFileBtn` and `OpenFolderBtn`.

### Event Handlers

```csharp
private void OpenFolderBtn_Click(
#nullable enable
object sender, RoutedEventArgs e)
{
  VistaFolderBrowserDialog folderBrowserDialog = new VistaFolderBrowserDialog();
  folderBrowserDialog.Description = "Please select a folder.";
  folderBrowserDialog.UseDescriptionForTitle = true;
  bool? nullable = folderBrowserDialog.ShowDialog();
  if (!(1 == (nullable.GetValueOrDefault() ? 1 : 0) & nullable.HasValue))
    return;
  this.PathInput.Text = folderBrowserDialog.SelectedPath;
}

private void OpenFileBtn_Click(object sender, RoutedEventArgs e)
{
  OpenFileDialog openFileDialog1 = new OpenFileDialog();
  openFileDialog1.Title = "Open File";
  OpenFileDialog openFileDialog2 = openFileDialog1;
  bool? nullable = openFileDialog2.ShowDialog();
  bool flag = true;
  if (!(nullable.GetValueOrDefault() == flag & nullable.HasValue))
    return;
  this.PathInput.Text = openFileDialog2.FileName;
}

private void PathInput_SelectionChanged(object sender, RoutedEventArgs e)
{
  string formatted = "";
  this.modTitleTextBox.Text = this.PathInput.Text.Hash(App.CurrentGame.Folders, out formatted).ToString();
  this.FormattedPath.Text = string.Format("Formatted: {0} ", (object) formatted);
}
```

These methods handle events:

- `OpenFolderBtn_Click`: Opens a folder browser dialog and sets the `PathInput` text to the selected path.
- `OpenFileBtn_Click`: Opens a file dialog and sets the `PathInput` text to the selected file.
- `PathInput_SelectionChanged`: Handles text changes in `PathInput`, hashes the text, and updates `modTitleTextBox` and `FormattedPath`.

### Component Initialization

```csharp
[DebuggerNonUserCode]
[GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
public void InitializeComponent()
{
  if (this._contentLoaded)
    return;
  this._contentLoaded = true;
  Application.LoadComponent((object) this, new Uri("/Meta.Editor;V1.0.5.32;component/windows/hashgenwindow.xaml", UriKind.Relative));
}
```

This method loads the XAML component associated with the `HashGenWindow`. It ensures the component is only loaded once.

### Delegate Creation

```csharp
[DebuggerNonUserCode]
[GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
internal
#nullable disable
Delegate _CreateDelegate(Type delegateType, string handler)
{
  return Delegate.CreateDelegate(delegateType, (object) this, handler);
}
```

This method creates a delegate for a given handler. The `#nullable disable` directive ensures nullable warnings are suppressed for this method.

### Component Connection

```csharp
[DebuggerNonUserCode]
[GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
[EditorBrowsable(EditorBrowsableState.Never)]
void IComponentConnector.Connect(int connectionId, object target)
{
  switch (connectionId)
  {
    case 1:
      this.PathInput = (TextBox) target;
      this.PathInput.TextChanged += new TextChangedEventHandler(this.PathInput_SelectionChanged);
      break;
    case 2:
      this.OpenFileBtn = (Button) target;
      break;
    case 3:
      this.OpenFolderBtn = (Button) target;
      break;
    case 4:
      this.FormattedPath = (TextBlock) target;
      break;
    case 5:
      this.modTitleTextBox = (TextBox) target;
      break;
    default:
      this._contentLoaded = true;
      break;
  }
}
```

This method connects the components (controls) to their respective fields and sets up event handlers. The `switch` statement uses `connectionId` to determine which component to connect.

### Summary

This code defines a WPF window class `HashGenWindow` that allows users to select a file or folder, input a path, and display a hashed version of the path. It uses delegates for event handling, initializes components from XAML, and connects UI elements to code-behind methods for interaction. The use of nullable reference types ensures safer code by handling potential `null` references appropriately.

## /Meta/Editor/Windows/InputWindow.cs

Sure, let's break down the provided C# code step by step:

### Using Directives

```csharp
using Meta.Editor.Controls;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
```

These lines bring various namespaces into scope. They allow you to use the classes and methods defined in these namespaces without fully qualifying their names.

### Nullable Context

```csharp
#nullable enable
```

This directive enables nullable reference types for the rest of the file. It allows the compiler to give warnings about potential null reference issues.

### Namespace Declaration

```csharp
namespace Meta.Editor.Windows
```

This line declares a namespace called `Meta.Editor.Windows`. Namespaces are used to organize code into a hierarchical structure and prevent naming conflicts.

### Class Declaration

```csharp
public class InputWindow : MetaWindow, IComponentConnector
```

This line declares a public class `InputWindow` that inherits from `MetaWindow` and implements the `IComponentConnector` interface.

### Fields and Properties

```csharp
internal Label lblQuestion;
internal TextBox txtAnswer;
internal Button btnDialogOk;
private bool _contentLoaded;
```

These are internal fields used within the class:

- `lblQuestion`: A `Label` control.
- `txtAnswer`: A `TextBox` control.
- `btnDialogOk`: A `Button` control.
- `_contentLoaded`: A boolean flag indicating whether the content is loaded.

### Constructor

```csharp
public InputWindow(string question, string defaultAnswer = "")
{
    this.InitializeComponent();
    this.lblQuestion.Content = (object) question;
    this.txtAnswer.Text = defaultAnswer;
}
```

The constructor initializes an instance of `InputWindow`:

- It calls `InitializeComponent()` to load and initialize the XAML components.
- It sets the content of `lblQuestion` to the provided `question`.
- It sets the text of `txtAnswer` to the provided `defaultAnswer`.

### Event Handlers

```csharp
private void btnDialogOk_Click(object sender, RoutedEventArgs e)
{
    this.DialogResult = new bool?(true);
}

private void Window_ContentRendered(object sender, EventArgs e)
{
    this.txtAnswer.SelectAll();
    this.txtAnswer.Focus();
}
```

These methods handle events:

- `btnDialogOk_Click`: Sets the dialog result to `true` when the OK button is clicked.
- `Window_ContentRendered`: Selects all text in `txtAnswer` and sets the focus to it when the content is rendered.

### Property

```csharp
public string Answer => this.txtAnswer.Text;
```

This property returns the text entered in `txtAnswer`.

### InitializeComponent Method

```csharp
[DebuggerNonUserCode]
[GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
public void InitializeComponent()
{
    if (this._contentLoaded)
        return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/Meta.Editor;V1.0.5.32;component/windows/inputwindow.xaml", UriKind.Relative));
}
```

This method loads the XAML components for the window:

- It checks if the content is already loaded to avoid reloading.
- It sets `_contentLoaded` to `true`.
- It calls `Application.LoadComponent` to load the XAML file associated with this window.

### Delegate Creation Method

```csharp
[DebuggerNonUserCode]
[GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
internal Delegate _CreateDelegate(Type delegateType, string handler)
{
    return Delegate.CreateDelegate(delegateType, (object) this, handler);
}
```

This internal method creates a delegate of the specified type and handler name. It's used internally by the WPF framework to wire up event handlers.

### IComponentConnector Implementation

```csharp
[DebuggerNonUserCode]
[GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
[EditorBrowsable(EditorBrowsableState.Never)]
void IComponentConnector.Connect(int connectionId, object target)
{
    switch (connectionId)
    {
        case 1:
            this.lblQuestion = (Label) target;
            break;
        case 2:
            this.txtAnswer = (TextBox) target;
            break;
        case 3:
            this.btnDialogOk = (Button) target;
            break;
        default:
            this._contentLoaded = true;
            break;
    }
}
```

This method connects the controls defined in XAML to their respective fields:

- It takes a connection ID and target object.
- Depending on the connection ID, it assigns the target to the appropriate field.

### Summary

This `InputWindow` class is a WPF window designed to prompt the user with a question and receive an answer. It initializes and handles various UI controls such as labels, text boxes, and buttons, and provides mechanisms for handling events and retrieving the user's input. The `IComponentConnector` interface and associated methods are used by the WPF framework to wire up the controls and events defined in XAML.

## /Meta/Editor/Windows/MetaSchemaCallback.cs

### Code Explanation

#### Nullable Context

```csharp
#nullable enable
```

This directive enables nullable reference types for the entire file. It allows the compiler to give warnings about potential null reference issues. This feature is part of C# 8.0 and later.

#### Namespace Declaration

```csharp
namespace Meta.Editor.Windows
```

This line declares a namespace called `Meta.Editor.Windows`. Namespaces are used to organize code into a hierarchical structure and prevent naming conflicts.

#### Delegate Declaration

```csharp
public delegate void MetaSchemaCallback(MetaSchemaWindow owner);
```

This line declares a delegate named `MetaSchemaCallback`. Here's what each part means:

- `public`: The delegate is accessible from other classes.
- `delegate`: This keyword is used to define a delegate, which is a type that represents references to methods with a specific parameter list and return type.
- `void`: The delegate does not return any value.
- `MetaSchemaCallback`: The name of the delegate.
- `(MetaSchemaWindow owner)`: The delegate takes a single parameter of type `MetaSchemaWindow`.

A delegate in C# is similar to a function pointer in other languages like C/C++, but it is type-safe and secure. Delegates are used to pass methods as arguments to other methods, create callback methods, or define event handlers.

### Context

In this specific context:

- The namespace `Meta.Editor.Windows` might be part of a larger application related to editing meta schemas, possibly in a graphical user interface or editor tool.
- The delegate `MetaSchemaCallback` is designed to represent methods that take a `MetaSchemaWindow` object as a parameter and perform some action without returning a value.

### Usage Example

To provide a complete picture, here's a simple example of how this delegate might be used:

#### Defining the Method

```csharp
public class MetaSchemaWindow
{
    public void ExampleMethod()
    {
        // Method implementation
    }
}
```

#### Using the Delegate

```csharp
public class ExampleUsage
{
    public void ExecuteCallback(MetaSchemaCallback callback, MetaSchemaWindow window)
    {
        // Invoke the callback with the window instance
        callback(window);
    }

    public void Example()
    {
        MetaSchemaWindow window = new MetaSchemaWindow();
        MetaSchemaCallback callback = window.ExampleMethod;

        ExecuteCallback(callback, window);
    }
}
```

In this example:

- `MetaSchemaWindow` is a class with a method `ExampleMethod`.
- The `ExecuteCallback` method takes a `MetaSchemaCallback` delegate and a `MetaSchemaWindow` instance, then invokes the callback with the provided window.
- The `Example` method demonstrates creating a `MetaSchemaWindow` instance, assigning its `ExampleMethod` to a `MetaSchemaCallback` delegate, and then passing this delegate to the `ExecuteCallback` method.

## /Meta/Editor/Windows/MetaSchemaCancelCallback.cs

### Code Explanation

#### Nullable Context

```csharp
#nullable enable
```

This directive enables nullable reference types for the entire file. It allows the compiler to give warnings about potential null reference issues. This feature is part of C# 8.0 and later.

#### Namespace Declaration

```csharp
namespace Meta.Editor.Windows
```

This line declares a namespace called `Meta.Editor.Windows`. Namespaces are used to organize code into a hierarchical structure and prevent naming conflicts.

#### Delegate Declaration

```csharp
public delegate void MetaSchemaCallback(MetaSchemaWindow owner);
```

This line declares a delegate named `MetaSchemaCallback`. Here's what each part means:

- `public`: The delegate is accessible from other classes.
- `delegate`: This keyword is used to define a delegate, which is a type that represents references to methods with a specific parameter list and return type.
- `void`: The delegate does not return any value.
- `MetaSchemaCallback`: The name of the delegate.
- `(MetaSchemaWindow owner)`: The delegate takes a single parameter of type `MetaSchemaWindow`.

A delegate in C# is similar to a function pointer in other languages like C/C++, but it is type-safe and secure. Delegates are used to pass methods as arguments to other methods, create callback methods, or define event handlers.

### Context

In this specific context:

- The namespace `Meta.Editor.Windows` might be part of a larger application related to editing meta schemas, possibly in a graphical user interface or editor tool.
- The delegate `MetaSchemaCallback` is designed to represent methods that take a `MetaSchemaWindow` object as a parameter and perform some action without returning a value.

### Usage Example

To provide a complete picture, here's a simple example of how this delegate might be used:

#### Defining the Method

```csharp
public class MetaSchemaWindow
{
    public void ExampleMethod()
    {
        // Method implementation
    }
}
```

#### Using the Delegate

```csharp
public class ExampleUsage
{
    public void ExecuteCallback(MetaSchemaCallback callback, MetaSchemaWindow window)
    {
        // Invoke the callback with the window instance
        callback(window);
    }

    public void Example()
    {
        MetaSchemaWindow window = new MetaSchemaWindow();
        MetaSchemaCallback callback = window.ExampleMethod;

        ExecuteCallback(callback, window);
    }
}
```

In this example:

- `MetaSchemaWindow` is a class with a method `ExampleMethod`.
- The `ExecuteCallback` method takes a `MetaSchemaCallback` delegate and a `MetaSchemaWindow` instance, then invokes the callback with the provided window.
- The `Example` method demonstrates creating a `MetaSchemaWindow` instance, assigning its `ExampleMethod` to a `MetaSchemaCallback` delegate, and then passing this delegate to the `ExecuteCallback` method.

## /Meta/Editor/Windows/MetaSchemaFailedCallback.cs

Certainly! Let's break down the code snippet you provided step by step:

### `#nullable enable`

This directive enables nullable reference types in C#. It allows the code to explicitly specify whether a reference type can be `null`. When nullable reference types are enabled, the compiler will issue warnings if it detects potential `null` dereference issues. This helps to write safer and more reliable code by preventing `null` reference exceptions.

### `namespace Meta.Editor.Windows`

This line defines a namespace. Namespaces are used to organize code into a logical hierarchy and to prevent naming conflicts. In this case, the namespace `Meta.Editor.Windows` indicates that the code within is related to the "Meta" project, specifically the "Editor" component, and within that, the "Windows" module or subcomponent.

### `public delegate void MetaSchemaFailedCallback(MetaSchemaWindow owner);`

This line declares a delegate. In C#, a delegate is a type that represents references to methods with a particular parameter list and return type. Delegates are used to define callback methods and event handlers.

- `public`: This keyword indicates that the delegate is accessible from other classes and assemblies.
- `delegate`: This keyword is used to define a delegate type.
- `void`: This indicates that the delegate points to methods that return no value (i.e., `void` methods).
- `MetaSchemaFailedCallback`: This is the name of the delegate type.
- `(MetaSchemaWindow owner)`: This specifies the signature of the methods the delegate can point to. In this case, the delegate can point to any method that takes a single parameter of type `MetaSchemaWindow` and returns `void`.

### Summary

Putting it all together, this code snippet:

1. Enables nullable reference types for the following code.
2. Declares a namespace `Meta.Editor.Windows` to organize the code.
3. Defines a public delegate type named `MetaSchemaFailedCallback`, which can reference any method that takes a `MetaSchemaWindow` object as a parameter and returns `void`.

This delegate might be used in scenarios where you need to specify a callback method to be invoked when a certain event occurs, such as when a schema operation fails in the context of a `MetaSchemaWindow`.

## /Meta/Editor/Windows/MetaSchemaOkCallback.cs

This code defines a delegate type named `MetaSchemaOkCallback` within the namespace `Meta.Editor.Windows`. Let's break down the components and their roles:

### `#nullable enable`

This directive enables nullable reference types for the code that follows. This feature, introduced in C# 8.0, helps in dealing with null references by making nullability explicit in the type system. When `#nullable enable` is used, the compiler enforces rules about nullability, helping to prevent null reference exceptions.

### Namespace Declaration

```csharp
namespace Meta.Editor.Windows
```

This line declares the namespace `Meta.Editor.Windows`. Namespaces are used to organize code into a hierarchical structure, preventing name collisions and providing a way to group related types together.

### Delegate Declaration

```csharp
public delegate void MetaSchemaOkCallback(SchemaWindow owner);
```

This line defines a public delegate named `MetaSchemaOkCallback`. Let's break down the delegate declaration:

- **public**: This keyword indicates that the delegate is accessible from any other code in the same assembly or another assembly that references it.
- **delegate**: This keyword is used to declare a delegate type.
- **void**: The return type of the delegate. In this case, it returns no value (`void`).
- **MetaSchemaOkCallback**: The name of the delegate.
- **SchemaWindow owner**: The parameter list of the delegate. This delegate takes a single parameter of type `SchemaWindow` named `owner`.

### Delegate

A delegate is a type that represents references to methods with a particular parameter list and return type. Delegates are used to pass methods as arguments to other methods, enabling flexible and reusable code.

In this context, `MetaSchemaOkCallback` is a delegate that represents any method that takes a `SchemaWindow` object as a parameter and returns `void`. This delegate might be used for callbacks, particularly to handle an "OK" action related to a `SchemaWindow` in the application.

### Usage Example

An example of how this delegate might be used:

```csharp
namespace Meta.Editor.Windows
{
  public class SchemaWindow
  {
    // A method that matches the delegate signature
    public void OnSchemaOk(SchemaWindow owner)
    {
      // Handle the OK action
      Console.WriteLine("Schema OK action handled for: " + owner.ToString());
    }

    public void ExampleUsage()
    {
      // Create an instance of the delegate, pointing to the OnSchemaOk method
      MetaSchemaOkCallback okCallback = new MetaSchemaOkCallback(OnSchemaOk);

      // Invoke the delegate
      okCallback(this);
    }
  }
}
```

In this example:

- A method `OnSchemaOk` is defined that matches the `MetaSchemaOkCallback` delegate signature.
- An instance of the `MetaSchemaOkCallback` delegate is created, pointing to the `OnSchemaOk` method.
- The delegate is invoked with `this` as the argument, calling the `OnSchemaOk` method with the current instance of `SchemaWindow`.

This delegate mechanism allows for flexible assignment of methods to handle specific actions, promoting decoupling and reusability in the application.

## /Meta/Editor/Windows/MetaSchemaTaskCallback.cs

This C# code snippet defines a delegate within the `Meta.Editor.Windows` namespace. Here is a detailed explanation:

### Nullable Context

- `#nullable enable`: This directive enables nullable reference types in the code that follows. It helps the compiler to understand and enforce nullability rules, which can prevent null reference exceptions by making it clear when a variable can or cannot be null.

### Namespace

- **Meta.Editor.Windows**: This is the namespace that groups related classes, delegates, and other types. It helps organize code and avoid naming conflicts.

### Delegate Definition

- **MetaSchemaTaskCallback**: This delegate represents a method that takes a `SchemaWindow` object as a parameter and does not return a value. It is defined using the `public delegate` syntax, which specifies the method signature that any method assigned to this delegate must match.

### Usage

- **SchemaWindow owner**: The parameter `owner` is of type `SchemaWindow`, indicating that any method assigned to this delegate must accept a `SchemaWindow` object as an argument.

### Purpose

- The `MetaSchemaTaskCallback` delegate is designed to be used as a callback mechanism within the `Meta.Editor.Windows` namespace, particularly for tasks involving the `SchemaWindow` class. A method that matches this delegate's signature can be passed around and invoked, allowing for flexible and decoupled code execution.

### Example

Here is an example of how this delegate might be used:

```csharp
namespace Meta.Editor.Windows
{
    public class SchemaWindow
    {
        public void ExampleMethod()
        {
            // Create a callback method that matches the MetaSchemaTaskCallback delegate signature
            MetaSchemaTaskCallback callback = new MetaSchemaTaskCallback(TaskCallbackMethod);

            // Invoke the callback with 'this' as the SchemaWindow owner
            callback(this);
        }

        private void TaskCallbackMethod(SchemaWindow owner)
        {
            // Implementation of the callback method
            Console.WriteLine($"Callback invoked with SchemaWindow owner: {owner}");
        }
    }
}
```

In this example:

- The `TaskCallbackMethod` matches the signature defined by `MetaSchemaTaskCallback`.
- An instance of `SchemaWindow` calls `ExampleMethod`, which creates the callback and invokes it.
- The `TaskCallbackMethod` is executed, demonstrating how the delegate facilitates passing and invoking methods with specific parameters.

## /Meta/Editor/Windows/MetaSchemaTaskWindow.cs

This code defines a class `MetaSchemaWindow` which is a part of a namespace `Meta.Editor.Windows`. This class is a `Window` and implements `IComponentConnector`. It manages the process of deserializing a MetaAsset using FlatbufferSchema, displaying progress and status in a WPF application. Here's a breakdown of the key components and their roles:

### Namespaces and Imports

The code begins by importing several namespaces required for the functionality:

- `Meta.Core`
- `Meta.Core.IO`
- `Meta.Editor.Converters`
- `Meta.Structures.Flatbuffers`
- `MetaEditor`
- Various System namespaces

### Class Definition

The `MetaSchemaWindow` class has several key parts:

#### Fields and Properties

- **Callbacks**: `_callback` and `_failedCallback` are used to notify success or failure of the deserialization process.
- **Progress Tracking**: `progress` to track the current progress, `schema` for the Flatbuffer schema, `asset` for the MetaAsset being processed, and `status` for the current status message.
- **UI Elements**: `taskWindow`, `taskTextBlock`, `taskProgressBar`, `statusTextBox`, and `cancelButton` are internal UI components.
- **Flatc Path**: `Flatc` property provides the path to the Flatc executable.
- **INotifyPropertyChanged**: Implements property change notification for `Asset`, `Schema`, `Progress`, and `Status`.

#### Constructor

The constructor initializes the window, sets up the UI, binds properties, and sets up event handlers:

```csharp
public MetaSchemaWindow(
    Window owner,
    MetaAsset _asset,
    FlatbufferSchema _schema,
    MetaSchemaCallback callback = null,
    MetaSchemaFailedCallback failedCallback = null)
{
    ...
}
```

#### Methods

- **Serialize**: Asynchronously writes the schema to a temporary file, copies the asset, and runs the Flatc process to generate JSON.
- **MetaSchemaWindow_Loaded**: Handles the window's loaded event, deserializing the asset using Flatc, updating progress, and cleaning up temporary files.
- **SetIndeterminate**: Updates the progress bar to an indeterminate state.
- **Update**: Updates the status and progress of the deserialization process.
- **Show (overloaded)**: Static methods to show the window with specified parameters.

#### Property Change Notification

The `NotifyPropertyChanged` method raises the `PropertyChanged` event to update bindings in the UI.

### XAML Component Initialization

- **InitializeComponent**: Loads the XAML component for the window.
- **IComponentConnector.Connect**: Connects UI components to their corresponding fields.

### Asynchronous Execution

The deserialization process is run asynchronously to keep the UI responsive:

```csharp
private async void Serialize()
{
    await Task.Run((Action)(() => { ... }));
}
```

### Event Handling

Handles window loaded events and performs necessary operations, including running external processes (Flatc) and updating the UI based on the results.

### Usage

To use this class, an instance of `MetaSchemaWindow` is created, configured with the necessary parameters, and shown. The progress and status are updated during the deserialization process, providing feedback to the user.

This class is designed to handle deserialization of complex assets in a WPF application, providing a user-friendly interface to monitor the progress and handle errors effectively.

## /Meta/Editor/Windows/MetaTaskCallback.cs

This C# code snippet is defining a namespace, `Meta.Editor.Windows`, and within that namespace, it is declaring a delegate type named `MetaTaskCallback`.

Let's break down each part:

### Nullable Annotations

```csharp
#nullable enable
```

This directive enables nullable reference types in the code that follows. This means that the compiler will perform static analysis to track the nullability of reference types, helping to prevent null reference exceptions.

### Namespace Declaration

```csharp
namespace Meta.Editor.Windows
{
```

This defines a namespace called `Meta.Editor.Windows`. Namespaces are used to organize code and prevent naming conflicts.

### Delegate Declaration

```csharp
public delegate void MetaTaskCallback(MetaTaskWindow owner);
```

This line declares a delegate type named `MetaTaskCallback`. A delegate is a type that represents references to methods with a specific parameter list and return type. In this case:

- `public` means the delegate is accessible from other code that references this namespace.
- `delegate` indicates that this is a delegate type.
- `void` specifies that the methods referenced by this delegate do not return a value.
- `MetaTaskCallback` is the name of the delegate.
- `(MetaTaskWindow owner)` defines the parameter list for the delegate. This delegate takes a single parameter of type `MetaTaskWindow`.

Putting it all together, `MetaTaskCallback` is a delegate type that can reference any method that takes a single `MetaTaskWindow` parameter and returns `void`.

### Example Usage

Here's a simple example of how this delegate might be used:

```csharp
namespace Meta.Editor.Windows
{
  public class MetaTaskWindow
  {
    // Some properties and methods for MetaTaskWindow
  }

  public class TaskHandler
  {
    public void HandleTask(MetaTaskWindow window)
    {
      // Task handling logic
    }

    public void Execute(MetaTaskCallback callback, MetaTaskWindow window)
    {
      callback(window);
    }
  }

  public class Program
  {
    public static void Main()
    {
      MetaTaskWindow window = new MetaTaskWindow();
      TaskHandler handler = new TaskHandler();

      // Assigning a method to the delegate
      MetaTaskCallback callback = handler.HandleTask;

      // Executing the delegate
      handler.Execute(callback, window);
    }
  }
}
```

In this example, `MetaTaskCallback` is used to reference the `HandleTask` method, which matches the delegate signature. The `Execute` method takes a `MetaTaskCallback` delegate and a `MetaTaskWindow` instance and calls the delegate with the instance.

## /Meta/Editor/Windows/MetaTaskWindow.cs

The provided code defines a `MetaTaskWindow` class in the `Meta.Editor.Windows` namespace, which is a WPF (Windows Presentation Foundation) window designed to display task progress and status updates in a user interface. Here's a detailed explanation of the code:

### Namespaces and Imports

```csharp
using Meta.Editor.Converters;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Shell;
```

These namespaces include essential classes and methods for WPF, asynchronous programming, component model interfaces, and debugging.

### Class Definition

```csharp
namespace Meta.Editor.Windows
{
  public class MetaTaskWindow : Window, IComponentConnector
  {
    // Fields and properties
    private MetaTaskCallback _callback;
    private double progress;
    private string status;
    internal Grid taskWindow;
    internal TextBlock taskTextBlock;
    internal ProgressBar taskProgressBar;
    internal TextBlock statusTextBox;
    internal Button cancelButton;
    private bool _contentLoaded;

    // Events
    public event PropertyChangedEventHandler PropertyChanged;

    // Properties with change notification
    public double Progress
    {
      get => this.progress;
      set
      {
        if (value == this.progress)
          return;
        this.progress = value;
        this.NotifyPropertyChanged(nameof(Progress));
      }
    }

    public string Status
    {
      get => this.status;
      set
      {
        if (!(value != this.status))
          return;
        this.status = value;
        this.NotifyPropertyChanged(nameof(Status));
      }
    }

    // Constructor
    private MetaTaskWindow(
      Window owner,
      string task,
      string initialStatus,
      MetaTaskCallback callback)
    {
      this.InitializeComponent();
      this.taskTextBlock.Text = task;
      this.Progress = 0.0;
      this.Status = initialStatus;
      this._callback = callback;
      this.Owner = owner;
      this.Loaded += new RoutedEventHandler(this.MetaTaskWindow_Loaded);
      Application.Current.MainWindow.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Normal;
      BindingOperations.SetBinding((DependencyObject)Application.Current.MainWindow.TaskbarItemInfo, TaskbarItemInfo.ProgressValueProperty, new Binding(nameof(Progress))
      {
        Converter = (IValueConverter)new DelegateBasedValueConverter(),
        ConverterParameter = (object)(Func<object, object>)(value => (object)((double)value / 100.0)),
        Source = (object)this
      });
    }

    // Event handlers and methods
    private async void MetaTaskWindow_Loaded(object sender, RoutedEventArgs e)
    {
      await Task.Run((Action)(() => this._callback(this)));
      Application.Current.MainWindow.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.None;
      this.Close();
    }

    public void SetIndeterminate(bool newIndeterminate)
    {
      Application.Current.Dispatcher.Invoke((Action)(() =>
      {
        this.taskProgressBar.IsIndeterminate = newIndeterminate;
        Application.Current.MainWindow.TaskbarItemInfo.ProgressState = newIndeterminate ? TaskbarItemProgressState.Indeterminate : TaskbarItemProgressState.Normal;
      }));
    }

    public void Update(string? status = null, double? progress = null)
    {
      if (status != null)
        this.Status = status;
      if (progress.HasValue)
        this.Progress = progress.Value;
    }

    // Static methods to show the window
    public static void Show(
      Window owner,
      string task,
      string initialStatus,
      MetaTaskCallback callback)
    {
      new MetaTaskWindow(owner, task, initialStatus, callback).ShowDialog();
    }

    public static void Show(string task, string initialStatus, MetaTaskCallback callback)
    {
      MetaTaskWindow.Show(Application.Current.MainWindow, task, initialStatus, callback);
    }

    // Property change notification
    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
      PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
      if (propertyChanged == null)
        return;
      propertyChanged((object)this, new PropertyChangedEventArgs(propertyName));
    }

    // Generated code for component initialization
    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object)this, new Uri("/Meta.Editor;V1.0.5.32;component/windows/metataskwindow.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
    internal Delegate _CreateDelegate(Type delegateType, string handler)
    {
      return Delegate.CreateDelegate(delegateType, (object)this, handler);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.taskWindow = (Grid)target;
          break;
        case 2:
          this.taskTextBlock = (TextBlock)target;
          break;
        case 3:
          this.taskProgressBar = (ProgressBar)target;
          break;
        case 4:
          this.statusTextBox = (TextBlock)target;
          break;
        case 5:
          this.cancelButton = (Button)target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
```

### Key Points

1. **Namespace and Class**: `MetaTaskWindow` is defined within the `Meta.Editor.Windows` namespace and inherits from the `Window` class. It also implements `IComponentConnector` for XAML component linking.

2. **Fields and Properties**:

   - Private fields: `_callback`, `progress`, `status`.
   - Internal fields: `taskWindow`, `taskTextBlock`, `taskProgressBar`, `statusTextBox`, `cancelButton`, `_contentLoaded`.
   - Public properties: `Progress` and `Status`, both with `INotifyPropertyChanged` implementation to notify changes.

3. **Constructor**:

   - Initializes the window with task details, initial status, and a callback.
   - Sets up bindings for task progress updates.

4. **Methods**:

   - `MetaTaskWindow_Loaded`: Executes the callback asynchronously when the window is loaded and updates the taskbar progress.
   - `SetIndeterminate`: Sets the progress bar and taskbar item to an indeterminate state.
   - `Update`: Updates the status and progress values.
   - `Show`: Static methods to display the window.

5. **INotifyPropertyChanged Implementation**:

   - `NotifyPropertyChanged`: Notifies listeners of property changes.

6. **Component Initialization**:
   - `InitializeComponent`: Loads the XAML components for the window.
   - `IComponentConnector.Connect`: Connects XAML-defined components to their corresponding fields in the code-behind.

The `MetaTaskWindow` class provides a user interface for tracking the progress and status of a task, integrating with the Windows taskbar for visual feedback, and supports asynchronous task execution and updates.

## /Meta/Editor/Windows/OptionsWindow.cs

The provided C# code defines a class named `OptionsWindow` within the `Meta.Editor.Windows` namespace. This class inherits from `MetaWindow` and implements the `IComponentConnector` interface, which is used for WPF component connections. The `OptionsWindow` class is responsible for displaying and managing user options in a graphical window. Here's a detailed explanation of the code:

### Namespaces and Dependencies

```csharp
using Meta.Core;
using Meta.Editor.Controls;
using Meta.Editor.Extensions;
using Microsoft.Win32;
using PropertyTools.DataAnnotations;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
```

- Various namespaces are imported for core functionality, WPF controls, data annotations, component model, diagnostics, reflection, interop services, and markup extensions.

### Nullable Context

```csharp
#nullable enable
```

- Enables nullable reference types for improved null safety.

### Namespace and Class Definition

```csharp
namespace Meta.Editor.Windows
{
  public class OptionsWindow : MetaWindow, IComponentConnector
  {
```

- `namespace Meta.Editor.Windows`: Defines the namespace.
- `public class OptionsWindow`: Defines the `OptionsWindow` class, which inherits from `MetaWindow` and implements `IComponentConnector`.

### Fields and Properties

```csharp
    [ExpandableObject]
    private OptionsWindow.EditorOptionsData MetaOptions;
    internal PropertyTools.Wpf.PropertyGrid pgrid;
    internal Button cancelButton;
    internal Button saveButton;
    private bool _contentLoaded;
```

- `MetaOptions`: An instance of the nested `EditorOptionsData` class, marked with `[ExpandableObject]` to allow property expansion in a property grid.
- `pgrid`: Internal field for the property grid control.
- `cancelButton`: Internal field for the cancel button.
- `saveButton`: Internal field for the save button.
- `_contentLoaded`: A flag to check if the content has been loaded.

### Constructor

```csharp
    public OptionsWindow() => this.InitializeComponent();
```

- The constructor initializes the component by calling `InitializeComponent`.

### Event Handlers

#### Window_Loaded

```csharp
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      this.MetaOptions = new OptionsWindow.EditorOptionsData();
      this.MetaOptions.Load();
      this.pgrid.SelectedObject = (object)this.MetaOptions;
    }
```

- This method is called when the window is loaded.
- It initializes `MetaOptions`, loads the options, and sets the selected object in the property grid to `MetaOptions`.

#### cancelButton_Click

```csharp
    private void cancelButton_Click(object sender, RoutedEventArgs e) => this.Close();
```

- Closes the window when the cancel button is clicked.

#### saveButton_Click

```csharp
    private void saveButton_Click(object sender, RoutedEventArgs e)
    {
      if (this.Validate())
      {
        this.MetaOptions.Save();
        this.Close();
      }
      Config.Save();
    }
```

- Saves the options and closes the window when the save button is clicked, if validation is successful.

### Helper Methods

#### Validate

```csharp
    private bool Validate() => this.MetaOptions.Validate();
```

- Validates the options using the `Validate` method of `MetaOptions`.

#### InitializeComponent

```csharp
    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object)this, new Uri("/Meta.Editor;V1.0.5.32;component/windows/optionswindow.xaml", UriKind.Relative));
    }
```

- Initializes the component by loading the XAML content if it hasn't been loaded already.

#### \_CreateDelegate

```csharp
    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
    internal Delegate _CreateDelegate(Type delegateType, string handler)
    {
      return Delegate.CreateDelegate(delegateType, (object)this, handler);
    }
```

- Creates a delegate for the specified handler.

#### IComponentConnector.Connect

```csharp
    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.pgrid = (PropertyTools.Wpf.PropertyGrid)target;
          break;
        case 2:
          this.cancelButton = (Button)target;
          this.cancelButton.Click += new RoutedEventHandler(this.cancelButton_Click);
          break;
        case 3:
          this.saveButton = (Button)target;
          this.saveButton.Click += new RoutedEventHandler(this.saveButton_Click);
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
```

- Connects the components defined in the XAML to their respective fields and event handlers.

### EditorOptionsData Class

```csharp
    [DisplayName("Editor Options")]
    public class EditorOptionsData : OptionsExtension
    {
      [Category("Backups")]
      [DisplayName("Enabled")]
      [Description("Enables file backups.")]
      public bool BackupsEnabled { get; set; } = true;

      [Category("Backups")]
      [DisplayName("Max Count")]
      [Description("Maximum amount of backups to save per each file.")]
      public int BackupsMaxCount { get; set; } = 3;

      [Category("Editor")]
      [DisplayName("Set as Default Installation")]
      [Description("Use this installation for .JSFB files.")]
      public bool DefaultInstallation { get; set; } = false;

      [Category("Watcher")]
      [DisplayName("Enabled")]
      [Description("Meta will actively watch your exported JSON and re-compile.")]
      public bool WatchEnabled { get; set; } = true;

      [Category("Watcher")]
      [DisplayName("Windows Notifications")]
      [Description("Meta will actively watch your exported JSON and re-compile.")]
      public bool WindowsNotifications { get; set; } = true;

      [Category("Watcher")]
      [DisplayName("Load check")]
      [Description("Enabling this will make Meta check whether any changes have been outside of Meta for JSON files.")]
      public bool WatchLoadEnabled { get; set; } = true;

      [Category("Editor")]
      [DirectoryPath]
      [AutoUpdateText]
      [Browsable(false)]
      public string PrefWorkDir { get; set; }

      public override void Load()
      {
        base.Load();
        this.BackupsEnabled = Config.Get<bool>("BackupsEnabled", true);
        this.BackupsMaxCount = Config.Get<int>("BackupsMaxCount", 3);
        this.WatchEnabled = Config.Get<bool>("WatchEnabled", true);
        this.PrefWorkDir = Config.Get<string>("PrefWorkDir", string.Empty);
        this.WindowsNotifications = Config.Get<bool>("WindowsNotifications", true);
        this.WatchLoadEnabled = Config.Get<bool>("WatchLoadEnabled", true);
        string str = "2kjsfb";
        string location = Assembly.GetEntryAssembly().Location;
        if (Registry.CurrentUser.OpenSubKey("Software\\Classes\\" + str) == null || !((string) Registry.CurrentUser.OpenSubKey("Software\\Classes\\" + str).OpenSubKey("shell").OpenSubKey("open").OpenSubKey("command").GetValue("")).Contains(location))
          return;
        this.DefaultInstallation = true;
      }

      public override void Save()
      {
        base.Save();
        Config.Add("BackupsEnabled", (object)this.BackupsEnabled);
        Config.Add("BackupsMaxCount", (object)this.BackupsMaxCount);
        Config.Add("WatchEnabled", (object)this.WatchEnabled);
        Config.Add("PrefWorkDir", (object)this.PrefWorkDir);
        Config.Add("WindowsNotifications", (object)this.WindowsNotifications);
        Config.Add("WatchLoadEnabled", (object)this.WatchLoadEnabled);
        Config.Save();
        if (!this.DefaultInstallation)
          return;
        string str1 = ".jsfb";
        string str2 = "2kjsfb";
        string location = Assembly.GetEntryAssembly().Location;
        string str3 = "Flatbuffer File";
        RegistryKey subKey1 = Registry.CurrentUser.CreateSubKey("Software\\Classes\\" + str1);
        subKey1.SetValue("", (object)str2);
        RegistryKey subKey2 = Registry.CurrentUser.CreateSubKey("Software\\Classes\\" + str2);
        subKey2.SetValue("", (object)str3);
        subKey2.CreateSubKey("DefaultIcon").SetValue("", (object)("\"" + location + "\",0"));
        RegistryKey subKey3 = subKey2.CreateSubKey("shell");
        subKey3.CreateSubKey("edit").CreateSubKey("command").SetValue("", (object)("\"" + location + "\" \"%1\""));
        subKey3.CreateSubKey("open").CreateSubKey("command").SetValue("", (object)("\"" + location + "\" \"%1\""));
        subKey1.Close();
        subKey2.Close();
        subKey3.Close();
        RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\" + str1, true);
        registryKey.DeleteSubKey("UserChoice", false);
        registryKey.Close();


 OptionsWindow.EditorOptionsData.SHChangeNotify(134217728U, 0U, IntPtr.Zero, IntPtr.Zero);
      }

      public override bool Validate() => true;

      [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
      private static extern void SHChangeNotify(
        uint wEventId,
        uint uFlags,
        IntPtr dwItem1,
        IntPtr dwItem2);
    }
  }
}
```

#### Fields and Properties

- Contains various properties for different options categories such as "Backups", "Editor", and "Watcher".
- Uses attributes like `[Category]`, `[DisplayName]`, and `[Description]` for categorizing and describing properties in the property grid.

#### Load Method

- Loads configuration settings into the properties from a configuration source.

#### Save Method

- Saves the current settings back to the configuration source.
- Updates the Windows Registry if the `DefaultInstallation` option is set.

#### Validate Method

- Always returns `true` indicating the options are valid.

#### SHChangeNotify Method

- A P/Invoke method for notifying the system of changes to file associations.

### Summary

- The `OptionsWindow` class manages user options in a WPF window.
- It includes methods for loading, saving, and validating options.
- The nested `EditorOptionsData` class defines the specific options available and their behavior.
- The class integrates with WPF controls and the Windows Registry for managing settings and file associations.

## /Meta/Editor/Windows/SchemaNameConverter.cs

The provided C# code defines a class named `SchemaNameConverter` within the `Meta.Editor.Windows` namespace. This class implements the `IValueConverter` interface from the `System.Windows.Data` namespace, which is typically used in data binding scenarios in WPF (Windows Presentation Foundation) applications. Here's a detailed explanation of the code:

### Namespaces and Dependencies

```csharp
using System;
using System.Globalization;
using System.Windows.Data;
```

- `System`: Provides fundamental classes and base classes that define commonly-used value and reference data types.
- `System.Globalization`: Provides classes that define culture-related information, such as language, country/region, calendars, and formats for dates and numbers.
- `System.Windows.Data`: Provides classes for data binding in WPF applications.

### Nullable Context

```csharp
#nullable enable
```

Enables nullable reference types, allowing the compiler to perform static analysis to help ensure that `null` values are only assigned where they are intended to be.

### Namespace and Class Definition

```csharp
namespace Meta.Editor.Windows
{
  public class SchemaNameConverter : IValueConverter
  {
```

- `namespace Meta.Editor.Windows`: Defines a namespace to logically organize the code.
- `public class SchemaNameConverter`: Defines a public class named `SchemaNameConverter`.
- `IValueConverter`: An interface that allows for the implementation of custom logic to convert data between the source and target.

### Convert Method

```csharp
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return value is string str ? (object) str.Split('_')[0] : value;
    }
```

- `Convert` method: Converts the source value to a target value.

  - `object value`: The value produced by the binding source.
  - `Type targetType`: The type of the binding target property.
  - `object parameter`: An optional parameter to use in the converter logic.
  - `CultureInfo culture`: The culture to use in the converter.

- The method checks if `value` is of type `string`.
  - If `value` is a string (`str`), it splits the string at the first underscore (`_`) character and returns the first part of the split string.
  - If `value` is not a string, it returns the original `value`.

### ConvertBack Method

```csharp
    public object ConvertBack(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
```

- `ConvertBack` method: Converts the target value back to the source value.

  - `object value`: The value produced by the binding target.
  - `Type targetType`: The type to convert to.
  - `object parameter`: An optional parameter to use in the converter logic.
  - `CultureInfo culture`: The culture to use in the converter.

- The method throws a `NotImplementedException`, indicating that the conversion back from the target to the source is not implemented.

### Summary

- The `SchemaNameConverter` class implements the `IValueConverter` interface for use in WPF data binding scenarios.
- The `Convert` method extracts the substring before the first underscore in a string value.
- The `ConvertBack` method is not implemented, meaning this converter is intended for one-way binding scenarios where only the conversion from source to target is needed.

## /Meta/Editor/Windows/SchemaWindow.cs

This C# code defines a `SchemaWindow` class within the `Meta.Editor.Windows` namespace. This class is a specialized window used to interact with Flatbuffer schemas in a graphical user interface. Below is an explanation of the key components and functionality:

### Namespaces and Imports

- The code imports various namespaces, including ones for UI controls, flatbuffers, threading, and event handling. These namespaces provide the necessary classes and methods to build and manage the UI and handle data operations.

### Class Definition

- **SchemaWindow**: This class inherits from `MetaWindow` and implements `INotifyPropertyChanged` and `IComponentConnector` interfaces. It is used to create a window that interacts with Flatbuffer schemas.

### Fields and Properties

- **\_callback, \_cancelCallback, \_okCallback**: These fields store callback functions for different actions within the window.
- **selectedSchema, schemas, activeFile**: These fields store the currently selected schema, the list of available schemas, and the active file, respectively.
- **cancelButton, saveButton**: UI elements for cancel and save actions.
- **\_contentLoaded**: A flag to check if the content has been loaded.

### Event Handlers

- **PropertyChanged**: An event to notify when a property changes.
- **Active, SelectedSchema, Schemas**: Properties with getters and setters that notify when their values change.

### Constructor

- **SchemaWindow**: Initializes the window with an owner, file, schemas, and callbacks. It sets the data context and window title, and registers a loaded event handler.

### Static Method

- **Show**: Creates and displays a `SchemaWindow` dialog.

### Methods

- **CancelButton_Click**: Handles the cancel button click event, disables the button, invokes the cancel callback, and closes the window.
- **OkButton_Click**: Handles the OK button click event, invokes the OK callback, and closes the window.
- **SchemaWindow_Loaded**: Asynchronously executes the callback when the window is loaded.
- **NotifyPropertyChanged**: Invokes the `PropertyChanged` event.
- **InitializeComponent**: Loads the component if it hasn't been loaded already.
- **\_CreateDelegate**: Creates a delegate for event handling.
- **Connect**: Connects UI elements to their event handlers based on connection ID.

### Summary

- This class provides a way to interact with Flatbuffer schemas through a GUI.
- It uses callbacks to handle user actions (cancel, save).
- The `INotifyPropertyChanged` interface is used to update the UI when properties change.
- It uses XAML for defining the UI components, loaded via `InitializeComponent`.

The class essentially creates a window where users can view, select, and interact with Flatbuffer schemas, with specific actions handled by provided callback functions.

## /Meta/Structures/Flatbuffers/FlatbufferSerializeQueue.cs

The provided C# code defines a `FlatbufferSerializeQueue` class within the `Meta.Structures.Flatbuffers` namespace. This class is responsible for managing the serialization of assets using Flatbuffers, a serialization library. Here's a detailed explanation of the code:

### Namespaces and Dependencies

```csharp
using Meta.Core;
using Meta.Core.Interfaces;
using Meta.Core.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
```

These `using` directives import various necessary namespaces for logging, file IO, process management, asynchronous programming, and core functionalities from the Meta framework.

### Class Definition

```csharp
#nullable enable
namespace Meta.Structures.Flatbuffers
{
  public sealed class FlatbufferSerializeQueue
  {
```

- `#nullable enable` enables nullable reference types.
- The class is defined as `sealed`, meaning it cannot be inherited.

### Fields and Properties

```csharp
    private Queue<SerializationRequest> serializationQueue = new Queue<SerializationRequest>();
    private SerializationRequest currentRequest;
    private MetaSerializerCallback _callback;
    private MetaSerializerFailedCallback _failedCallback;

    private static string Flatc => Path.Combine(App.ThirdPartyPath, "flatc.exe");

    public SerializationRequest Active
    {
      get => this.currentRequest;
      set
      {
        if (value == this.currentRequest)
          return;
        this.currentRequest = value;
      }
    }
```

- `serializationQueue`: A queue to hold pending serialization requests.
- `currentRequest`: The current request being processed.
- `_callback` and `_failedCallback`: Callbacks for success and failure.
- `Flatc`: Static property to get the path to the `flatc.exe` executable.
- `Active`: Property to get or set the current request.

### Constructor

```csharp
    public FlatbufferSerializeQueue(ILogger logger)
    {
    }
```

The constructor accepts an `ILogger` object, but it does not do anything with it in the provided code.

### Methods

#### Add

```csharp
    public void Add(
      MetaAsset asset,
      FlatbufferSchema schema,
      EngineVersion engine,
      string json,
      string jsfb,
      MetaSerializerCallback callback = null,
      MetaSerializerFailedCallback failedCallback = null)
    {
      this.serializationQueue.Enqueue(new SerializationRequest(asset, schema, engine, json, jsfb, callback, failedCallback));
      this.ProcessNextFile();
    }
```

- `Add` method enqueues a new `SerializationRequest` and calls `ProcessNextFile` to start processing the queue.

#### ProcessNextFile

```csharp
    private async void ProcessNextFile()
    {
      if (this.serializationQueue.Count <= 0)
        return;
      SerializationRequest request = this.serializationQueue.Dequeue();
      if (request != null)
      {
        bool flag = await this.InitializeSerialization(request);
        this.ProcessNextFile();
      }
      request = null;
    }
```

- Dequeues and processes the next file in the queue asynchronously.
- Calls `InitializeSerialization` to handle the actual serialization.

#### GetEngine

```csharp
    private string GetEngine(EngineVersion engine)
    {
      return engine != 1 ? Path.Combine(App.ThirdPartyPath, "flatc.exe") : Path.Combine(App.ThirdPartyPath, "flatcnu.exe");
    }
```

- Returns the appropriate Flatbuffer compiler executable based on the engine version.

#### InitializeSerialization

```csharp
    private async Task<bool> InitializeSerialization(SerializationRequest request)
    {
      bool flag = await Task.Run(() =>
      {
        this.Active = request;
        string tempPath = Path.GetTempPath();
        string path = Path.Combine(tempPath, $"{Guid.NewGuid()}.fbs");
        File.WriteAllBytes(path, request.Schema.schema);
        string arguments = $"-b \"{path}\" \"{request.JSON}\"";
        try
        {
          Process process = Process.Start(new ProcessStartInfo(this.GetEngine(request.Engine), arguments)
          {
            CreateNoWindow = true,
            WorkingDirectory = App.CachePath
          });
          process.WaitForExit();
          if (process.ExitCode == 0)
          {
            File.Move(Path.Combine(App.CachePath, $"{request.Asset.NameWithoutExt}.jsfb"), request.JSFB, true);
            request._callback(this);
            return true;
          }
          request._failedCallback(this);
          return false;
        }
        finally
        {
          File.Delete(path);
          this.Active = null;
        }
      });
      return flag;
    }
```

- Asynchronously handles the serialization by creating a temporary file, executing the Flatbuffer compiler, and managing callbacks.

### SerializationRequest Class

```csharp
    public class SerializationRequest
    {
      public MetaSerializerCallback _callback;
      public MetaSerializerFailedCallback _failedCallback;

      public MetaAsset Asset { get; }
      public FlatbufferSchema Schema { get; }
      public string JSON { get; }
      public string JSFB { get; }
      public EngineVersion Engine { get; }

      public SerializationRequest(
        MetaAsset asset,
        FlatbufferSchema schema,
        EngineVersion engine,
        string jSON,
        string jSFB,
        MetaSerializerCallback callback = null,
        MetaSerializerFailedCallback failedCallback = null)
      {
        this.Asset = asset;
        this.Schema = schema;
        this.Engine = engine;
        this.JSON = jSON;
        this.JSFB = jSFB;
        this._callback = callback;
        this._failedCallback = failedCallback;
      }
    }
  }
}
```

- The `SerializationRequest` class represents a request to serialize an asset with properties for the asset, schema, JSON, JSFB, engine version, and callbacks.

### Summary

- The `FlatbufferSerializeQueue` class manages a queue of serialization requests, processes them asynchronously, and uses the Flatbuffers compiler to generate serialized files.
- Callbacks are provided for handling success and failure scenarios.
- The class ensures that only one file is processed at a time by dequeuing and processing each request sequentially.

## /Meta/Structures/Flatbuffers/MetaSerializerCallback.cs

This code snippet is part of a C# program using nullable reference types and defines a delegate within a namespace. Here's a detailed explanation:

1. **#nullable enable**: This directive enables nullable reference types for the code that follows. It allows the compiler to perform static analysis on nullable reference types to catch potential null reference errors. This means the compiler will give warnings if it detects that a reference type variable can be null.

2. **namespace Meta.Structures.Flatbuffers**: This line declares a namespace called `Meta.Structures.Flatbuffers`. Namespaces are used to organize code and prevent name conflicts by grouping related classes, interfaces, and other types under a common name.

3. **public delegate void MetaSerializerCallback(FlatbufferSerializeQueue owner)**: This line defines a delegate named `MetaSerializerCallback`. A delegate is a type that represents references to methods with a particular parameter list and return type. In this case, `MetaSerializerCallback` is a delegate that represents methods that take a single parameter of type `FlatbufferSerializeQueue` and return `void`.

   - `public`: This modifier indicates that the delegate is accessible from other classes and assemblies.
   - `void`: This indicates that the methods referenced by this delegate do not return a value.
   - `FlatbufferSerializeQueue owner`: This is the parameter that the methods referenced by this delegate will take. `FlatbufferSerializeQueue` is likely a class or struct defined elsewhere in the code.

### Summary

The code defines a delegate type `MetaSerializerCallback` within the `Meta.Structures.Flatbuffers` namespace. This delegate can reference any method that takes a `FlatbufferSerializeQueue` parameter and returns `void`. The `#nullable enable` directive ensures that nullable reference types are enabled, helping to avoid null reference errors.

## /Meta/Structures/Flatbuffers/MetaSerializerFailedCallback.cs

```csharp
#nullable enable
namespace Meta.Structures.Flatbuffers
{
  public delegate void MetaSerializerFailedCallback(FlatbufferSerializeQueue owner);
}
```

### Explanation

1. **#nullable enable**:

   - This compiler directive enables nullable reference types for the following code. It allows the compiler to provide warnings about nullability issues, helping to catch potential null reference exceptions at compile time rather than at runtime. This feature is part of C# 8.0 and later versions.

2. **namespace Meta.Structures.Flatbuffers**:

   - This line declares a namespace named `Meta.Structures.Flatbuffers`. Namespaces are used in C# to organize code into logical groups and to prevent name conflicts. Within this namespace, you can define classes, interfaces, structs, delegates, and other types.

3. **public delegate void MetaSerializerFailedCallback(FlatbufferSerializeQueue owner)**:

   - This line defines a delegate named `MetaSerializerFailedCallback`.

   Let's break this down further:

   - **public**: The `public` access modifier makes the delegate accessible from other classes and assemblies.
   - **delegate**: The `delegate` keyword is used to declare a delegate type.
   - **void**: This specifies that the delegate references methods that return `void` (i.e., they do not return a value).
   - **MetaSerializerFailedCallback**: This is the name of the delegate.
   - **(FlatbufferSerializeQueue owner)**: This specifies the parameter list for the delegate. In this case, it indicates that methods referenced by this delegate take a single parameter of type `FlatbufferSerializeQueue`.

### Summary

The code snippet is defining a public delegate type named `MetaSerializerFailedCallback` within the `Meta.Structures.Flatbuffers` namespace. This delegate represents any method that takes a single parameter of type `FlatbufferSerializeQueue` and returns `void`.

The `#nullable enable` directive at the beginning ensures that nullable reference types are enabled for the code that follows, helping to identify potential null reference issues at compile time. This setup is useful for handling callbacks, especially in scenarios where serialization processes may fail, and you need to handle such failures through a standardized callback method.

## /MetaEditor/App.cs

This `App.cs` file defines the main application class for a WPF application called `MetaEditor`. Here's an overview of its components and functionality:

### Namespaces and Libraries

The file imports a range of namespaces and libraries, including those for Windows Presentation Foundation (WPF), JSON serialization (Newtonsoft.Json), diagnostics, threading, and custom namespaces like `Meta.Core`.

### Class: `App`

The `App` class inherits from `Application`, which is the base class for a WPF application.

#### Static Fields

- `Game`: Stores the current game's name as a string.
- `CurrentGame`: An instance of `MetaGame` representing the current game.
- `Version`: Stores the application's version.
- `EventQueue`: A `BlockingCollection` to manage actions queued for execution.
- `NotifyManager`: Manages notifications in the application.
- `PluginManager`, `SchemaManager`, `SerializeQueue`, `DiscordManager`: Managers for various functionalities (plugins, schema, serialization, Discord RPC).
- `FileData`: A dictionary storing file data.
- `MemoryManager`: Manages memory-related tasks.
- `isGameRunning`: Boolean indicating if the game is running.
- `GameProcess`: Stores the process information of the running game.
- `_contentLoaded`: Boolean indicating if the content is loaded.

#### Properties

- `Logger`: Static property for logging.
- `NotificationLifeTime`: Returns the lifetime of a notification as a float.

#### Constructor: `App()`

- Sets the application version.
- Registers an assembly resolver for loading dependencies.
- Initializes various managers (`Logger`, `PluginManager`, `SchemaManager`, `SerializeQueue`, `DiscordManager`).
- Sets Discord presence status.

#### Static Properties and Methods

- `GameActive`: Checks if the game process is active.
- `ActiveGame`: Returns the current game process.
- `GameRunning`: Gets or sets the game running status.
- `Application_Startup(object sender, StartupEventArgs e)`: Handles application startup tasks.
  - Loads configuration and memory manager.
  - Loads JSON data files into `FileData`.
  - Starts a task to process the event queue.
- `GameProcess_Exited(object? sender, EventArgs e)`: Event handler for when the game process exits.
- `InitiateWatchGame()`: Initializes watching the game process.
- `Enqueue(Action action)`: Adds an action to the event queue.
- `CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)`: Resolves assembly dependencies.

#### Methods: `InitializeComponent` and `Main`

- `InitializeComponent()`: Initializes the components, sets the startup URI, and loads the main window.
- `Main()`: The entry point of the application.
  - Shows a splash screen.
  - Creates an instance of the `App` class, initializes the components, and runs the application.

### Functionality Overview

1. **Application Initialization**:

   - Sets up versioning, logging, and various managers.
   - Registers assembly resolver for dependencies.
   - Sets Discord presence for the application.

2. **Game Management**:

   - Checks if the game is active and manages the game process lifecycle.
   - Monitors the game process and updates its running status.

3. **Event Queue Processing**:

   - Uses a blocking collection to queue and process actions asynchronously.

4. **File Data Loading**:

   - Loads JSON files from the `data` directory into a nested dictionary structure.

5. **Notification Management**:

   - Initializes a notification manager for in-app notifications.

6. **Application Startup**:

   - Loads configuration settings.
   - Initializes memory manager and data files.
   - Starts processing the event queue.

7. **Main Entry Point**:
   - Displays a splash screen and initializes the main application window.

Overall, this class sets up and manages the core functionality of the `MetaEditor` WPF application, handling tasks such as version management, game process monitoring, file data loading, event queue processing, and dependency resolution.

## /MetaEditor/MainWindow.cs

This `MainWindow.cs` file defines the `MainWindow` class for a WPF application using the MaterialDesignThemes.Wpf library. It contains UI controls, event handlers, and methods to manage the application's main window and its functionalities. Here's a detailed breakdown:

### Imports

The file imports various libraries for functionality such as WPF controls, JSON handling, and core application logic:

```csharp
using MaterialDesignThemes.Wpf;
using Meta.Core;
using Meta.Core.Attributes;
using Meta.Editor;
using Meta.Editor.Controls;
using Meta.Editor.Windows;
using Meta.Structures.Flatbuffers;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shell;
using System.Windows.Threading;
```

### Namespace and Class Definition

The `MainWindow` class is defined within the `MetaEditor` namespace and extends `MetaWindow`, implementing `IComponentConnector` and `IStyleConnector`:

```csharp
namespace MetaEditor
{
  public class MainWindow : MetaWindow, IComponentConnector, IStyleConnector
  {
    public static string Version = "";
    private Queue<string> fileQueue = new Queue<string>();
    internal MainWindow Main;
    internal Grid mainGrid;
    internal Menu menu;
    internal MenuItem OpenModMenuItem;
    internal MenuItem OpenMoviesMenuItem;
    internal MenuItem OpenSDB;
    internal MenuItem OpenCollectionMenuItem;
    internal MenuItem SaveCollectionMenuItem;
    internal MenuItem RecentItemList;
    internal MenuItem ExitMenuItem;
    internal MenuItem ToolsMenuItem;
    internal MenuItem CreationSuite;
    internal MenuItem HashGenerator;
    internal MenuItem Plugins;
    internal MenuItem CloseAllDocumentsMenuItem;
    internal ComboBox GameList;
    internal ComboBox PART_EngineVersion;
    internal ItemsControl AssetEditorToolbarItems;
    internal MetaTabControl tabControl;
    internal TextBlock changeLogTextBlock;
    internal ListView LoadedPluginsList;
    internal MetaDetachedTabControl tabContent;
    internal MetaTabControl miscTabControl;
    internal TextBox tb;
    private bool _contentLoaded;
```

### Constructor

The constructor initializes the main window, sets up the UI components, event handlers, and binds commands for various functionalities:

```csharp
    public MainWindow()
    {
      this.InitializeComponent();
      this.tabContent.HeaderControl = (Control) this.tabControl;
      this.Title = "dot.Meta Editor | " + App.Version;
      MenuItem menuItem = new MenuItem();
      menuItem.Header = (object) "Options";
      menuItem.Icon = (object) new Image()
      {
        Source = (new ImageSourceConverter().ConvertFromString("pack://application:,,,/Meta.Editor;component/Images/Compile.png") as ImageSource)
      };
      MenuItem newItem1 = menuItem;
      newItem1.Click += new RoutedEventHandler(this.optionsMenuItem_Click);
      this.ToolsMenuItem.Items.Add((object) newItem1);
      this.TaskbarItemInfo = new TaskbarItemInfo();
      RoutedCommand routedCommand1 = new RoutedCommand();
      RoutedCommand routedCommand2 = new RoutedCommand();
      RoutedCommand routedCommand3 = new RoutedCommand();
      routedCommand1.InputGestures.Add((InputGesture) new KeyGesture((Key) 58, (ModifierKeys) 2));
      routedCommand2.InputGestures.Add((InputGesture) new KeyGesture((Key) 62, (ModifierKeys) 2));
      routedCommand3.InputGestures.Add((InputGesture) new KeyGesture((Key) 47, (ModifierKeys) 2));
      this.CommandBindings.Add(new CommandBinding((ICommand) routedCommand1, new ExecutedRoutedEventHandler(this.OpenCollectionMenuItem_Click)));
      this.CommandBindings.Add(new CommandBinding((ICommand) routedCommand2, new ExecutedRoutedEventHandler(this.SaveCollectionMenuItem_Click)));
      this.CommandBindings.Add(new CommandBinding((ICommand) routedCommand3, new ExecutedRoutedEventHandler(this.CloseAllDocumentsMenuItem_Click)));
      foreach (object newItem2 in Enum.GetValues(typeof (EngineVersion)))
        this.PART_EngineVersion.Items.Add(newItem2);
      this.PART_EngineVersion.SelectedItem = (object) (EngineVersion) 0;
      foreach (object key in App.FileData.Keys)
        this.GameList.Items.Add(key);
      this.GameList.SelectedItem = (object) Config.Get<string>("Game", "WWE 2K24");
      App.Game = (string) this.GameList.SelectedItem;
    }
```

### Event Handlers and Methods

The class includes various event handlers and methods to handle user interactions and functionality:

- **TextBox TextChanged**: Manages the focus and scrolling of the text box when text changes:

```csharp
    private void LogTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
      if (this.tb.IsFocused)
        this.tb.MoveFocus(new TraversalRequest((FocusNavigationDirection) 1));
      this.tb.ScrollToEnd();
    }
```

- **OpenStringDatabase**: Opens and loads a string database file:

```csharp
    public void OpenStringDatabase(string filePath)
    {
      MetaTabItem ti = new MetaTabItem();
      MetaSDBControl editor = new MetaSDBControl(App.Logger);
      editor.LoadAsset(filePath);
      RoutedCommand routedCommand = new RoutedCommand();
      routedCommand.InputGestures.Add((InputGesture) new KeyGesture((Key) 66, (ModifierKeys) 2));
      ti.Content = (object) editor;
      ti.Header = (object) Path.GetFileName(filePath);
      ti.Icon = editor.Icon;
      ti.IsSelected = true;
      ti.CloseButtonVisible = true;
      ti.CloseButtonClick += (RoutedEventHandler) ((s, o) => this.ShutdownEditorAndRemoveTab((MetaBaseControl) editor, ti));
      ti.MiddleMouseButtonClick += (MouseEventHandler) ((s, o) => this.ShutdownEditorAndRemoveTab((MetaBaseControl) editor, ti));
      editor.CommandBindings.Add(new CommandBinding((ICommand) routedCommand, (ExecutedRoutedEventHandler) ((o, e) => this.RemoveTab(ti))));
      this.AddTab(ti);
    }
```

- **tabControl_SelectionChanged**: Updates the toolbar items and engine version binding when the selected tab changes:

```csharp
    private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (!((this.tabControl.SelectedItem is MetaTabItem selectedItem ? selectedItem.Content : (object) null) is MetaBaseControl content))
        return;
      this.AssetEditorToolbarItems.ItemsSource = (IEnumerable) content.RegisterToolbarItems();
      this.PART_EngineVersion.SetBinding(Selector.SelectedItemProperty, (BindingBase) new Binding("Engine")
      {
        Source = (object) content
      });
    }
```

- **OpenFlatbufferItem_Click**: Handles opening flatbuffer files:

```csharp
    private void OpenFlatbufferItem_Click(object sender, RoutedEventArgs e)
    {
      OpenFileDialog openFileDialog1 = new OpenFileDialog();
      openFileDialog1.Filter = "(All supported formats)|*.jsfb";
      openFileDialog1.Title = "Open Flatbuffer (JSFB)";
      openFileDialog1.Multiselect = true;
      OpenFileDialog openFileDialog2 = openFileDialog1;
      bool? nullable = openFileDialog2.ShowDialog();
      bool flag = true;
      if (!(nullable.GetValueOrDefault() == flag & nullable.HasValue))
        return;
      foreach (string fileName in openFileDialog2.FileNames)
        this.fileQueue.Enqueue(fileName);
      this.ProcessNextFile();
    }
```

- **ProcessNextFile**: Processes the next file in the queue asynchronously:

```csharp
    private async void ProcessNextFile()
    {
      if (this.fileQueue.Count <= 0)
        return;
      string file = this.fileQueue.Dequeue();
      if (File.Exists(file))
      {
        bool flag = await this.InitializeSchema(file);
        int num = flag ? 1 : 0;
        this.ProcessNextFile();
      }
      file = (string) null;
    }
```

- **InitializeSchema**: Initializes the schema for a given file:

```csharp
    private async Task<bool> InitializeSchema(string file)
    {
      bool flag = await Task.Run<bool>((Func<bool>) (() =>
      {
        IEnumerable<FlatbufferSchema> flatbufferSchemas;
        if (App.SchemaManager.Exist(SchemaManager.GetTag(file), ref flatbufferSchemas, Enum.Parse<SchemaVersion>(App.Game.Replace(' ', '_'))))
        {
          CacheFile cached_file = Config.Get<CacheFile>(file, (CacheFile) null);
          if (cached_file != null)
          {
            if (cached_file.Schema != null)
            {
              FlatbufferSchema schema1 = flatbufferSchemas.Where<FlatbufferSchema>((Func<FlatbufferSchema, bool>) (schema => schema.name.Equals(cached_file.Schema.Schema_Name) && schema.identifier.Equals(cached_file.Schema.Schema_Tag))).FirstOrDefault<FlatbufferSchema>();
              if (schema1 != null)
              {
                Application.Current.Dispatcher.Invoke((Action) (() => this.LoadFlatbuffer(schema1, file)));
                return true;
              }
              App.Logger.LogError("There was a problem trying to

 find the specified cache scheme", Array.Empty<object>());
              return false;
            }
            if (File.Exists(cached_file.JSON_Path))
            {
              if (MetaMessageBox.Show("Cached file exists with missing schema data. Would you like to update?", "Meta File Manager", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
              {
                FlatbufferSchema schema = flatbufferSchemas.Count<FlatbufferSchema>() > 1 ? this.GetSchema(flatbufferSchemas, file) : flatbufferSchemas.FirstOrDefault<FlatbufferSchema>();
                if (schema != null)
                {
                  Application.Current.Dispatcher.Invoke((Action) (() => this.LoadFlatbuffer(schema, file)));
                  Config.UpdateFile(cached_file, cached_file.JSFB_Path, cached_file.JSON_Path, cached_file.LastModified, cached_file.Game, new CacheFile.SchemaConfig()
                  {
                    Schema_Name = schema.name,
                    Schema_Tag = schema.identifier
                  }, (EngineVersion) 0);
                  return true;
                }
              }
            }
            else
            {
              FlatbufferSchema schema = flatbufferSchemas.Count<FlatbufferSchema>() > 1 ? this.GetSchema(flatbufferSchemas, file) : flatbufferSchemas.FirstOrDefault<FlatbufferSchema>();
              if (schema != null)
              {
                Application.Current.Dispatcher.Invoke((Action) (() => this.LoadFlatbuffer(schema, file)));
                return true;
              }
            }
          }
          else
          {
            FlatbufferSchema schema = flatbufferSchemas.Count<FlatbufferSchema>() > 1 ? this.GetSchema(flatbufferSchemas, file) : flatbufferSchemas.FirstOrDefault<FlatbufferSchema>();
            if (schema != null)
            {
              Application.Current.Dispatcher.Invoke((Action) (() => this.LoadFlatbuffer(schema, file)));
              return true;
            }
          }
        }
        else if (MetaMessageBox.Show("Schema not supported.", "Meta File Manager", MessageBoxButton.OK) == MessageBoxResult.OK)
          return false;
        return false;
      }));
      return flag;
    }
```

- **LoadFlatbuffer**: Loads a flatbuffer schema:

```csharp
    private bool LoadFlatbuffer(FlatbufferSchema schema, string file)
    {
      FlatbufferControl flatbuffer = new FlatbufferControl(App.Logger, schema, file);
      if (flatbuffer == null || !flatbuffer.Initialize())
        return false;
      MetaTabItem ti = new MetaTabItem();
      RoutedCommand routedCommand = new RoutedCommand();
      routedCommand.InputGestures.Add((InputGesture) new KeyGesture((Key) 66, (ModifierKeys) 2));
      ti.Content = (object) flatbuffer;
      ti.Header = (object) flatbuffer.Asset.NameWithExt;
      ti.Icon = schema.icon;
      ti.TabId = flatbuffer.Asset.NameWithExt;
      ti.IsSelected = true;
      ti.CloseButtonVisible = true;
      ti.CloseButtonClick += (RoutedEventHandler) ((s, o) => this.ShutdownEditorAndRemoveTab((MetaBaseControl) flatbuffer, ti));
      ti.MiddleMouseButtonClick += (MouseEventHandler) ((s, o) => this.ShutdownEditorAndRemoveTab((MetaBaseControl) flatbuffer, ti));
      flatbuffer.CommandBindings.Add(new CommandBinding((ICommand) routedCommand, (ExecutedRoutedEventHandler) ((o, e) => this.RemoveTab(ti))));
      this.AddTab(ti);
      flatbuffer.Tab = ti;
      return true;
    }
```

- **GetSchema**: Retrieves the schema for a file:

```csharp
    private FlatbufferSchema GetSchema(IEnumerable<FlatbufferSchema> schemas, string file)
    {
      FlatbufferSchema selectedSchema = new FlatbufferSchema();
      Application.Current.Dispatcher.Invoke((Action) (() => SchemaWindow.Show((Window) this, file, schemas, (MetaSchemaTaskCallback) (task => { }), (MetaSchemaCancelCallback) (task => selectedSchema = (FlatbufferSchema) null), (MetaSchemaOkCallback) (task => selectedSchema = task.SelectedSchema))));
      return selectedSchema;
    }
```

- **OpenCreation_Click**: Opens the creation window:

```csharp
    private void OpenCreation_Click(object sender, RoutedEventArgs e)
    {
      CreationWindow creationWindow = new CreationWindow();
      creationWindow.Owner = Application.Current.MainWindow;
      creationWindow.Show();
    }
```

- **OpenSDBItem_Click**: Handles opening SDB (String Database) files:

```csharp
    private void OpenSDBItem_Click(object sender, RoutedEventArgs e)
    {
      OpenFileDialog openFileDialog1 = new OpenFileDialog();
      openFileDialog1.Filter = "(All supported formats)|*.sdb";
      openFileDialog1.Title = "Open SDB (String Database)";
      openFileDialog1.Multiselect = false;
      OpenFileDialog openFileDialog2 = openFileDialog1;
      bool? nullable = openFileDialog2.ShowDialog();
      bool flag = true;
      if (!(nullable.GetValueOrDefault() == flag & nullable.HasValue))
        return;
      this.OpenStringDatabase(openFileDialog2.FileName);
    }
```

- **ValidateFlatbufferWithName**: Validates the flatbuffer file name:

```csharp
    private static bool ValidateFlatbufferWithName(string fileName, out string? type)
    {
      string ident = Path.GetFileNameWithoutExtension(fileName);
      var data = ((IEnumerable<Type>) Assembly.Load("Meta.Structures.Flatbuffers").GetTypes()).Where<Type>((Func<Type, bool>) (t => t.GetCustomAttributes(typeof (BufferIdentifierAttribute), true).Length != 0)).Where<Type>((Func<Type, bool>) (t => t.GetCustomAttributes(typeof (GameVersionAttribute), true).Cast<GameVersionAttribute>().Any<GameVersionAttribute>((Func<GameVersionAttribute, bool>) (attr => attr.Value.Equals(App.Game))))).Select(t => new
      {
        Type = t,
        Attributes = t.GetCustomAttributes(typeof (BufferIdentifierAttribute), true).Cast<BufferIdentifierAttribute>().FirstOrDefault<BufferIdentifierAttribute>()
      }).FirstOrDefault(x => x.Attributes.Value.Equals(ident));
      if (data != null)
      {
        type = data.Attributes.Value;
        return true;
      }
      type = (string) null;
      return false;
    }
```

- **ValidateSchema**: Validates the schema for a file:

```csharp
    private static bool ValidateSchema(string fileName, out object types)
    {
      string ident = "";
      if (File.Exists(fileName))
      {
        using (BinaryReader binaryReader = new BinaryReader((Stream) new FileStream(fileName, FileMode.Open, FileAccess.Read)))
        {
          binaryReader.BaseStream.Position = 4L;
          ident = new string(binaryReader.ReadChars(4));
          binaryReader.Dispose();
        }
        List<Type> list = ((IEnumerable<Type>) Assembly.Load("Meta.Editor").GetTypes()).Where<Type>((Func<Type, bool>) (type => type.GetCustomAttributes<EditorTypeAttribute>().Any<EditorTypeAttribute>((Func<EditorTypeAttribute, bool>) (attr => attr.Value == ident)) && type.GetCustomAttributes<GameVersionAttribute>().Any<GameVersionAttribute>((Func<GameVersionAttribute, bool>) (attr => attr.Value == App.Game)))).ToList<Type>();
        if (list.Count<Type>() > 0)
        {
          types = (object) list;
          return true;
        }
        types = (object) null;
        return false;
      }
      int num = (int) MetaMessageBox.Show(fileName + " was not found.", "Meta File Manager");
      types = (object) null;
      return false;
    }
```

- **MetaTabItem_MouseMove and MetaTabItem_DragOver**: Handle drag-and-drop functionality for `MetaTabItem` controls:

```csharp
    private void MetaTabItem_MouseMove(object sender, MouseEventArgs e)
    {
      if (!(e.Source is MetaTabItem source) || Mouse.PrimaryDevice.LeftButton != MouseButtonState.Pressed)
        return;
      int num = (int) DragDrop.DoDragDrop((DependencyObject) source, (object) source, DragDropEffects.All);
    }

    private void MetaTabItem_DragOver(object sender, DragEventArgs e)
    {
      MetaTabControl parent;
      int num;
      if (e.Source is MetaTabItem source && e.Data.GetData(typeof (MetaTabItem)) is MetaTabItem data && !((object) source).Equals((object) data))
      {
        parent = source.Parent as MetaTabControl;
        num = parent != null ? 1 : 0;
      }
      else
        num = 0;
      if (num == 0)
        return;
      int insertIndex = parent.Items.IndexOf((object) source);
      parent.Items.Remove((object) data);
      parent.Items.Insert(insertIndex, (object) data);
      data.IsSelected = true;
    }
```

- **optionsMenuItem_Click**: Opens the options window:

```csharp
    private void optionsMenuItem_Click(object sender, RoutedEventArgs e)
    {
      this.Effect = (Effect) new BlurEffect()
      {
        Radius = 2.0
      };
      new OptionsWindow().ShowDialog();
    }
```

- **AddTab**: Adds a new tab to the tab control:

```csharp
    private void AddTab(MetaTabItem ti)
    {
      this.tabControl.Items.Add((object) ti);
      (this.tabControl.Items[0] as MetaTabItem).Visibility = Visibility.Collapsed;
    }
```

- **RemoveTab and RemoveAllTabs**: Remove a tab or all tabs from the tab control:

```csharp
    public void RemoveTab(MetaTabItem ti

)
    {
      if (ti.Content is MetaBaseControl content)
        content.Closed();
      this.tabControl.Items.Remove((object) ti);
      if (this.tabControl.Items.Count != 1)
        return;
      MetaTabItem metaTabItem = this.tabControl.Items[0] as MetaTabItem;
      metaTabItem.Visibility = Visibility.Visible;
      metaTabItem.IsSelected = true;
      App.DiscordManager.SetPresence("Viewing: Home Page");
    }

    private void RemoveAllTabs()
    {
      while (this.tabControl.Items.Count > 1)
      {
        MetaTabItem ti = this.tabControl.Items[1] as MetaTabItem;
        if (ti.Content is MetaBaseControl content)
          this.ShutdownEditorAndRemoveTab(content, ti);
        else
          this.RemoveTab(ti);
      }
    }
```

- **ShutdownEditorAndRemoveTab**: Shuts down an editor and removes the tab:

```csharp
    private void ShutdownEditorAndRemoveTab(MetaBaseControl editor, MetaTabItem ti)
    {
      editor.Closed();
      ((DispatcherObject) this).Dispatcher.Invoke((Action) (() =>
      {
        if (ti.IsSelected)
          this.AssetEditorToolbarItems.ItemsSource = (IEnumerable) null;
        this.tabControl.Items.Remove((object) ti);
        if (this.tabControl.Items.Count != 1)
          return;
        MetaTabItem metaTabItem = this.tabControl.Items[0] as MetaTabItem;
        metaTabItem.Visibility = Visibility.Visible;
        metaTabItem.IsSelected = true;
      }));
    }
```

### Additional Methods

- **Main_MetaLoaded**: Binds the text property of the logger to the text box and initializes the recent items and plugins lists:

```csharp
    private void Main_MetaLoaded(object sender, EventArgs e)
    {
      (App.Logger as MetaLogger).AddBinding((UIElement) this.tb, TextBox.TextProperty);
      App.InitiateWatchGame();
      this.LoadMenuExtensions();
      this.RecentItemList.ItemsSource = (IEnumerable) Config.RecentFileList;
      this.LoadedPluginsList.ItemsSource = (IEnumerable) App.PluginManager.Plugins;
    }
```

- **MenuRecentItem_Click**: Handles clicks on recent item menu entries:

```csharp
    private void MenuRecentItem_Click(object sender, RoutedEventArgs e)
    {
      if (!(sender is MenuItem menuItem))
        return;
      this.fileQueue.Enqueue((string) menuItem.Tag);
      this.ProcessNextFile();
    }
```

- **SaveCollectionMenuItem_Click**: Saves the current collection of open documents:

```csharp
    private void SaveCollectionMenuItem_Click(object sender, RoutedEventArgs e)
    {
      if (this.tabControl.Items.Count > 1)
      {
        MetaSaveFileDialog metaSaveFileDialog = new MetaSaveFileDialog("Save collection", "*.mcl (Meta Collection File)|*.mcl", "", config: false);
        if (!metaSaveFileDialog.ShowDialog())
          return;
        ObservableCollection<string> observableCollection = new ObservableCollection<string>();
        foreach (object obj in (IEnumerable) this.tabControl.Items)
        {
          if (((ContentControl) obj).Content.GetType() == typeof (FlatbufferControl))
          {
            Meta.Editor.Controls.Editor assetEditor = ((FlatbufferControl) ((ContentControl) obj).Content).assetEditor;
            if (assetEditor != null)
              observableCollection.Add(assetEditor.Asset.Name);
          }
        }
        File.WriteAllText(Path.GetDirectoryName(metaSaveFileDialog.FileName) + "\\" + Path.GetFileNameWithoutExtension(metaSaveFileDialog.FileName) + ".mcl", JsonConvert.SerializeObject((object) observableCollection, Formatting.Indented));
      }
      else
      {
        int num = (int) MetaMessageBox.Show("Error: No files are open");
      }
    }
```

- **OpenCollectionMenuItem_Click**: Opens a collection of documents from a file:

```csharp
    private void OpenCollectionMenuItem_Click(object sender, RoutedEventArgs e)
    {
      OpenFileDialog openFileDialog1 = new OpenFileDialog();
      openFileDialog1.Filter = "(All supported formats)|*.mcl";
      openFileDialog1.Title = "Open MCL (Meta Collection File)";
      openFileDialog1.Multiselect = false;
      OpenFileDialog openFileDialog2 = openFileDialog1;
      bool? nullable = openFileDialog2.ShowDialog();
      bool flag = true;
      if (!(nullable.GetValueOrDefault() == flag & nullable.HasValue))
        return;
      List<string> stringList = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(openFileDialog2.FileName));
      if (stringList.Count > 0)
      {
        foreach (string str in stringList)
        {
          this.fileQueue.Enqueue(str);
          this.ProcessNextFile();
        }
      }
      else
      {
        int num = (int) MetaMessageBox.Show("Error: No files to open");
      }
    }
```

- **GameList_SelectionChanged**: Updates the game configuration when a new game is selected:

```csharp
    private void GameList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      this.RemoveAllTabs();
      App.Game = (string) this.GameList.SelectedItem;
      App.CurrentGame = JsonConvert.DeserializeObject<MetaGame>(JsonConvert.SerializeObject(App.FileData[App.Game]["Game"]));
      Config.Add("Game", this.GameList.SelectedItem);
      Config.Save();
    }
```

- **EngineVersion_SelectionChanged**: Updates the engine version binding when the engine version selection changes:

```csharp
    private void EngineVersion_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (!((this.tabControl.SelectedItem is MetaTabItem selectedItem ? selectedItem.Content : (object) null) is MetaBaseControl content))
        return;
      content.OnEngineSet((EngineVersion) this.PART_EngineVersion.SelectedItem);
    }
```

- **CloseAllDocumentsMenuItem_Click**: Closes all open documents:

```csharp
    private void CloseAllDocumentsMenuItem_Click(object sender, RoutedEventArgs e)
    {
      this.RemoveAllTabs();
    }
```

- **HashGenerator_Click**: Opens the hash generator window:

```csharp
    private void HashGenerator_Click(object sender, RoutedEventArgs e)
    {
      HashGenWindow hashGenWindow = new HashGenWindow();
      hashGenWindow.Owner = Application.Current.MainWindow;
      hashGenWindow.Show();
    }
```

- **ExitMenuItem_Click**: Exits the application:

```csharp
    private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }
```

- **LoadMenuExtensions**: Loads and adds menu extensions from plugins:

```csharp
    private void LoadMenuExtensions()
    {
      foreach (MenuExtension menuExtension in App.PluginManager.MenuExtensions)
      {
        PackIconKind result;
        if (Enum.TryParse<PackIconKind>(menuExtension.Icon, out result))
        {
          PackIcon packIcon1 = new PackIcon();
          packIcon1.Kind = result;
          ((FrameworkElement) packIcon1).Width = 16.0;
          ((FrameworkElement) packIcon1).Height = 16.0;
          PackIcon packIcon2 = packIcon1;
          MenuItem newItem = new MenuItem();
          newItem.Header = (object) menuExtension.MenuItemName;
          newItem.Icon = (object) packIcon2;
          newItem.Command = (ICommand) menuExtension.MenuItemClicked;
          this.Plugins.Items.Add((object) newItem);
        }
      }
    }
```

### Auto-Generated Methods

- **InitializeComponent**: Initializes the components of the main window:

```csharp
    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/Meta.Editor;V1.0.5.32;component/windows/mainwindow.xaml", UriKind.Relative));
    }
```

- **\_CreateDelegate**: Creates a delegate for event handlers:

```csharp
    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
    internal Delegate _CreateDelegate(Type delegateType, string handler)
    {
      return Delegate.CreateDelegate(delegateType, (object) this, handler);
    }
```

- **IComponentConnector.Connect**: Connects the components based on the connection ID:

```csharp
    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.Main = (MainWindow) target;
          break;
        case 2:
          this.mainGrid = (Grid) target;
          break;
        case 3:
          this.menu = (Menu) target;
          break;
        case 4:
          this.OpenModMenuItem = (MenuItem) target;
          break;
        case 5:
          this.OpenMoviesMenuItem = (MenuItem) target;
          this.OpenMoviesMenuItem.Click += new RoutedEventHandler(this.OpenFlatbufferItem_Click);
          break;
        case 6:
          this.OpenSDB = (MenuItem) target;
          this.OpenSDB.Click += new RoutedEventHandler(this.OpenSDBItem_Click);
          break;
        case 7:
          this.OpenCollectionMenuItem = (MenuItem) target;
          this.OpenCollectionMenuItem.Click += new RoutedEventHandler(this.OpenCollectionMenuItem_Click);
          break;
        case 8:
          this.SaveCollectionMenuItem = (MenuItem) target;
          this.SaveCollectionMenuItem.Click += new RoutedEventHandler(this.SaveCollectionMenuItem_Click);
          break;
        case 9:
          this.RecentItemList = (MenuItem) target;
          break;
        case 11:
          this.ExitMenuItem = (MenuItem) target;
          this.ExitMenuItem.Click += new RoutedEventHandler(this.ExitMenuItem_Click);
          break;
        case 12:
          this.ToolsMenuItem = (MenuItem) target;
          break;
        case 13:
          this.CreationSuite = (MenuItem) target;
          this.CreationSuite.Click += new RoutedEventHandler(this.OpenCreation_Click);
          break;
        case 14:
          this.HashGenerator = (MenuItem) target;
          this.HashGenerator.Click += new RoutedEventHandler(this.HashGenerator_Click);
          break;
        case 15:
          this.Plugins = (MenuItem) target;
          break;
        case 16:
          this.CloseAllDocumentsMenuItem = (MenuItem) target;
          this.CloseAllDocumentsMenuItem.Click += new RoutedEvent

Handler(this.CloseAllDocumentsMenuItem_Click);
          break;
        case 17:
          ((ButtonBase) target).Click += new RoutedEventHandler(this.OpenFlatbufferItem_Click);
          break;
        case 18:
          ((ButtonBase) target).Click += new RoutedEventHandler(this.OpenSDBItem_Click);
          break;
        case 19:
          this.GameList = (ComboBox) target;
          this.GameList.SelectionChanged += new SelectionChangedEventHandler(this.GameList_SelectionChanged);
          break;
        case 20:
          this.PART_EngineVersion = (ComboBox) target;
          this.PART_EngineVersion.SelectionChanged += new SelectionChangedEventHandler(this.EngineVersion_SelectionChanged);
          break;
        case 21:
          this.AssetEditorToolbarItems = (ItemsControl) target;
          break;
        case 22:
          this.tabControl = (MetaTabControl) target;
          break;
        case 23:
          this.changeLogTextBlock = (TextBlock) target;
          break;
        case 24:
          this.LoadedPluginsList = (ListView) target;
          break;
        case 25:
          this.tabContent = (MetaDetachedTabControl) target;
          break;
        case 26:
          this.miscTabControl = (MetaTabControl) target;
          break;
        case 27:
          this.tb = (TextBox) target;
          this.tb.TextChanged += new TextChangedEventHandler(this.LogTextBox_TextChanged);
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
```

- **IStyleConnector.Connect**: Connects styles based on the connection ID:

```csharp
    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IStyleConnector.Connect(int connectionId, object target)
    {
      if (connectionId != 10)
        return;
      ((MenuItem) target).Click += new RoutedEventHandler(this.MenuRecentItem_Click);
    }
  }
}
```

### Summary

The `MainWindow.cs` file defines a comprehensive WPF main window class that manages a range of functionalities such as loading and saving files, managing tabs, and interacting with various UI components. The class is built to support modular extensions via plugins and integrates command bindings for keyboard shortcuts. The auto-generated methods and event handlers ensure the smooth functioning of the user interface and seamless user interactions.

## /MetaEditor/MemoryConfig.cs

This C# file defines a class `MemoryConfig` in the `MetaEditor` namespace. This class is marked with the `[FlatBufferTable]` attribute, indicating that it is used with FlatBuffers, a serialization library that allows efficient reading and writing of data. The class is used to represent a memory configuration with various properties.

Here’s a detailed explanation:

#### Using Directives

```csharp
using FlatSharp.Attributes;
using System.Collections.Generic;
```

- `FlatSharp.Attributes`: This namespace contains attributes used by the FlatSharp library for FlatBuffers serialization.
- `System.Collections.Generic`: This namespace provides generic collection types such as `Dictionary`.

#### Class Definition

```csharp
#nullable enable
namespace MetaEditor
{
  [FlatBufferTable]
  public class MemoryConfig
  {
    public long MaximumReach { get; set; }

    public Dictionary<string, int> Regions { get; set; }

    public Dictionary<string, string> AOB { get; set; }

    public Dictionary<string, int> ProfileOffsets { get; set; }

    public Dictionary<string, int> MotionOffsets { get; set; }

    public Dictionary<string, int> MoveOffsets { get; set; }
  }
}
```

- `#nullable enable`: Enables nullable reference types, providing better null safety by indicating which variables can be null.
- **Namespace**: `MetaEditor` indicates that this class is part of the `MetaEditor` namespace.
- **Class**: `MemoryConfig` is marked with `[FlatBufferTable]`, which indicates it is a table in FlatBuffers serialization.

#### Properties

- **MaximumReach**: A `long` property indicating the maximum reach value.
- **Regions**: A dictionary mapping strings to integers, likely representing different memory regions and their associated values.
- **AOB**: A dictionary mapping strings to strings, possibly representing arrays of bytes (AOB) and their corresponding patterns or descriptions.
- **ProfileOffsets**: A dictionary mapping strings to integers, representing offsets for different profiles.
- **MotionOffsets**: A dictionary mapping strings to integers, representing offsets for different motions.
- **MoveOffsets**: A dictionary mapping strings to integers, representing offsets for different moves.

## /MetaEditor/MetaGame.cs

This C# file defines a class `MetaGame` in the `MetaEditor` namespace. This class represents a game configuration and includes properties for the executable file, memory configuration, and associated folders.

Here’s a detailed explanation:

#### Using Nullable Reference Types

```csharp
#nullable enable
```

- `#nullable enable`: Enables nullable reference types, providing better null safety by indicating which variables can be null.

#### Namespace and Class Definition

```csharp
namespace MetaEditor
{
  public class MetaGame
  {
    public string Exe { get; set; }

    public MemoryConfig Memory { get; set; }

    public string[] Folders { get; set; }
  }
}
```

- **Namespace**: `MetaEditor` indicates that this class is part of the `MetaEditor` namespace.
- **Class**: `MetaGame` represents a game configuration.

#### Properties

- **Exe**: A `string` property representing the path or name of the executable file for the game.
- **Memory**: A `MemoryConfig` property representing the memory configuration for the game. This leverages the previously defined `MemoryConfig` class.
- **Folders**: A `string[]` property representing an array of folder paths or names associated with the game.

### Summary

- `MemoryConfig`: This class is used to configure various memory-related aspects of the game, with properties for maximum reach, regions, AOB patterns, and offsets for profiles, motions, and moves.
- `MetaGame`: This class represents a game configuration, including the executable file, memory configuration (using the `MemoryConfig` class), and associated folders.

Both classes use nullable reference types for better null safety and are part of the `MetaEditor` namespace, likely for a tool or application related to game configuration and memory management.

## /themes/generic.xaml

The provided `generic.xaml` file is a set of style definitions for various WPF (Windows Presentation Foundation) controls. These styles define the visual appearance and behavior of controls in a WPF application. Below is a summary of the key components and their purposes:

### 1. Border and Polygon

These styles are used to define a border with an inner polygon. The polygon's shape and appearance are specified, and it changes appearance based on mouse interactions (hover and press).

### 2. ControlTemplate.Triggers

These triggers change the appearance of controls based on certain conditions, such as when the mouse hovers over a control or when a button is pressed.

### 3. ScrollViewer and ScrollBar Styles

- `ScrollViewer` and its nested `ScrollBar` controls are styled to customize the appearance of scrollbars.
- The vertical and horizontal scrollbars (`PART_VerticalScrollBar` and `PART_HorizontalScrollBar`) have templates defined to control their look and behavior.

### 4. TreeView and TreeViewItem Styles

- `TreeView` style sets background, border, padding, and foreground colors.
- `TreeViewItem` style defines the layout of items within the TreeView, including the expander button for expanding/collapsing items, and changes appearance based on mouse interactions and item selection.

### 5. Menu and MenuItem Styles

- `Menu` style sets the foreground and background colors and defines how the items within the menu should appear.
- `MenuItem` style differentiates between top-level headers, submenu headers, and submenu items, setting their respective templates and visual states (e.g., highlighted, disabled).

### 6. ListView and ListViewItem Styles

- `ListView` style defines the appearance of the list view control, including background, border, and foreground colors.
- `ListViewItem` style sets up the appearance of items within a ListView, including mouse-over and selection states.

### 7. TabControl and TabItem Styles

- `TabControl` style defines the layout and appearance of tab controls, including the tab strip placement and content panel.
- `TabItem` style customizes the look of individual tabs, including the content and close button.

### 8. ContextMenuItem and Separator Styles

- `ContextMenuItem` style applies the `MenuItem` style to custom context menu items.
- `Separator` style sets the appearance of separator lines within menus.

### 9. Custom Controls (`ctrl` namespace)

Styles are defined for custom controls, which include:

- `MetaTabControl`: A custom tab control with specific appearance and behavior.
- `MetaTabItem`: Custom tab items within the `MetaTabControl`.
- `MetaMessageBox`: A custom message box control with templates for different button configurations (e.g., OK, Cancel, Yes, No).
- `MetaSpinner`: A custom spinner control with animated rotation.
- `MetaDockableWindow`: A custom dockable window with templates for the title bar and buttons.

### 10. PropertyGrid Styles

- `PropertyGrid` style sets the appearance of a property grid control, including background, border, and foreground colors.
- `CategoryControlTemplate`: Defines how categories within the property grid should look.
- `TabHeaderTemplate`: Sets the appearance of tab headers within the property grid.
- `ToolTipTemplate`: Defines how tooltips within the property grid should look.

### ControlTemplate

A `ControlTemplate` is used to define the visual structure of a control. It consists of a hierarchy of elements and visual states that determine how the control appears and responds to user interactions. Each control template in the styles is tailored to customize the look and feel of standard and custom controls.

### Triggers

- `Trigger`: Used to apply property changes based on specific conditions.
- `MultiDataTrigger`: Used to apply property changes based on multiple conditions.
- `DataTrigger`: Used to change property values based on data conditions.

### Summary

Overall, the `generic.xaml` file is a comprehensive set of styles and templates that define the visual theme of a WPF application. It customizes standard controls like `ScrollViewer`, `TreeView`, `Menu`, and `ListView`, as well as custom controls in the `ctrl` namespace, ensuring a consistent and tailored user interface across the application.

## /windows/hashgenwindow.xaml

This XAML code defines a window for a WPF application named `Meta.Editor.Windows.HashGenWindow`. The window uses various namespaces and controls to provide a user interface for generating hashes. Let's break down the key parts of the code:

### 1. **MetaWindow Declaration**

```xml
<ctrl:MetaWindow x:Class="Meta.Editor.Windows.HashGenWindow"
                 xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                 xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                 xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
                 xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
                 xmlns:local="clr-namespace:Meta.Editor.Windows"
                 xmlns:ctrl="clr-namespace:Meta.Editor.Controls"
                 xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes"
                 Title="Meta Hash Generator" Height="140" Width="600" EnableDropShadow="True" ResizeBorderWidth="7"
                 DropShadowOpacity=".5" Background="{StaticResource WindowBackground}" Topmost="False"
                 ResizeMode="NoResize" WindowStartupLocation="CenterScreen" SnapsToDevicePixels="True">
```

- **ctrl:MetaWindow**: A custom window control defined in the `Meta.Editor.Controls` namespace.
- **x:Class**: Specifies the fully qualified name of the class that implements this window.
- **xmlns**: Defines XML namespaces for WPF, XAML, custom controls, and Material Design.
  - `d` and `mc` are typically used for design-time support in tools like Blend.
  - `local`: Refers to the namespace `Meta.Editor.Windows`.
  - `ctrl`: Refers to the namespace `Meta.Editor.Controls`.
  - `materialDesign`: Refers to Material Design themes in XAML.
- **Title**: Title of the window.
- **Height** and **Width**: Specifies the size of the window.
- **EnableDropShadow**: Enables a drop shadow for the window.
- **ResizeBorderWidth**: Width of the resize border.
- **DropShadowOpacity**: Opacity of the drop shadow.
- **Background**: Sets the window's background using a static resource.
- **Topmost**: Specifies that the window is not always on top.
- **ResizeMode**: Disables resizing of the window.
- **WindowStartupLocation**: Centers the window on the screen when it starts.
- **SnapsToDevicePixels**: Ensures pixel alignment for better rendering.

### 2. **Grid Layout**

```xml
<Grid Background="{StaticResource ListBackground}">
  <Grid.RowDefinitions>
    <RowDefinition/>
  </Grid.RowDefinitions>
```

- **Grid**: Main layout container for the window.
  - **Background**: Sets the background of the grid using a static resource.
  - **Grid.RowDefinitions**: Defines a single row with automatic height.

### 3. **Border and StackPanel**

```xml
<Border Margin="5, 6">
  <StackPanel>
```

- **Border**: Provides a border around the stack panel with a margin.
- **StackPanel**: Arranges child elements into a single line, either vertically or horizontally.

### 4. **Grid for Path Input**

```xml
<Grid>
  <Grid.ColumnDefinitions>
    <ColumnDefinition Width="60"/>
    <ColumnDefinition Width="*"/>
    <ColumnDefinition Width="Auto"/>
    <ColumnDefinition Width="Auto"/>
  </Grid.ColumnDefinitions>
  <Label Content="Path " FontFamily="Global User Interface" Width="75" Grid.Column="0"/>
  <TextBox TextChanged="PathInput_SelectionChanged" x:Name="PathInput" Grid.Column="1"
           VerticalContentAlignment="Center" Text="" Margin="1" BorderThickness="1"/>
  <Button x:Name="OpenFileBtn" Grid.Column="2" Width="100" Margin="1,0,0,0">
    <StackPanel Orientation="Horizontal">
      <PackIcon Kind="File" FrameworkElement.Margin="0"/>
      <TextBlock Margin="5 0 0 0" Text="Select File" VerticalAlignment="Center"/>
    </StackPanel>
  </Button>
  <Button x:Name="OpenFolderBtn" Grid.Column="3" Width="100" Margin="1,0,0,0">
    <StackPanel Orientation="Horizontal">
      <PackIcon Kind="Folder" FrameworkElement.Margin="0"/>
      <TextBlock Margin="5 0 0 0" Text="Select Folder" VerticalAlignment="Center"/>
    </StackPanel>
  </Button>
</Grid>
```

- **Grid**: Defines a layout with four columns for the path input section.
  - **ColumnDefinition**: Specifies the widths of the columns.
  - **Label**: Displays the label "Path".
  - **TextBox**: Input field for the path with an event handler for text changes.
  - **Button**: Buttons for selecting a file or folder, each containing a stack panel with an icon and text.

### 5. **DockPanel for Formatted Path**

```xml
<DockPanel LastChildFill="True">
  <TextBlock x:Name="FormattedPath" Text="Waiting..." FontFamily="Global User Interface" FontSize="11"
             Foreground="Gray" FontWeight="Medium" Padding="0,5"/>
</DockPanel>
```

- **DockPanel**: Arranges child elements docked to an edge of the panel.
  - **TextBlock**: Displays the formatted path with initial text "Waiting...".

### 6. **DockPanel for Hash Output**

```xml
<DockPanel LastChildFill="True" Margin="0,0,0,0">
  <Label Content="Hash " FontFamily="Global User Interface" Width="75"/>
  <TextBox x:Name="modTitleTextBox" IsReadOnly="True" VerticalContentAlignment="Center" Text="" Margin="1"
           BorderThickness="1"/>
</DockPanel>
```

- **DockPanel**: Another dock panel for the hash output.
  - **Label**: Displays the label "Hash".
  - **TextBox**: Read-only text box for displaying the generated hash.

### Key Points

- **Custom Window**: Uses `MetaWindow`, a custom window class, for specialized behavior and appearance.
- **Event Handling**: Includes event handlers for path input changes.
- **Layout**: Uses a grid and stack panels for organizing input fields, buttons, and outputs.
- **Styling and Resources**: Uses static resources for consistent styling and appearance.
- **Buttons and Icons**: Provides buttons for selecting files and folders, each with an icon and text for better user experience.

This XAML defines a simple yet functional window for generating hashes, with well-organized input fields and output display areas, all wrapped in a custom window control with additional styling and behavior.

## /windows/inputwindow.xaml

This XAML code defines a custom window named `InputWindow` in a WPF (Windows Presentation Foundation) application. Here's a detailed breakdown:

### `<ctrl:MetaWindow>` Declaration

- **x:Class**: Specifies the code-behind class for this XAML file (`Meta.Editor.Windows.InputWindow`).
- **xmlns**: The default namespace for WPF elements.
- **xmlns:d**: The namespace for design-time tools in Visual Studio and Blend.
- **xmlns:x**: The namespace for XAML's XAML language elements.
- **xmlns:mc**: The namespace for markup compatibility.
- **xmlns:ctrl**: Custom namespace for controls defined in the `Meta.Editor.Controls` namespace.

### Window Properties

- **EnableDropShadow**: Enables a shadow around the window.
- **ResizeBorderWidth**: The width of the border used for resizing.
- **DropShadowOpacity**: The opacity of the drop shadow (0.5).
- **Width** and **Height**: The dimensions of the window (400 by 142).
- **Title**: The title of the window, set to "Input".
- **ResizeMode**: Disables resizing the window (`NoResize`).
- **WindowStartupLocation**: Centers the window on the screen.
- **SnapsToDevicePixels**: Ensures pixel alignment for crisp rendering.

### Grid Layout

- **Grid**: The root layout container with a background color.
  - **Background**: Sets the background color using a static resource (`ListBackground`).
  - **Grid.RowDefinitions**: Defines two rows with automatic height.

### Border

- **Border**: A border that wraps the main content with padding.
  - **Padding**: Sets the padding inside the border to 5.

### StackPanel

- **StackPanel**: A stack panel to arrange elements vertically.
  - **Label**: A label named `lblQuestion`.
    - **Name**: Sets the name to "lblQuestion".
    - **Grid.Column**: Positions the label in the first column.
    - **Content**: Sets the text to "Question:".
  - **TextBox**: A text box named `txtAnswer`.
    - **Name**: Sets the name to "txtAnswer".
    - **Grid.Column**: Positions the text box in the first column.
    - **Grid.Row**: Positions the text box in the first row.
    - **MinWidth**: Sets the minimum width to 250.
    - **Text**: Sets the initial text to "Answer".
  - **WrapPanel**: A wrap panel to arrange buttons horizontally.
    - **Grid.Row**: Positions the wrap panel in the second row.
    - **Grid.ColumnSpan**: Spans the wrap panel across two columns.
    - **HorizontalAlignment**: Aligns the wrap panel to the right.
    - **Margin**: Sets the margin around the wrap panel (0,15,0,0).

### Buttons

- **Button**: Defines an "Accept" button.
  - **Name**: Sets the name to "btnDialogOk".
  - **IsDefault**: Sets the button as the default button.
  - **MinWidth**: Sets the minimum width to 60.
  - **Margin**: Sets the margin around the button (0,0,2,0).
  - **StackPanel**: Arranges content horizontally.
    - **TextBlock**: Displays the text "Accept".
      - **Margin**: Sets the margin around the text (0,0,0,0).
      - **Text**: Sets the text to "Accept".
      - **VerticalAlignment**: Aligns the text vertically to the center.
- **Button**: Defines a "Cancel" button.
  - **IsCancel**: Sets the button as the cancel button.
  - **MinWidth**: Sets the minimum width to 60.
  - **StackPanel**: Arranges content horizontally.
    - **TextBlock**: Displays the text "Cancel".
      - **Margin**: Sets the margin around the text (0,0,0,0).
      - **Text**: Sets the text to "Cancel".
      - **VerticalAlignment**: Aligns the text vertically to the center.

This code creates a simple, centered input window with a shadow and no resizing. The window contains a question label, an answer text box, and "Accept" and "Cancel" buttons. The layout uses a grid, a border for padding, and stack panels for arranging the elements.

## /windows/mainwindow.xaml

This XAML code defines the main window for a WPF application named `MetaEditor.MainWindow`, which uses custom controls from the `Meta.Editor.Controls` namespace. This window includes various controls and layouts to create a feature-rich user interface. Let's break down each part of the code:

### 1. **MetaWindow Declaration**

```xml
<ctrl2:MetaWindow x:Class="MetaEditor.MainWindow"
                  xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                  xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
                  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                  xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
                  xmlns:ctrl2="clr-namespace:Meta.Editor.Controls"
                  xmlns:ext="clr-namespace:Meta.Editor.Extensions"
                  xmlns:clr="clr-namespace:System;assembly=mscorlib"
                  xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes"
                  x:Name="Main" MetaLoaded="Main_MetaLoaded" Icon="{DynamicResource Logo}" Title="dot.Meta Editor"
                  Height="720" Width="1280" ResizeMode="CanResize" WindowStartupLocation="CenterScreen"
                  EnableDropShadow="True" ResizeBorderWidth="7" DropShadowOpacity="0"
                  Background="{StaticResource WindowBackground}" Topmost="False">
```

- **ctrl2:MetaWindow**: A custom window control from the `Meta.Editor.Controls` namespace.
- **x:Class**: Specifies the fully qualified name of the class that implements this window.
- **xmlns**: Defines XML namespaces for WPF, XAML, and custom controls.
  - `d` and `mc` are for design-time support in tools like Blend.
  - `ctrl2`: Custom controls namespace (`Meta.Editor.Controls`).
  - `ext`: Extensions namespace (`Meta.Editor.Extensions`).
  - `clr`: System namespace (`System`) from the mscorlib assembly.
  - `materialDesign`: Material Design themes in XAML.
- **x:Name**: Name of the window.
- **MetaLoaded="Main_MetaLoaded"**: Event handler for the MetaLoaded event.
- **Icon**: Sets the window icon using a dynamic resource.
- **Title**: Title of the window.
- **Height** and **Width**: Specifies the size of the window.
- **ResizeMode**: Allows the window to be resized.
- **WindowStartupLocation**: Centers the window on the screen when it starts.
- **EnableDropShadow**: Enables a drop shadow for the window.
- **ResizeBorderWidth**: Width of the resize border.
- **DropShadowOpacity**: Opacity of the drop shadow.
- **Background**: Sets the window's background.
- **Topmost**: Specifies that the window is not always on top.

### 2. **FrameworkElement.Resources**

```xml
<FrameworkElement.Resources>
  <BitmapImage x:Key="Logo" UriSource="pack://application:,,,/Meta.Editor;component/Images/appicon.png"/>
</FrameworkElement.Resources>
```

- **FrameworkElement.Resources**: Contains resources used within this window.
- **BitmapImage**: Defines an image resource with a specific URI source.

### 3. **Grid Layout**

```xml
<Grid x:Name="mainGrid" Background="{StaticResource ListBackground}">
  <Grid.RowDefinitions>
    <RowDefinition Height="22"/>
    <RowDefinition Height="26"/>
    <RowDefinition Height="30"/>
    <RowDefinition Height="*"/>
    <RowDefinition Height=".3*"/>
  </Grid.RowDefinitions>
```

- **Grid**: Main layout container for the window.
  - **x:Name**: Name of the grid.
  - **Background**: Sets the background of the grid.
  - **Grid.RowDefinitions**: Defines rows with specific heights.

### 4. **Menu (Row 0)**

```xml
<Grid Row="0">
  <Grid.ColumnDefinitions>
    <ColumnDefinition Width="*"/>
  </Grid.ColumnDefinitions>
  <Menu x:Name="menu" Height="22" Grid.Column="0" VerticalAlignment="Top">
    <MenuItem Header="File" Height="22">
      <!-- Menu items for File, Open, Save, etc. -->
    </MenuItem>
    <MenuItem x:Name="ToolsMenuItem" Header="Tools" Height="22"/>
    <MenuItem Header="Utility" Height="22">
      <!-- Utility menu items -->
    </MenuItem>
    <MenuItem x:Name="Plugins" Header="Plugins" Height="22"/>
    <MenuItem Header="Window" Height="22">
      <!-- Window menu items -->
    </MenuItem>
  </Menu>
</Grid>
```

- **Menu**: Defines the menu for the application.
  - **MenuItem**: Represents each menu item, including sub-menus and actions.

### 5. **Toolbar and Controls (Row 1)**

```xml
<Grid Row="1" Background="{StaticResource ListBackground}">
  <Grid.ColumnDefinitions>
    <ColumnDefinition Width="*"/>
    <ColumnDefinition Width="Auto"/>
  </Grid.ColumnDefinitions>
  <Border BorderBrush="{StaticResource ControlBackground}" BorderThickness="0">
    <DockPanel Margin="1">
      <Border HorizontalAlignment="Left" DockPanel.Dock="Left" RenderOptions.EdgeMode="Aliased">
        <StackPanel Orientation="Horizontal" Margin="0">
          <!-- Buttons and ComboBoxes for toolbar -->
        </StackPanel>
      </Border>
      <Border Margin="0" DockPanel.Dock="Left" RenderOptions.EdgeMode="Aliased">
        <ItemsControl x:Name="AssetEditorToolbarItems">
          <!-- ItemsControl for toolbar items -->
        </ItemsControl>
        <FrameworkElement.Style>
          <Style TargetType="{x:Type Border}">
            <Style.Triggers>
              <DataTrigger Binding="{Binding Path=Items.Count, ElementName=AssetEditorToolbarItems}" Value="0">
                <Setter Property="UIElement.Visibility" Value="Collapsed"/>
              </DataTrigger>
            </Style.Triggers>
          </Style>
        </FrameworkElement.Style>
      </Border>
      <Border Background="Transparent" Margin="1,0,0,0" HorizontalAlignment="Stretch" DockPanel.Dock="Left" RenderOptions.EdgeMode="Aliased"/>
    </DockPanel>
  </Border>
</Grid>
```

- **Toolbar**: Contains buttons and controls for various actions.

### 6. **Tab Control (Row 2)**

```xml
<Grid Row="2">
  <Border Grid.Row="1" BorderBrush="{StaticResource ControlBackground}" BorderThickness="0" Margin="0">
    <ctrl2:MetaTabControl x:Name="tabControl" SelectionChanged="tabControl_SelectionChanged" Margin="2,4,2,0">
      <FrameworkElement.Resources>
        <Style TargetType="{x:Type ctrl2:MetaTabItem}">
          <Setter Property="UIElement.AllowDrop" Value="True"/>
          <EventSetter ctrl2:MetaTabItem.MouseMove="MetaTabItem_MouseMove"/>
          <EventSetter ctrl2:MetaTabItem.DragOver="MetaTabItem_DragOver"/>
        </Style>
      </FrameworkElement.Resources>
      <FrameworkElement.Style>
        <Style TargetType="{x:Type ctrl2:MetaTabControl}">
          <Setter Property="Control.Template">
            <Setter.Value>
              <ControlTemplate TargetType="{x:Type ctrl2:MetaTabControl}">
                <!-- ControlTemplate for MetaTabControl -->
              </ControlTemplate>
            </Setter.Value>
          </Setter>
        </Style>
      </FrameworkElement.Style>
      <ctrl2:MetaTabItem Header="Home Page" CloseButtonVisible="False" Icon="Home">
        <!-- Content for Home Page tab -->
      </ctrl2:MetaTabItem>
    </ctrl2:MetaTabControl>
  </Border>
</Grid>
```

- **MetaTabControl**: Custom tab control for organizing content in tabs.
  - **MetaTabItem**: Represents each tab with custom properties and events.

### 7. **Detached Tab Control (Row 3)**

```xml
<Grid Row="3">
  <Border BorderThickness="0" BorderBrush="Transparent" Margin="2 0">
    <ctrl2:MetaDetachedTabControl x:Name="tabContent" Foreground="{StaticResource FontColor}"/>
  </Border>
</Grid>
```

- **MetaDetachedTabControl**: Custom tab control for additional content.

### 8. **Miscellaneous Tab Control (Row 4)**

```xml
<Grid Row="4">
  <Border BorderThickness="0" BorderBrush="{StaticResource ControlBackground}" Margin="2">
    <ctrl2:MetaTabControl x:Name="miscTabControl" Grid.Row="2" BorderThickness="0">
      <ctrl2:MetaTabItem Header="Log" CloseButtonVisible="False">
        <Grid>
          <Border BorderBrush="{StaticResource ControlBackground}" RenderOptions.EdgeMode="Aliased" BorderThickness="0">
            <TextBox TextChanged="LogTextBox_TextChanged" x:Name="tb" FontFamily="Consolas" IsReadOnly="True"
                     VerticalScrollBarVisibility="Auto" HorizontalScrollBarVisibility="Auto" FontWeight="Normal"
                     Background="#FF1D1D1D" Padding="4" BorderBrush="Transparent" BorderThickness="0"/>
          </Border>
        </Grid>
      </ctrl2:MetaTabItem>
    </ctrl2:MetaTabControl>
  </Border>
</Grid>
```

- **Log Tab**: Displays a read-only log in

a text box within a tab.

### Key Points

- **Custom Controls**: Uses custom controls (`MetaWindow`, `MetaTabControl`, `MetaTabItem`) for specialized functionality.
- **Event Handling**: Includes event handlers for various actions.
- **Layout**: Organized using a grid with multiple rows and columns for different UI elements.
- **Styling and Resources**: Uses static resources for consistent styling and appearance.
- **Menus and Toolbars**: Provides a comprehensive menu and toolbar system for user interactions.
- **Tabs**: Uses tab controls to organize different sections of the application.

This XAML defines a feature-rich main window with a structured layout, custom controls, and comprehensive functionality for a WPF application.

## /windows/metaschemawindow.xaml

This XAML code defines a custom window in a WPF (Windows Presentation Foundation) application. Here’s a detailed breakdown:

### `<Window>` Declaration

- **x:Class**: Specifies the code-behind class for this XAML file (`Meta.Editor.Windows.MetaSchemaWindow`).
- **xmlns**: The default namespace for WPF elements.
- **xmlns:x**: The namespace for XAML's XAML language elements.
- **xmlns:d**: The namespace for design-time tools in Visual Studio and Blend.
- **xmlns:mc**: The namespace for markup compatibility.
- **xmlns:local**: Custom namespace for elements defined in the `Meta.Editor.Windows` namespace.
- **xmlns:controls**: Custom namespace for elements defined in the `Meta.Editor.Controls` namespace.

### Window Properties

- **Title**: The title of the window, left empty.
- **Height** and **Width**: The dimensions of the window (60 by 500).
- **AllowsTransparency**: Allows the window to have a transparent background.
- **WindowStyle**: Sets the window style to none, removing the default window chrome (title bar, borders).
- **Background**: Sets the background color using a static resource (`ListBackground`).
- **WindowStartupLocation**: Centers the window on the screen.
- **Topmost**: Ensures the window is always on top.
- **ShowInTaskbar**: Hides the window from the taskbar.

### Grid Layout

- **Grid**: The root layout container named `taskWindow`.
  - **Visibility**: Sets the initial visibility to `Visible`.
  - **SnapsToDevicePixels**: Ensures pixel alignment for crisp rendering.

### Border

- **Border**: A border that wraps the main content.
  - **VerticalAlignment** and **HorizontalAlignment**: Centers the border within the window.
  - **Height** and **Width**: Sets the dimensions of the border (60 by 500).
  - **BorderBrush**: Sets the border color using a static resource (`WindowBackground`).
  - **BorderThickness**: Sets the border thickness to 1.

### Inner Grid

- **Grid**: Contains two rows defined by `Grid.RowDefinitions`.
  - The first row has flexible height, and the second row has a fixed height of 23 units.

### StackPanel

- **StackPanel**: Positioned in the first row (Grid.Row="0").
  - **VerticalAlignment** and **HorizontalAlignment**: Centers the content vertically and horizontally.
  - **Orientation**: Sets the orientation to vertical.
  - **TextBlock**: Displays a text block named `taskTextBlock`.
    - **Text**: Sets the initial text to "Header Text".
    - **Foreground**: Sets the text color using a static resource (`FontColor`).
    - **Margin**: Removes any margins around the text.
    - **FontFamily**: Sets the font family to "Global User Interface".
    - **FontWeight**: Sets the font weight to bold.
    - **VerticalAlignment** and **HorizontalAlignment**: Centers the text within the stack panel.
    - **FontSize**: Sets the font size to 14.

### Inner Grid (Row 1)

- **Grid**: Positioned in the second row (Grid.Row="1").
  - **Background**: Sets the background color using a static resource (`WindowBackground`).
  - **Grid.ColumnDefinitions**: Defines three columns.
    - The first and third columns have fixed widths (26 units and auto, respectively).
    - The second column takes up the remaining space.

### ProgressBar

- **ProgressBar**: Positioned in the first column, spanning three columns (Grid.ColumnSpan="3").
  - **Background** and **BorderBrush**: Set to transparent.
  - **Foreground**: Sets the progress bar color using a static resource (`ListBackground`).
  - **Value**: Binds to the `Progress` property of the `MetaSchemaWindow` using a relative source.

### MetaSpinner

- **controls:MetaSpinner**: Custom control for a spinner animation.
  - **Width** and **Height**: Sets the dimensions to 20 by 20.

### Status TextBlock

- **TextBlock**: Positioned in the second column (Grid.Column="1").
  - **Background**: Sets to transparent.
  - **Padding**: Sets padding around the text (4,5,4,0).
  - **Foreground**: Sets the text color using a static resource (`FontColor`).
  - **FontFamily**: Sets the font family to "Global User Interface".
  - **TextTrimming**: Trims the text with ellipsis if it overflows.
  - **Text**: Binds to the `Status` property of the `MetaSchemaWindow` using a relative source.

### Cancel Button

- **Button**: Positioned in the third column (Grid.Column="2").
  - **Margin**: Sets the margin around the button to 0.
  - **Visibility**: Initially collapsed.
  - **Cursor**: Changes the cursor to hand when hovered over.
  - **ToolTip**: Displays a tooltip when hovered over.
  - **Image**: Displays an image inside the button.
  - **FrameworkElement.Style**: Defines a custom style for the button.
    - **Setter**: Sets various properties like `Background`, `Foreground`, and `Opacity`.
    - **Style.Triggers**: Defines triggers to change the button's appearance based on different states (mouse over, pressed, disabled).
  - **Control.Template**: Defines the control template for the button.
    - **Border**: Sets the background and presents the content within a border.

This code creates a transparent, centered, and topmost window with a progress bar, a spinner, a status text block, and a cancel button. The window is designed to display schema-related information and progress in a sleek, minimalistic style.

## /windows/metataskwindow.xaml

This XAML code defines a custom window in a WPF (Windows Presentation Foundation) application. Here’s a detailed breakdown:

### `<Window>` Declaration

- **x:Class**: Specifies the code-behind class for this XAML file (`Meta.Editor.Windows.MetaTaskWindow`).
- **xmlns**: The default namespace for WPF elements.
- **xmlns:x**: The namespace for XAML's XAML language elements.
- **xmlns:d**: The namespace for design-time tools in Visual Studio and Blend.
- **xmlns:mc**: The namespace for markup compatibility.
- **xmlns:local**: Custom namespace for elements defined in the `Meta.Editor.Windows` namespace.
- **xmlns:controls**: Custom namespace for elements defined in the `Meta.Editor.Controls` namespace.

### Window Properties

- **Title**: The title of the window, left empty.
- **Height** and **Width**: The dimensions of the window (60 by 500).
- **AllowsTransparency**: Allows the window to have a transparent background.
- **WindowStyle**: Sets the window style to none, removing the default window chrome (title bar, borders).
- **Background**: Sets the background color using a static resource (`ListBackground`).
- **WindowStartupLocation**: Centers the window on the screen.
- **Topmost**: Ensures the window is always on top.
- **ShowInTaskbar**: Hides the window from the taskbar.

### Grid Layout

- **Grid**: The root layout container named `taskWindow`.
  - **Visibility**: Sets the initial visibility to `Visible`.
  - **SnapsToDevicePixels**: Ensures pixel alignment for crisp rendering.

### Border

- **Border**: A border that wraps the main content.
  - **VerticalAlignment** and **HorizontalAlignment**: Centers the border within the window.
  - **Height** and **Width**: Sets the dimensions of the border (60 by 500).
  - **BorderBrush**: Sets the border color using a static resource (`WindowBackground`).
  - **BorderThickness**: Sets the border thickness to 1.

### Inner Grid

- **Grid**: Contains two rows defined by `Grid.RowDefinitions`.
  - The first row has flexible height, and the second row has a fixed height of 23 units.

### StackPanel

- **StackPanel**: Positioned in the first row (Grid.Row="0").
  - **VerticalAlignment** and **HorizontalAlignment**: Centers the content vertically and horizontally.
  - **Orientation**: Sets the orientation to vertical.
  - **TextBlock**: Displays a text block named `taskTextBlock`.
    - **Text**: Sets the initial text to "Header Text".
    - **Foreground**: Sets the text color using a static resource (`FontColor`).
    - **Margin**: Removes any margins around the text.
    - **FontFamily**: Sets the font family to "Global User Interface".
    - **FontWeight**: Sets the font weight to bold.
    - **VerticalAlignment** and **HorizontalAlignment**: Centers the text within the stack panel.
    - **FontSize**: Sets the font size to 14.

### Inner Grid (Row 1)

- **Grid**: Positioned in the second row (Grid.Row="1").
  - **Background**: Sets the background color using a static resource (`WindowBackground`).
  - **Grid.ColumnDefinitions**: Defines three columns.
    - The first and third columns have fixed widths (26 units and auto, respectively).
    - The second column takes up the remaining space.

### ProgressBar

- **ProgressBar**: Positioned in the first column, spanning three columns (Grid.ColumnSpan="3").
  - **Background** and **BorderBrush**: Set to transparent.
  - **Foreground**: Sets the progress bar color using a static resource (`ListBackground`).
  - **Value**: Binds to the `Progress` property of the `MetaTaskWindow` using a relative source.

### MetaSpinner

- **controls:MetaSpinner**: Custom control for a spinner animation.
  - **Width** and **Height**: Sets the dimensions to 20 by 20.

### Status TextBlock

- **TextBlock**: Positioned in the second column (Grid.Column="1").
  - **Background**: Sets to transparent.
  - **Padding**: Sets padding around the text (4,5,4,0).
  - **Foreground**: Sets the text color using a static resource (`FontColor`).
  - **FontFamily**: Sets the font family to "Global User Interface".
  - **TextTrimming**: Trims the text with ellipsis if it overflows.
  - **Text**: Binds to the `Status` property of the `MetaTaskWindow` using a relative source.

### Cancel Button

- **Button**: Positioned in the third column (Grid.Column="2").
  - **Margin**: Sets the margin around the button to 0.
  - **Visibility**: Initially collapsed.
  - **Cursor**: Changes the cursor to hand when hovered over.
  - **ToolTip**: Displays a tooltip when hovered over.
  - **Image**: Displays an image inside the button.
  - **FrameworkElement.Style**: Defines a custom style for the button.
    - **Setter**: Sets various properties like `Background`, `Foreground`, and `Opacity`.
    - **Style.Triggers**: Defines triggers to change the button's appearance based on different states (mouse over, pressed, disabled).
  - **Control.Template**: Defines the control template for the button.
    - **Border**: Sets the background and presents the content within a border.

This code creates a transparent, centered, and topmost window with a progress bar, a spinner, a status text block, and a cancel button. The window is designed to display task-related information and progress in a sleek, minimalistic style.

## /windows/optionswindow.xaml

This XAML code defines a custom window for a WPF application named `OptionsWindow`, which is a part of the `Meta.Editor.Windows` namespace. The window uses various namespaces and controls to provide a user interface for setting options. Let's break down the key parts of the code:

### 1. **MetaWindow Declaration**

```xml
<ctrl:MetaWindow x:Class="Meta.Editor.Windows.OptionsWindow"
                 xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                 xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                 xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
                 xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
                 xmlns:ctrl="clr-namespace:Meta.Editor.Controls"
                 xmlns:pt="http://propertytools.org/wpf"
                 xmlns:propertyGrid1="http://schemas.xceed.com/wpf/xaml/toolkit"
                 Loaded="Window_Loaded" Title="Options" Height="720" Width="600" EnableDropShadow="True"
                 ResizeBorderWidth="7" DropShadowOpacity=".5" Background="{StaticResource WindowBackground}"
                 Topmost="False" ResizeMode="NoResize" WindowStartupLocation="CenterScreen"
                 SnapsToDevicePixels="True">
```

- **ctrl:MetaWindow**: A custom window control defined in the `Meta.Editor.Controls` namespace.
- **x:Class**: Specifies the fully qualified name of the class that implements this window.
- **xmlns**: Defines XML namespaces for WPF, XAML, and custom controls.
  - `d` and `mc` are typically used for design-time support in tools like Blend.
  - `ctrl`: Custom controls namespace (`Meta.Editor.Controls`).
  - `pt`: PropertyTools namespace for property grid controls.
  - `propertyGrid1`: Another namespace for property grid controls from Xceed.

### 2. **Window Properties**

- **Loaded="Window_Loaded"**: Event handler for the window's Loaded event.
- **Title="Options"**: Title of the window.
- **Height="720" Width="600"**: Specifies the size of the window.
- **EnableDropShadow="True"**: Enables a drop shadow for the window.
- **ResizeBorderWidth="7"**: Width of the resize border.
- **DropShadowOpacity=".5"**: Opacity of the drop shadow.
- **Background="{StaticResource WindowBackground}"**: Sets the window's background.
- **Topmost="False"**: Specifies that the window is not always on top.
- **ResizeMode="NoResize"**: Disables resizing of the window.
- **WindowStartupLocation="CenterScreen"**: Centers the window on the screen when it starts.
- **SnapsToDevicePixels="True"**: Ensures pixel alignment for better rendering.

### 3. **FrameworkElement.Resources**

```xml
<FrameworkElement.Resources>
  <ResourceDictionary/>
</FrameworkElement.Resources>
```

- **FrameworkElement.Resources**: Contains resources that can be used within this window. Currently, it's an empty `ResourceDictionary`.

### 4. **Grid Layout**

```xml
<Grid Background="{StaticResource WindowBackground}">
  <Grid.RowDefinitions>
    <RowDefinition/>
    <RowDefinition Height="38"/>
  </Grid.RowDefinitions>
  <PropertyGrid x:Name="pgrid" FrameworkElement.Margin="0" Control.Padding="4" TabVisibility="VisibleIfMoreThanOne"
                CategoryControlType="Template"/>
  <Border Grid.Row="2" Background="{StaticResource ListBackground}">
    <Grid Margin="8">
      <DockPanel LastChildFill="False">
        <Button Click="cancelButton_Click" x:Name="cancelButton" Content="Cancel" DockPanel.Dock="Left" Width="75"/>
        <Button Click="saveButton_Click" x:Name="saveButton" Content="Save" DockPanel.Dock="Right" Width="75"/>
      </DockPanel>
    </Grid>
  </Border>
</Grid>
```

- **Grid**: Main layout container for the window.
  - **Background="{StaticResource WindowBackground}"**: Sets the background of the grid.
  - **Grid.RowDefinitions**: Defines two rows, one filling the available space and one with a fixed height of 38 units.

### 5. **PropertyGrid**

```xml
<PropertyGrid x:Name="pgrid" FrameworkElement.Margin="0" Control.Padding="4" TabVisibility="VisibleIfMoreThanOne" CategoryControlType="Template"/>
```

- **PropertyGrid**: A control used to display and edit properties. This is from the PropertyTools or Xceed toolkit.
  - **x:Name="pgrid"**: Names the control for reference in code-behind.
  - **FrameworkElement.Margin="0"**: Sets the margin.
  - **Control.Padding="4"**: Sets the padding inside the control.
  - **TabVisibility="VisibleIfMoreThanOne"**: Shows tabs if there is more than one.
  - **CategoryControlType="Template"**: Sets the type of control used for categories.

### 6. **Bottom Border with Buttons**

```xml
<Border Grid.Row="2" Background="{StaticResource ListBackground}">
  <Grid Margin="8">
    <DockPanel LastChildFill="False">
      <Button Click="cancelButton_Click" x:Name="cancelButton" Content="Cancel" DockPanel.Dock="Left" Width="75"/>
      <Button Click="saveButton_Click" x:Name="saveButton" Content="Save" DockPanel.Dock="Right" Width="75"/>
    </DockPanel>
  </Grid>
</Border>
```

- **Border**: Provides a border around the bottom section of the window.
  - **Grid.Row="2"**: Places the border in the second row of the grid.
  - **Background="{StaticResource ListBackground}"**: Sets the background of the border.
  - **Grid**: Contains the buttons.
    - **Margin="8"**: Sets the margin around the grid.
    - **DockPanel**: Arranges child elements horizontally or vertically.
      - **LastChildFill="False"**: The last child does not fill the remaining space.
      - **Button**: Two buttons (`Cancel` and `Save`) with click event handlers (`cancelButton_Click` and `saveButton_Click`), names, content, docking, and widths.

### Key Points

- **Custom Window**: Uses `MetaWindow`, a custom window class, for specialized behavior and appearance.
- **Event Handling**: Includes event handlers for window loading and button clicks.
- **Layout**: Utilizes a grid layout with rows for the main content and buttons.
- **PropertyGrid**: A key control for displaying and editing properties, likely central to the options functionality.
- **Styling and Resources**: Uses static resources for consistent styling across the application.

This XAML defines a well-structured options window with a property grid for settings and buttons for saving or canceling changes, all wrapped in a custom window control with additional styling and behavior.

## /windows/schemawindow.xaml

This XAML code defines a window in a WPF (Windows Presentation Foundation) application. Here’s a detailed breakdown:

### `<ctrl:MetaWindow>` Declaration

- **x:Class**: Specifies the code-behind class for this XAML file.
- **xmlns**: The default namespace for WPF elements.
- **xmlns:x**: The namespace for XAML's XAML language elements.
- **xmlns:d**: The namespace for design-time tools in Visual Studio and Blend.
- **xmlns:mc**: The namespace for markup compatibility.
- **xmlns:ctrl**: Custom namespace for controls defined in the `Meta.Editor.Controls` namespace.
- **xmlns:local**: Custom namespace for other elements in the `Meta.Editor.Windows` namespace.

### Window Properties

- **Title**: The title of the window, "Schema Library".
- **Height** and **Width**: The dimensions of the window.
- **EnableDropShadow**: Enables a shadow around the window.
- **ResizeBorderWidth**: The width of the border used for resizing.
- **DropShadowOpacity**: The opacity of the drop shadow.
- **Background**: The background color or resource.
- **Topmost**: Determines whether the window is always on top.
- **ResizeMode**: Disables resizing the window.
- **WindowStartupLocation**: Centers the window on the screen.
- **SnapsToDevicePixels**: Ensures pixel alignment for crisp rendering.

### Resources

- **<local:SchemaNameConverter x:Key="CleanSchema"/>**: A resource defining a value converter named "CleanSchema".

### Grid Layout

- **Grid**: The root layout container.
- **Grid.RowDefinitions**: Defines two rows, the first flexible and the second fixed at 38 units high.

### DataGrid

- **DataGrid**: Displays data in a tabular format.
  - **Grid.Row="0"**: Positions the DataGrid in the first row.
  - **Background**: Sets the background color.
  - **BorderThickness, Padding, HorizontalAlignment, HeadersVisibility**: Configures layout and appearance.
  - **CanUserAddRows, CanUserDeleteRows, AutoGenerateColumns, SelectionUnit, IsReadOnly, HorizontalContentAlignment, SelectionMode**: Configures user interactions.
  - **ItemsSource**: Binds to the data source "Schemas".
  - **SelectedItem**: Two-way binds to the selected schema.

### DataGrid Columns

- **DataGridTextColumn**: Defines columns for displaying text.
  - **Binding**: Binds to properties of the data source, with converters where needed.
  - **Header**: Sets the column header text.
  - **Width**: Configures column width.

### Header and Cell Styles

- **<Style TargetType="{x:Type DataGridColumnHeader}">**: Defines styles for column headers.

  - **Setter**: Sets various properties like `Background`, `Foreground`, `FontWeight`, `BorderThickness`, `Padding`, and `BorderBrush`.

- **<Style TargetType="{x:Type DataGridCell}">**: Defines styles for data cells.
  - **Setter**: Sets properties like `Background`, `Foreground`, and `BorderThickness`.
  - **<Style.Triggers>**: Changes cell background when selected.

### Bottom Buttons

- **Border**: Wraps the bottom section.
  - **Grid**: Contains the buttons.
  - **DockPanel**: Layout container for buttons.
    - **Button**: Defines "Cancel" and "Accept" buttons with click event handlers (`CancelButton_Click` and `OkButton_Click`).

This code creates a non-resizable, centered window with a DataGrid that lists schemas with columns for Name, Tag, and Description. The DataGrid is styled, and the window includes "Cancel" and "Accept" buttons at the bottom.

## /XamlGeneratedNamespace/GeneratedInternalTypeHelper.cs

This C# code defines a sealed class `GeneratedInternalTypeHelper` within the namespace `XamlGeneratedNamespace`. This class is automatically generated by the XAML compiler and is used internally by the WPF infrastructure to facilitate the creation and manipulation of types, properties, delegates, and events during the parsing and compilation of XAML. Here's a detailed breakdown of the code:

### Namespace and Usings

```csharp
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Windows.Markup;
```

- **System**: Provides fundamental classes and base classes that define commonly-used values and reference data types.
- **System.CodeDom.Compiler**: Contains classes for generating and compiling source code.
- **System.ComponentModel**: Contains classes that are used to implement the run-time and design-time behavior of components and controls.
- **System.Diagnostics**: Provides classes that allow you to interact with system processes, event logs, and performance counters.
- **System.Globalization**: Contains classes that define culture-related information, including language, country/region, calendars, and formatting of dates and numbers.
- **System.Reflection**: Provides classes that retrieve information about assemblies, modules, members, parameters, and other entities in managed code.
- **System.Windows.Markup**: Contains classes for XAML markup.

### Class Definition

```csharp
namespace XamlGeneratedNamespace
{
  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public sealed class GeneratedInternalTypeHelper : InternalTypeHelper
  {
    ...
  }
}
```

- **namespace XamlGeneratedNamespace**: Declares the namespace for the class.
- **DebuggerNonUserCode**: Instructs the debugger to step through this code without stopping, treating it as non-user code.
- **GeneratedCode**: Indicates that the code was generated by a tool (the XAML compiler, in this case).
- **EditorBrowsable(EditorBrowsableState.Never)**: Hides the class from IntelliSense in the editor, making it less likely to be used accidentally.
- **sealed**: Indicates that the class cannot be inherited.
- **GeneratedInternalTypeHelper**: The class name, inheriting from `InternalTypeHelper`.

### Methods

#### CreateInstance

```csharp
protected virtual object CreateInstance(Type type, CultureInfo culture)
{
  return Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.CreateInstance, null, null, culture);
}
```

- **CreateInstance**: Creates an instance of the specified type, using the specified culture for any culture-specific information.
- **Activator.CreateInstance**: Uses reflection to create an instance of the specified type.

#### GetPropertyValue

```csharp
protected virtual object GetPropertyValue(PropertyInfo propertyInfo, object target, CultureInfo culture)
{
  return propertyInfo.GetValue(target, BindingFlags.Default, null, null, culture);
}
```

- **GetPropertyValue**: Retrieves the value of the specified property from the target object, using the specified culture for any culture-specific information.
- **propertyInfo.GetValue**: Uses reflection to get the value of the property.

#### SetPropertyValue

```csharp
protected virtual void SetPropertyValue(PropertyInfo propertyInfo, object target, object value, CultureInfo culture)
{
  propertyInfo.SetValue(target, value, BindingFlags.Default, null, null, culture);
}
```

- **SetPropertyValue**: Sets the value of the specified property on the target object, using the specified culture for any culture-specific information.
- **propertyInfo.SetValue**: Uses reflection to set the value of the property.

#### CreateDelegate

```csharp
protected virtual Delegate CreateDelegate(Type delegateType, object target, string handler)
{
  return (Delegate) target.GetType().InvokeMember("_CreateDelegate", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, target, new object[2] { delegateType, handler }, null);
}
```

- **CreateDelegate**: Creates a delegate of the specified type for the specified target object and method handler.
- **target.GetType().InvokeMember**: Uses reflection to invoke a method named `_CreateDelegate` on the target object.

#### AddEventHandler

```csharp
protected virtual void AddEventHandler(EventInfo eventInfo, object target, Delegate handler)
{
  eventInfo.AddEventHandler(target, handler);
}
```

- **AddEventHandler**: Adds an event handler to the specified event on the target object.
- **eventInfo.AddEventHandler**: Uses reflection to add the event handler.

### Summary

The `GeneratedInternalTypeHelper` class provides methods for creating instances, getting and setting property values, creating delegates, and adding event handlers. These methods use reflection to interact with the types and members at runtime, making them essential for the WPF framework to dynamically create and manipulate objects and their properties based on the XAML definitions. The class is marked with attributes to indicate it is generated code, should not be user-modified, and is hidden from IntelliSense to prevent accidental usage.
