   M S B A M L   `   `   `  ????J  FEchoApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:EchoApplication.ViewEchoApplication.View  5   	   E'clr-namespace:EchoApplication.ViewModelEchoApplication.ViewModel  5   	   %    EchoApplication.View.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3view"clr-namespace:EchoApplication.View     5   	   =	viewmodel'clr-namespace:EchoApplication.ViewModel     5   	     ? Title$  Главное меню??5	   	   $??Center=?6   $	??800??6;   $
??1250??6H    ? WindowStartupLocation$ CenterScreen=?6U    ? WindowState$ Normal=?6z    ? 
ResizeMode$ 	CanResize=?6?   .??5      ?? $??5q?6   
???????$??3q?61    ?? CornerRadius$ 2??6E   ._?5   
   ?  ? ColumnDefinitions 5      ?? 5      $
??321* ?6#   ?? 5      $
??296* ?6#    ? RowDefinitions 5      ?? 5      $
??auto ?6    ?? 5      $??* ?6    .+?5      ?? $??0??6   $??0,0,0,2q?6"   
???????$??2??6U   ._?5      ?  5      ?? 5      $
??auto ?6(   .+?5      ? $??0??6    5      ?? 5      $
??auto ?6/   ?? 5      .+?5      ?? $??0??6$   $??Bottom=?64   $??5q?6O   $??20(?6Z   ??6h   ?? *SelectedProjectNameText+?? 5       $??1??6%   $??5q?65    ?? Orientation$ 
Horizontal=?6@   $??Bottom=?6Y   $??Right=?6t   .+?5!      ?? $??0,0,5,0q?6%   $.??(Добавить новый проект??66    ? Cursor$
 Hand??6t   ???	#FF3A56B7??6V   ?? *	AddButton+6?   5$      5%      5&      5'      ?? 5(      $??1??6   $??2??6O   ??6*   ?? *CurrentViewModel+	 ? 	Resources	 5)      
 ?? DataType2  ,EchoApplication.ViewModel.ProjectWindowModel(   "EchoApplication.View.ProjectWindow9  3EchoApplication.ViewModel.ProjectElementWindowModel/   )EchoApplication.View.ProjectElementWindow??%?   (??       5*   #   *, +)(?? 2     5-   #   *, +)?? 5*      "
  6#   .R?5+        5,      ?? 5-      "
  6#   .R?5.        5/      50      51      52      53      55      