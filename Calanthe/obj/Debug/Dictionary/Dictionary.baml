   M S B A M L   `   `   `  ����C  ?Calanthe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CalantheCalanthe  5   	       Calanthe.Dictionary   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Calanthe     5   	   -   5           win#��[  5   	     � Title$  Diccionario��5	   	    � WindowStartupLocation$ CenterScreen=�6   .��5
      �  J� RenderTransformOrigin$ 0.048,0.142&�6    � ColumnDefinitions 5   
   �� 5      $
��147* �6   �� 5      $
��916* �6   �� 5      $
��147* �6    � RowDefinitions 5   
   �� 5      $	��94* �6   �� 5      $
��429* �6   �� 5      $	��98* �6   .+�5   
   �� $��0��6   $��2��6   $��/Resources/Logo.ico��6-   $��0,0,6,0q�6J   �� 5   
   -   5         ��Name$ Back_b��5   /     Base#��[ 6   $��0��6?   $��0��6O   $
��Auto��6\   $
��Auto��6i   $��Atrás��6w   $��16,28,16,27q�6�   6�   � 5   
   $��1��6   $��1��6    5      �� 5      $	��30* �6    �� 5      $
��113* �6    .+�5      � $��0��6   $��Right=�6%   .+�5      �� $��58��6   ��5       �� 5!       �� ImageSource$ Research.png��6%    j� Stretch$ Uniform=�6@   5#      �� 5$      -   5         ��Name$ 
tbResearch��5$      $	��267��6.   ���	#FF0A08086x   5%      &   System.Windows.Controls.DataGrid  5'      -   5        	  Name$	 dbWords��5'   ;     	data_grid#��[ 6   $��1��6L   
   Columns
 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Header$ Palabra��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *Word+6S     5*      $ Traducción��6)   $ * 6]    6=   �� *Translation+6]   4  .System.Windows.Controls.DataGridTemplateColumn  5+         CellTemplate 5,      �� 5-      .R�5.   "   �� $ edit_b��6K   -   5          Research#��[ 5.   )   $��Corregir��6[   6�   5/      51        52       53      �� 54      .R�55   "   �� $ del_b��6K   -   5        #��[ 55   )   $��Eliminar��6Z   6�   56      58      5:      5;      � 5=   
   $��1��6   $��2��6$   $��Center=�61   $��Center=�6N   .+�5>      �� -   5        $ Back_lessons��5>      $��Lección��6+   6=   �� 5?      -   5        $ Add_b��5?      $��Agregar��6$   66   5@      5A      5B      