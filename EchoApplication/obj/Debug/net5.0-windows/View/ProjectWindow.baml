   M S B A M L   `   `   `  ????J  FEchoApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:EchoApplication.ViewEchoApplication.View  5      (    "EchoApplication.View.ProjectWindow   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:EchoApplication.View     5      _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .??5
      ?   ? RowDefinitions  5   
   ?? 5      $
??auto ?6   ?? 5      $??* ?6   .+?5   
   &   System.Windows.Controls.DataGrid  -   5        $??1??5      $??Disabled=?6J      AutoGenerateColumns$ False??6?      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6?   ??6    ?? *ProjectCollection+ ?? SelectedItem 6?   ?? *SelectedProjectItem+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly$
 True??6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   ??  ?? Path$
 Name?   HeaderStyle 5      ?? 5      	 ?? 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"	  6    .?5      ?? 
 ?? Property
 ? ?? ?? Value 5   "   ?? 5   &    ?? 
TargetType"  66   .R?5   *   ?? $??5q?61   
???????$??1q?6T    ?? CornerRadius$ 1??6h   
???????._?5   .   ?? $-??'Наименование проекта??68   $??Stretch=?6T   $??Center=?6s    ?? TextAlignment$ Center=?6?   
?????p?6?   5   +   5   '   5       ?? Triggers 5      P? 5   "    P? Property ?@J?IsMouseOver P? Value$
 True??6A   . ?5   &   ?? 
 ? ?? 5    *   ?? 5!   .   "  6>   .R?5"   2   ?? $??5q?69   
???????$??1q?6\   $ 1??6p   
???????._?5#   6   ?? $-??'Наименование проекта??6@   $??Stretch=?6\   $??Center=?6{   $ Center=?6?   
???   ?6?   5$   3   5%   /   5'   '   5(   #   5*         ElementStyle 5,      ?? 5-      "	 ??6    .?5.      ?? 
 ? ??$ Center=?6D   5/      51      4  .System.Windows.Controls.DataGridTemplateColumn  52         Header$ Настройка??6)    53      ?? 54      "	  6    .?55      ?? 
 ? ?? 56   "   ?? 57   &   "  66   .R?58   *   ?? $??5q?61   
???????$??1q?6T   $ 1??6h   
???????._?59   .   ?? $??Настройка??68   $??Stretch=?6I   $??Center=?6h   $ Center=?6?   
???   ?6?   5:   +   5;   '   5=      5>         CellTemplate 5@      ?? 5A      .R?5B      ??  ?? Orientation$ 
Horizontal=?6)   $??5q?6B   .+?5C   "   ?? $??5q?6)   $??Отрисовка??64   ???	#FF3A56B7??6H   ??  ?? RelativeSource ??  ?? AncestorType DataGrid$ DataContext.DrawButton?6?   ?? 5D   "   $??5q?6)   $"??Экспортировать??64   ???	#FF3A56B7??6M   ??  ??  DataGrid$% DataContext.ExportProjectButton?6?   ?? 5E   "   $??5q?6)   $??Изменить??64   ???	#FF3A56B7??6G   ??  ??  DataGrid$# DataContext.EditProjectButton?6?   ?? 5F   "   $??5q?6)   $??Удалить??64   ???	#FFF12F1B??6F   ??  ??  DataGrid$% DataContext.DeleteProjectButton?6?   5G      5I      5K         RowDetailsTemplate 5M      ?? 5N      .R?5O        -   5        $ False??5O   J   $ * 6f   $??Disabled=?6v    "  TemplateDataGridPrintAndExport#???   5S      ??5O      ?? *BoreHoleCollection+ 5P      ?? *SelectedBoreHoleData+ ?? UpdateSourceTrigger$ PropertyChanged=?1   +EchoApplication.View.FixScrollingBehaviorOn   ParentDataGrid 5R       ??  ?? *FindAncestor+"   5T        5U      $ Скважина??61   $
 True??6C    6V   ?? *BoreHoleName+  5V      $ Настройка??65    5W   "   ?? 5X   &   "	  6,   .?5Y   *   ?? 
 ? ??$ Center=?6P   5Z   '    5\   "   ?? 5]   &   .R?5^   *   ?? $ 
Horizontal=?65   $??5q?6N   .+?5_   .   ?? $??5q?65   $??Изменить??6@   ???	#FF3A56B7??6S   ??  ??  DataGrid$* $DataContext.EditBoreHoleParamsButton?6?   ?? 5`   .   $??5q?65   $??Удалить??6@   ???	#FFF12F1B6S   5a   +   5c   '   5e       5g      ?? 5h      .R?5i   "     $ False??6+   $ * 6H      
IsReadOnly$
 True??6?   ??6X   ?? *ProjectDataCollection+ 6?   ?? *SelectedProjectData+$ PropertyChanged=? 5j   &     5k   *   $ Время замера??6=    6S   ?? *MeasureTime+  5l   *   $ Время отклика??6=    6T   ?? *ResponseTime+  5m   *   $! Скорость звука??6=    6U   ?? *SpeedOfSound+  5n   *   $ Дистанция (m)??6=    6T   ?? *
Distance+  5o   *   $ Настройка??6A    5p   .   ?? 5q   2   "	  68   .?5r   6   ?? 
 ? ??$ Center=?6\   5s   3    5u   .   ?? 5v   2   .R?5w   6   ?? $ 
Horizontal=?6A   $??5q?6Z   .+?5x   :   ?? $??5q?6A   $??Изменить??6L   ???	#FF3A56B7??6_   ??  ??  DataGrid$' !DataContext.EditProjectDataButton?6?   ?? 5y   :   $??5q?6A   $??Удалить??6L   ???	#FFF12F1B??6^   ??  ??  DataGrid$) #DataContext.DeleteProjectDataButton?6?   5z   7   5|   3   5~   +   5?   #   5?      5?      5?      5?      5?      5?      