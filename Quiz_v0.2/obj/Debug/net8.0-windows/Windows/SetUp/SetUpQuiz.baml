   M S B A M L   `   `   `  ����D  @Quiz_v0.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Quiz_v0._2.Windows.SetUpQuiz_v0._2.Windows.SetUp  5   	   (    "Quiz_v0._2.Windows.SetUp.SetUpQuiz   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Quiz_v0._2.Windows.SetUp     5   	     � Title$  
Game Setup��5   	   $	��500��6   $	��700��6)   $	��500��65   $	��700��6E   $	��500��6T   $	��700��6d    � WindowStartupLocation$ CenterScreen=�6s      
Background#���   5	   	   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��
Game Setup��6   $��24(�6&   $
��Bold"�64   $��Center=�5       $��0,0,0,20q�61   $��0��6C     	TextColor#���  5!      �� 5%   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��Center=�6;   $
��0,10q�6V   .+�5&      �� $��Number of Teams:��6   $��16(�60   $��Center=�6>   $	��200��6Y   #���  5'      �� 5)      -   5         ��Name$ scrollBar_teamCount��5)      $	��150��65   $��20��6A    � Minimum$ 2Q�5*       � Maximum$ 10Q�6$    � Value$ 2Q�61    � SmallChange$ 1Q�5+      	 � LargeChange$	 1Q�6(   
 �� Orientation$
 
Horizontal=�5,      61   �� 5-      -   5         ��Name$ teamCountText��5-      $��2��6/   $��16(�68   $��Center=�6F   $��10,0,0,0q�6a   #���  5.      50      �� 53   
   $ 
Horizontal=�6   $��2��6.   $��Center=�6;   $
��0,10q�6V   .+�54      �� -   5         ��Name$ checkBox_withTimer��54      $��	Use Timer��63   $��16(�6G   $��0,0,10,0q�6U   #���  55      6e   �� 57      -   5         ��Name$ textBox_secondsTimer��57      $��60��64   $��60��6>   $��16(�6I    �� 
IsReadOnly$
 True��6W     ButtonBackground#���  58        ButtonForeground#���  59      5;      �� 5>   
   $ 
Horizontal=�6   $��3��6.   $��Center=�6;   $
��0,10q�6V   .+�5?      �� $��Use Existing Template:��6   $��16(�66   $	��200��6D   $��Center=�6P   #���  5@      �� 5B      -   5         ��Name$ input_button��5B      $��Select��6+   $	��120��6<   $��30��6H   #���  5C      #���  5D      5F      �� 5I   
   $ 
Horizontal=�6   $��4��6.   $��Center=�6;   $
��0,10q�6V   .+�5J      �� $��Create New Template:��6   $��16(�64   $	��200��6B   $��Center=�6N   #���  5K      �� 5M      -   5        $ createTemplateButton��5M      $��Create��63   $	��120��6D   $��30��6P   #���  5N      #���  5O      5Q      �� 5T   
   $ 
Horizontal=�6   $��5��6.   $��Center=�6;   $
��0,10q�6V   .+�5U      �� $��Active Template:��6   $��16(�60   $	��200��6>   $��Center=�6J   #���  5V      �� 5X      -   5        $ ActiveTemplateTextBox��5X      $��No Active Template��65   $��16(�6O   $	��300��6]   $
 True��6i   #���  5Y      #���  5Z      5\      �� 5_   
   -   5        $ createGameButton��5_      $��Create Game��6+   $��6��6A   $	��160��6N   $��40��6Z   $��Center=�5`      $��Center=�6,   #���  5a      #���  5b      5d      5e      