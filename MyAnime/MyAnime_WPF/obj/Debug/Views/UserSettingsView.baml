   M S B A M L   `   `   `  ����F  BMyAnime_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MyAnime_WPF.ViewsMyAnime_WPF.Views  5   	   ?$clr-namespace:MyAnime_WPF.ComponentsMyAnime_WPF.Components  5   S   (    "MyAnime_WPF.Views.UserSettingsView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:MyAnime_WPF.Views     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962af bMaterialDesignThemes.MahApps, Version=0.1.5.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   
   7
components$clr-namespace:MyAnime_WPF.Components   6S      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � Title$ Inloggen��5   	   $
��1080��6   $
��1920��6(    � AllowsTransparency . 
������  � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      .+�5   
   �� $��4��6   ��5      �� 5      .��5      �  � Color$ #7be9f6��6#    � Offset$	 0.0Q�5   #   � 5      $ #f083da��6#   $ 1Q�5   #   5       5"      �� 5#   
   -   5        	 ��Name$	 btnBack��5#      
������ $��50��5%      $	��150��5&      $��0q�5'      $
��Left=�5(      .��5*      �� 
 �� Orientation$
 
Horizontal=�6   .+�5+      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ KeyboardArrowLeft=�6*   $��45��6C   $��40��6O   �� 5,      $
��Back��6   
������� J� Opacity$	 0.8Q�6:   $��32(�6H   6X   5-      5.      �� 5/   
   $��1��6   .+�50      �� $	��120��51      $��0,10,0,0q�52      $
 0.75Q�53      ��50      �� *Avatar+53      �� 58      $��Settings��6   $��Light"�59      $��64(�5:      
�������$��Center=�5<      $
 0.75Q�5=      5>      �� 5?   
   $��2��6   .+�5@      �� $��Center=�6   $
 
Horizontal=�5A      $��0,40,0,0q�5B      .+�5C      �� -   5         ��Name$ txtUserName��5C      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ New UserName��5E      .  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 ���� /  )MaterialDesignThemes.Wpf.ValidationAssist   
Background
 ���� $��Light"�5H      $��32(�5I      
�������
������ $��0q�5L      $
��Left=�5M      $	��300��5N      ��5D      �� *
UserName+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors . 5N        5O      $ AccountCircle=�6*   
�������$��0,0,0,0q�5Q   *   $��40��5R   *   $��40��5S   *   5T      �� 5U      $	��340��6   $��2��5V      
�������$	 0.5Q�5X      �� 5Y      $��Center=�6   $
 
Horizontal=�5Z      $��0,20,0,0q�5[      .+�5\      �� -   5        $ txtEmail��5\      $ 	New Email��5^      
 ���� 
 ���� $��Light"�5a      $��32(�5b      
�������
������ $��0q�5e      $
��Left=�5f      $	��300��5g      ��5]      �� *Email+$ PropertyChanged=� . 5g        5h      $ Email=�6*   
�������$��0,0,0,0q�5j   *   $��40��5k   *   $��40��5l   *   5m      �� 5n      $	��340��6   $��2��5o      
�������$	 0.5Q�5q      �� 5r      $��Center=�6   $
 
Horizontal=�5s      $��0,30,0,0q�5t      .+�5u      0   *MyAnime_WPF.Components.BindablePasswordBox  $ Old Password��5w      $��32(�5x      $	��300��5y         Password 5v      �� *OldPassword+$ PropertyChanged=� �� Mode$ TwoWay=� . 5y        5|      $ Onepassword=�6*   
�������$��0,0,0,0q�5~   *   $��40��5   *   $��40��5�   *   5�      �� 5�      $	��340��6   $��2��5�      
�������$	 0.5Q�5�      �� 5�      $��Center=�6   $
 
Horizontal=�5�      $��0,30,0,0q�5�      .+�5�        $ New Password��5�      $��32(�5�      $	��300��5�       5�      �� *NewPassword+$ PropertyChanged=�$ TwoWay=� . 5�        5�      $ Onepassword=�6*   
�������$��0,0,0,0q�5�   *   $��40��5�   *   $��40��5�   *   5�      �� 5�      $	��340��6   $��2��5�      
�������$	 0.5Q�5�      �� 5�      $��Center=�6   $
 
Horizontal=�5�      $��0,30,0,0q�5�      .+�5�        $ Repeat Password��5�      $��32(�5�      $	��300��5�       5�      �� *RepeatPassword+$ PropertyChanged=�$ TwoWay=� . 5�        5�      $ Onepassword=�6*   
�������$��0,0,0,0q�5�   *   $��40��5�   *   $��40��5�   *   5�      �� 5�      $	��340��6   $��2��5�      
�������$	 0.5Q�5�      5�      �� 5�   
   $
 
Horizontal=�6   $��Right=�5�      $��Bottom=�5�      $��3��5�      $��	0,0,40,40q�5�      .+�5�      �� 
������ +  %MaterialDesignThemes.Wpf.RippleAssist   Feedback
 ��+��$	��160��5�      $��	50,40,0,0q�6%   $��30��5�      ���#7be9f6$��Delete My Account��5�      $��DeleteAccount��5�      $��Center=�5�      ��5�      �� 5�      �� 5�      
������ 
 ��+��$	��160��5�      $��	40,40,0,0q�6%   $��30��5�      ���#7be9f6$��Adjust My Info��5�      $��
AdjustInfo��5�      $��Center=�5�      ��5�      �� 5�      5�      5�      5�      