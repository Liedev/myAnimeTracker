   M S B A M L   `   `   `  ����F  BMyAnime_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MyAnime_WPFMyAnime_WPF  5   	   ?$clr-namespace:MyAnime_WPF.ComponentsMyAnime_WPF.Components  5   R   !    MyAnime_WPF.Views.LogInView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:MyAnime_WPF     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962af bMaterialDesignThemes.MahApps, Version=0.1.5.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   7
components$clr-namespace:MyAnime_WPF.Components   6R   -   5           MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � Title$ Inloggen��5   	   $	��450��6   $	��380��6'    � AllowsTransparency . 
������  � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   ��  �� CornerRadius$ 10��6   $��2��5      ��5      �� 5      .��5      �  � Color$ #7be9f6��6#   	 � Offset$		 0.0Q�5   #   � 5      $ #f083da��6#   $	 1Q�5    #   5!      5#      �� 5$   
   $	��Top=�6   $��Right=�5%      $��20��5&      $��20��5'      
������ 
�������$��X��5*      $��0q�5+      $��	0,10,10,0q�5,      $��Close��5.      ��5-      �� 5.      �� 5/   
   .+�50      ��  
 gundam#��[ 6   $	��120��51      $��0,10,0,0q�52      
 J� Opacity$

 0.75Q�53      �� 57      $��My Anime��6   $��Light"�58      $��40(�59      
�������$��Center=�5;      $

 0.75Q�5<      5=      �� 5>   
   $��1��6   .+�5?      �� $��Center=�6    �� Orientation$ 
Horizontal=�5@      $��0,40,0,0q�5A      .+�5B      �� -   5         ��Name$ txtUserName��5B      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ UserName��5D      .  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 ���� /  )MaterialDesignThemes.Wpf.ValidationAssist   
Background
 ���� $��Light"�5G      $��20(�5H      
�������
������ $��0q�5K      $
��Left=�5L      $	��235��5M      ��5C      �� *
UserName+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors . 5M      '  !MaterialDesignThemes.Wpf.PackIcon  5N         Kind$ AccountCircle=�6*   
�������$��0,8,0,0q�5P   *   5Q      �� 5R      $	��250��6   $��2��5S      
�������$	
 0.5Q�5U      �� 5V      $��Center=�6   $ 
Horizontal=�5W      $��0,20,0,0q�5X      .+�5Y      0   *MyAnime_WPF.Components.BindablePasswordBox  $ Password��5[      $��20(�5\      $	��235��5]         Password 5Z      �� *
Password+$ PropertyChanged=� �� Mode$ TwoWay=� . 5]        5`      $ Onepassword=�6*   
�������$��0,8,0,0q�5b   *   5c      �� 5d      $	��250��6   $��2��5e      
�������$	
 0.5Q�5g      �� 5h      
���  ��$��30��6D   ��6   �� *	ErrorInfo+6D   �� 5i      $ 
Horizontal=�6   .+�5j      �� 
������ +  %MaterialDesignThemes.Wpf.RippleAssist   Feedback
 ��+��$	��120��5l      $��	50,10,0,0q�6%   $��30��5m      ���#7be9f6$��Register��5n      $��Register��5p      $��Center=�5q      ��5o      �� 5q      �� 5r      
������ 
 ��+��$	��120��5t      $��	40,10,0,0q�6%   $��30��5u      ���#7be9f6$��Log In��5v      $��LogIn��5x      $��Center=�5y      ��5w      �� 5y      5z      5{      5|      5}      