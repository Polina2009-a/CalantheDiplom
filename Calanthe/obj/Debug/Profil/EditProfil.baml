   M S B A M L   `   `   `  ����C  ?Calanthe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CalantheCalanthe  5   	       Calanthe.EditProfil   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Calanthe     5   	      win#��[  5   	     � Title$  Editar perfil��5	   	    � WindowStartupLocation$ CenterScreen=�6   .��5
      �  J� RenderTransformOrigin$ 0.048,0.142&�6    � ColumnDefinitions 5   
   �� 5      $
��147* �6   �� 5      $
��916* �6   �� 5      $
��147* �6    � RowDefinitions 5   
   �� 5      $	��94* �6   �� 5      $
��433* �6   �� 5      $	��94* �6   .+�5   
   � $��1��6   $��2��6   $
��84,0q�60    5      �� 5      $
��234* �6    �� 5      $	��36* �6    �� 5      $	��22* �6    �� 5      $	��33* �6    �� 5      $	��42* �6    �� 5      $	��38* �6    �� 5      $	��42* �6    �� 5      $	��38* �6    �� 5      $	��42* �6    .+�5"      � $��1��6   $��170,0q�6    $��8��6/    5#      �� 5$      $	��65* �6'   �� 5%      $
��266* �6'   �� 5&      $��65 �6'    5(      �� 5)      $	��30* �6$   �� 5*      $	��45* �6$   �� 5+      $	��30* �6$   �� 5,      $	��35* �6$   �� 5-      $	��48* �6$   �� 5.      $	��31* �6$   �� 5/      $	��34* �6$   �� 50      $	��48* �6$   �� 51      $	��38* �6$   ��53      �� 54       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��55      �  � Color$ 	#FFAF5FC4��6'   � 56      $ 	#FF422449��6'    � Offset$ 1Q�69   57      .+�59      �� $��0��6   $��1��6%   $��	0,0,129,0q�65   .��6H   Inicio de sesión6Z   �� 5:      -   5        	 ��Name$	 Login��5:      $��1��6)   $��1��66   ��6F   Z� .��6]   ��5;      �� 5<      
 �� ImageSource$
 /Resources/Line.png��6%   .��5=   *   5>      �� 5?      $��3��6   $��1��6%   .��65   Correo electrónico6I   �� 5@      -   5        $
	 Mail��5@      $��4��6(   $��1��65    �� 
IsReadOnly . ��6E   Z� .��6o   ��5A      �� 5B      $
 /Resources/Line.png��6%   .��5C   *   5D      �� 5E      $��6��6   $��1��6%   .��65   Contraseña6A   G� 5F      -   5         G�Name$ Password_pb��5F      $y�Hidden=�63   $��7��6H   $��1��6U   $��0,0,34,0q�6�   ��6f   Z� ��5G      �� 5H      $
 /Resources/Line.png��6%   5J      �� 5K      -   5        $	 Password��5K      $��7��6,   $��1��6:   $��0,0,37,0q�6�   ��6J   Z� .��6�   ��5L      �� 5M      $
 /Resources/Line.png��6%   .��5N   *   5O      �� 5P      -   5         ��Name$	 eye��5P        eye#��[ 6&   $��1��6C   $��7��6T   $
��Left=�6a   $��31��6�   $��	229,0,0,0q�6�   ��6|   Z� ��6�   Z� ��5Q      �� 5R       j� Stretch$ Uniform=�6%   $+
 %/Calanthe;component/Resources/Eye.png��67   5T      5U      o� 5W        menu#��[ 6   $��24��61   $��Bottom=�6=   $��
0,0,224,58q�6X   $��Right=�6l   $	��133��6�    K� ZIndex$ 3��6�   .@�5X      m�   menuitem#��[ 6   $��
Subir foto��6=   $��24��6Q   $	��133��6]    m� Icon 5Y      �� 5Z      $G��AC:\Users\Полина\Desktop\Calanthe\Calanthe\Profil\Pencil.png��6    .@�5\      m� -   5         m�Name$ NewFoto��5\      #��[ 61   $��Cargar��6S   6c   m� 5]      -   5        $	 Del��5]      #��[ 6-   $��Eliminar��6O   6a   5^      5`      A� 5b      -   5         A�Name$ imageEllipse��5b      $��0��6,   $��268,44,268,29q�69   6R   5c      �� 5e   
   $��0��6   $��2��6   $��/Resources/Logo.ico��6-   $��0,0,6,0q�6J   �� 5g   
   -	   5        $ Back_b��5g   /     Base#��[ 6   $��0��6?   $��0��6O   $
��Auto��6\   $
��Auto��6i   $��16,28,16,27q�6w   $��Atrás��6�   6�   � 5i   
   $��1��6   $��2��6$   $��Center=�61   $��Center=�6N   .+�5j      �� -
   5        $ Save_b��5j      $��Guardar��6&   $��0,0,40,0q�68   6J   �� 5k      -   5        $ GoOut_b��5k      $��Salir��6'   67   5l      5m      5n      