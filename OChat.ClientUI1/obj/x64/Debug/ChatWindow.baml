   M S B A M L   `   `   `  ����  OChat.ClientUI1     OChat.ClientUI1.ChatWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	   -   5          � Title$  OChat - Join the Fun��5   	    � SizeToContent$ WidthAndHeight=�6&    � 
ResizeMode$ CanMinimize=�6^    +� FocusedElement 6w   ��  �� ElementName$ TxtChatMessage�� � 	Resources 5	       !  ListBoxtemStyleNoHighlighting �� 
TargetType �� Property �� Value	 �� 
TargetType
 ��Name��%�   &	        �� 5
   
   " ��66   .�5      ��  � �� 5      �� 5      "	 ��6&   .R�5      � #��z��6   .+�5      �� $
 contentPresenter��6/   6K   5      5      5      5      5      .��5      � $	��600��6   $	��500��6   
�������.+�5   
   �� 
�������
�������$��1,1,0,0q�6;   $��75,0,0,0q�6U   ._�5      �� -   5        $��RichTextBoxMainChatWindow��5      " �� VerticalScrollBarVisibility$
 Auto=�6;   $
��Left=�6^   $��0q�6y    �� 
IsReadOnly . $	��Top=�6�   $	��541��6�   . �5      /� .T�5      J� 5      5      5      �� 5   
   -   5         ��Name$ ListBoxUsers��5      $��0��6   #��[  65   $��Stretch=�6y   $��
0,0,425,39q�5      
�������$��0,1,0,1q�6=   
���������5       �� 5!      .R�5"      �� 
�������$��2,3,2,0q�64   $��0,0,0,1q�6E   ._�5#      � $��0q�6   
������  � ColumnDefinitions 5$      �� 5%   "   $��15 �63   �� 5&   "   $��* �63   6?   .+�5(      "  FontAwesome.WPF.ImageAwesome  $��0��6.   $��20��6>      Icon$ 
UserCircle=�6J      
Foreground 6\   �� *Color+6{   �� 5)      $��12(�6F   $��1��6T   $
��Left=�6d   
���iii���6$   �� *
FontWeight+��6   �� *Name+6�   5*      5+      5,      5.      �� 5/   
   $��98,559,22,20q�6   $��0,0,0,1q�6'   
�������._�50      �� -   5         ��Name$ TxtChatMessage��50   4   |�. 
���iii�$
��Left=�51      $��0q�62    �� TextWrapping$
 Wrap=�6F    �� 	MaxLength$ 50��6Z   $��Center=�52      $	��Top=�68   $	��380��6P   $��21��6\   $��0q�6h    J� RenderTransformOrigin$ 0.511,0.176&�6s   53      �� 54   
    J� IsHitTestVisible .  $��12(�6-   $��Enter your Message here��6;   $��Center=�6Z   
�������$��100,561,171,20q�6�   $	��229��6�   ��55      �� 56      " ��6   .�57      ��  � y�$ 	Collapsed=�63    �� Triggers 58      �� 59       �� Binding 6&   �� *Text+$ TxtChatMessage�� �� Value  6[   .a�5:      ��  � y�$ Visible=�6;   5;      5=      5?        5@   
   -   5        $��	ImgLogout��5@       � Cursor$
 Hand��6K    � ToolTip$ Logout��6Y   $ SignOut=�6j   $��41,567,429,7q�6y   $ 0.5,0.5&�6�   
 �\\��z�5A      V� 5B      .~�5C      �� �� 5D      �� 5E       �� Angle$
 -180Q�6&   T� 5F      5G      5I        5J   
   -   5          Name$ ImgBugReport��5J      $
 Hand��6S   $ Report a Bug��6a   $	 Bug=�6x   $��4,566,465,7q�6�   $ 0.803,-0.355&�6�   
 ��p�� J� Opacity$	 0.9Q�6�   5K      5L      